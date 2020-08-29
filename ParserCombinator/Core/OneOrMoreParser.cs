using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator.Core
{
    public class OneOrMoreParser<T> : IParser<IEnumerable<T>>
    {
        IParser<IEnumerable<T>> Parser { get; }

        public OneOrMoreParser(IParser<T> parser)
        {
            Parser =
                new ParserConverter<(T, IEnumerable<T>), IEnumerable<T>>(
                    new SequenceParser<T, IEnumerable<T>>(
                        parser,
                        new ZeroOrMoreParser<T>(parser)),
                    tuple => new[] { tuple.Item1 }.Concat(tuple.Item2));
        }

        public async Task<(bool isSuccess, Cursol cursol, IEnumerable<T> parsed)> ParseAsync(Cursol cursol)
            => await Parser.ParseAsync(cursol);
    }
}
