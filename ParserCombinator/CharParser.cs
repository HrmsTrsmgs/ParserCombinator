using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator
{
    public class CharParser : Parser<char>
    {
        public char Char { get; }

        public CharParser(char @char) => Char = @char;

        public override async Task<(bool isSuccess, Cursol cursol, char parsed)> ParseAsync(Cursol cursol)
            => cursol.Current switch
            {
                var c when c == Char 
                    => (true, cursol.GoFoward(1), Char),
                _ => (false, cursol, default)
            };
    }
}
