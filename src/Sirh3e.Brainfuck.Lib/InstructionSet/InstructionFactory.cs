using System;
using System.Collections.Generic;
using Sirh3e.Brainfuck.Lib.InstructionSet.Instructions;

namespace Sirh3e.Brainfuck.Lib.InstructionSet
{
    public static class InstructionFactory
    {
        private static readonly Dictionary<Instruction, IInstruction> Instructions = new(16);

        public static IInstruction CreateInstruction(Instruction type)
        {
            if (Instructions.TryGetValue(type, out var instruction))
                return instruction;

            instruction = type switch
            {
                Instruction.Shr => new ShrInstruction(),
                Instruction.Shl => new ShlInstruction(),
                Instruction.Plus => new PlusInstruction(),
                Instruction.Minus => new MinusInstruction(),
                Instruction.Dot => new DotInstruction(),
                Instruction.Comma => new CommaInstruction(),
                Instruction.SquareBracketOpen => new SquareBracketOpenInstruction(),
                Instruction.SquareBracketClose => new SquareBracketCloseInstruction(),
                Instruction.Nop => new NopInstruction(),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };

            if (!Instructions.TryAdd(type, instruction))
            {
                throw new InvalidOperationException();
            }

            return instruction;
        }
    }
}