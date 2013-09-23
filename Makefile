all:
	mkdir -p Generated
	mono bin/Coco.exe -frames Frames -o Generated -namespace Tastier Grammar/Tastier.ATG
	mcs Main.cs Generated/*.cs -out:Tastier.exe

clean:
	rm -f *.exe
	rm -rf Generated/*
