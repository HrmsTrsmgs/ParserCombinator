using Marimo.Parser;
using Marimo.ParserCombinator;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Marimo.Parser.Test
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

        [Fact]
        public async Task 数値はマイナスを識別します()
        {
            var result = await JSON.ParseAsync(@"{""a"":-1}");

            result.Pairs.Count.Is(1);
            var value = (JSONLiteral)result["a"];
            value.ValueType.Is(LiteralType.Number);
            value.Value.Is("-1");
        }

        [Fact]
        public async Task 数値は複数桁を識別します()
        {
            var result = await JSON.ParseAsync(@"{""a"":123}");

            result.Pairs.Count.Is(1);
            var value = (JSONLiteral)result["a"];
            value.ValueType.Is(LiteralType.Number);
            value.Value.Is("123");
        }
    }
}
