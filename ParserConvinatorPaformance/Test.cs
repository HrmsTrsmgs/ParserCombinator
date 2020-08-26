using Marimo.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParserConbinatorParormance
{
    public class Test
    {
        [Fact]
        public async Task パフォーマンス測定()
        {
            var path = @"..\..\..\testdata\test.json";
            if (File.Exists(path))
            {
                string text = File.ReadAllText(@"..\..\..\testdata\test.json");

                await JSON.ParseAsync(text);
            }
        }
    }
}
