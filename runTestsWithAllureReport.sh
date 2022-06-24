#!/bin/sh
echo "Start running API tests..."
dotnet test RestApiTestsOnDotNetCore3_1 -s "./RestApiTestsOnDotNetCore3_1/env.runsettings"
echo "Navigate to 'RestApiTestsOnDotNetCore3_1' test project directory..."
cd RestApiTestsOnDotNetCore3_1
echo "Generating allure-results..."
allure generate "/app/RestApiTestsOnDotNetCore3_1/bin/Debug/netcoreapp3.1/allure-results" --clean
echo "Opening allure server..."
allure open "allure-report" --port 9999