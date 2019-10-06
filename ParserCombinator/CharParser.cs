using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator
{
    public class CharParser
    {
        public char Char { get; }

        public CharParser(char @char)
        {
            Char = @char;
        }

        public async Task<(bool isSuccess, Cursol cursol)> ParseAsync(Cursol cursol)
        {
            if(cursol.Text[cursol.Index] == Char)
            {
                return (true, cursol.GoFoward(1));
            }
            else
            {
                return (false, cursol);
            }
        }
    }
}
