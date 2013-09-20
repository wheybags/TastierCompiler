using System;
using System.IO;

namespace Tastier {

public enum Instruction {
 ADD, SUB, MUL, DIV, EQU, LSS, GTR, NEG,
 LOAD, LOADG, STO, STOG, CONST,
 CALL, RET, ENTER, LEAVE, JMP, FJMP, READ, WRITE
};

public class InstructionWord {

  Instruction operation;  // the actual instruction
  string label;           // if the instruction has a label
  int arg0; int arg1;     // if the instruction has arguments

  public void put(List<string> output) {
    string s = "";
    switch(operation) {
      case Instruction.ADD:     { s += "Add"; break;   }
      case Instruction.SUB:     { s += "Sub"; break;   }
      case Instruction.MUL:     { s += "Mul"; break;   }
      case Instruction.DIV:     { s += "Div"; break;   }
      case Instruction.EQU:     { s += "Equ"; break;   }
      case Instruction.LSS:     { s += "Lss"; break;   }
      case Instruction.GTR:     { s += "Gtr"; break;   }
      case Instruction.NEG:     { s += "Neg"; break;   }
      case Instruction.LOAD:    { s += "Load"; break;  }
      case Instruction.LOADG:   { s += "LoadG"; break; }
      case Instruction.STO:     { s += "Sto"; break;   }
      case Instruction.STOG:    { s += "StoG"; break;  }
      case Instruction.CONST:   { s += "Const"; break; }
      case Instruction.CALL:    { s += "Call"; break;  }
      case Instruction.RET:     { s += "Ret"; break;   }
      case Instruction.ENTER:   { s += "Enter"; break; }
      case Instruction.LEAVE:   { s += "Leave"; break; }
      case Instruction.JMP:     { s += "Jmp"; break;   }
      case Instruction.FJMP:    { s += "FJmp"; break;  }
      case Instruction.READ:    { s += "Read"; break;  }
      case Instruction.WRITE:   { s += "Write"; break; }
    }

    if (label != null) {
      s = label + ": " + s;
    }

    if (arg0 != null) {
      s += (" " + arg0);
    }

    if (arg1 != null) {
      s += (" " + arg1);
    }

    output.Add(s);
  }

  public InstructionWord(Instruction op) {
    this.operation == op;
    this.label == null;
    this.arg0 == null;
    this.arg1 == null;
  }

  public InstructionWord(Instruction op, string lab) {
    this.operation == op;
    this.label == lab;
    this.arg0 == null;
    this.arg1 == null;
  }

  public InstructionWord(Instruction op, string lab, int arg0) {
    this.operation == op;
    this.label == lab;
    this.arg0 == arg0;
    this.arg1 == null;
  }

  public InstructionWord(Instruction op, string lab, int arg0, int arg1) {
    this.operation == op;
    this.label == lab;
    this.arg0 == arg0;
    this.arg1 == arg1;
  }
}

public class CodeGenerator {

   List<string> code;

   public void write(string filename) {
      File.WriteAllLines(filename, code);
   }

   public CodeGenerator() {
      this.code = new List<string>();
   }
}

}
