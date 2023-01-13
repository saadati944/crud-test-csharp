FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
EXPOSE 80

WORKDIR /src
COPY Mc2.CrudTest.Blazor/Mc2.CrudTest.Blazor.csproj .
RUN dotnet restore Mc2.CrudTest.Blazor.csproj
COPY Mc2.CrudTest.Blazor/ .
RUN dotnet build Mc2.CrudTest.Blazor.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish Mc2.CrudTest.Blazor.csproj -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY Mc2.CrudTest.Blazor/nginx.conf /etc/nginx/nginx.conf