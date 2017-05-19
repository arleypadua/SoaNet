# Soa-Net
A fluent API that you can use to build processes using the SOA concept and RESTful services.

## Features
* Step-by-Step execution
* Support to REST APIs
* Step for "if" conditions
* Asynchronous step
 
## Todo
* Create nuget package

## Getting Started
1) Clone this repository: 
    ```sh
    $ git clone https://github.com/arleypadua
    ```
2) Open the solution file "SoaNet.sln"

3) Add a new class on the SoaNet.Examples project

4) Add the usings:
    ```sh
    using SoaNet.Process;
    using SoaNet.Process.Extensions.Http;
    using SoaNet.Process.Extensions.Test;
    ```
    
5) Start calling your services:
    ```sh
    ProcessBuilder builder = new ProcessBuilder();
    builder
        .ForceUseTestOptions() 
        .AddStep("https://get-service.foo/?someParameter=someData")
        .AddStep("https://post-service.bar", HttpMethod.Post, new { someParameter = "someData" });
    ```
    
    **P.S**.: The extension method ForceUseTestOptions() outputs a log in the console for every process event: OnStart, OnSuccess, OnFail and OnFinish. You can find more information on how to use those events opening the example classes.

6) In case you want to add an conditional step, use the following extension method:
    ```sh
    builder
        .If(() => { return (1 + 1) == 2; }, // Boolean lambda expression
            builder.CreateHttpStep("https://true-part-service"),    
            builder.CreateHttpStep("https://false-part-service"));
    ```
    
7) To use a data that was returned in any past step:
    ```sh
    var step = builder.CreateHttpStep("https://get-service.foo");
    builder
        .AddStep(step)
        .AddStep("https://post-service.bar",
            HttpMethod.Post,
            () =>
            {
                // Return the object with the new request body
                // This will be serialized to a json object
                return new { requestParam = step.Result.Data.SomeResult };
            });
    ```
    
8) For those cases that you want to execute more than one step at once:    
    ```sh
    builder
        .AddAsyncSteps(
            builder.CreateHttpStep("https://get-service.foo"),
            builder.CreateHttpStep("https://get-service.bar"));
    ```

9) Finally, you must build the process, and then run it!
    ```sh
    var builtProcess = builder.Build();
    builtProcess.Run();
    ```

You may use it as your will. Just **help me improve it** and **give me some credits =)**
