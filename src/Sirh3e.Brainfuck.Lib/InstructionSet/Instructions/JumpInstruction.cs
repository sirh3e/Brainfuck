using System;
using Sirh3e.Brainfuck.Lib.Core;

namespace Sirh3e.Brainfuck.Lib.InstructionSet.Instructions
{
    public abstract class JumpInstruction : IJumpInstruction
    {
        public void Execute(IVm vm)
        {
            _ = vm ?? throw new ArgumentNullException(nameof(vm));

            var index = IsThisIndex(vm.CurrentMemory) ? Index : vm.InstructionIndex;
            var isSmaller = vm.InstructionIndex < index;

            var delta = isSmaller
                ? (uint)(index - vm.InstructionIndex)
                : (uint)(vm.InstructionIndex - index);

            Func<uint, int> func = isSmaller
                ? vm.IncreaseInstructionIndexBy
                : vm.DecreaseInstructionIndexBy;

            func(delta);
        }

        protected abstract bool IsThisIndex(byte @byte);
        public int Index { get; init; }
    }
}