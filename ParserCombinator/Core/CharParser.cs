using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator.Core
{
    public class CharParser : IParser<char>
    {
        public char Char { get; }

        public bool IgnoreCase { get; }

        public CharParser(char @char, bool ignoreCase = false)
        {
            Char = @char;
            IgnoreCase = ignoreCase;
        }

        public async Task<(bool isSuccess, Cursol cursol, char parsed)> ParseAsync(Cursol cursol)
        => cursol.Current switch
        {
            var c when (IgnoreCase && c.HasValue ? Char.ToLower(c.Value) == Char.ToLower(Char) : c == Char)
                    => (true, cursol.GoFoward(1), Char),
            _ => (false, cursol, default)
        };
    }
}
