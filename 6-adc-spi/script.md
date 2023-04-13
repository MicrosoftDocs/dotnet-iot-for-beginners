*Please note this is a shooting script and not intended to be a word-for-word representation of the final videos.*

**Narrator**

Welcome back to .NET IoT for Beginners. In this video, we're exploring Analog-to-Digital converters, also called ADCs, like this little guy, the MCP3008.  ADCs play a crucial role in translating continuous analog signals, such as sound or temperature, into discrete digital data that computers and other devices can store, transmit, and analyze. Let's dive in!

**Console**

The MCP3008 uses the SPI, or Serial Peripheral Interface, bus. SPI works a little differently from I²C, but we don't really need to know the details since the .NET IoT Libraries handle that for us. All I need to do is make sure I've enabled SPI on my Pi.

**Potentiometer**

To show how an analog to digital converter converts analog signals to digital values, I'll use a potentiometer. A potentiometer is a variable resistor. It has three terminals. The middle pin is called the wiper, and its output is variable. The two outer terminals are called the ends. The ends are connected positive and ground. As the knob is turned, the resistance inside the potentiometer changes and attenuates the voltage on the wiper pin.

**MCP3008 breadboard**

I'm going to build a circuit to display the resistance of the potentiometer as a percentage. I've got my MCP3008 on my breadboard already.

I'll start by connecting my Pi's 3.3V pin and ground pins to power rail on the breadboard.

Then I'll connect the Vdd pin to positive. This powers the MCP3008.

I'll also connect the Vref pin to positive. This is the reference voltage. At runtime, the MCP3008 will compare the voltage from this pin to the input pin and assign a value from 0 to 1023.

Next I'll connect the analog ground pin to ground.

Then it's time to hook up the SPI pins. They correspond to pins on my Pi. I'll start with the clock pin, then I'll connect the Dout pin to the Pi's MI (master input) pin, and the Din to the Pi's MO (output) pin. Finally I'll connect the Chip Select pin to the Pi's CE0 pin. I'll explain more about that when we get to the code.

I'll connect the digital gnd pin to ground, and then I'll wire up the potentiometer so it the ends are connected to the rail and the wiper pin is connected to the first input pin.

**Console**

I'll create a new .NET console app named ADC and open it in my IDE. Next I'll add the Iot.Device.Bindings nuget package. Then I'll go to the .NET IoT docs and get the code from the Read values from an analog-to-digital converter tutorial. Let's review the code.

I start by creating a new SpiConnectionSettings object. The SpiConnectionSettings object has two parameters: The ID of the SPI bus, and the chip select line. Compared to I²C's bus system, SPI employs exclusive I/O pin access, with chip select pins determining the active device for communication. This parameter specifies which of my Pi's chip select pins to activate.

Then, just as in the I²C example in previous videos, I create a new SpiDevice object using the SpiConnectionSettings object I just created. The SpiDevice object is the object that actually communicates with the device.

After that, I create an MCP3008 object, passing in the SpiDevice object I just created. The MCP3008 object is a wrapper around the SpiDevice object that makes it easier to read from the ADC.

Then I enter the main loop of the program. First I clear the console, then I use the Read function to read the value of the CH0 pin on the MCP3008. The Read function returns a value between 0 and 1023, which I then write to the console.

Next I divide that value by 10.23 to express the value as a percentage. Then I write that percentage rounded to the nearest tenth to the console.

Finally, I wait for 500 milliseconds, and then repeat the loop.

**MCP3008 Breadboard**

I've deployed my app, so now I'll run it.

I'm starting with my potentiometer turned completely counterclockwise. As I turn it clockwise, the values increase as the voltage to the ADC increases. When I turn it all the way clockwise, the values reach 100%. Likewise, turning counterclockwise reduces the values.

**Ads1115**

Now let's try this with a different ADC. This is an Ads1115. This ADC is 16-bit, so it has more resolution than the MCP3008. It also uses the I²C bus. If you need a refresher on I²C, check out the previous video.

**Ads1115 breadboard**

I've removed my MCP3008 from my breadboard, but I've left the potentiometer. I'll switch the positive voltage from a 3.3V pin to a 5V pin, and then I'll wire up the SDA and SCL pins. I'll also connect the address pin to ground. This sets the I²C address. Finally, I'll connect the A0 input to the variable output on the potentiometer.

**VS Code**

Now I'll paste in some code for my Ads1115. You can find this code in the GitHub repo for these videos.

This code should look pretty familiar. I start by creating a new I2cConnectionSettings object. The I2cConnectionSettings object has two parameters: The ID of the I²C bus, and the address of the device. Since I connected the address pin to ground, the address of the device is this constant, which is 72 in decimal, and 0x48 in hex.

Then I create the I2cDevice object and use it to create an Ads1115 object, specifying input channel 0 and the measuring range of 6.144 volts.

Looking at the main loop, you might notice The ADS1115 operates differently from the MCP3008. The ReadRaw function returns values between 0 and 32,767. To ensure that every position on the potentiometer returns a unique value, it's best to use a measuring range greater than the supply voltage. For example, if the potentiometer is supplied with 5V, setting the measuring range to 6.144V will allow the ADS1115 to measure the full range of the potentiometer without any dead zones.

One advantage of the ads1115 is that I don't need to do any math to determine the voltage. The object has a RawToVoltage function that takes the raw value and converts it to a voltage.

Like in the previous example, both of these values are written to the console, and then the loop repeats after 500 ms.

**Ads1115 Breadboard**

I've deployed the code, and I've already enabled my I²C bus, so it's ready to run. As I turn the potentiometer fully clockwise, notice that the raw value never reaches the maximum of 32,767. This is because the measuring range is set to 6.144V, and the potentiometer is only supplied with 5V.

**Narrator**

The possibilities for analog-to-digital converters are endless. You can use them to measure temperature, humidity, pressure, and more. As an example, I thought I'd share one of my personal projects.

I live in Kansas City, Missouri, USA, and like most Kansas Citians, I love good BBQ. A few years ago, I bought my own wood pellet smoker so I could learn to smoke my own meat. Unfortunately, the smoker's controller, which controls the rate at which pellets are fed to the fire, was just a simple thermostat. When the temperature drops too low, the controller responds by turning an auger to feed more pellets to the fire. However, due to the lag time between when the fuel is added to the fire and when the temperature rises, the temperature would often overshoot the target. If you know anything about BBQ, you should know that the mantra is "low and slow," so I was pretty disappointed that I was having a hard time keeping the temperature close to my target.

The solution to this problem is a PID controller. PID stands for Proportional-Integral-Derivative, and it's a control theory that uses a closed loop to continually adjust the rate of change as a process variable reaches its target. You already use the algorithm every day, without even realizing it. If you've used cruise control while driving a car, you've used a PID controller. The controller constantly monitors the speed of the car, and adjusts the throttle to keep the speed close to the target speed without overshooting it.

I decided to build my own PID controller for my smoker. I based my design off of a similar project, so I can't claim all the credit. However, my solution is, as far as I know, the only project to do it with .NET using the techniques I've shown you in this video series. I control the auger, blower, and igniter using GPIO output to drive relays. An Analog-to-Digital Converter reads temperatures for the grill and meat probes, and a 20x4 LCD display shows status information. Additionally, I integrated the smoker with my home automation system, Home Assistant, using the MQTTnet library. I can control and monitor my smoker remotely, receive automated notifications when the food is done, and more. The code for my customized smoker, Inferno, is available on this GitHub repo. Instead of reviewing the entire codebase, I'll just show you how Inferno monitors temperatures using an analog-to-digital converter.

**RTD Breadboard**

This is a solderable breadboard. It works just like a regular breadboard, except you can solder components in place to create a permanent circuit. I use this breadboard to test changes to my code without having to push the code to the smoker. You can see the MCP3008 in the middle, and it's wired up mostly like the potentiometer I showed you earlier. The difference is, instead of a potentiometer, I've built a voltage drop circuit. This is very similar to the voltage divider I showed you with the laser receiver in a previous video, but instead of two resistors, I have a resistor and a screw terminal. The screw terminal is connected to the smoker's heat probe, which is a special type of thermistor called an RTD, or Resistance Temperature Detector. The MCP3008's CH0 pin reads the output of the voltage drop circuit.

**RTD Code**

I've included code to read the RTD in the repo for this video series. Let's review it.

I'll start with Program.cs. I start by reading the appsettings.json file for configuration parameters. I'll talk more about this configuration in a moment.

Just as I showed you before, I create a new SpiConnectionSettings object and use that to create an SpiDevice object. I then use the SpiDevice object and the configuration object to create an object I call RtdProbe. The main loop of the program just displays the value of the RtdProbe's ProbeTemp property every second.

Now let's look at RtdProbe. RtdProbe is a wrapper around the MCP3008. In the constructor, I initialize the ADC, and then I initialize a ConcurrentQueue to store resistance readings from the RTD. Let's come back to that later.

Next I read an offset value from the configuration object. This is used to for fine-grained adjustments to the temperature reading. In the case of this RTD, I know it runs about 9 degrees fahrenheit too hot, so I set the offset to -9.

The final thing I do in the constructor is kick off a long-running task called ReadAdc. ReadAdc just loops forever. It reads the ADC, converts the raw value to resistance, and then adds the resistance to the _probeResistances ConcurrentQueue. If there are more than 100 items in the queue, I dequeue the extra items and throw them away.

Why am I doing this? Well, the MCP3008, being a 10-bit ADC, can only read values between 0 and 1023. However, the RTD has a resistance range of 100 ohms to 1,000 ohms. That's a huge range, and it's not possible to get a precise reading with a 10-bit ADC. To get around this, I keep the last 100 readings, and then average them when the ProbeTemp property is accessed. This gives me a much more precise reading. In retrospect, I could have used a higher resolution ADC, like the ADS1115, or the MAX31865, which is specifically designed for RTDs, but this solution works well enough.

The rest of this is just some math to convert the average resistance to a temperature value. First I calculate the temperature in degrees celsius using the well-known formula for a 2-wire RTD, and then because I'm American, I convert that value to degrees fahrenheit.

Let's test it.

**RTD Demo**

When I first run the program, it correctly detects the ambient temperature as 76°F. RTDs are great for high temperatures, so let's heat it up. That's probably good enough, now let's cool it back down to freezing. This will take a minute or two to cool to freezing, so I'll speed up the video a bit. There we go!

**NARRATOR**

That was fun!
This concludes the .NET IoT for Beginners series, at least for now. I had a lot of fun making it, and I hope you found it useful. I tried to include a good sampling of topics, and you should be able to to extend these lessons to apply to any of the dozens of IoT devices supported by the .NET IoT libraries. If I missed something that you'd also like to see covered in this series, please let me know in the comments. I'm also the author of the .NET IoT docs, so if you have any topics you want added to the docs, please open an issue on the dotnet docs repo.

Thanks for watching. Happy IoT hacking, and I hope to see you again soon!
