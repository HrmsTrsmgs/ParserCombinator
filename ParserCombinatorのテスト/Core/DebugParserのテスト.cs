using Marimo.ParserCombinator.Core;
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
        public async Task ParseAsyncは内部パーサーと同じように成功します()
        {
            var cursol = new Cursol("public");
            var parser = new CharParser('p');
            var tested = new DebugParser<char>(parser, () => { });
            (await tested.ParseAsync(cursol)).IsStructuralEqual(await parser.ParseAsync(cursol));
        }
        [Fact]
        public async Task ParseAsyncは内部パーサーと同じように失敗します()
        {
            var cursol = new Cursol("public");
            var parser = new CharParser('a');
            var tested = new DebugParser<char>(parser, () => { });
            (await tested.ParseAsync(cursol)).IsStructuralEqual(await parser.ParseAsync(cursol));
        }

        [Fact]
        public async Task ParseAsyncは指定したActionを呼びます()
        {
            bool isActioned = false;
            var cursol = new Cursol("public");
            var parser = new CharParser('a');
            var tested = new DebugParser<char>(parser, () => { isActioned = true; });

            isActioned.IsFalse();
            await tested.ParseAsync(cursol);
            isActioned.IsTrue();
        }
    }
}
