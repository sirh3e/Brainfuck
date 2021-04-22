FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ./src/Sirh3e.Brainfuck.Cli/ ./Sirh3e.Brainfuck.Cli/
COPY ./src/Sirh3e.Brainfuck.Lib/ ./Sirh3e.Brainfuck.Lib/
WORKDIR "/src/Sirh3e.Brainfuck.Cli/"
RUN dotnet build "Sirh3e.Brainfuck.Cli.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sirh3e.Brainfuck.Cli.csproj" -c Release -o /app/publish

FROM base AS final
ENV BRAINFUCK_DIR=/src/brainfuck
WORKDIR /src/brainfuck
COPY ./src/brainfuck .
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Sirh3e.Brainfuck.Cli.dll", "HelloWorld.bf"]