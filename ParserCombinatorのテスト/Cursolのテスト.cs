﻿using Marimo.ParserCombinator;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Marimo.Test.ParserCombinator
{
    public class Cursolのテスト
    {
        [Fact]
        public void 初期状態のIndexは0です()
        {
            var tested = new Cursol("");
            tested.Index.Is(0);
        }

        [Fact]
        public void 初期状態のTextはコンストラクタで指定したものです()
        {
            var text = "ABC";
            var tested = new Cursol(text);
            tested.Text.Is(text);
        }

        [Fact]
        public void GoFowardでIndexが進んだCursolが手に入ります()
        {
            var tested = new Cursol("ABC");
            tested = tested.GoFoward(2);
            tested.Index.Is(2);
        }
        [Fact]
        public void GoFowardは前の状態と比較して進んだ値を指定します()
        {
            var tested = new Cursol("ABC");
            tested = tested.GoFoward(1);
            tested = tested.GoFoward(1);
            tested.Index.Is(2);
        }
        [Fact]
        public void GoFowardは最後の文字の一個先までしか進むことができません()
        {
            var tested = new Cursol("ABC");
            tested = tested.GoFoward(4);
            tested.Index.Is(3);
        }

        [Fact]
        public void GoFowardは元の値をCursolを変更しません()
        {
            var tested = new Cursol("ABC");
            tested.GoFoward(1);
            tested.Index.Is(0);
        }

        [Fact]
        public void Copyは同じTextを持つCursolを返します()
        {
            var tested = new Cursol("ABC");
            tested.Copy().Text.Is("ABC");
        }

        [Fact]
        public void Copyは同じIndexを持つCursolを返します()
        {
            var tested = new Cursol("ABC");
            tested = tested.GoFoward(1);
            tested.Copy().Index.Is(1);
        }
    }
}
