*Please note this is a shooting script and not intended to be a word-for-word representation of the final videos.*

- Intro
- Connect MCP3008 to Pot

I start by creating a new SpiConnectionSettings object. The SpiConnectionSettings object has two parameters: The ID of the SPI bus, and the chip select line. Compared to I²C's bus system, SPI employs exclusive I/O pin access, with chip select pins determining the active device for communication. This parameter specifies which of my Pi's chip select pins to activate.

Then, just as in the I²C example in previous videos, I create a new SpiDevice object using the SpiConnectionSettings object I just created. The SpiDevice object is the object that actually communicates with the device.

After that, I create an MCP3008 object, passing in the SpiDevice object I just created. The MCP3008 object is a wrapper around the SpiDevice object that makes it easier to read from the ADC.

Then I enter the main loop of the program. First I clear the console, then I use the Read function to read the value of the CH0 pin on the MCP3008. The Read function returns a value between 0 and 1023, which I then write to the console.

Next I divide that value by 10.23 to express the value as a percentage. Then I write that percentage rounded to the nearest tenth to the console.

Finally, I wait for 500 milliseconds, and then repeat the loop.


- Demo MCP3008
- Connect Ads1115 to Pot

This code should look pretty familiar. I start by creating a new I2cConnectionSettings object. The I2cConnectionSettings object has two parameters: The ID of the I²C bus, and the address of the device. Since I connected the address pin to ground, the address of the device is this constant, which is 72 in decimal, and 0x48 in hex.

Then I create the I2cDevice object and use it to create an Ads1115 object, specifying input channel 0 and the measuring range of 6.144 volts.

Looking at the main loop, you might notice The ADS1115 operates differently from the MCP3008. The ReadRaw function returns values between 0 and 32,767. To ensure that every position on the potentiometer returns a unique value, it's best to use a measuring range greater than the supply voltage. For example, if the potentiometer is supplied with 5V, setting the measuring range to 6.144V will allow the ADS1115 to measure the full range of the potentiometer without any dead zones.

One advantage of the ads1115 is that I don't need to do any math to determine the voltage. The object has a RawToVoltage function that takes the raw value and converts it to a voltage.

Like in the previous example, both of these values are written to the console, and then the loop repeats after 500 ms.

- Demo

**Narrator**

As I mentioned earlier, the possibilities for analog-to-digital converters are endless. You can use them to measure temperature, humidity, pressure, and more. As an example, I thought I'd share one of my personal projects.

I live in Kansas City, Missouri, USA, and like most Kansas Citians, I love good BBQ. A few years ago, I bought my own wood pellet smoker so I could learn to smoke my own meat. Unfortunately, the smoker's controller, which controls controls the rate of pellets, was just a simple thermostat. When the temperature drops too low, the controller responds by turning an auger to feed more pellets to the fire. However, due to the lag time between when the fuel is added to the fire, and when the temperature rises, the temperature would often overshoot the target. If you know anything about BBQ, you should know that the mantra is "low and slow," so I was pretty disappointed that I was having a hard time keeping the temperature close to my target.

The solution to this problem is a PID controller. PID stands for Proportional-Integral-Derivative, and it's a control theory that uses a closed loop to continually adjust the rate of change as a process variable reaches its target. You already use the algorithm every day, without even realizing it. If you've used cruise control while driving a car, you've used a PID controller. The controller constantly monitors the speed of the car, and adjusts the throttle to keep the speed close to the target speed.

I decided to build my own PID controller for my smoker. I based my design off of a similar project, so I can't claim all the credit. However, my solution is, as far as I know, the only project to do it with .NET using the techniques I've shown you in this video series. I control the auger, blower, and igniter using GPIO output to drive relays. A 20x4 LCD display shows the front display, and an Analog-to-Digital Converter reads temperatures for the grill and meat probe. Additionally, I integrated the smoker with my home automation system, Home Assistant, using the MQTTnet library. I can control and monitor my smoker remotely, receive automated notifications when the food is done, and more. The code for my customized smoker, Inferno, is available on this GitHub repo. Instead of reviewing the entire codebase, I'll just show you how Inferno monitors temperatures using an analog-to-digital controller.

**RTD Breadboard**

This is a solderable breadboard. It works just like a regular breadboard, except you can solder components in place to create a permanent circuit. I use this breadboard to test changes to my code without having to push the code to the smoker. You can see the MCP3008 in the middle, and it's wired up mostly like the potentiometer I showed you earlier. The difference is, instead of a potentiometer, I've built a voltage drop circuit. This is very similar to the voltage divider I showed you with the laser receiver in a previous video, but instead of two resistors, I have a resistor and a screw terminal. The screw terminal is connected to the smoker's heat probe, which is a special type of thermistor called an RTD, or Resistance Temperature Detector. The MCP3008's CH0 pin reads the output of the voltage drop circuit.

**RTD Code**

I've included code to read the RTD in the repo for this video series. Let's review it.

I'll start with Program.cs. I start by reading the appsettings.json file for configuration parameters. I'll talk more about this configuration in a moment.

Then I create a new SpiConnectionSettings object and use that to create an SpiDevice object. I then use the SpiDevice object and the configuration object to create an object I call RtdProbe. The main loop of the program just displays the value of the RtdProbe's ProbeTemp property every second.

Now let's look at RtdProbe. RtdProbe is a wrapper around the MCP3008. In the constructor, I initialize the ADC, and then I initialize a ConcurrentQueue to store resistance readings from the RTD. Let's come back to that later.

Next I read an offset value from the configuration object. This is used to for fine-grained adjustments to the temperature reading. In the case of this RTD, I know it runs about 9 degrees fahrenheit too hot, so I set the offset to -9.

The final thing I do in the constructor is kick off a long-running task called ReadAdc. ReadAdc just loops forever. It reads the ADC, converts the raw value to a resistance, and then adds the resistance to the _probeResistances ConcurrentQueue. If there are more than 100 items in the queue, I dequeue the extra items and throw them away.

Why am I doing this? Well, the MCP3008, being a 10-bit ADC, can only read values between 0 and 1023. However, the RTD has a resistance range of 100 ohms to 1,000 ohms. That's a huge range, and it's not possible to get a precise reading with a 10-bit ADC. To get around this, I keep the last 100 readings, and then average them when the ProbeTemp property is accessed. This gives me a much more precise reading. In retrospect, I should have used a higher resolution ADC, like the ADS1115, or the MAX31865, which is specifically designed for RTDs, but this solution works well enough.

The rest of this is just some math to convert the average resistance to a temperature value. First I calculate the temperature in degrees celsius using the well-known formula for a 2-wire RTD, and then because I'm American, I convert that value to degrees fahrenheit.

Let's test it.

**RTD Demo**



**NARRATOR**

This concludes the .NET IoT for Beginners series, at least for now. I had a lot of fun making it, and I hope you found it useful. I tried to include a good sampling of topics, and you should be able to to extend these lessons to apply to any of the dozens of IoT devices supported by the .NET IoT libraries. If I missed something that you'd also like to see covered in this series, please let me know in the comments. I'm also the author of the .NET IoT docs, so if you have any topics you want added to the docs, please open an issue on the dotnet docs repo.

Thanks for watching. Happy IoT hacking, and I hope to see you again soon!
