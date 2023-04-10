# Introduction

Welcome! These are the notes for the "Introduction" video in the ".NET IoT for Beginners" series.

## Notes

- Hardware:
  - Any ARM-based Single Board Computer (SBC)
    - Recommend Raspberry Pi 3 or 4 (2 will work but is limited to 32-bit OS)
  - microSD card (at least 8 GB)

- Raspberry Pi OS:
  - Download Raspberry Pi Imager: [raspberrypi.com/imager](placeholder_URL)
  - Select 64-bit Lite Raspberry Pi OS

- Prepare Raspberry Pi:
  - Configure hostname
  - Enable SSH
  - Set user password
  - Configure Wi-Fi (optional)
  - Set timezone and locale

- Connect to Raspberry Pi:
  - SSH command: `ssh pi@hostname`

- Sense HAT demo:
  - Sense HAT documentation: [sense-hat_docs](placeholder_URL)
  - .NET IoT quickstart guide: [quickstart_guide](placeholder_URL)
  - Enable I²C interface: `sudo raspi-config`
  - Install Git: `sudo apt update` and `sudo apt install git`
  - Run demo command from guide

- Next video:
  - Deploy, run, and debug code on ARM devices

## Links

- Raspberry Pi documentation: [raspberrypi.org/documentation](placeholder_URL)