using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Sirh3e.Brainfuck.Lib.InstructionSet;
using Sirh3e.Brainfuck.Lib.InstructionSet.Instructions;

namespace Sirh3e.Brainfuck.Lib.Core
{
    public static class Parser
    {
        public static IImmutableList<IInstruction> Parse(IEnumerable<Token> tokens)
        {
            var index = 0;
            var indexes = new Stack<int>();
            var instructions = new List<IInstruction>();

            T CreateJumpInstruction<T>(int index)
                where T : JumpInstruction, new()
                => new()
            {
                Index = index
            };

            void SetInstruction<T>(int instructionIndex, int index)
                where T : JumpInstruction, new()
                    => instructions[instructionIndex] = CreateJumpInstruction<T>(index);

            bool TrySetInstruction<T>(int instructionIndex, int index)
                where T : JumpInstruction, new()
            {
                if (instructions[instructionIndex] is not T)
                    return false;

                SetInstruction<T>(instructionIndex, index);
                return true;
            }

            void SquareBracketClose()
            {
                var previous = indexes.Pop();

                if (!(TrySetInstruction<SquareBracketOpenInstruction>(previous, index)
                      && TrySetInstruction<SquareBracketCloseInstruction>(index, previous)))
                {
                    throw new InvalidOperationException();
                }
            }

            void PatchInstruction(Token token)
            {
                switch (token)
                {
                    case Token.SquareBracketOpen:
                        indexes.Push(index);
                        break;
                    case Token.SquareBracketClose:
                        {
                            SquareBracketClose();
                            break;
                        }
                }
            }

            foreach (var token in tokens)
            {
                if (token == Token.WhiteSpace)
                    continue;

                var instruction = Parse(token);
                instructions.Add(instruction);

                PatchInstruction(token);
                index++;
            }
            return instructions.ToImmutableList();
        }

        public static IInstruction Parse(Token token)
            => InstructionFactory.CreateInstruction(Map[token]);

        public static readonly Dictionary<Token, Instruction> Map = new()
        {
            { Token.Shr, Instruction.Shr },
            { Token.Shl, Instruction.Shl },
            { Token.Plus, Instruction.Plus },
            { Token.Minus, Instruction.Minus },
            { Token.Dot, Instruction.Dot },
            { Token.Comma, Instruction.Comma },
            { Token.SquareBracketOpen, Instruction.SquareBracketOpen },
            { Token.SquareBracketClose, Instruction.SquareBracketClose },
            { Token.WhiteSpace, Instruction.Nop },
        };
    }
}