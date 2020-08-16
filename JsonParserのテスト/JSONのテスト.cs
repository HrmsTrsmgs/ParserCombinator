using Marimo.Parser;
using Marimo.ParserCombinator;
using System;
using System.Threading.Tasks;
using Xunit;

namespace JsonParserテスト
{
    public class JSONのテスト
    {
        [Fact]
        public async Task 空のオブジェクトを識別します()
        {
            var result =await JSON.ParseAsync("{}");

            result.Pairs.Count.Is(0);
        }
    }
}
