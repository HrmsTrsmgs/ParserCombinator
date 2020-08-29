using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Marimo.ParserCombinator.Core
{
    public class DelimitedSequenceParser<T, U> : Parser<IEnumerable<T>>
    {
        Parser<T> Sequence { get; }
        Parser<U> Delimiter { get; }
        public DelimitedSequenceParser(Parser<T> sequence, Parser<U> delimiter)
        {
            Sequence = sequence;
            Delimiter = delimiter;
        }

        public override async Task<(bool isSuccess, Cursol cursol, IEnumerable<T> parsed)> ParseAsync(Cursol cursol)
        {
            var parseds = new List<T>();
            var current = cursol;
            bool isSuccess;
            T parsed;
            var beforeDelimiter = current;
            while (true)
            {
                (isSuccess, current, parsed) = await Sequence.ParseAsync(current);
                if (!isSuccess)
                {
                    return (true, beforeDelimiter, parseds);
                }
                parseds.Add(parsed);
                beforeDelimiter = current;
                (isSuccess, current, _) = await Delimiter.ParseAsync(current);
                if (!isSuccess)
                {
                    return (true, beforeDelimiter, parseds);
                }
            }
            
        }
    }
}
