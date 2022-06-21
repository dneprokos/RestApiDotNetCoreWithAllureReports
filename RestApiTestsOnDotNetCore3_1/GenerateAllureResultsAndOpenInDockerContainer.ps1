$ReportLocation = (pwd).path + "\bin\Debug\netcoreapp3.1\allure-results";

WRITE-OUTPUT "Generating allure-report..."
allure generate "$ReportLocation" --clean

WRITE-OUTPUT "Rebuild docker compose image..."
docker-compose build --no-cache

WRITE-OUTPUT "Running docker compose..."
docker-compose up -d

WRITE-OUTPUT "Reports are available on htttp://localhost:9999/index.html"