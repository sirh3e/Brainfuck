using System;
using System.Collections.Generic;

namespace Sirh3e.Brainfuck.Lib.Core
{
    public static class Lexer
    {
        public static IEnumerable<Token> Tokenize(string text)
        {
            _ = text ?? throw new ArgumentNullException(nameof(text));

            foreach (var @char in text)
                yield return Tokenize(@char);
        }

        public static Token Tokenize(char @char)
            => @char switch
            {
                '>' => Token.Shr,
                '<' => Token.Shl,
                '+' => Token.Plus,
                '-' => Token.Minus,
                '.' => Token.Dot,
                ',' => Token.Comma,
                '[' => Token.SquareBracketOpen,
                ']' => Token.SquareBracketClose,
                _ => Token.WhiteSpace
            };
    }
}