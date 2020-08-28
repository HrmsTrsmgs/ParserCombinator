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
        {
            var (isSuccess, _, _) = await ExpectChars.ParseAsync(cursol);
            if (isSuccess)
            {
                return (false, cursol, default);
            }
            else
            {
                return (true, cursol.GoFoward(1), cursol.Current.Value);
            }
        }
    }
}
