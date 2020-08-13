using System;
using System.Threading.Tasks;
using Xunit;
using SpracheJSON;
using System.CodeDom;

namespace SpracheJSONのテスト
{
    namespace JSONテスト
    {
        public class JsonParserのテスト
        {
            [Fact]
            public void 空のオブジェクトを識別します()
            {
                var result = JSON.Parse("{}");

                result.Pairs.Count.Is(0);
            }

            [Fact]
            public void オブジェクトの中身の値を識別します()
            {
                var result = JSON.Parse(@"{""a"":1}");

                result.Pairs.Count.Is(1);
                var value = result["a"];
                value.IsInstanceOf<JSONLiteral>();
            }
            [Fact]
            public void 数値の値を識別します()
            {
                var result = JSON.Parse(@"{""a"":1}");

                result.Pairs.Count.Is(1);
                var value = (JSONLiteral)result["a"];
                value.ValueType.Is(LiteralType.Number);
                value.Value.Is("1");   
            }
            [Fact]
            public void 文字列の値を識別します()
            {
                var result = JSON.Parse(@"{""a"":""b""}");

                result.Pairs.Count.Is(1);
                var value = (JSONLiteral)result["a"];
                value.ValueType.Is(LiteralType.String);
                value.Value.Is("b");
            }
            [Fact]
            public void 真偽値の値を識別します()
            {
                var result = JSON.Parse(@"{""a"":true}");

                result.Pairs.Count.Is(1);
                var value = (JSONLiteral)result["a"];
                value.ValueType.Is(LiteralType.Boolean);
                value.Value.Is("true");
            }

            [Fact]
            public void Nullの値を識別します()
            {
                var result = JSON.Parse(@"{""a"":null}");

                result.Pairs.Count.Is(1);
                var value = (JSONLiteral)result["a"];
                value.ValueType.Is(LiteralType.Null);
                value.Value.IsNull();
            }

        }
    }

}
