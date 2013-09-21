all:
	mkdir -p Generated
	cococs -frames Frames -o Generated -namespace Tastier Grammar/Tastier.ATG
	mono-csc Main.cs Generated/*.cs -out:Tastier.exe

clean:
	rm -f *.exe 
	rm -rf Generated/*
