using System;

namespace Tastier { // DMA

class Tastier { // DMA

  public static void Main (string[] arg) {
    if (arg.Length > 0) {
      Scanner scanner = new Scanner(arg[0]);
      Parser parser = new Parser(scanner);
      parser.Parse();
      if (parser.errors.count == 0) {
        //parser.Write("test.asm");
      }
    } else Console.WriteLine("-- No source file specified");
  }

}

}
