using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator.Core
{
    public class ExpectCharParser : IParser<char>
    {
        IParser<char> ExpectChars { get; }

        public ExpectCharParser(IParser<char> expectChars)
        {
            ExpectChars = expectChars;
        }

        public async Task<(bool isSuccess, Cursol cursol, char parsed)> ParseAsync(Cursol cursol)
            => await ExpectChars.ParseAsync(cursol) switch
            {
                (true, _, _) => (false, cursol, default),
                (false, _, _) => (true, cursol.GoFoward(1), cursol.Current.Value)
            };
    }
}
