using Marimo.ParserCombinator.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Marimo.Test.ParserCombinator.Core
{
    public class OneOrMoreParserのテスト
    {
        [Fact]
        public async Task 一つ目の要素のパースに失敗したら失敗です()        {
            var tested = new OrParser<char>(new CharParser('a'));

            var (isSuccess, _, _) = await tested.ParseAsync(new Cursol("b"));

            isSuccess.IsFalse();
        }

        [Fact]
        public async Task 一つ目の要素のパースに成功したら成功です()
        {
            var tested = new OrParser<char>(new CharParser('a'));

            var (isSuccess, _, _) = await tested.ParseAsync(new Cursol("a"));

            isSuccess.IsTrue();
        }
    }
}
