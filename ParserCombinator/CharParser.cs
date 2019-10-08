using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator
{
    public class CharParser : Parser<char>
    {
        public char Char { get; }

        public CharParser(char @char)
        {
            Char = @char;
        }



        public override async Task<(bool isSuccess, Cursol cursol, char parsed)> ParseAsync(Cursol cursol)
        {
            if(cursol.Text[cursol.Index] == Char)
            {
                return (true, cursol.GoFoward(1), Char);
            }
            else
            {
                return (false, cursol, default);
            }
        }
    }
}
