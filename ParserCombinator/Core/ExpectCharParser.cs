using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator.Core
{
    public class ExpectCharParser : Parser<char>
    {
        Parser<char> ExpectChars { get; }

        public ExpectCharParser(Parser<char> expectChars)
        {
            ExpectChars = expectChars;
        }

        protected override async ValueTask<(bool isSuccess, Cursol cursol, char parsed)> ParseCoreAsync(Cursol cursol)
            => await ExpectChars.ParseAsync(cursol) switch
            {
                (true, _, _) => (false, cursol, default),
                (false, _, _) => (true, cursol.GoFoward(1), cursol.Current.Value)
            };
    }
}
