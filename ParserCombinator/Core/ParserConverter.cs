using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator.Core
{
    public static class ParserConverter
    {
        public static ParserConverter<U, T> Create<T, U>(Parser<U> parser, Func<U, T> converter)
        {
            return new ParserConverter<U, T>(parser, converter);
        }
    }
    public class ParserConverter<U, T> : Parser<T>
    {
        Parser<U> parser { get; }
        Func<U, T> converter { get; }

        public ParserConverter(Parser<U> parser, Func<U, T> converter)
        {
            this.parser = parser;
            this.converter = converter;
        }

        public override async Task<(bool isSuccess, Cursol cursol, T parsed)> ParseAsync(Cursol cursol)
        {
            var (isSuccess, afterCursol, parsed) = await parser.ParseAsync(cursol);
            
            return (isSuccess, afterCursol, (isSuccess ? converter(parsed) : default));
        }
    }
}
