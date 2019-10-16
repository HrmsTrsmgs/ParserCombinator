using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator
{
    public class CharParser : Parser<char>
    {
        public char Char { get; }

        public bool IgnoreCase { get; }

        public CharParser(char @char, bool ignoreCase = false)
        {
            Char = @char;
            IgnoreCase = ignoreCase;
        }

        public override async Task<(bool isSuccess, Cursol cursol, char parsed)> ParseAsync(Cursol cursol)
            => cursol.Current switch
            {
            var c when (IgnoreCase && c.HasValue ? Char.ToLower(c.Value) == Char.ToLower(Char) : c == Char)
                    => (true, cursol.GoFoward(1), Char),
                _ => (false, cursol, default)
            };
    }
}
