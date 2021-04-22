namespace Sirh3e.Brainfuck.Lib.InstructionSet.Instructions
{
    public class SquareBracketOpenInstruction : JumpInstruction
    {
        protected override bool IsThisIndex(byte @byte)
            => @byte == 0;
    }
}