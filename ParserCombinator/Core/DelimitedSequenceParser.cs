using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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

            var parseds = new List<T>();
            var current = cursol;
            bool isSuccess;
            T parsed;
            var beforeDelimiter = current;
            while (true)
            {
                (isSuccess, current, parsed) = await sequence.ParseAsync(current);
                if (isSuccess)
                {
                    parseds.Add(parsed);
                }
                else
                {
                    return (true, beforeDelimiter, parseds);
                }
                beforeDelimiter = current;
                (isSuccess, current, _) = await delimiter.ParseAsync(current);
                if (!isSuccess)
                {
                    return (true, beforeDelimiter, parseds);
                }
            }
            
        }
    }
}
