using System;
using Sirh3e.Brainfuck.Lib.Core;

namespace Sirh3e.Brainfuck.Lib.InstructionSet.Instructions
{
    public class CommaInstruction : IInstruction
    {
        public void Execute(IVm vm)
        {
            var @byte = (byte)Console.Read();
            var delta = (byte)(@byte - vm.CurrentMemory);

            Func<byte, byte> func = delta <= 0
                ? vm.IncreaseCurrentMemoryBy
                : vm.DecreaseCurrentMemoryBy;

            func(delta);
        }
    }
}