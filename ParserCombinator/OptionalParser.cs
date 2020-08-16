using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator
{
    public static class OptionalParser
    {
        public static OptionalParser<T> Create<T>(Parser<T> parser)
        {
            return new OptionalParser<T>(parser);
        }
    }
    public class OptionalParser<T> : Parser<Optional<T>>
    {
        Parser<T> parser { get; }
        public OptionalParser(Parser<T> parser)
        {
            this.parser = parser;
        }

        public override async Task<(bool isSuccess, Cursol cursol, Optional<T> parsed)> ParseAsync(Cursol cursol)
        {
            var (isSuccess, afterCursol, parsed) = await parser.ParseAsync(cursol);
            return (true, afterCursol, new Optional<T>(isSuccess, parsed));
        }
    }
}
