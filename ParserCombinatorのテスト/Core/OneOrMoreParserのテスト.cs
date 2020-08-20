using Marimo.ParserCombinator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Marimo.Test.ParserCombinator.Core
{
    public class OneOrMoreParserのテスト
    {
        [Fact]
        public async Task 一つ目の要素のパースに失敗したら失敗です()        {
            var tested = new OneOrMoreParser<char>(new CharParser('a'));

            var (isSuccess, _, _) = await tested.ParseAsync(new Cursol("b"));

            isSuccess.IsFalse();
        }

        [Fact]
        public async Task 一つ目の要素のパースに成功したら成功です()
        {
            var tested = new OneOrMoreParser<char>(new CharParser('a'));

            var (isSuccess, _, _) = await tested.ParseAsync(new Cursol("a"));

            isSuccess.IsTrue();
        }
        [Fact]
        public async Task 一つ目の要素のパースに成功したら一つ目の要素のみが得られます()
        {
            var tested = new OneOrMoreParser<char>(new CharParser('a'));

            var (_, _, parsed) = await tested.ParseAsync(new Cursol("a"));

            parsed.Count().Is(1);
            parsed.ElementAt(0).Is('a');
        }

        [Fact]
        public async Task 一つ目の要素のパースに成功したらカーソルは進みます()
        {
            var tested = new OneOrMoreParser<char>(new CharParser('a'));

            var (_, cursol, _) = await tested.ParseAsync(new Cursol("a"));

            cursol.Index.Is("a".Length);
        }

        [Fact]
        public async Task 二つ目の要素のパースに成功したら二つ分カーソルは進みます()
        {
            var tested = new OneOrMoreParser<char>(new CharParser('a'));

            var (_, cursol, _) = await tested.ParseAsync(new Cursol("aa"));

            cursol.Index.Is("aa".Length);
        }
    }
}
