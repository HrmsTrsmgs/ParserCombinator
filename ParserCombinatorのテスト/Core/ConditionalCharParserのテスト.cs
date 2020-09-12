using Marimo.ParserCombinator;
using Marimo.ParserCombinator.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Marimo.Test.ParserCombinator.Core
{
    public class ConditionalCharParserのテスト
    {
        [Fact]
        public void ParseAsyncは指定した文字を読み込みに成功します()
        {
            var cursol = new Cursol("public");
            var tested = new ConditionalCharParser(c => c == 'p');

            var result = tested.Parse(cursol);

            result.isSuccess.IsTrue();
        }

    }
}
