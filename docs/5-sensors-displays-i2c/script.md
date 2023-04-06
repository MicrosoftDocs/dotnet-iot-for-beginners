**NARRATOR**

Welcome back, I'm happy to see you again. In the last video, I showed you how to read input on a GPIO pin. As an extended demonstration, I used GPIO pins to send and receive Morse code.

Communcation between IoT devices and sensors is kind of like Morse code. Messages are sent in a series of pulses across the wire. You can use GPIO pins like I did in the last video to send data like this, in a process is called bit banging. The problem is, it's not very efficient. Luckily, most Single Board Computers (like Raspberry Pi) have a dedicated Inter-Integrated Circuit (I²C) bus. This is a serial bus that can be used to communicate with a variety of devices. It's a lot faster than bit banging, and it's a lot easier to use.

In this video, I'm going to show you how to interact with some I²C devices. I've selected a few devices that are easy to use, but you should be able to use this information to use the .NET IoT Libraries to interact with any supported I²C device.

**Terminal**

Before I can use my Raspberry Pi's I²C bus, I need to enable it. I'll open a terminal window and run `sudo raspi-config`. I'll use the Interface Options menu to ensure that the I²C interface is enabled. Now I can connect devices to the I²C bus. Let's look at one now.

**BME280 breakouts**

This little silver box is a BME280 temperature, humidity, and pressure sensor. It's a pretty common sensor, and it's available on breakout boards from many different manufacturers. The one on the left is from Adafruit, and the one on the right is from a generic vendor I found on Amazon. They're both the same sensor, but the Adafruit one is a little more full-featured, as it has both I²C and SPI interfaces.

**BME280 on breadboard**

For this video, I'm going to use the generic sensor.

First I'll connect the SDA pin to the SDA pin on my device. This is the wire that carries the data.

Then I'll connect the SCL pins. This is the wire that synchronizes the clock for all the devices on the bus.

Finally I'll connect the ground pin to ground, and then the sensor's voltage pin to the 3.3V pin on my device. This is the power supply for the sensor.

**Desktop**

To get data from the sensor, I'll create a new console app named Sensor and open it in my IDE. I'll add the `Iot.Device.Bindings` NuGet package to my project. This is an open source library that uses our old friend `System.Device.Gpio` to communicate with a variety of devices. Using this library is a lot easier than writing the code to communicate with the sensor directly.

Then I'll copy the code from the Read Environmental Conditions from a Sensor tutorial in the .NET IoT docs.

Let's review the code.

After the `using` statements, I create a new I2cConnectionSettings object. The constructor takes two parameters. The first is the ID of the I²C bus on my device. The second parameter is the address of the sensor on the bus. The DefaultI2cAddress constant is 119 in decimal, or 77 in hex. The documentation for the sensor I'm using specifies an address of 76 in hex, so I'll change that. The SecondaryI2cAddress constant is 118 in decimal, which is 76 in hex.

Then I create a new I2cDevice object. This represents the I²C device, but isn't specific about what kind of device it is. It just knows that it communicates using I²C. I'll pass in the I2cConnectionSettings object I created earlier.

Finally, I create a new Bme280 object, passing in the I2cDevice object. This is the object that represents the sensor. It knows how to communicate with the physical sensor using the I2cDevice object, so I don't have to know anything about the I²C protocol or the sensor's registers.

In the main loop of the program, I first clear the text console. Then I specify that I want the Forced power mode. In this mode, the sensor wakes up, takes its readings, and goes back to sleep. After waiting for the amount of time specified by the MeasurementDuration property, I read the sensor's readings. One handy feature of the Bme280 class is that it returns data using types from Units.NET, an open-source library that makes it easy to work with physical units.

After reading the values, I print them to the console.

Now I'll deploy and run the program.

Looks like we're successfully reading some data!

**NARRATOR**

Now that we've got the sensor reading data, let's add another device to the I²C bus to display the data.

**20x4 LCD Character display**

This is a 20x4 LCD display. It can display 4 lines of text, each up to 20 characters. It has a 16-pin header on it, and it's a little tricky to connect directly to your device. Luckily, displays like this are often sold with a GPIO expander connected to the header. The expander has a dedicated I²C interface that handles doing all the hard work for you.

**LCD and breadboard**

Connecting additional devices to the I²C bus is as simple as connecting more wires to the SDA and SCL pins on the GPIO header. Then I'll connect the ground and power pins. Since this display uses 5V, I'll connect it to the 5V pin on my device.

**Desktop**

To make things easier, I'll go back to the .NET IoT docs to borrow some code from the Display Text on an LCD tutorial. I'll grab these lines of code that initialize the display, and paste them into my program.cs right after the BME280 gets initialized.

Since the variable names are a little ambiguous, I'll rename the variables to make it clear what they are. Then I'll use my IDE's quick actions to add the missing `using` statements so everything resolves correctly.

Let's take a minute to review this code.

Just as with the Bme280, I create a new I²C device with the bus ID and address of the GPIO expander. I don't have any documentation for this display, so how did I know what address to use? Well, I looked at the chip on IO expander, and in black-on-black text only visible from a certain angle, it says "PCF8574T". Most sources I could find said the address for this chip is 0x20, but that threw an exception at runtime. Then I read the datasheet for the chip, and it says that the default address is configurable between 0x20 and 0x27. You could easily figure out which address you need by trial and error, but the datasheet explains how to set the address using the chip's A0, A1, and A2 pins. A visual inspection shows that those pins are all exposed on contact pads on the back of the IO expander, and since none of the pads are bridged, the address is 0x27.

After creating the I²C device, I use it to create a Pcf8574 object . This represents the GPIO expander.

Finally, I create a new Lcd2004 object. This is the object that represents the 20x4 LCD display. It has a bunch of constructor parameters that map various functions to the GPIO pins on the GPIO expander. I got these values from samples in the library's GitHub repo, and they appear to work on every display I've tried that uses the same expander chip. The parameters all seem pretty self-explanatory, but I wanted to talk about the controller parameter. Notice that it expects an instance of the GpioController class we've seen in previous videos, so we're giving it a new GpioController with the Pcf8574 object as a parameter. This is a little confusing, but it makes sense if you think about it. The Pcf8574 class inherits from GpioDriver, so essentially we're creating an instance of GpioController that represents the GPIO pins on the GPIO expander.

Now I'll add some code to the main loop to display the sensor's readings on the LCD.

First, where I clear the console, I'll also clear the display. Then to make things easier, I'll just duplicate these lines that print values to the console and modify them to print to the display instead.

Next, before printing each line of text, I'll set the cursor position to the beginning of the line. This is necessary because the display doesn't automatically wrap text to the next line.

To make each line fit in 20 characters, I'll abbreviate the labels.

Finally, just because I want to show how useful the Units.NET library is, I'll change the LCD output to use US customary units. 

**Test bench**

Success! The sensor is reading data, and it's being displayed on the LCD. I'll use my heat gun to warm up the sensor. Now I'll use compressed air to cool it down. The sensor is working as expected.

**NARRATOR**

Remember, even if you don't have the exact devices I showed in this video, the concepts are the same. You can use the Iot.Device.Bindings library to connect to any supported I²C device.

That's all for now. In the next video, I'll show you how to use an Analog-to-Digital Converter to read analog data.
