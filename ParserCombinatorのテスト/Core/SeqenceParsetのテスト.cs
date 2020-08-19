using Marimo.ParserCombinator;
using Marimo.ParserCombinator.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Marimo.Test.ParserCombinator.Core
{
    public class 要素を2つ持つSeqenceParserのテスト
    {
        IParser<(string, string)> tested;

        public 要素を2つ持つSeqenceParserのテスト()
        {
            tested = new SequenceParser<string, string>(
                new WordParser("public"),
                new WordParser("static"));
        }

        [Fact]
        public async Task ParseAsyncは指定した単語を読み込みに成功します()
        {
            var cursol = new Cursol("public static");

            var result = await tested.ParseAsync(cursol);

            result.isSuccess.IsTrue();
        }

        [Fact]
        public async Task ParseAsyncは一つ目の解析に失敗した場合は失敗します()
        {
            var cursol = new Cursol("publica static");

            var result = await tested.ParseAsync(cursol);

            result.isSuccess.IsFalse();
        }

        [Fact]
        public async Task ParseAsyncは指定した単語を読み込みます()
        {
            var cursol = new Cursol("public static");

            var result = await tested.ParseAsync(cursol);

            result.parsed.Is(("public", "static"));
        }

        [Fact]
        public async Task ParseAsyncはふたつ目の解析に失敗した場合は失敗します()
        {
            var cursol = new Cursol("public statiac");

            var result = await tested.ParseAsync(cursol);

            result.isSuccess.IsFalse();
        }

        [Fact]
        public async Task ParseAsyncは読み込みに成功した場合に単語の長さだけ進んだカーソルを返します()
        {
            var cursol = new Cursol("public static");
            var tested = SequenceParser.Create(new WordParser("public"), new WordParser("static"));

            var result = await tested.ParseAsync(cursol);

            result.cursol.Index.Is("public static".Length);
        }
    }
    public class 要素を3つ持つSeqenceParserのテスト
    {
        IParser<(string, string, string)> tested;

        public 要素を3つ持つSeqenceParserのテスト()
        {
            tested = new SequenceParser<string, string, string>(
                new WordParser("public"),
                new WordParser("static"),
                new WordParser("int"));
        }


        [Fact]
        public async Task ParseAsyncは指定した単語を読み込みに成功します()
        {
            var cursol = new Cursol("public static int");
            
            var result = await tested.ParseAsync(cursol);

            result.isSuccess.IsTrue();
        }

        [Fact]
        public async Task ParseAsyncは一つ目の解析に失敗した場合は失敗します()
        {
            var cursol = new Cursol("publica static int");

            var result = await tested.ParseAsync(cursol);

            result.isSuccess.IsFalse();
        }

        [Fact]
        public async Task ParseAsyncは指定した単語を読み込みます()
        {
            var cursol = new Cursol("public static int");

            var result = await tested.ParseAsync(cursol);

            result.parsed.Is(("public", "static", "int"));
        }

        [Fact]
        public async Task ParseAsyncはふたつ目の解析に失敗した場合は失敗します()
        {
            var cursol = new Cursol("public statiac int");

            var result = await tested.ParseAsync(cursol);

            result.isSuccess.IsFalse();
        }
        [Fact]
        public async Task ParseAsyncは三つ目の解析に失敗した場合は失敗します()
        {
            var cursol = new Cursol("public statiac innt");

            var result = await tested.ParseAsync(cursol);

            result.isSuccess.IsFalse();
        }


        [Fact]
        public async Task ParseAsyncは読み込みに成功した場合に単語の長さだけ進んだカーソルを返します()
        {
            var cursol = new Cursol("public static int");

            var result = await tested.ParseAsync(cursol);

            result.cursol.Index.Is("public static int".Length);
        }
    }
}
