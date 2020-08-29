using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator.Core
{
    public class ParserConverter<U, T> : Parser<T>
    {
        Parser<U> Parser { get; }
        Func<U, T> Converter { get; }

        public ParserConverter(Parser<U> parser, Func<U, T> converter)
        {
            Parser = parser;
            Converter = converter;
        }

        public override async Task<(bool isSuccess, Cursol cursol, T parsed)> ParseAsync(Cursol cursol)
        {
            var (isSuccess, afterCursol, parsed) = await Parser.ParseAsync(cursol);
            
            return (isSuccess, afterCursol, (isSuccess ? Converter(parsed) : default));
        }
    }
}
