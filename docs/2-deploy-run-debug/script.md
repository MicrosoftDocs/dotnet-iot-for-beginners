# Deploy-run-debug

*Please note this is a shooting script and not intended to be a word-for-word representation of the final videos.*

> Narrator view

Hi, friends! In our last video, we learned how to get Raspberry Pi OS installed on our Raspberry Pi and connect to it via SSH. In this video, we're going to learn how to deploy, run, and debug our code on the Raspberry Pi.

I'm going to use Visual Studio Code as my main development environment, so you can follow along on your operating system of choice. This video will also demonstrate how to deploy and debug if you prefer to use Visual Studio on Windows. No matter what your development environment is, I'll assume that you already have the .NET SDK installed.

Let's get started!

> Terminal/VS Code view

I'm going to start on my development machine by creating a new .NET console application. I'm going to call it `HelloWorld`. I'll use the `dotnet new console` command to create a new console application. I'll use the `cd` command to change to the `HelloWorld` directory, and then I'll use the `code .` command to open the directory in Visual Studio Code.

> Visual Studio view

If you're using Visual Studio, you can use the `File > New > Project` menu to create a new console application.

> Visual Studio Code view

Once the project is open in the IDE, I'll write a simple program to ask the user's name and then print a greeting.

Now that I've done that, I'll save the file and switch to the terminal. I'll use the `dotnet run` command to run the application. I'll type in my name, and the application will print a greeting.

> Visual Studio view

If you're using Visual Studio, you can use the `Debug > Start Debugging` menu to run the application.

> Visual Studio Code view

Now that I've run the application, I'll switch back to Visual Studio Code. 

I'll use the `dotnet publish` command to publish the application. I'll use the `--runtime` option to specify the runtime identifier for my target environment, which is linux-arm. If you're using one of the 64-bit versions of Raspberry Pi OS, be sure to use linux-arm64. I'll use the `--self-contained` option to specify that the application should be published with all of its dependencies that . I'll use the `--no-restore` option to specify that the application should not restore packages. I'll use the `--no-build` option to specify that the application should not build the application. I'll use the `--force` option to specify that the application should overwrite any existing files.
