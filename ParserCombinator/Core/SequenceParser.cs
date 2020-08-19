using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace Marimo.ParserCombinator.Core
{
    public class SequenceParser<T1, T2> : IParser<(T1, T2)>
    {
        (IParser<T1>, IParser<T2>) parsers { get; }
        public SequenceParser(IParser<T1> parser1, IParser<T2> parser2)
        {
            this.parsers = (parser1, parser2);
        }
        public async Task<(bool isSuccess, Cursol cursol, (T1, T2) parsed)> ParseAsync(Cursol cursol)
        {
            (T1, T2) returnValue = default;
            var helper = new SequenceHelper(cursol);

            return
                await helper.ParseAsync(parsers.Item1, value => returnValue.Item1 = value) &&
                await helper.ParseAsync(parsers.Item2, value => returnValue.Item2 = value)
                ? (true, helper.Current, returnValue)
                : (false, cursol, default);
        }
    }
    public class SequenceParser<T1, T2, T3> : IParser<(T1, T2, T3)>
    {
        (IParser<T1>, IParser<T2>, IParser<T3>) parsers { get; }
        public SequenceParser(IParser<T1> parser1, IParser<T2> parser2, IParser<T3> parser3)
        {
            this.parsers = (parser1, parser2, parser3);
        }
        public async Task<(bool isSuccess, Cursol cursol, (T1, T2, T3) parsed)> ParseAsync(Cursol cursol)
        {
            (T1, T2, T3) returnValue = default;
            var helper = new SequenceHelper(cursol);

            return
                await helper.ParseAsync(parsers.Item1, value => returnValue.Item1 = value) &&
                await helper.ParseAsync(parsers.Item2, value => returnValue.Item2 = value) &&
                await helper.ParseAsync(parsers.Item3, value => returnValue.Item3 = value)
                ? (true, helper.Current, returnValue)
                : (false, cursol, default);
        }
    }
    public class SequenceParser<T1, T2, T3, T4> : IParser<(T1, T2, T3, T4)>
    {
        (IParser<T1>, IParser<T2>, IParser<T3>, IParser<T4>) parsers { get; }
        public SequenceParser(
            IParser<T1> parser1,
            IParser<T2> parser2,
            IParser<T3> parser3,
            IParser<T4> parser4)
        {
            this.parsers = (parser1, parser2, parser3, parser4);
        }

        public async Task<(bool isSuccess, Cursol cursol, (T1, T2, T3, T4) parsed)> ParseAsync(Cursol cursol)
        {
            (T1, T2, T3, T4) returnValue = default;
            var helper = new SequenceHelper(cursol);

            return
                await helper.ParseAsync(parsers.Item1, value => returnValue.Item1 = value) &&
                await helper.ParseAsync(parsers.Item2, value => returnValue.Item2 = value) &&
                await helper.ParseAsync(parsers.Item3, value => returnValue.Item3 = value) &&
                await helper.ParseAsync(parsers.Item4, value => returnValue.Item4 = value)
                ? (true, helper.Current, returnValue)
                : (false, cursol, default);
        }
    }

    public class SequenceParser<T1, T2, T3, T4, T5> : IParser<(T1, T2, T3, T4, T5)>
    {
        (IParser<T1>, IParser<T2>, IParser<T3>, IParser<T4>, IParser<T5>) parsers { get; }
        public SequenceParser(
            IParser<T1> parser1,
            IParser<T2> parser2,
            IParser<T3> parser3,
            IParser<T4> parser4,
            IParser<T5> parser5)
        {
            this.parsers = (parser1, parser2, parser3, parser4, parser5);
        }

        public async Task<(bool isSuccess, Cursol cursol, (T1, T2, T3, T4, T5) parsed)> ParseAsync(Cursol cursol)
        {
            (T1, T2, T3, T4, T5) returnValue = default;
            var helper = new SequenceHelper(cursol);

            return
                await helper.ParseAsync(parsers.Item1, value => returnValue.Item1 = value) &&
                await helper.ParseAsync(parsers.Item2, value => returnValue.Item2 = value) &&
                await helper.ParseAsync(parsers.Item3, value => returnValue.Item3 = value) &&
                await helper.ParseAsync(parsers.Item4, value => returnValue.Item4 = value) &&
                await helper.ParseAsync(parsers.Item5, value => returnValue.Item5 = value)
                ? (true, helper.Current, returnValue)
                : (false, cursol, default);
        }
    }

    public class SequenceParser<T1, T2, T3, T4, T5, T6> : IParser<(T1, T2, T3, T4, T5, T6)>
    {
        (IParser<T1>, IParser<T2>, IParser<T3>, IParser<T4>, IParser<T5>, IParser<T6>) parsers { get; }
        public SequenceParser(
            IParser<T1> parser1,
            IParser<T2> parser2,
            IParser<T3> parser3,
            IParser<T4> parser4,
            IParser<T5> parser5,
            IParser<T6> parser6)
        {
            this.parsers = (parser1, parser2, parser3, parser4, parser5, parser6);
        }

        public async Task<(bool isSuccess, Cursol cursol, (T1, T2, T3, T4, T5, T6) parsed)> ParseAsync(Cursol cursol)
        {
            (T1, T2, T3, T4, T5, T6) returnValue = default;
            var helper = new SequenceHelper(cursol);

            return
                await helper.ParseAsync(parsers.Item1, value => returnValue.Item1 = value) &&
                await helper.ParseAsync(parsers.Item2, value => returnValue.Item2 = value) &&
                await helper.ParseAsync(parsers.Item3, value => returnValue.Item3 = value) &&
                await helper.ParseAsync(parsers.Item4, value => returnValue.Item4 = value) &&
                await helper.ParseAsync(parsers.Item5, value => returnValue.Item5 = value) &&
                await helper.ParseAsync(parsers.Item6, value => returnValue.Item6 = value)
                ? (true, helper.Current, returnValue)
                : (false, cursol, default);
        }
    }

    public class SequenceParser<T1, T2, T3, T4, T5, T6, T7> : IParser<(T1, T2, T3, T4, T5, T6, T7)>
    {
        (IParser<T1>, IParser<T2>, IParser<T3>, IParser<T4>, IParser<T5>, IParser<T6>, IParser<T7>) parsers { get; }
        public SequenceParser(
            IParser<T1> parser1,
            IParser<T2> parser2,
            IParser<T3> parser3,
            IParser<T4> parser4,
            IParser<T5> parser5,
            IParser<T6> parser6,
            IParser<T7> parser7)
        {
            this.parsers = (parser1, parser2, parser3, parser4, parser5, parser6, parser7);
        }

        public async Task<(bool isSuccess, Cursol cursol, (T1, T2, T3, T4, T5, T6, T7) parsed)> ParseAsync(Cursol cursol)
        {
            (T1, T2, T3, T4, T5, T6, T7) returnValue = default;
            var helper = new SequenceHelper(cursol);

            return
                await helper.ParseAsync(parsers.Item1, value => returnValue.Item1 = value) &&
                await helper.ParseAsync(parsers.Item2, value => returnValue.Item2 = value) &&
                await helper.ParseAsync(parsers.Item3, value => returnValue.Item3 = value) &&
                await helper.ParseAsync(parsers.Item4, value => returnValue.Item4 = value) &&
                await helper.ParseAsync(parsers.Item5, value => returnValue.Item5 = value) &&
                await helper.ParseAsync(parsers.Item6, value => returnValue.Item6 = value) &&
                await helper.ParseAsync(parsers.Item7, value => returnValue.Item7 = value)
                ? (true, helper.Current, returnValue)
                : (false, cursol, default);
        }
    }
    public class SequenceParser<T1, T2, T3, T4, T5, T6, T7, T8> : IParser<(T1, T2, T3, T4, T5, T6, T7, T8)>
    {
        (IParser<T1>, IParser<T2>, IParser<T3>, IParser<T4>, IParser<T5>, IParser<T6>, IParser<T7>, IParser<T8>) parsers { get; }
        public SequenceParser(
            IParser<T1> parser1,
            IParser<T2> parser2,
            IParser<T3> parser3,
            IParser<T4> parser4,
            IParser<T5> parser5,
            IParser<T6> parser6,
            IParser<T7> parser7,
            IParser<T8> parser8)
        {
            this.parsers = (parser1, parser2, parser3, parser4, parser5, parser6, parser7, parser8);
        }

        public async Task<(bool isSuccess, Cursol cursol, (T1, T2, T3, T4, T5, T6, T7, T8) parsed)> ParseAsync(Cursol cursol)
        {
            (T1, T2, T3, T4, T5, T6, T7, T8) returnValue = default;
            var helper = new SequenceHelper(cursol);

            return
                await helper.ParseAsync(parsers.Item1, value => returnValue.Item1 = value) &&
                await helper.ParseAsync(parsers.Item2, value => returnValue.Item2 = value) &&
                await helper.ParseAsync(parsers.Item3, value => returnValue.Item3 = value) &&
                await helper.ParseAsync(parsers.Item4, value => returnValue.Item4 = value) &&
                await helper.ParseAsync(parsers.Item5, value => returnValue.Item5 = value) &&
                await helper.ParseAsync(parsers.Item6, value => returnValue.Item6 = value) &&
                await helper.ParseAsync(parsers.Item7, value => returnValue.Item7 = value) &&
                await helper.ParseAsync(parsers.Item8, value => returnValue.Item8 = value)
                ? (true, helper.Current, returnValue)
                : (false, cursol, default);
        }
    }
    public class SequenceParser<T1, T2, T3, T4, T5, T6, T7, T8, T9> : IParser<(T1, T2, T3, T4, T5, T6, T7, T8, T9)>
    {
        (IParser<T1>, IParser<T2>, IParser<T3>, IParser<T4>, IParser<T5>, IParser<T6>, IParser<T7>, IParser<T8>, IParser<T9>) parsers { get; }
        public SequenceParser(
            IParser<T1> parser1,
            IParser<T2> parser2,
            IParser<T3> parser3,
            IParser<T4> parser4,
            IParser<T5> parser5,
            IParser<T6> parser6,
            IParser<T7> parser7,
            IParser<T8> parser8,
            IParser<T9> parser9)
        {
            this.parsers = (parser1, parser2, parser3, parser4, parser5, parser6, parser7, parser8, parser9);
        }

        public async Task<(bool isSuccess, Cursol cursol, (T1, T2, T3, T4, T5, T6, T7, T8, T9) parsed)> ParseAsync(Cursol cursol)
        {
            (T1, T2, T3, T4, T5, T6, T7, T8, T9) returnValue = default;
            var helper = new SequenceHelper(cursol);

            return
                await helper.ParseAsync(parsers.Item1, value => returnValue.Item1 = value) &&
                await helper.ParseAsync(parsers.Item2, value => returnValue.Item2 = value) &&
                await helper.ParseAsync(parsers.Item3, value => returnValue.Item3 = value) &&
                await helper.ParseAsync(parsers.Item4, value => returnValue.Item4 = value) &&
                await helper.ParseAsync(parsers.Item5, value => returnValue.Item5 = value) &&
                await helper.ParseAsync(parsers.Item6, value => returnValue.Item6 = value) &&
                await helper.ParseAsync(parsers.Item7, value => returnValue.Item7 = value) &&
                await helper.ParseAsync(parsers.Item8, value => returnValue.Item8 = value) &&
                await helper.ParseAsync(parsers.Item9, value => returnValue.Item9 = value)
                ? (true, helper.Current, returnValue)
                : (false, cursol, default);
        }
    }
    public class SequenceParser<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : IParser<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)>
    {
        (IParser<T1>, IParser<T2>, IParser<T3>, IParser<T4>, IParser<T5>, IParser<T6>, IParser<T7>, IParser<T8>, IParser<T9>, IParser<T10>) parsers { get; }
        public SequenceParser(
            IParser<T1> parser1,
            IParser<T2> parser2,
            IParser<T3> parser3,
            IParser<T4> parser4,
            IParser<T5> parser5,
            IParser<T6> parser6,
            IParser<T7> parser7,
            IParser<T8> parser8,
            IParser<T9> parser9,
            IParser<T10> parser10)
        {
            this.parsers = (parser1, parser2, parser3, parser4, parser5, parser6, parser7, parser8, parser9, parser10);
        }

        public async Task<(bool isSuccess, Cursol cursol, (T1, T2, T3, T4, T5, T6, T7, T8, T9, T10) parsed)> ParseAsync(Cursol cursol)
        {
            (T1, T2, T3, T4, T5, T6, T7, T8, T9, T10) returnValue = default;
            var helper = new SequenceHelper(cursol);

            return
                await helper.ParseAsync(parsers.Item1, value => returnValue.Item1 = value) &&
                await helper.ParseAsync(parsers.Item2, value => returnValue.Item2 = value) &&
                await helper.ParseAsync(parsers.Item3, value => returnValue.Item3 = value) &&
                await helper.ParseAsync(parsers.Item4, value => returnValue.Item4 = value) &&
                await helper.ParseAsync(parsers.Item5, value => returnValue.Item5 = value) &&
                await helper.ParseAsync(parsers.Item6, value => returnValue.Item6 = value) &&
                await helper.ParseAsync(parsers.Item7, value => returnValue.Item7 = value) &&
                await helper.ParseAsync(parsers.Item8, value => returnValue.Item8 = value) &&
                await helper.ParseAsync(parsers.Item9, value => returnValue.Item9 = value) &&
                await helper.ParseAsync(parsers.Item10, value => returnValue.Item10 = value)
                ? (true, helper.Current, returnValue)
                : (false, cursol, default);
        }
    }

    class SequenceHelper
    {
        public Cursol Current { get; private set; }

        public SequenceHelper(Cursol current) => Current = current;
        public async Task<bool> ParseAsync<T>(IParser<T> parser, Action<T> setter)
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
