using SpracheJSON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SpracheJSONParormanceTest
{
    public class Test
    {
        [Fact]
        public void パフォーマンス測定()
        {
            var path = @"..\..\testdata\test.json";
            if (File.Exists(path))
            {
                string text = File.ReadAllText(@"..\..\..\testdata\test.json");

                JSON.Parse(text);
            }
        }
    }
}
