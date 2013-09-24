CSHARPCOMPILER = $(shell command -v mono-csc >/dev/null 2>&1)

ifeq ($(strip $(CSHARPCOMPILER)),)
CSHARPCOMPILER = mcs
endif

export http_proxy="http://www-proxy.scss.tcd.ie:8080"

all: test/Coco.exe doc/UserManual.pdf
	mkdir -p generated
	mkdir -p bin
	mono bin/coco.exe -frames src/frames -o generated -namespace Tastier src/grammar/Tastier.ATG
	$(CSHARPCOMPILER) src/Main.cs generated/*.cs -out:bin/tcc.exe

test/Coco.exe:
	curl http://www.ssw.uni-linz.ac.at/coco/CS/Coco.exe >> bin/coco.exe

doc/UserManual.pdf:
	mkdir -p doc
	curl http://ssw.jku.at/coco/Doc/UserManual.pdf >> doc/UserManual.pdf

clean:
	rm -rf generated/*
