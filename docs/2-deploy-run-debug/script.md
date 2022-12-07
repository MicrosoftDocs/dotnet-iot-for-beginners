# Deploy-run-debug

*Please note this is a shooting script and not intended to be a word-for-word representation of the final videos.*

> Narrator view

Hi, friends! In our last video, we learned how to get Raspberry Pi OS installed on our Raspberry Pi and connect to it via SSH. In this video, we're going to learn how to deploy, run, and debug our code on the Raspberry Pi.

I'm going to use Visual Studio Code on my PC as my main development environment, so you can follow along on your operating system of choice. This video will also demonstrate how to deploy and debug if you prefer to use Visual Studio on Windows. No matter what your development environment is, I'll assume that you already have the .NET SDK installed.

Before we get started, I recommend you enable passwordless SSH access to your Raspberry Pi. This will make it easier to deploy and debug your code. The .NET IoT docs, located at this URL, link to a great tutorial on how to do this. I'll also include a link in the description.

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

> Narrator view

Now that we've seen how to run our application on our development machine, let's see how to deploy it to the Raspberry Pi.

> Visual Studio Code view

I'll use the `dotnet publish` command to publish the application. I'll use the `--runtime` option to specify the runtime identifier for my target environment, which is linux-arm. If you're using one of the 64-bit versions of Raspberry Pi OS, be sure to use linux-arm64. I'll use the `--self-contained` option to specify that the application should be published with the .NET runtime included. This means that I can run the app on the Raspberry Pi without having to install the .NET runtime, but it also means that the app will be larger.

> Visual Studio view

If you're using Visual Studio, you can use the `Publish` menu to publish the application. Be sure to select the target runtime and the `Self-contained` option.

> Visual Studio Code

Now that I've published the application, I'll use an SSH file transfer utility to copy the application to the Raspberry Pi. I'll use the `scp` command line tool, which is part of OpenSSH. If you prefer to use a graphical file transfer utility, you can use WinSCP or FileZilla.

 The syntax for the `scp` command is `scp <source> <destination>`. The source is the path to the application on my development machine, and the destination is the path to the application on the Raspberry Pi. The destination path is in the format `username@hostname:path`. I'll use the `pi` username and the IP address of my Raspberry Pi. I'll use the `~` character to specify the home directory of the user. Finally, the `-r` option tells `scp` to copy the directory recursively.

Now that I've copied the application to the Raspberry Pi, I'll use the `ssh` command to connect to the Raspberry Pi. You can see that the app is in the home directory of the `pi` user. In the app directory, the HelloWorld.dll file is the .NET assembly that contains the application. Since we deployed the app as a self-contained app, the .NET runtime is included in the app directory. There's also a shim file called HelloWorld that's used to launch the app. Before we can run the app, we need to make the shim file executable. I'll use the `chmod` command to make the file executable. Now I'll run the app like this. I'll type in my name, and the app will print a greeting.

> Narrator view

We've deployed the app to the Raspberry Pi and run it. Now let's see how to debug it.

> Visual Studio Code view

Before I can debug the app, I need to install the .NET Core debugger on the Raspberry Pi. That's easy to do at the command line. We'll run this command that downloads a run a script that handles everything for us. Don't try to copy this command from the video. You can get it from the debugging tutorial in the .NET IoT docs. I'll also include a link in the description.

Visual Studio Code needs a launch.json file to define how to launch the app and attach to it for debugging remotely. I'll create one and paste in this configuration I've created already. Note the `program` property that points to the shim, the `cwd` property that points to the app directory, and the `pipeTransport` property that defines how to connect to the Raspberry Pi. Again, don't try to copy this configuration from the video. You can get it from the debugging tutorial in the .NET IoT docs. I'll also include a link in the description.

Now that I've created the launch.json file, I'll switch to the Debug view. I'll click the green arrow to start debugging. Before I type in my name, I'll set a breakpoint on the `Console.WriteLine` line. I'll type in my name, and the app will stop at the breakpoint. 

> Visual Studio view

In Visual Studio, you can use the `Debug > Attach to Process` menu to attach to the app. You'll need to provide the IP address or hostname of the Raspberry Pi and the username and password for the user.

> Narrator view

That's all there is to deploying and debugging .NET apps on Raspberry Pi. In the next video, we'll learn how to use the .NET IoT libraries to control the GPIO pins on the Raspberry Pi.
