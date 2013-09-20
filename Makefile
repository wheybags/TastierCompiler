all:
	cococs Tastier.ATG -namespace Tastier
	mono-csc Tastier.cs Scanner.cs Parser.cs SymTab.cs CodeGen.cs

clean:
	rm -f *.exe *.old
	rm -f Parser.cs Scanner.cs
