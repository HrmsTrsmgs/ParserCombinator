using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace Marimo.ParserCombinator
{

    public class SequenceParser
    {
        public static SequenceParser<T1, T2> Create<T1, T2>(Parser<T1> parser1, Parser<T2> parser2)
            => new SequenceParser<T1, T2>(parser1, parser2);
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
        public override async Task<(bool isSuccess, Cursol cursol, (T1, T2) parsed)> ParseAsync(Cursol cursol)
        {
            (T1, T2) returnValue = default;
            var helper =  new SequenceHelper(cursol);
            
            return
                await helper.ParseAsync(parser1, value => returnValue.Item1 = value) &&
                await helper.ParseAsync(parser2, value => returnValue.Item2 = value)
                ? (true, helper.Current, returnValue)
                :(false, cursol, default);
        }

        class SequenceHelper
        {
            public Cursol Current { get; private set; }

            public SequenceHelper(Cursol current) => Current = current;
            public async Task<bool> ParseAsync<T>(Parser<T> parser, Action<T> setter)
            {
                var result = await parser.ParseAsync(Current);
                if (!result.isSuccess)
                {
                    return result.isSuccess;
                }
                Current = result.cursol;
                setter(result.parsed);
                return result.isSuccess;
            }
        }
    }
}
