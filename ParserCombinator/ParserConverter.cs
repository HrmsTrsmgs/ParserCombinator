using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator
{
    public static class ParserConverter
    {
        public static ParserConverter<T, U> Create<T, U>(Parser<U> parser, Func<U, T> converter)
        {
            return new ParserConverter<T, U>(parser, converter);
        }
    }
    public class ParserConverter<T, U> : Parser<T>
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
            var (isSuccess, _, _) = await parser.ParseAsync(cursol);
            return (isSuccess, cursol, default(T));
        }
    }
}
