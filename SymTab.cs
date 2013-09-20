using System;
using System.Collections.Generic;

namespace Tastier {

public enum TType { // types
  Undefined,
  Integer,
  Boolean
};

public enum Kind {
  Variable,
  Procedure,
  Scope
};

public enum AddressKind {
  Direct,
  Label
};

public class Address {

  public int value_if_direct;
  public string value_if_label;
  public AddressKind kind;

  public Address labelAddress(string value) {
    Address adr = new Address();
    adr.kind = AddressKind.Label;
    adr.value_if_label = value;
    return adr;
  }

  public Address directAddress(int value) {
    Address adr = new Address();
    adr.kind = AddressKind.Direct;
    adr.value_if_direct = value;
    return adr;
  }

};

public class Obj {      // object describing a declared name

  public string name;         // name of the object
  public TType type;           // type of the object (undef for proc)
  public Kind kind;           // var, proc, scope
  public Address address;     // address in memory or start of proc
  public int level;           // nesting level

  public Obj(string name, TType type, Kind kind, Address address, int level ) {
    this.name = name;
    this.type = type;
    this.kind = kind;
    this.level = level;
  }

}

public class Scope {
  public List<Obj> localObjects;
  public int nestingLevel;
  public int nextFreeAddress;

  public Scope(){
    this.localObjects = new List<Obj>();
    this.nextFreeAddress = 0;
  }
}

public class SymbolTable {

  public Stack<Scope> openScopes; // all the scopes currently open

  Parser parser;

  public SymbolTable(Parser parser) {
    this.parser = parser;
    this.openScopes = new Stack<Scope>();
  }

  // open a new scope
  public void OpenScope () {
    Scope scop = new Scope();
    openScopes.Push(scop);
  }

  // close the current scope
  public void CloseScope () {
    openScopes.Pop();
  }

  // create a new object node in the current scope
  public Obj NewObj (string name, Kind kind, TType type) {
    currentScope = openScopes.Peek();

    //first check if the object has already been declared
    foreach (Obj o in currentScope.localObjects) {
      if (o.name == name) { parser.SemErr("name declared twice"); }
    }

    Obj obj = new Obj(name, type, kind, openScopes.Count);

    // if the object is a variable, then it gets an address in data memory
    if (kind == Kind.Variable) {
      obj.address = Address.directAddress(currentScope.nextFreeAddress);
      currentScope.nextFreeAddress += 1;
    }

    currentScope.locals.Add(obj);
    return obj;
  }

  public int currentLevel() { return openScopes.Count; }

  // search the name in all open scopes and return its object node
  public Obj Find (string name) {
    foreach (Scope s in openScopes) {
      foreach (Obj o in s.localObjects) {
        if (o.name == name) {
          return o;
        }
      }
    }
    parser.SemErr(name + " is undeclared");
    return null;
  }

} // end SymbolTable

} // end namespace
