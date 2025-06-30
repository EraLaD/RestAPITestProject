API Testing Project 

This project uses C#, xUnit to perform testing on a public API , which can be found at the following link https://restful-api.dev/. 
It validates functionalities such as getting list of objects/getting  objects by id/ creating ,updating and deletion of objects.

Prerequisites
. .NET SDK 8 or later
.  Visual Studio 2022 or any IDE that supports .NET
.  Git to clone the repo
.  Command line interface such as command prmopt, powershell

Project Setup
1. Clone the repository
    git clone https://github.com/your-username/your-repo-name.git
    cd your-repo-name
   
2. Restore dependencies - to download the required tools for this project.
   dotnet restore
4. Open the solution in the preferred IDE.

How to execute the tests
1. After opening the solution in visual studio go to  Test > Run All Tests.
   *The result will be displayed in the Test Explorer window.

Folder structure
1.Tests/ - Contains the test cases (GET, POST, PUT, DELETE)
2.TestData/ - Reusable test data. 
3.Support/APIEndpoints -  API end points required for the tests
4.Support/Utils - Build the URL using the base url and provide the HttpClient
5.ApiModels/ - Model the API request object and API response objects.

NOTES
.Since this is a public API it maybe unstable or usage limited.
