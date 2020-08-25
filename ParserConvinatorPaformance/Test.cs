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
        [Fact(Skip ="必要なときのみ実行")]
        public async Task パフォーマンス測定()
        {
            string text = File.ReadAllText(@"..\..\..\testdata\test.json");

            await JSON.ParseAsync(text);
        }
    }
}
