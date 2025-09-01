
# pet-store-tests
Automation tests for PET store API endpoints

## Setup & Usage

### 1. Clean and Build the Project
```sh
dotnet clean
dotnet build
```

### 2. Run the Tests
```sh
dotnet test
```

### 3. Generate LivingDoc Report
After running tests, generate the SpecFlow LivingDoc report:
```sh
livingdoc test-assembly bin/Debug/net8.0/PetStoreApiSpecFlowTests.dll -t bin/Debug/net8.0/TestExecution.json
```
This will create a `LivingDoc.html` file in your project directory with a visual report of your SpecFlow test results.
