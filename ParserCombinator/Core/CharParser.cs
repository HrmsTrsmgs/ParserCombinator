using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator.Core
{
    public class CharParser : Parser<char>
    {
        char Char { get; }

        bool IgnoreCase { get; }

        public CharParser(char @char, bool ignoreCase = false)
        {
            Char = @char;
            IgnoreCase = ignoreCase;
        }

        protected override ValueTask<(bool isSuccess, Cursol cursol, char parsed)> ParseCoreAsync(Cursol cursol)
            => new ValueTask<(bool isSuccess, Cursol cursol, char parsed)>(cursol.Current switch
            {
                var c when (IgnoreCase && c.HasValue ? char.ToLower(c.Value) == char.ToLower(Char) : c == Char)
                        => (true, cursol.GoFoward(1), c.Value),
                _ => (false, cursol, default)
            });
    }
}
