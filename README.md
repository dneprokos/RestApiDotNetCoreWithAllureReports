# RestApiDotNetCoreWithAllureReports
Rest API tests on .Core 3.1 with Allure reports in Docker file

### Preconditions/Build

1. Pull solution
2. Build Solution inside of visual studio or with help of command line
3. Install docker on you PC/Laptop (this step is required if you want to generate Allure reports in docker)

### Run tests from Visual Studio
1. In Visual Studio: select configuration file you wanna run Test--> Configure Run Settings-->  
![image](https://user-images.githubusercontent.com/8307892/174791331-a5c534fe-5f4d-4867-b508-426ee80834fd.png)

2. Just click tests you wanna run in Test Explorer

![image](https://user-images.githubusercontent.com/8307892/174791650-aa168aa2-b801-4403-bf21-3b655ca305d0.png)

3. Wait until tests run is finished

### Run tests from Command Line
1. Open RestApiTestsOnDotNetCore3_1 test project root folder
2. Open CMD for this folder
3. Type "dotnet test -s "./env.runsettings"", where -s is a location of .runsettings test configuration file

![image](https://user-images.githubusercontent.com/8307892/174792378-d2ad6d1e-5430-4413-9587-870286b3743f.png)

5. Wait until tests run is finished 

![image](https://user-images.githubusercontent.com/8307892/174792229-f868f9a9-83af-4f9b-bde3-bdce3fed9bf8.png)


### Generate Allure Reports
1.Find and run Powershell script "GenerateAllureResultsAndOpenInDockerContainer.ps1" in root directory of the project
2.Wait until script is processed
3.Open browser on page: http://localhost:9999/index.html (You may need to clear browser cache in case if you're generating it few times) 

![image](https://user-images.githubusercontent.com/8307892/174792510-a745fb4d-5134-4ca1-9cce-29abccb4c897.png)

**Note**: Script was created to avoid manual command run steps. 
In general it generates allure-report folder
Than it creates and run docker container with Alure server copying allure-result and running it


