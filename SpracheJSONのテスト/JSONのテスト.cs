using System;
using System.Threading.Tasks;
using Xunit;
using SpracheJSON;
using System.CodeDom;
using System.Collections.Generic;
using Sprache;

namespace SpracheJSONのテスト
{
    public class JSONのテスト
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
        public void オブジェクトの中身は複数持てます()
        {
            var result = JSON.Parse(@"{""a"":1, ""b"":2}");

            result.Pairs.Count.Is(2);
            var value = result["a"];
            value.IsInstanceOf<JSONLiteral>();
            var value2 = result["b"];
            value2.IsInstanceOf<JSONLiteral>();
        }
        [Fact]
        public void 数値はマイナスを識別します()
        {
            var result = JSON.Parse(@"{""a"":-1}");

            result.Pairs.Count.Is(1);
            var value = (JSONLiteral)result["a"];
            value.ValueType.Is(LiteralType.Number);
            value.Value.Is("-1");
        }
        [Fact]
        public void 数値は複数桁を識別します()
        {
            var result = JSON.Parse(@"{""a"":123}");

            result.Pairs.Count.Is(1);
            var value = (JSONLiteral)result["a"];
            value.ValueType.Is(LiteralType.Number);
            value.Value.Is("123");
        }

        [Fact]
        public void 数値は0から9を識別します()
        {
            var result = JSON.Parse(@"{""a"":1234567890}");

            result.Pairs.Count.Is(1);
            var value = (JSONLiteral)result["a"];
            value.ValueType.Is(LiteralType.Number);
            value.Value.Is("1234567890");
        }

        [Fact]
        public void 数値は小数を識別します()
        {
            var result = JSON.Parse(@"{""a"":1.2}");

            result.Pairs.Count.Is(1);
            var value = (JSONLiteral)result["a"];
            value.ValueType.Is(LiteralType.Number);
            value.Value.Is("1.2");
        }
        [Fact]
        public void 数値は小数点以下複数桁を識別します()
        {
            var result = JSON.Parse(@"{""a"":1.234}");

            result.Pairs.Count.Is(1);
            var value = (JSONLiteral)result["a"];
            value.ValueType.Is(LiteralType.Number);
            value.Value.Is("1.234");
        }
        [Fact]
        public void 数値は小数で整数部の数字は0個でも識別します()
        {
            var result = JSON.Parse(@"{""a"":}");
            result.Pairs.Count.Is(1);
            var value = (JSONLiteral)result["a"];
            value.ValueType.Is(LiteralType.Number);
            value.Value.Is("");
        }
        [Fact]
        public void 数値は小数で小数部の数字は0個でも識別します()
        {
            var result = JSON.Parse(@"{""a"":0.}");
            result.Pairs.Count.Is(1);
            var value = (JSONLiteral)result["a"];
            value.ValueType.Is(LiteralType.Number);
            value.Value.Is("0.");
        }
        [Fact]
        public void 数値は指数部を識別します()
        {
            // これで指数部が成立するか疑問なのだがホワイトボックステストなので。
            var result = JSON.Parse(@"{""a"":e}");
            result.Pairs.Count.Is(1);
            var value = (JSONLiteral)result["a"];
            value.ValueType.Is(LiteralType.Number);
            value.Value.Is("e");
        }
        [Fact]
        public void 数値の指数部Eは大文字でも小文字でも識別します()
        {
            // これで指数部が成立するか疑問なのだがホワイトボックステストなので。
            var result = JSON.Parse(@"{""a"":E}");
            result.Pairs.Count.Is(1);
            var value = (JSONLiteral)result["a"];
            value.ValueType.Is(LiteralType.Number);
            value.Value.Is("E");
        }

        [Fact]
        public void 数値の指数部のプラスを識別します()
        {
            // これで指数部が成立するか疑問なのだがホワイトボックステストなので。
            var result = JSON.Parse(@"{""a"":e+}");
            result.Pairs.Count.Is(1);
            var value = (JSONLiteral)result["a"];
            value.ValueType.Is(LiteralType.Number);
            value.Value.Is("e+");
        }
        [Fact]
        public void 数値の指数部のマイナスを識別します()
        {
            // これで指数部が成立するか疑問なのだがホワイトボックステストなので。
            var result = JSON.Parse(@"{""a"":e-}");
            result.Pairs.Count.Is(1);
            var value = (JSONLiteral)result["a"];
            value.ValueType.Is(LiteralType.Number);
            value.Value.Is("e-");
        }
        [Fact]
        public void 数値の指数部の数値を識別します()
        {
            var result = JSON.Parse(@"{""a"":e+0}");
            result.Pairs.Count.Is(1);
            var value = (JSONLiteral)result["a"];
            value.ValueType.Is(LiteralType.Number);
            value.Value.Is("e+0");
        }
        [Fact]
        public void 数値の指数部の複数の数字を識別します()
        {
            var result = JSON.Parse(@"{""a"":e+10}");
            result.Pairs.Count.Is(1);
            var value = (JSONLiteral)result["a"];
            value.ValueType.Is(LiteralType.Number);
            value.Value.Is("e+10");
        }

        [Fact]
        public void 数値の指数部のプラスマイナスが数字の後だと認識しません()
        {
            Assert.Throws<ParseException>(() => JSON.Parse(@"{""a"":e10+}"));
        }
        [Fact]
        public void 数値の指数部のプラスマイナスがeの前だと認識しません()
        {
            Assert.Throws<ParseException>(() => JSON.Parse(@"{""a"":+e10}"));
        }

        [Fact]
        public void 値が何もない場合は数値と判断されます()
        {
            var result = JSON.Parse(@"{""a"":}");
            result.Pairs.Count.Is(1);
            var value = (JSONLiteral)result["a"];
            value.ValueType.Is(LiteralType.Number);
            value.Value.Is("");
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
        public void 文字列の複数文字を識別します()
        {
            var result = JSON.Parse(@"{""a"":""bc""}");

            result.Pairs.Count.Is(1);
            var value = (JSONLiteral)result["a"];
            value.ValueType.Is(LiteralType.String);
            value.Value.Is("bc");
        }
        [Fact]
        public void 文字列のエスケープ文字を識別します()
        {
            var result = JSON.Parse("{\"a\":\"\\\\\\\"\\b\\f\\n\\r\\t\"}");

            result.Pairs.Count.Is(1);
            var value = (JSONLiteral)result["a"];
            value.ValueType.Is(LiteralType.String);
            value.Value.Is("\\\"\b\f\n\r\t");
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
        public void 真偽値はtrueとfalseが可能です()
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
        public void 真偽値は大文字と小文字を区別せずに識別します()
        {
            var result = JSON.Parse(@"{""a"":TRUE, ""b"":FALSE}");

            result.Pairs.Count.Is(2);
            var trueValue = (JSONLiteral)result["a"];
            trueValue.ValueType.Is(LiteralType.Boolean);
            trueValue.Value.Is("TRUE");
            var falseValue = (JSONLiteral)result["b"];
            falseValue.ValueType.Is(LiteralType.Boolean);
            falseValue.Value.Is("FALSE");
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
            var result = JSON.Parse(@"{""a"":[1]}");

            result.Pairs.Count.Is(1);
            var array = (JSONArray)result["a"];
            array.Elements.Count.Is(1);
            array.Elements[0].IsInstanceOf<JSONLiteral>();
        }
        [Fact]
        public void 配列は複数の要素を持ちます()
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
