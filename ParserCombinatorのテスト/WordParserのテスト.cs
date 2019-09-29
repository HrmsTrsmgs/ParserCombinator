using Marimo.ParserCombinator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Marimo.Test.ParserCombinator
{
    public class WordParserのテスト
    {
        [Fact]
        public async Task ParseAsyncは指定した単語を読み込みに成功します()
        {
            var cursol = new Cursol("public");
            var tested = new WordParser("public");

            var result = await tested.ParseAsync(cursol);

            result.isSuccess.IsTrue();
        }

        [Fact]
        public async Task ParseAsyncは指定していない単語を読み込みに失敗します()
        {
            var cursol = new Cursol("publi");
            var tested = new WordParser("public");

            var result = await tested.ParseAsync(cursol);

            result.isSuccess.IsFalse();
        }

        [Fact]
        public async Task ParseAsyncは読み込みに成功した場合にその分進んだカーソルを返します()
        {
            var cursol = new Cursol("public");
            var tested = new WordParser("public");

            var result = await tested.ParseAsync(cursol);

            result.cursol.Index.Is(6);
        }

        [Fact]
        public async Task ParseAsyncは読み込みに成功した場合に単語の長さだけ進んだカーソルを返します()
        {
            var cursol = new Cursol("void");
            var tested = new WordParser("void");

            var result = await tested.ParseAsync(cursol);

            result.cursol.Index.Is(4);
        }

        [Fact]
        public async Task ParseAsyncは読み込みに失敗した場合には進んでいないカーソルを返します()
        {
            var cursol = new Cursol("publi");
            var tested = new WordParser("public");

            var result = await tested.ParseAsync(cursol);

            result.cursol.Index.Is(0);
        }
    }
}
