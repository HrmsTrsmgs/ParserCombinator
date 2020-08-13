using System;
using System.Threading.Tasks;
using Xunit;
using SpracheJSON;
using System.CodeDom;
using System.Collections.Generic;

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
            public void 真偽値はtrueとfalseが可能ですします()
            {
                var result = JSON.Parse(@"{""a"":true, ""b"":false}");

                result.Pairs.Count.Is(2);
                var trueValue = (JSONLiteral)result["a"];
                trueValue.ValueType.Is(LiteralType.Boolean);
                trueValue.Value.Is("true");
                var falseValue = (JSONLiteral)result["b"];
                falseValue.ValueType.Is(LiteralType.Boolean);
                falseValue.Value.Is("false");
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
            [Fact]
            public void Nullの値の識別は大文字小文字を区別しませんします()
            {
                var result = JSON.Parse(@"{""a"":NULL}");

                result.Pairs.Count.Is(1);
                var value = (JSONLiteral)result["a"];
                value.ValueType.Is(LiteralType.Null);
                value.Value.IsNull();
            }

            [Fact]
            public void オブジェクトの中身の配列を識別します()
            {
                var result = JSON.Parse(@"{""a"":[]}");

                result.Pairs.Count.Is(1);
                var value = result["a"];
                value.IsInstanceOf<JSONArray>();
            }
            [Fact]
            public void オブジェクトの中身の配列の中身を識別します()
            {
                var result = JSON.Parse(@"{""a"":[1,2]}");

                result.Pairs.Count.Is(1);
                var array = (JSONArray)result["a"];
                array.Elements.Count.Is(2);
                array.Elements[0].IsInstanceOf<JSONLiteral>();
                array.Elements[1].IsInstanceOf<JSONLiteral>();
            }
            [Fact]
            public void オブジェクトの中身のオブジェクトを識別します()
            {
                var result = JSON.Parse(@"{""a"":{}}");

                result.Pairs.Count.Is(1);
                var value = result["a"];
                value.IsInstanceOf<JSONObject>();
            }
        }

    }

}
