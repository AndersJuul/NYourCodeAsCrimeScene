FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

RUN apt-get update && apt-get install -y --no-install-recommends apt-utils gss-ntlmssp

WORKDIR /app
COPY . /app/
ENTRYPOINT ["dotnet", "NYourCodeAsCrimeScene.Web.dll"]
