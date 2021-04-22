using System;

namespace Sirh3e.Brainfuck.Lib.Core
{
    public interface IVm : IDisposable
    {
        public int InstructionIndex { get; }

        public int IncreaseInstructionIndexBy(uint amount);
        public int DecreaseInstructionIndexBy(uint amount);

        public int MemoryIndex { get; }

        public int IncreaseMemoryIndexBy(uint amount);
        public int DecreaseMemoryIndexBy(uint amount);

        public byte CurrentMemory { get; }

        public byte IncreaseCurrentMemoryBy(byte amount);
        public byte DecreaseCurrentMemoryBy(byte amount);

        public void AddCharToScreenBuffer(char @char);

        public void Run();
    }
}