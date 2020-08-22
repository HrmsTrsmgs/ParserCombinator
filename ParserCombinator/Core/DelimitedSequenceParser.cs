using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator.Core
{
    public class DelimitedSequenceParser<T, U> : IParser<IEnumerable<T>>
    {

        IParser<T> sequence { get; }
        IParser<U> delimiter { get; }
        public DelimitedSequenceParser(IParser<T> sequence, IParser<U> delimiter)
        {
            this.sequence = sequence;
            this.delimiter = delimiter;
        }

        public async Task<(bool isSuccess, Cursol cursol, IEnumerable<T> parsed)> ParseAsync(Cursol cursol)
        {
            return (false, cursol, new T[] { });
        }
    }
}
