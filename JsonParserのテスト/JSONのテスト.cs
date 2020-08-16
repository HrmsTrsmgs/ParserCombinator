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

        [Fact]
        public async Task オブジェクトの中身の値を識別します()
        {
            var result = await JSON.ParseAsync(@"{""a"":1}");

            result.Pairs.Count.Is(1);
            var value = result["a"];
            value.IsInstanceOf<JSONLiteral>();
        }
    }
}
