using Sirh3e.Brainfuck.Lib.Core;

namespace Sirh3e.Brainfuck.Lib.InstructionSet
{
    public interface IInstruction
    {
        public void Execute(IVm vm);
    }
}