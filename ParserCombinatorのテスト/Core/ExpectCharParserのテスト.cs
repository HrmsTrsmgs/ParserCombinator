using Marimo.ParserCombinator.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Marimo.ParserCombinator.Test.Core
{
    public class ExpectCharParserのテスト
    {
        [Fact]
        public async Task ParseAsyncは指定した文字を読み込みに成功します()
        {
            var cursol = new Cursol("public");
            var tested = new ExpectCharParser(
                new CharParser('a'));

            var result = await tested.ParseAsync(cursol);

            result.isSuccess.IsTrue();
        }
    }
}
