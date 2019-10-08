using Marimo.ParserCombinator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Marimo.Test.ParserCombinator
{
    public class CharParserのテスト
    {
        [Fact]
        public async Task ParseAsyncは指定した文字を読み込みに成功します()
        {
            var cursol = new Cursol("public");
            var tested = new CharParser('p');

            var result = await tested.ParseAsync(cursol);

            result.isSuccess.IsTrue();
        }

        [Fact]
        public async Task ParseAsyncは指定した文字を読み込みます()
        {
            var cursol = new Cursol("public");
            var tested = new CharParser('p');

            var result = await tested.ParseAsync(cursol);

            result.parsed.Is('p');
        }

        [Fact]
        public async Task ParseAsyncは指定していない文字を読み込みに失敗します()
        {
            var cursol = new Cursol("internal");
            var tested = new CharParser('p');

            var result = await tested.ParseAsync(cursol);

            result.isSuccess.IsFalse();
        }

        [Fact]
        public async Task ParseAsyncは読み込みに成功した場合にその分進んだカーソルを返します()
        {
            var cursol = new Cursol("public");
            var tested = new CharParser('p');

            var result = await tested.ParseAsync(cursol);

            result.cursol.Index.Is(1);
        }
    }
}
