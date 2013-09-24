CSHARPCOMPILER = $(shell command -v mono-csc >/dev/null 2>&1)

ifeq ($(strip $(CSHARPCOMPILER)),)
CSHARPCOMPILER = mcs
endif

export http_proxy="http://www-proxy.scss.tcd.ie:8080"

all: Test/Coco.exe Doc/UserManual.pdf
	mkdir -p Generated
	mono Test/Coco.exe -frames Frames -o Generated -namespace Tastier Grammar/Tastier.ATG
	$(CSHARPCOMPILER) Main.cs Generated/*.cs -out:Test/tcc.exe

Test/Coco.exe:
	curl http://www.ssw.uni-linz.ac.at/coco/CS/Coco.exe >> Test/Coco.exe

Doc/UserManual.pdf:
	mkdir -p Doc
	curl http://ssw.jku.at/coco/Doc/UserManual.pdf >> Doc/UserManual.pdf

clean:
	rm -f *.exe *.asm *.bc
	rm -rf Generated/*
