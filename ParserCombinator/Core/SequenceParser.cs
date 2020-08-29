using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace Marimo.ParserCombinator.Core
{
    public class SequenceParser<T1, T2> : IParser<(T1, T2)>
    {
        (IParser<T1>, IParser<T2>) Parsers { get; }
        public SequenceParser(IParser<T1> parser1, IParser<T2> parser2)
        {
            Parsers = (parser1, parser2);
        }
        public async Task<(bool isSuccess, Cursol cursol, (T1, T2) parsed)> ParseAsync(Cursol cursol)
        {
            (T1, T2) returnValue = default;
            var helper = new SequenceHelper(cursol);

            return
                await helper.ParseAsync(Parsers.Item1, value => returnValue.Item1 = value) &&
                await helper.ParseAsync(Parsers.Item2, value => returnValue.Item2 = value)
                ? (true, helper.Current, returnValue)
                : (false, cursol, default);
        }
    }
    public class SequenceParser<T1, T2, T3> : IParser<(T1, T2, T3)>
    {
        IParser<(T1, T2, T3)> Parser { get; }
        public SequenceParser(IParser<T1> parser1, IParser<T2> parser2, IParser<T3> parser3)
        {
            Parser =
                new ParserConverter<(T1, (T2, T3)), (T1, T2, T3)>(
                new SequenceParser<T1, (T2, T3)>(
                    parser1,
                    new SequenceParser<T2, T3>(
                        parser2,
                        parser3)),
                tuple => (tuple.Item1, tuple.Item2.Item1, tuple.Item2.Item2));
        }
        public async Task<(bool isSuccess, Cursol cursol, (T1, T2, T3) parsed)> ParseAsync(Cursol cursol)
            => await Parser.ParseAsync(cursol);
    }
    public class SequenceParser<T1, T2, T3, T4> : IParser<(T1, T2, T3, T4)>
    {
        IParser<(T1, T2, T3, T4)> Parser { get; }
        public SequenceParser(
            IParser<T1> parser1,
            IParser<T2> parser2,
            IParser<T3> parser3,
            IParser<T4> parser4)
        {
            Parser =
                new ParserConverter<(T1, (T2, T3, T4)), (T1, T2, T3, T4)>(
                new SequenceParser<T1, (T2, T3, T4)>(
                    parser1,
                    new SequenceParser<T2, T3, T4>(
                        parser2,
                        parser3,
                        parser4)),
                tuple => (tuple.Item1, tuple.Item2.Item1, tuple.Item2.Item2, tuple.Item2.Item3));
        }

        public async Task<(bool isSuccess, Cursol cursol, (T1, T2, T3, T4) parsed)> ParseAsync(Cursol cursol)
            => await Parser.ParseAsync(cursol);
    }

    public class SequenceParser<T1, T2, T3, T4, T5> : IParser<(T1, T2, T3, T4, T5)>
    {
        IParser<(T1, T2, T3, T4, T5)> Parser { get; }
        public SequenceParser(
            IParser<T1> parser1,
            IParser<T2> parser2,
            IParser<T3> parser3,
            IParser<T4> parser4,
            IParser<T5> parser5)
        {
            Parser =
                new ParserConverter<(T1, (T2, T3, T4, T5)), (T1, T2, T3, T4, T5)>(
                new SequenceParser<T1, (T2, T3, T4, T5)>(
                    parser1,
                    new SequenceParser<T2, T3, T4, T5>(
                        parser2,
                        parser3,
                        parser4,
                        parser5)),
                tuple => (
                    tuple.Item1,
                    tuple.Item2.Item1,
                    tuple.Item2.Item2,
                    tuple.Item2.Item3,
                    tuple.Item2.Item4));
        }

        public async Task<(bool isSuccess, Cursol cursol, (T1, T2, T3, T4, T5) parsed)> ParseAsync(Cursol cursol)
            => await Parser.ParseAsync(cursol);
    }

    public class SequenceParser<T1, T2, T3, T4, T5, T6> : IParser<(T1, T2, T3, T4, T5, T6)>
    {
        IParser<(T1, T2, T3, T4, T5, T6)> Parser { get; }
        public SequenceParser(
            IParser<T1> parser1,
            IParser<T2> parser2,
            IParser<T3> parser3,
            IParser<T4> parser4,
            IParser<T5> parser5,
            IParser<T6> parser6)
        {
            Parser =
                new ParserConverter<(T1, (T2, T3, T4, T5, T6)), (T1, T2, T3, T4, T5, T6)>(
                new SequenceParser<T1, (T2, T3, T4, T5, T6)>(
                    parser1,
                    new SequenceParser<T2, T3, T4, T5, T6>(
                        parser2,
                        parser3,
                        parser4,
                        parser5,
                        parser6)),
                tuple => (
                    tuple.Item1,
                    tuple.Item2.Item1,
                    tuple.Item2.Item2,
                    tuple.Item2.Item3,
                    tuple.Item2.Item4,
                    tuple.Item2.Item5));
        }

        public async Task<(bool isSuccess, Cursol cursol, (T1, T2, T3, T4, T5, T6) parsed)> ParseAsync(Cursol cursol)
            => await Parser.ParseAsync(cursol);
    }

    public class SequenceParser<T1, T2, T3, T4, T5, T6, T7> : IParser<(T1, T2, T3, T4, T5, T6, T7)>
    {
        IParser<(T1, T2, T3, T4, T5, T6, T7)> Parser { get; }
        public SequenceParser(
            IParser<T1> parser1,
            IParser<T2> parser2,
            IParser<T3> parser3,
            IParser<T4> parser4,
            IParser<T5> parser5,
            IParser<T6> parser6,
            IParser<T7> parser7)
        {
            Parser =
                new ParserConverter<(T1, (T2, T3, T4, T5, T6, T7)), (T1, T2, T3, T4, T5, T6, T7)>(
                new SequenceParser<T1, (T2, T3, T4, T5, T6, T7)>(
                    parser1,
                    new SequenceParser<T2, T3, T4, T5, T6, T7>(
                        parser2,
                        parser3,
                        parser4,
                        parser5,
                        parser6,
                        parser7)),
                tuple => (
                    tuple.Item1,
                    tuple.Item2.Item1,
                    tuple.Item2.Item2,
                    tuple.Item2.Item3,
                    tuple.Item2.Item4,
                    tuple.Item2.Item5,
                    tuple.Item2.Item6));
        }

        public async Task<(bool isSuccess, Cursol cursol, (T1, T2, T3, T4, T5, T6, T7) parsed)> ParseAsync(Cursol cursol)
            => await Parser.ParseAsync(cursol);
    }
    public class SequenceParser<T1, T2, T3, T4, T5, T6, T7, T8> : IParser<(T1, T2, T3, T4, T5, T6, T7, T8)>
    {
        IParser<(T1, T2, T3, T4, T5, T6, T7, T8)> Parser { get; }
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
            Parser =
                new ParserConverter<(T1, (T2, T3, T4, T5, T6, T7, T8)), (T1, T2, T3, T4, T5, T6, T7, T8)>(
                new SequenceParser<T1, (T2, T3, T4, T5, T6, T7, T8)>(
                    parser1,
                    new SequenceParser<T2, T3, T4, T5, T6, T7, T8>(
                        parser2,
                        parser3,
                        parser4,
                        parser5,
                        parser6,
                        parser7,
                        parser8)),
                tuple => (
                    tuple.Item1,
                    tuple.Item2.Item1,
                    tuple.Item2.Item2,
                    tuple.Item2.Item3,
                    tuple.Item2.Item4,
                    tuple.Item2.Item5,
                    tuple.Item2.Item6,
                    tuple.Item2.Item7));
        }

        public async Task<(bool isSuccess, Cursol cursol, (T1, T2, T3, T4, T5, T6, T7, T8) parsed)> ParseAsync(Cursol cursol)
            => await Parser.ParseAsync(cursol);
    }
    public class SequenceParser<T1, T2, T3, T4, T5, T6, T7, T8, T9> : IParser<(T1, T2, T3, T4, T5, T6, T7, T8, T9)>
    {
        (IParser<T1>, IParser<T2>, IParser<T3>, IParser<T4>, IParser<T5>, IParser<T6>, IParser<T7>, IParser<T8>, IParser<T9>) Parsers { get; }
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
            Parsers = (parser1, parser2, parser3, parser4, parser5, parser6, parser7, parser8, parser9);
        }

        public async Task<(bool isSuccess, Cursol cursol, (T1, T2, T3, T4, T5, T6, T7, T8, T9) parsed)> ParseAsync(Cursol cursol)
        {
            (T1, T2, T3, T4, T5, T6, T7, T8, T9) returnValue = default;
            var helper = new SequenceHelper(cursol);

            return
                await helper.ParseAsync(Parsers.Item1, value => returnValue.Item1 = value) &&
                await helper.ParseAsync(Parsers.Item2, value => returnValue.Item2 = value) &&
                await helper.ParseAsync(Parsers.Item3, value => returnValue.Item3 = value) &&
                await helper.ParseAsync(Parsers.Item4, value => returnValue.Item4 = value) &&
                await helper.ParseAsync(Parsers.Item5, value => returnValue.Item5 = value) &&
                await helper.ParseAsync(Parsers.Item6, value => returnValue.Item6 = value) &&
                await helper.ParseAsync(Parsers.Item7, value => returnValue.Item7 = value) &&
                await helper.ParseAsync(Parsers.Item8, value => returnValue.Item8 = value) &&
                await helper.ParseAsync(Parsers.Item9, value => returnValue.Item9 = value)
                ? (true, helper.Current, returnValue)
                : (false, cursol, default);
        }
    }
    public class SequenceParser<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : IParser<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)>
    {
        (IParser<T1>, IParser<T2>, IParser<T3>, IParser<T4>, IParser<T5>, IParser<T6>, IParser<T7>, IParser<T8>, IParser<T9>, IParser<T10>) Parsers { get; }
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
            Parsers = (parser1, parser2, parser3, parser4, parser5, parser6, parser7, parser8, parser9, parser10);
        }

        public async Task<(bool isSuccess, Cursol cursol, (T1, T2, T3, T4, T5, T6, T7, T8, T9, T10) parsed)> ParseAsync(Cursol cursol)
        {
            (T1, T2, T3, T4, T5, T6, T7, T8, T9, T10) returnValue = default;
            var helper = new SequenceHelper(cursol);

            return
                await helper.ParseAsync(Parsers.Item1, value => returnValue.Item1 = value) &&
                await helper.ParseAsync(Parsers.Item2, value => returnValue.Item2 = value) &&
                await helper.ParseAsync(Parsers.Item3, value => returnValue.Item3 = value) &&
                await helper.ParseAsync(Parsers.Item4, value => returnValue.Item4 = value) &&
                await helper.ParseAsync(Parsers.Item5, value => returnValue.Item5 = value) &&
                await helper.ParseAsync(Parsers.Item6, value => returnValue.Item6 = value) &&
                await helper.ParseAsync(Parsers.Item7, value => returnValue.Item7 = value) &&
                await helper.ParseAsync(Parsers.Item8, value => returnValue.Item8 = value) &&
                await helper.ParseAsync(Parsers.Item9, value => returnValue.Item9 = value) &&
                await helper.ParseAsync(Parsers.Item10, value => returnValue.Item10 = value)
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
            var (isSuccess, cursol, parsed) = await parser.ParseAsync(Current);
            if (!isSuccess)
            {
                return isSuccess;
            }
            Current = cursol;
            setter(parsed);
            return isSuccess;
        }
    }
}
