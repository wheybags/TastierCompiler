all:
	mkdir -p Generated
	cococs -frames Frames -o Generated -namespace Tastier Grammar/Tastier.ATG
	mono-csc Code/*.cs Generated/*.cs

clean:
	rm -f *.exe 
	rm -rf Generated/*
