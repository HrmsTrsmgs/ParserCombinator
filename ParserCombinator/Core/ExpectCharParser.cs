using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator.Core
{
    public class ExpectCharParser : IParser<char>
    {
        IParser<char> ecpectChars { get; }

        public ExpectCharParser(IParser<char> ecpectChars)
        {
            this.ecpectChars = ecpectChars;
        }

        public async Task<(bool isSuccess, Cursol cursol, char parsed)> ParseAsync(Cursol cursol)
        {
            return (true, cursol, default);
        }
    }
}
