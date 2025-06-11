
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /EvalCedric

COPY . ./

RUN dotnet restore
# Build and publish a release
RUN dotnet publish -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /EvalCedric

COPY --from=build /EvalCedric/out .

EXPOSE 8080
EXPOSE 8081

ENTRYPOINT ["dotnet", "EvalCedric.dll"]