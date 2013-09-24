CSHARPCOMPILER = $(shell command -v mono-csc >/dev/null 2>&1)

ifeq ($(strip $(CSHARPCOMPILER)),)
CSHARPCOMPILER = mcs
endif

all: Test/Coco.exe
	mkdir -p Generated
	mono Test/Coco.exe -frames Frames -o Generated -namespace Tastier Grammar/Tastier.ATG
	$(CSHARPCOMPILER) Main.cs Generated/*.cs -out:Test/tcc.exe

Test/Coco.exe:
	curl http://www.ssw.uni-linz.ac.at/coco/CS/Coco.exe >> Test/Coco.exe

clean:
	rm -f *.exe *.asm *.bc
	rm -rf Generated/*
