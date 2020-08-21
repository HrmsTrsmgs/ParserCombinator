using Marimo.ParserCombinator;
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

        [Fact]
        public async Task ParseAsyncはIgnoreCaseでない場合に小文字指定の場合に大文字を区別します()
        {
            var cursol = new Cursol("Public");
            var tested = new CharParser('p');

            var result = await tested.ParseAsync(cursol);

            result.parsed.Is('p');
        }

        [Fact]
        public async Task ParseAsyncはIgnoreCaseで小文字指定でも大文字を識別します()
        {
            var cursol = new Cursol("Public");
            var tested = new CharParser('p', true);

            var (isSuccess, _, _) = await tested.ParseAsync(cursol);

            isSuccess.IsTrue();
        }

        [Fact]
        public async Task ParseAsyncはIgnoreCaseで大文字指定でも小文字を識別します()
        {
            var cursol = new Cursol("public");
            var tested = new CharParser('P', true);

            var (isSuccess, _, _) = await tested.ParseAsync(cursol);

            isSuccess.IsTrue();
        }
    }
}
