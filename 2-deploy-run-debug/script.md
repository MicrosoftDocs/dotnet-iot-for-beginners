# Deploy-run-debug

*Please note this is a shooting script and not intended to be a word-for-word representation of the final videos.*

[Narrator view]

Hi, friends! In our last video, I showed you how to get Raspberry Pi OS installed on a Raspberry Pi and connect to it via SSH. In this video, I'm going to show you how to deploy, run, and debug code on ARM devices like my Raspberry Pi. Remember, even if you're not using a Raspberry Pi, you can still apply these concepts to similar devices.

[Console view]

Before we get started, I recommend you enable passwordless SSH access to your Raspberry Pi. This will make it easier to deploy and debug your code. The .NET IoT docs, located at this URL, link to a great tutorial on how to do this.

I'm in PowerShell on Windows, but this should also work in zsh or bash on macOS or Linux. I'll start by running this command to print the contents of the `.ssh` in my profile directory. I'm looking for a file named `id_rsa.pub`, which contains the public key for my SSH key pair. Since I don't have this file, I'll use the `ssh-keygen` command to generate a new key pair, accepting all the defaults. Listing the contents of the `.ssh` directory shows the file is present now.

Referring to the passwordless SSH documentation, here's the command to copy my public key to the pi. I'll copy and paste it into Notepad, and I'll change the target username and IP address to match my device. Now I'll copy the command and paste it into PowerShell and run it. When prompted, I'll type in the password for the `pi` user.

Now that I've copied my public key to the Raspberry Pi, I'll use the `ssh` command to connect. Since I'm authenticated using my key pair, I won't be prompted for a password.

[Narrator View]

Now we're ready to run some code! I'm going to use Visual Studio Code as my main development environment to make it easier to follow along if you're using macOS or Linux. I'll also demonstrate everything using Visual Studio on Windows. Either way, you'll also need the .NET 7 SDK.

Before we get started, let's talk about why I recommend doing development work on a PC instead of in the Raspberry Pi OS desktop environment.

[Raspberry Pi OS 64-bit montage]

As of this recording the C# extension for Visual Studio Code doesn't support the 32-bit version of Raspberry Pi OS, which is the default version. It runs fine on the 64-bit version, but given the performance contraints of the relatively low-powered Raspberry Pi, I recommend using a more powerful development machine for the best experience.

[Terminal/VS Code view]

Here's a shell on my development machine. I'm going to start by cloning the sample app repository from GitHub.  It's located at this URL. The project is in the `Animate` folder inside repo. I'll switch to the project directory and open it in Visual Studio Code.

Here's the code. It's not a long program. It's a fun animation demo that prints output to the console. Seems like it's working, so I'll press `Ctrl+C` to stop it.

[Visual Studio view]

If you're using Visual Studio, you can use the Clone Repository feature. Once the repo is cloned, you can run the app in the IDE using any of the usual methods. The app opens on my other monitor. It's successfully running, so I'll stop it.

[Narrator view]

Now that we've seen the app running, let's see how to deploy it to the device.

[Docs view]

The .NET IoT documentation describes two ways to publish your app, framework-dependent and self-contained. Framework-dependent deployment creates a version of your app that uses the .NET runtime that's installed on the target device. Self-contained deployment creates a version of your app that includes the .NET runtime, so it can run without any dependencies on the target device. Framework-dependent deployment is smaller, but self-contained deployment is more portable. For these videos, we'll use self-contained deployment so we don't have to worry about installing the .NET runtime on the device.

[Visual Studio Code view]

From the terminal in VS Code, I'll use the dotnet publish command shown here to create a self-contained version of my app, making sure to use the right --runtime option for the target environment. In my case, that's "linux-arm64", because I'm using the 64-bit OS. Take note of the output path that contains the published app. Looking inside that directory, we see the application files along with the .NET runtime.

[Visual Studio view]

If I'm using Visual Studio, I'll right click on the project in Solution Explorer, and select **Publish**. Then I'll specify that I want to publish to a folder and select finish to and generate the publish profile. Since we're going to be debugging later, I'll select the Debug configuration. I'll  also select the self-contained deployment mode along with the right target runtime for my operating system. After saving the publish profile, I'll click Publish. When the publish is done, take note of the output path.

[Terminal view]

Now that I've got published files, the next step is to copy them to the device. This process is the same regardless of IDE.

First I'll use the `ssh` command to create a folder on the destination device. Then I'll use the SCP command to copy the files. The syntax for the SCP command looks like this.

[FileZilla view]

If you prefer, you can use a drag-and-drop tool, like the open-source tool Filezilla.

[Terminal view]

Now that I've copied the application to the Raspberry Pi, I'll ssh to the device and switch to the app directory. Listing the contents of that directoy shows all of my files, including this file called Animate with no extension. This is the executable shim that launches the app. Before I can run it, I have to mark it executable with this command (`chmod +x ./Animate`). Now I can run the app on the Raspberry Pi.

[Narrator view]

I've deployed the app to the device and I've made sure it runs. Now let's see how to debug it.

[Visual Studio Code view]

Before I can debug the app, I need to install the .NET debugger on the device. I'll go to the documentation site and copy this command, then I'll run it on the pi. It downloads and runs a script to install the debugger.

Now I'll go back to the docs and copy the launch.json configuration for a self-contained app. In Code, I'll go to the run and debug tab in and generate the launch.json file.

Now that I've created the launch.json file, I'll paste in the configuration. I'll give the configuration a unique name, and then I'll set the path to the executable and the working directory. After saving the file, I can select the configuration from the dropdown and press F5 to start the app.

The animation displays oddly because the debug console displays text differently, but the app is running. I can set breakpoints, step through code, and inspect variables. When I'm done, I can stop debugging.

[Visual Studio view]

Using Visual Studio is even easier. I'll start by running the app on the device. In Visual Studio, I'll go to the Debug menu and select Attach to Process. I'll select SSH as my connection type, and then I'll fill out the form with my connection info. Visual Studio handles installing the debugger, so all I have to do is select the running process from the list. Now I can debug the app.

[Narrator view]

That's all for this video. In the next video, I'll show you how to use the .NET IoT libraries to control general-purpose input/output pins for things like LEDs and relays. See you then!