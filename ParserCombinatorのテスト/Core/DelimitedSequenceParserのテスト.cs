﻿using Marimo.ParserCombinator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Marimo.ParserCombinator.Test.Core
{
    public class DelimitedSequenceParserのテスト
    {
        [Fact]
        public void 最初の要素のパースに失敗しても成功です()
        {
            var tested = new DelimitedSequenceParser<char, char>(
                new CharParser('a'),
                new CharParser(','));

            var (isSuccess, _, _) = tested.Parse(new Cursol("b"));

            isSuccess.IsTrue();
        }

        [Fact]
        public void 最初の要素のパースに失敗すればカーソルは進みません()
        {
            var tested = new DelimitedSequenceParser<char, char>(
                new CharParser('a'),
                new CharParser(','));

            var (_, cursol, _) = tested.Parse(new Cursol("b"));

            cursol.Index.Is(0);
        }

        [Fact]
        public void 最初の要素のパースに失敗すれば空の要素が結果となります()
        {
            var tested = new DelimitedSequenceParser<char, char>(
                new CharParser('a'),
                new CharParser(','));

            var (_, _, parsed) = tested.Parse(new Cursol("b"));

            parsed.Count().Is(0);
        }

        [Fact]
        public void 最初の要素のパースに成功すれば成功です()
        {
            var tested = new DelimitedSequenceParser<char, char>(
                new CharParser('a'),
                new CharParser(','));

            var (isSuccess, _, _) = tested.Parse(new Cursol("a"));

            isSuccess.IsTrue();
        }
        [Fact]
        public void 最初の要素のパースに成功すればカーソルが進みます()
        {
            var tested = new DelimitedSequenceParser<char, char>(
                new CharParser('a'),
                new CharParser(','));

            var (_, cursol, _) = tested.Parse(new Cursol("a"));

            cursol.Index.Is("a".Length);
        }
        [Fact]
        public void 最初の要素のパースに成功すれば最初の一つが結果になります()
        {
            var tested = new DelimitedSequenceParser<char, char>(
                new CharParser('a'),
                new CharParser(','));

            var (_, _, parsed) = tested.Parse(new Cursol("a"));

            parsed.Is(new[] { 'a' });
        }
        [Fact]
        public void 区切り子で終わった場合は区切り子は読み込みません()
        {
            var tested = new DelimitedSequenceParser<char, char>(
                new CharParser('a'),
                new CharParser(','));

            var (_, cursol, _) = tested.Parse(new Cursol("a,"));

            cursol.Index.Is("a".Length);
        }

        [Fact]
        public void 二つ目の要素も結果に入ります()
        {
            var tested = new DelimitedSequenceParser<char, char>(
                new CharParser('a'),
                new CharParser(','));

            var (_, _, parsed) = tested.Parse(new Cursol("a,a"));

            parsed.Is(new[] { 'a', 'a' });
        }
    }
}
