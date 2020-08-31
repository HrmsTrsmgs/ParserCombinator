﻿using Marimo.ParserCombinator;
using Marimo.ParserCombinator.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Marimo.Test.ParserCombinator.Core
{
    public class ParserConverterのテスト
    {
        ParserConverter<string, int> Tested { get; }

        public ParserConverterのテスト()
        {
            Tested = ParserConverter.Create(new WordParser("123"), s => int.Parse(s));
        }


        [Fact]
        public void パースします()
        {
            Tested.Parse(new Cursol("123"));
        }

        [Fact]
        public void 指定したパーサーと同じ条件で成功します()
        {
            var (isSuccess, _, _) = Tested.Parse(new Cursol("123"));

            isSuccess.IsTrue();
        }

        [Fact]
        public void 指定したパーサーと同じ条件で失敗します()
        {
            var (isSuccess, _, _) = Tested.Parse(new Cursol("124"));

            isSuccess.IsFalse();
        }

        [Fact]
        public void 指定した通り変換がなされます()
        {
            var (_, _, parsed) = Tested.Parse(new Cursol("123"));

            parsed.Is(123);
        }

        [Fact]
        public void 成功した時はカーソルが進みます()
        {
            var (_, cursol, _) = Tested.Parse(new Cursol("123"));

            cursol.Index.Is(3);
        }
        [Fact]
        public void 失敗した時はカーソルが進みません()
        {
            var (_, cursol, _) = Tested.Parse(new Cursol("124"));

            cursol.Index.Is(0);
        }
    }
}
