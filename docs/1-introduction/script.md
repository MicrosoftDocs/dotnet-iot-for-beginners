# Introduction

*Please note this is a shooting script and not intended to be a word-for-word representation of the final videos.*

> Narrator view

Hi! I'm Cam Soper, a content developer working with .NET at Microsoft. One of my favorite things about .NET is how it runs everywhere. Well, maybe not *everywhere*, but it does run on a wide variety of devices and operating systems.

In this series, I'm going to talk about using on common single-board computers, like Raspberry Pi and Hummingboard. Since these devices are small and inexpensive, they're often used in Internet of Things scenarios. Raspberry Pi is the most ubiquitous, so I'll use Raspberry Pi these videos.

In later videos. we'll look at how to deploy, run, and debug code in these environments. Then I'll show you how to use the .NET IoT Libraries to communicate with a variety of IoT devices, like sensors and displays.

In this video, I'm going to start by showing you what you need to get started with .NET IoT on Raspberry Pi.

> Raspberry Pi view

This is a Raspberry Pi 3 Model B. It's a single-board computer that's about the size of a credit card. It has a quad-core ARM processor, 1 GB of RAM, and a built-in wireless network adapter. It's a great platform for learning about IoT. For these videos, you can use Raspberry Pi 2, 3, or 4 models, although I would recommend using a Raspberry Pi 3 or 4, as they're a little more future-proof.

> SD card view

You'll also need a microSD card. You can use any size, but I recommend at least 8 GB. You'll need a microSD card reader to write the operating system to the card.

> raspberrypi.org view

You can download the operating system from the Raspberry Pi website. Raspberry Pi supports several Linux-based operating systems. I recommend using Raspberry Pi OS, which is a Debian-based Linux distribution. To install Raspberry Pi OS, first install and run the Raspberry Pi Imager from RaspberryPi.org.

> Raspberry Pi Imager view

You can select the default Raspberry Pi OS (32-bit) option, but we won't be using the desktop environment, so I recommend selecting the Raspberry Pi OS (32-bit) Lite option. This will install a minimal version of the operating system, which will save space on the microSD card.

Next select the microSD card you want to use.

Before you write the image to the card, you'll need to go into the advanced options. First, note that the default hostname is raspberrypi. I'm going to leave it as is, but you might want to change it to something more descriptive, especially if there are multiple Raspberry Pis on your network.

Next, enable SSH. This will allow you to remotely connect to the Raspberry Pi from your development machine. 

Then specify a password for the default user, pi. This is the user you'll use to log in to the Raspberry Pi. 

If the Raspberry Pi is going to use Wi-Fi, you can also specify the SSID, password, and country here. Otherwise, you'll need to connect the Raspberry Pi to your network using an Ethernet cable.

Optionally specify your timezone and locale. This will make it easier to work with dates and times.

Finally, click the save button and then click the Write button to write the image to the microSD card.

> Device view, showing Raspberry Pi OS booting

After the image is written, you can remove the microSD card from the card reader and insert it into the Raspberry Pi. Plug in a power supply and give the Raspberry Pi a few minutes to boot up. After the Raspberry Pi boots up, and it's connected to your network, you can connect to it using SSH. From a command shell on my development machine, I can run the following command to connect to the Raspberry Pi.

> Command shell view

The syntax is ssh username@hostname, where username is the default user, pi, and hostname is the hostname of the Raspberry Pi. If you didn't change the hostname, it's raspberrypi. If you did change the hostname, you'll need to use that instead.

> Narrator view

Now you're ready to start developing on Raspberry Pi. In the next video, I'll show you how to deploy, run, and debug code on Raspberry Pi.
