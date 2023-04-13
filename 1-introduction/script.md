# Introduction

*Please note this is a shooting script and not intended to be a word-for-word representation of the final videos.*

> Narrator view

Hi friends! I'm Cam Soper, a content developer working with .NET at Microsoft. My favorite thing about .NET is how it can run on a wide variety of devices, from tiny microcontrollers to powerful servers.

In this series, I'm going to talk about using .NET on common single-board computers, like Raspberry Pi, Orange Pi, and Hummingboard. Since these devices are small and inexpensive, they're often used in Internet of Things (or IoT) scenarios. I'll be using Raspberry Pi for these videos, but these concepts generally all apply to other single-board computers.

In later videos, I'll show you how to deploy, run, and debug code on these devices. Then I'll show you how to use the .NET IoT Libraries to control LEDs, relays, sensors and displays.

But in this video, I'm going to start by showing how I prepare a Raspberry Pi for use with .NET. Then I'll show you where to find the documentation and how to run quick demo of .NET on your Raspberry Pi.

> Raspberry Pi view

The board on the left is a Raspberry Pi 4 Model B. It's a single-board computer that's about the size of a credit card. It has a quad-core 64-bit ARM processor and a variety of ports, including USB, Ethernet, HDMI, and composite A/V. It comes with up to 8 gigabytes of integrated RAM. This other board is a Raspberry Pi 3 Model B. It's a little older, but it's still a great device for .NET.

For these videos, you can use Raspberry Pi 2, 3, or 4, though I would recommend using a Raspberry Pi 3 or 4.

You'll also need a microSD card. You can use any size, but I recommend at least 8 GB. You'll need a microSD card reader to write the operating system to the card.

> raspberrypi.org view

Raspberry Pi supports several Linux-based operating systems. For these videos, we'll use Raspberry Pi OS. To install Raspberry Pi OS, first install and run the Raspberry Pi Imager from RaspberryPi.com.

> Raspberry Pi Imager view

Here's the Imager app. To image the SD card, I'll first select an OS. Instead of the default 32-bit OS, I recommend selecting a 64-bit variant from the Raspberry Pi OS (Other) menu.  Since we won't be using the desktop environment, I'll be selecting the Lite version to save space on the microSD card.

Next select the microSD card you want to use.

Now I need to configure this Raspberry Pi to accept remote connections, so I'll go into the advanced options. First, note that the default hostname is raspberrypi. I'm going to leave it as is, but you might want to change it to something more descriptive, especially if there are multiple Raspberry Pis on your network.

Next, I'll enable SSH. This will allow remote connections to the Raspberry Pi from my development PC.

Then I'll specify a password for the default user, pi. This is the user I'll use to log in to the device.

Since I plan to use Wi-Fi, I'll specify the SSID, password, and country here. You can also connect your Raspberry Pi using an Ethernet cable.

I'll specify your timezone and locale to make it easier to work with dates and times.

Now that it's configured, I'll save my changes and write the SD card.

[Device view, showing Raspberry Pi OS booting]

After the image is written, you can remove the microSD card from the card reader and insert it into the Raspberry Pi. Plug in a power supply and give the Raspberry Pi a few minutes to boot up. After the Raspberry Pi boots up, and it's connected to your network, you can connect to it using SSH.

> Command shell view

After the device is done booting, I'll open a shell on my development machine and use the SSH command to connect to my Raspberry Pi. The syntax is `ssh username@hostname`, where `username` is the default user, *pi*, and `hostname` is the hostname we specified when we imaged the SD card.

On the first connection, you'll be prompted to verify that you want to connect to this host. After that, provide the password you specified earlier.  If you see a prompt like this, you're connected to the Raspberry Pi.

If you are unable to connect, make sure the Raspberry Pi is connected to your network and that you're using the correct hostname. You can also try connecting by the device's IP address, which you can retrieve from your router. If you're still having trouble, try connecting to the Raspberry Pi using a monitor and keyboard. From there, you can use the `ifconfig` command to get the IP address.

> Narrator view

Now my device is set up, and I'm ready to run some code. We'll do that in the next video. But for now, if you have a Raspberry Pi Sense HAT, I'll show you how to use it to run a quick demo of .NET on Raspberry Pi.

> Sense Hat web page view

 The Sense HAT is a board that plugs into the Raspberry Pi's GPIO header. It has a variety of sensors, including a gyroscope, accelerometer, and magnetometer. It also has a joystick and an LED matrix.

> Docs view

I'm going to follow the instructions in the .NET IoT quickstart guide. The quickstart guide is found in the .NET IoT docs, located at this URL. The quickstart guide walks you through running a script that installs the .NET SDK, downloads the sample code, and runs the sample app.

> Code view

Here's the code for the sample app. It's a pretty short program. I won't go over it in detail because we'll be diving into similar code in later videos, but feel free to review it on your own. For now, I'm just going to run the app to verify that the Sense HAT is working.

> Raspberry Pi view

Here's my Sense HAT. I've installed some LED darkening film to control the brightness of the LED matrix on camera. My Raspberry Pi is powered off, and I'm ready to install the Sense HAT. Once it's plugged in, you can power on the Raspberry Pi.

> Command shell view

I need to make a configration change so the Raspberry Pi can talk to the Sense HAT. Once the Raspberry Pi boots up and I'm connected, I'll run the Raspberry Pi configuration app with `sudo raspi-config`. Then I'll go into the `Interfacing Options` menu and enable the I²C interface.

After that, I need to install the Git command line client to so the script can download the code. I'll run `sudo apt update` to update the package list. Then I'll run `sudo apt install git` to install Git.

When the git client is installed, I'll paste in the command from the guide. This command downloads and installs the .NET SDK, clones the sample code, and then builds and runs the app.

> Raspberry Pi view

As you can see, the Sense HAT is functioning properly. The sensors are supplying data to the app, and the LED matrix is displaying a dot on a blue background. I can move the dot with the joystick, and if I click it, the background turns red.

> Narrator View

That's it for this video! In the next video, I'll show you how to deploy, run, and debug code on ARM devices like Raspberry Pi. I'll see you then!
