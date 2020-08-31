﻿using Marimo.ParserCombinator;
using Marimo.ParserCombinator.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Marimo.Test.ParserCombinator.Core
{
    public class CharParserのテスト
    {
        [Fact]
        public void ParseAsyncは指定した文字を読み込みに成功します()
        {
            var cursol = new Cursol("public");
            var tested = new CharParser('p');

            var result = tested.Parse(cursol);

            result.isSuccess.IsTrue();
        }

        [Fact]
        public void ParseAsyncは指定した文字を読み込みます()
        {
            var cursol = new Cursol("public");
            var tested = new CharParser('p');

            var result = tested.Parse(cursol);

            result.parsed.Is('p');
        }

        [Fact]
        public void ParseAsyncは指定していない文字を読み込みに失敗します()
        {
            var cursol = new Cursol("internal");
            var tested = new CharParser('p');

            var result = tested.Parse(cursol);

            result.isSuccess.IsFalse();
        }

        [Fact]
        public void ParseAsyncは読み込みに成功した場合にその分進んだカーソルを返します()
        {
            var cursol = new Cursol("public");
            var tested = new CharParser('p');

            var result = tested.Parse(cursol);

            result.cursol.Index.Is(1);
        }

        [Fact]
        public void ParseAsyncはIgnoreCaseでない場合に小文字指定の場合に大文字を区別します()
        {
            var cursol = new Cursol("Public");
            var tested = new CharParser('p');

            var (isSuccess, _, _) = tested.Parse(cursol);

            isSuccess.IsFalse();
        }

        [Fact]
        public void ParseAsyncはIgnoreCaseでない場合に大文字指定の場合に小文字を区別します()
        {
            var cursol = new Cursol("public");
            var tested = new CharParser('P');

            var (isSuccess, _, _) = tested.Parse(cursol);

            isSuccess.IsFalse();
        }

        [Fact]
        public void ParseAsyncはIgnoreCaseで小文字指定でも大文字を識別します()
        {
            var cursol = new Cursol("Public");
            var tested = new CharParser('p', true);

            var (isSuccess, _, _) = tested.Parse(cursol);

            isSuccess.IsTrue();
        }

        [Fact]
        public void ParseAsyncはIgnoreCaseで大文字指定でも小文字を識別します()
        {
            var cursol = new Cursol("public");
            var tested = new CharParser('P', true);

            var (isSuccess, _, _) = tested.Parse(cursol);

            isSuccess.IsTrue();
        }

        [Fact]
        public void ParseAsyncはIgnoreCaseで小文字指定の場合に実際に識別した文字を結果とします()
        {
            var cursol = new Cursol("Public");
            var tested = new CharParser('p', true);

            var (_, _, parsed) = tested.Parse(cursol);

            parsed.Is('P');
        }

        [Fact]
        public void ParseAsyncはIgnoreCaseで大文字指定の場合に実際に識別した文字を結果とします()
        {
            var cursol = new Cursol("public");
            var tested = new CharParser('P', true);

            var (_, _, parsed) = tested.Parse(cursol);

            parsed.Is('p');
        }
    }
}
