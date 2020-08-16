using Marimo.ParserCombinator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParserCombinatorのテスト
{
    public class ParserConverterのテスト
    {
        [Fact]
        public async Task パースします()
        {
            var tested = ParserConverter.Create(new WordParser("123"), s => int.Parse(s));
        }
    }
}
