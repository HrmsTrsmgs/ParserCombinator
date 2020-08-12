using System;
using System.Threading.Tasks;
using Xunit;
using SpracheJSON;

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
        }
    }

}
