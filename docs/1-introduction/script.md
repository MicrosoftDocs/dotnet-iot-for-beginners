# Introduction

*Please note this is a shooting script and not intended to be a word-for-word representation of the final videos.*

> Narrator view

Hi! I'm Cam Soper, a content developer working with .NET at Microsoft. One of my favorite things about .NET is how it runs everywhere. Well, maybe not *everywhere*, but it does run on a wide variety of devices and operating systems.

In this series, I'm going to talk about using on common single-board computers, like Raspberry Pi and Hummingboard. Since these devices are small and inexpensive, they're often used in Internet of Things scenarios. Raspberry Pi is the most ubiquitous, so I'll use Raspberry Pi these videos.

First we'll look at how to deploy, run, and debug code in these environments. Then I'll show you how to use the .NET IoT Libraries to communicate with a variety of IoT devices, like sensors and displays.

To get things jumpstarted, let's step through the quickstart in the .NET IoT Libraries documentation. You can follow along at this location.

> Caption: https://learn.microsoft.com/dotnet/iot/quickstart

The quickstart uses the Raspberry Pi Sense HAT, which is a board that includes a variety of sensors, a joystick, and an LED matrix. It's a great way to get started with .NET IoT.

I have my Raspberry Pi with the Sense HAT already powered on and connected to my network. I'm using a Raspberry Pi 4, but the instructions are the same for other models. Earlier I already installed Raspberry Pi OS using the Raspberry Pi Imager. I don't usually need a GUI, so I selected the 32-bit Lite version. I also enabled SSH and WiFi.

I'm connected to the Raspberry Pi in a secure shell session using the default username and password. The quickstart script needs the Git command line tool, so I'll install that first. After that's installed, I can run the quickstart script.

The quickstart script downloads and installs the .NET SDK, and then it downloads and runs the quickstart sample. After a few minutes, the sample is running and I can see the Sense HAT display. The display shows the temperature, humidity, and pressure. It also shows the orientation of the Sense HAT. The LED matrix lights up with a blue background and a yellow dot. I can use the joystick to move the dot around the display. I can also click the joystick to change the color of the background.

All of the code for the quickstart sample is in the Program.cs file. The sample uses the SenseHat class from the .NET IoT Libraries to read the sensors and display the data.