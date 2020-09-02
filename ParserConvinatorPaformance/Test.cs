using Marimo.Parser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public void パフォーマンス測定()
        {
            var path = @"..\..\..\testdata\test.json";
            if (File.Exists(path))
            {
                var sw = new Stopwatch();
                sw.Start();
                string text = File.ReadAllText(path);

                JSON.Parse(text);
                sw.Stop();
                var time = sw.Elapsed;
                Console.WriteLine(time);
            }
        }
    }
}
