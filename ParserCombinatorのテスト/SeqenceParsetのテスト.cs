using Marimo.ParserCombinator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Marimo.Test.ParserCombinator
{
    public class SeqenceParsetのテスト
    {
        [Fact]
        public async Task ParseAsyncは指定した単語を読み込みに成功します()
        {
            var cursol = new Cursol("public static");
            var tested = SequenceParser.Create(new WordParser("public"), new WordParser("static"));

            var result = await tested.ParseAsync(cursol);

            result.isSuccess.IsTrue();
        }
    }
}
