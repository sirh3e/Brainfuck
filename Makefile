CONTAINER		:= docker
CONTAINER_TAG	:= brainfuck

DOTNET			:= dotnet
PROJECT			:= src/Sirh3e.Brainfuck.Cli/Sirh3e.Brainfuck.Cli.csproj

.PHONY: all
all: format run

.PHONY: run
run:
	$(DOTNET) $@ --project $(PROJECT)

.PHONY: format
format:
	$(DOTNET) $@

.PHONY: restore
restore: clean
	$(DOTNET) $@

.PHONY: clean
clean:
	$(DOTNET) $@

.PHONY: watch
watch:
	$(DOTNET) $@ --project $(PROJECT) format

.PHONY: container-all
container-all: container-build container-run

.PHONY: container-build
container-build:
	$(CONTAINER) build --tag $(CONTAINER_TAG) .

.PHONY: container-run
container-run: container-build
	$(CONTAINER) run $(CONTAINER_TAG)

.PHONY: container-clean
container-clean:
	$(CONTAINER) image rm -f $(CONTAINER_TAG)