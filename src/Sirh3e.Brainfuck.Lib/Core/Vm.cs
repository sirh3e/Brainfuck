using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Sirh3e.Brainfuck.Lib.InstructionSet;

namespace Sirh3e.Brainfuck.Lib.Core
{
    public sealed class Vm : IVm
    {
        public int InstructionIndex { get; private set; } = -1;

        public int IncreaseInstructionIndexBy(uint amount)
        {
            InstructionIndex += (int)amount;
            return InstructionIndex;
        }

        public int DecreaseInstructionIndexBy(uint amount)
        {
            InstructionIndex -= (int)amount;
            return InstructionIndex;
        }

        public IImmutableList<IInstruction> Instructions { get; init; }

        public int MemoryIndex { get; private set; } = 0;

        public int IncreaseMemoryIndexBy(uint amount)
        {
            MemoryIndex += (int)amount;
            return MemoryIndex;
        }

        public int DecreaseMemoryIndexBy(uint amount)
        {
            MemoryIndex -= (int)amount;
            return MemoryIndex;
        }

        private byte[] Memory { get; } = new byte[30_000];
        private readonly List<char> _screenBuffer = new(512);

        public byte CurrentMemory
        {
            private set => Memory[MemoryIndex] = value;
            get => Memory[MemoryIndex];
        }

        public byte IncreaseCurrentMemoryBy(byte amount)
            => CurrentMemory += amount;

        public byte DecreaseCurrentMemoryBy(byte amount)
            => CurrentMemory -= amount;

        public void AddCharToScreenBuffer(char @char)
        {
            _screenBuffer.Add(@char);
        }

        public void Run()
        {
            while (Next())
            {
                Execute(Fetch());
            }
        }

        private void Execute(IInstruction instruction)
        {
            instruction.Execute(this);
        }

        private IInstruction Fetch()
            => Instructions[InstructionIndex];

        private bool Next()
            => IncreaseInstructionIndexBy(1) < Instructions.Count;

        private void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            Console.WriteLine(_screenBuffer.ToArray());
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}