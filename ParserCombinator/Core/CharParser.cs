using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator.Core
{
    public class CharParser : IParser<char>
    {
        char Char { get; }

        bool IgnoreCase { get; }

        public CharParser(char @char, bool ignoreCase = false)
        {
            Char = @char;
            IgnoreCase = ignoreCase;
        }

        public Task<(bool isSuccess, Cursol cursol, char parsed)> ParseAsync(Cursol cursol)
            => Task.FromResult(cursol.Current switch
            {
                var c when (IgnoreCase && c.HasValue ? Char.ToLower(c.Value) == Char.ToLower(Char) : c == Char)
                        => (true, cursol.GoFoward(1), c.Value),
                _ => (false, cursol, default)
            });
    }
}
