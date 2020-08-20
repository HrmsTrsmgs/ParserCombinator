using Marimo.ParserCombinator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Marimo.Test.ParserCombinator.Core
{
    public class ZeroOrMoreParserのテスト
    {
        [Fact]
        public async Task 一つ目の要素のパースに失敗しても成功です()        {
            var tested = new ZeroOrMoreParser<char>(new CharParser('a'));

            var (isSuccess, _, _) = await tested.ParseAsync(new Cursol("b"));

            isSuccess.IsTrue();
        }

        [Fact]
        public async Task 一つ目の要素のパースに失敗したらカーソルは進みません()
        {
            var tested = new ZeroOrMoreParser<char>(new CharParser('a'));

            var (_, cursol, _) = await tested.ParseAsync(new Cursol("b"));

            cursol.Index.Is(0);
        }

        [Fact]
        public async Task 一つ目の要素のパースに失敗したら結果は空です()
        {
            var tested = new ZeroOrMoreParser<char>(new CharParser('a'));

            var (_, _, parsed) = await tested.ParseAsync(new Cursol("b"));

            parsed.Count().Is(0);
        }

        [Fact]
        public async Task 一つ目の要素のパースに成功したら成功です()
        {
            var tested = new ZeroOrMoreParser<char>(new CharParser('a'));

            var (isSuccess, _, _) = await tested.ParseAsync(new Cursol("a"));

            isSuccess.IsTrue();
        }

        [Fact]
        public async Task 一つ目の要素のパースに成功したらカーソルは進みます()
        {
            var tested = new ZeroOrMoreParser<char>(new CharParser('a'));

            var (_, cursol, _) = await tested.ParseAsync(new Cursol("a"));

            cursol.Index.Is("a".Length);
        }
    }
}
