using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Transactions;
using System.Data.SqlTypes;

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
            var (isSuccess, current, parsed1) = await Parsers.Item1.ParseAsync(cursol);
            if (!isSuccess)
            {
                return (false, cursol, default);
            }
            T2 parsed2;
            (isSuccess, current, parsed2) = await Parsers.Item2.ParseAsync(current);
            if (!isSuccess)
            {
                return (false, cursol, default);
            }
            return (true, current, (parsed1, parsed2));
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
        IParser<(T1, T2, T3, T4, T5, T6, T7, T8, T9)> Parser { get; }
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
            Parser =
                new ParserConverter<(T1, (T2, T3, T4, T5, T6, T7, T8, T9)), (T1, T2, T3, T4, T5, T6, T7, T8, T9)>(
                new SequenceParser<T1, (T2, T3, T4, T5, T6, T7, T8, T9)>(
                    parser1,
                    new SequenceParser<T2, T3, T4, T5, T6, T7, T8, T9>(
                        parser2,
                        parser3,
                        parser4,
                        parser5,
                        parser6,
                        parser7,
                        parser8,
                        parser9)),
                tuple => (
                    tuple.Item1,
                    tuple.Item2.Item1,
                    tuple.Item2.Item2,
                    tuple.Item2.Item3,
                    tuple.Item2.Item4,
                    tuple.Item2.Item5,
                    tuple.Item2.Item6,
                    tuple.Item2.Item7,
                    tuple.Item2.Item8));
        }

        public async Task<(bool isSuccess, Cursol cursol, (T1, T2, T3, T4, T5, T6, T7, T8, T9) parsed)> ParseAsync(Cursol cursol)
            => await Parser.ParseAsync(cursol);
    }
    public class SequenceParser<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : IParser<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)>
    {
        IParser<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)> Parser { get; }
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
            Parser =
                new ParserConverter<(T1, (T2, T3, T4, T5, T6, T7, T8, T9, T10)), (T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)>(
                new SequenceParser<T1, (T2, T3, T4, T5, T6, T7, T8, T9, T10)>(
                    parser1,
                    new SequenceParser<T2, T3, T4, T5, T6, T7, T8, T9, T10>(
                        parser2,
                        parser3,
                        parser4,
                        parser5,
                        parser6,
                        parser7,
                        parser8,
                        parser9,
                        parser10)),
                tuple => (
                    tuple.Item1,
                    tuple.Item2.Item1,
                    tuple.Item2.Item2,
                    tuple.Item2.Item3,
                    tuple.Item2.Item4,
                    tuple.Item2.Item5,
                    tuple.Item2.Item6,
                    tuple.Item2.Item7,
                    tuple.Item2.Item8,
                    tuple.Item2.Item9));
        }

        public async Task<(bool isSuccess, Cursol cursol, (T1, T2, T3, T4, T5, T6, T7, T8, T9, T10) parsed)> ParseAsync(Cursol cursol)
            => await Parser.ParseAsync(cursol);
    }
}
