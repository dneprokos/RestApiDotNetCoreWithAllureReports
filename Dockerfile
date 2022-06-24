FROM mcr.microsoft.com/dotnet/sdk:3.1-alpine
WORKDIR /app
COPY . .
RUN dotnet restore
RUN apk add openjdk8
ENV PATH $PATH:/usr/lib/jvm/java-1.8-openjdk/bin
RUN apk add --update npm && npm install -g allure-commandline --save-dev && chmod +x runTestsWithAllureReport.sh
EXPOSE 9999 9999
CMD sh runTestsWithAllureReport.sh