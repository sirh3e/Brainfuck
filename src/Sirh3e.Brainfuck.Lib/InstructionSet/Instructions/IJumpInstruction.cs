namespace Sirh3e.Brainfuck.Lib.InstructionSet.Instructions
{
    public interface IJumpInstruction : IInstruction
    {
        public int Index { get; }
    }
}