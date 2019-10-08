using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.ParserCombinator
{

    public class SequenceParser
    {
        public static SequenceParser<T1, T2> Create<T1, T2>(Parser<T1> parser1, Parser<T2> parser2)
        {
            return new SequenceParser<T1, T2>(parser1, parser2);
        }
    }

    public class SequenceParser<T1, T2> : Parser<ValueTuple<T1, T2>>
    {
        Parser<T1> parser1 { get; }
        Parser<T2> parser2 { get; }
        public SequenceParser(Parser<T1> parser1, Parser<T2> parser2)
        {
            this.parser1 = parser1;
            this.parser2 = parser2;
        }

        
        public override async Task<(bool isSuccess, Cursol cursol, ValueTuple<T1, T2> parsed)> ParseAsync(Cursol cursol)
        {
            var result1 = await parser1.ParseAsync(cursol);

            if(!result1.isSuccess)
            {
                return (false, cursol, default);
            }
            var result2 = await parser2.ParseAsync(result1.cursol);
            if (!result2.isSuccess)
            {
                return (false, cursol, default);
            }
            return (true, result2.cursol, (result1.parsed, result2.parsed));
        }
    }
}
