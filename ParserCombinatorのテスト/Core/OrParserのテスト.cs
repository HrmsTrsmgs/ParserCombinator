using Marimo.ParserCombinator.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Marimo.Test.ParserCombinator.Core
{
    public class OrParserのテスト
    {
        [Fact]
        public async Task 一つ目の要素のパースに成功したら成功です()
        {
            var tested = new OrParser<char>(new CharParser('a'), new CharParser('b'));

            var (isSuccess, _, _) = await tested.ParseAsync(new Cursol("a"));

            isSuccess.IsTrue();
        }

        [Fact]
        public async Task 一つ目の要素のパースに成功したら一つ目の要素が返ります()
        {
            var tested = new OrParser<char>(new CharParser('a'), new CharParser('b'));

            var (_, _, parsed) = await tested.ParseAsync(new Cursol("a"));

            parsed.Is('a');
        }
    }
}
