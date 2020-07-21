# Useful links
# Creating docker image and deploying - https://www.youtube.com/watch?v=f0lMGPB10bM
# Dockerfile set up for project referencing another project - https://www.softwaredeveloper.blog/multi-project-dotnet-core-solution-in-docker-image

## CREATE BUILD IMAGE ##
# Get base SDK image
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
# Set container work directory
WORKDIR /app

# Copy project files build release. Note: publish also performs a dotnet restore
COPY . ./
RUN dotnet publish GameShelf.API -c Release -o GameShelf.API/out

## CREATE RUNTIME IMAGE ##
# Generate runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
# Copy files from /app/out in build image above
COPY --from=build-env /app/GameShelf.API/out .
ENTRYPOINT [ "dotnet", "GameShelf.API.dll" ]