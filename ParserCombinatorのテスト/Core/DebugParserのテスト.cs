﻿using Marimo.ParserCombinator.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Marimo.ParserCombinator.Test.Core
{
    public class DebugParserのテスト
    {
        [Fact]
        public void ParseAsyncは内部パーサーと同じように成功します()
        {
            var cursol = new Cursol("public");
            var parser = new CharParser('p');
            var tested = new DebugParser<char>(parser, () => { });
            (tested.Parse(cursol)).IsStructuralEqual(parser.Parse(cursol));
        }
        [Fact]
        public void ParseAsyncは内部パーサーと同じように失敗します()
        {
            var cursol = new Cursol("public");
            var parser = new CharParser('a');
            var tested = new DebugParser<char>(parser, () => { });
            (tested.Parse(cursol)).IsStructuralEqual(parser.Parse(cursol));
        }

        [Fact]
        public void ParseAsyncは指定したActionを呼びます()
        {
            bool isActioned = false;
            var cursol = new Cursol("public");
            var parser = new CharParser('a');
            var tested = new DebugParser<char>(parser, () => { isActioned = true; });

            isActioned.IsFalse();
            tested.Parse(cursol);
            isActioned.IsTrue();
        }
    }
}
