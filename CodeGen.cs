using System;
using System.IO;
using System.Collections.Generic;

namespace Tastier {

public enum Instruction {
 ADD, SUB, MUL, DIV, EQU, LSS, GTR, NEG,
 LOAD, LOADG, STO, STOG, CONST,
 CALL, RET, ENTER, LEAVE, JMP, FJMP, READ, WRITE
};

public enum Kind {
  Nullary, Unary, Binary
};

public class InstructionWord {

  Instruction operation;  // the actual instruction
  string label;           // if the instruction has a label
  Kind kind;              // nullary, unary or binary instructions
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

    if (kind = Kind.Unary || kind = Kind.Binary) {
      s += (" " + arg0);
    }

    if (kind = Kind.Binary) {
      s += (" " + arg1);
    }

    output.Add(s);
  }

  public InstructionWord(Instruction op) {
    this.operation = op;
    this.label = null;
    this.kind = Kind.Nullary;
  }

  public InstructionWord(Instruction op, int arg0) {
    this.operation = op;
    this.label = lab;
    this.kind = Kind.Unary;
    this.arg0 = arg0;
  }

  public InstructionWord(Instruction op, int arg0, int arg1) {
    this.operation = op;
    this.label = lab;
    this.kind = Kind.Binary;
    this.arg0 = arg0;
    this.arg1 = arg1;
  }
}

public class CodeGenerator {

  List<string> code;

  public void Write(string filename) {
    File.WriteAllLines(filename, code);
  }

  public void Emit(InstructionWord inst) {
    inst.put(code);
  }

  public CodeGenerator() {
    this.code = new List<string>();
  }
}

}
