namespace Sirh3e.Brainfuck.Lib.InstructionSet.Instructions
{
    public class SquareBracketCloseInstruction : JumpInstruction
    {
        protected override bool IsThisIndex(byte @byte)
            => @byte != 0;
    }
}