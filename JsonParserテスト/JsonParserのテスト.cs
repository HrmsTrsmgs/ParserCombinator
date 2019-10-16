using Marimo.Parser;
using Marimo.ParserCombinator;
using System;
using System.Threading.Tasks;
using Xunit;

namespace JsonParserテスト
{
    public class JsonParserのテスト
    {

        JsonParser tested;

        public JsonParserのテスト()
        {
            tested = new JsonParser();
        }

        [Fact]
        public async Task Nullはnullを識別します()
        {
            var result = await tested.Null.ParseAsync(new Cursol("null"));

            result.isSuccess.IsTrue();
            result.cursol.Index.Is(4);
        }

        [Fact]
        public async Task Nullは大文字小文字を認識せずにを識別します()
        {
            var result = await tested.Null.ParseAsync(new Cursol("NuLl"));

            result.isSuccess.IsTrue();
            result.cursol.Index.Is(4);
        }
    }
}
