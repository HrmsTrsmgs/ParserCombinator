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
    }
}
