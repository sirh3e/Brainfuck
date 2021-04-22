using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Sirh3e.Brainfuck.Lib.Core;

namespace Sirh3e.Brainfuck.Cli
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            //ToDo check if the input is source code
            //ToDo check if the input is source code
            var path = Environment.GetEnvironmentVariable("BRAINFUCK_DIR") ?? "/src/brainfuck/";
            var name = args.Any() ? args.First() : "HelloWorld.bf";

            var info = new FileInfo(Path.Combine(path, name));

            if (!info.Exists)
                throw new FileNotFoundException("Could not found file", info.FullName);

            using var reader = info.OpenText();
            var text = await reader.ReadToEndAsync();

            var tokens = Lexer.Tokenize(text);
            var instructions = Parser.Parse(tokens);

            using IVm vm = new Vm
            {
                Instructions = instructions
            };

            vm.Run();
        }
    }
}