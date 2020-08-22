using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator.Core
{
    public class ExpectCharParser : IParser<char>
    {
        IParser<char> expectChars { get; }

        public ExpectCharParser(IParser<char> expectChars)
        {
            this.expectChars = expectChars;
        }

        public async Task<(bool isSuccess, Cursol cursol, char parsed)> ParseAsync(Cursol cursol)
        {
            var (isSuccess, _, _) = await expectChars.ParseAsync(cursol);
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
