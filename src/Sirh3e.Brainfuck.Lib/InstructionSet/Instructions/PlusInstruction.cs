using System;
using Sirh3e.Brainfuck.Lib.Core;

namespace Sirh3e.Brainfuck.Lib.InstructionSet.Instructions
{
    public class PlusInstruction : IInstruction
    {
        public void Execute(IVm vm)
        {
            _ = vm ?? throw new ArgumentNullException(nameof(vm));

            vm.IncreaseCurrentMemoryBy(1);
        }
    }
}