﻿using Marimo.ParserCombinator.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Marimo.ParserCombinator.Test.Core
{
    public class ExpectCharParserのテスト
    {
        [Fact]
        public void ParseAsyncは指定ていない文字を読み込みに成功します()
        {
            var cursol = new Cursol("public");
            var tested = new ExpectCharParser(
                new CharParser('a'));

            var (isSuccess, _, _) = tested.Parse(cursol);

            isSuccess.IsTrue();
        }

        [Fact]
        public void ParseAsyncは指定していない文字を読み込みます()
        {
            var cursol = new Cursol("public");
            var tested = new ExpectCharParser(
                new CharParser('a'));

            var (_, _, parsed) = tested.Parse(cursol);

            parsed.Is('p');
        }

        [Fact]
        public void ParseAsyncは指定した文字を読み込みに失敗します()
        {
            var cursol = new Cursol("public");
            var tested = new ExpectCharParser(
                new CharParser('p'));

            var (isSuccess, _, _) = tested.Parse(cursol);

            isSuccess.IsFalse();
        }

        [Fact]
        public void ParseAsyncは読み込みに成功した場合にその分進んだカーソルを返します()
        {
            var tested = new ExpectCharParser(
                new CharParser('a'));

            var (_, cursol, _) = tested.Parse(new Cursol("public"));

            cursol.Index.Is(1);
        }

        [Fact]
        public void ParseAsyncは読み込みに成功した場合に読み込んだ文字を返します()
        {
            var tested = new ExpectCharParser(
                new CharParser('a'));

            var (_, _, parsed) = tested.Parse(new Cursol("public"));

            parsed.Is('p');
        }
    }
}
