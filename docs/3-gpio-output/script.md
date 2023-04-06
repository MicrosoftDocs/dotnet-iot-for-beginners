*Please note this is a shooting script and not intended to be a word-for-word representation of the final videos.*

[Narrator view]

I'm back, friends! In our last video, I showed you how to debug and deploy .NET apps on ARM devices like Raspberry Pi. In this video, I'm going to show you how to use the pins on the device to control external devices. I'll be using a Raspberry Pi, but the concepts are the same for other ARM devices.

[Raspberry Pi view]

This row of pins is called the General Purpose Input/Output (GPIO) header. As the name implies, these pins have a variety of uses. They can be used to control external devices, read sensor input, and more. There's a pinout diagram on the Raspberry Pi website that shows the function of each pin. If you're using a different device, the manufacturer probably publishes a similar diagram.

[Narrator view]

To start small, I'm going to show you what I consider to be the IoT equivilent of "Hello, World," blinking an LED. Before I start, though, let me introduce you to my friend, the breadboard. It's a tool for prototyping circuits, and I'll be using it a lot in these videos.

[Breadboard view]

The breadboard is organized in rows and columns called strips. These strips on the edges provide a continuous connection over the length of the breadboard. They're used to supply power for the circuit. They're usually color-coded for positive and ground.

The socket strips toward the middle of the breadboard allow components to be connected together without soldering or wires. For example, any pin plugged into row 1 anywhere between column a and e is connected to any other pin plugged into that same strip. On the other side of the divider, the strip located at row 1 columns f-j works the same way. This pattern applies to all the rows on the breadboard.

[Desk view]

I could connect components directly to my Raspberry Pi, but I like to use a breadboard because enables rapid prototyping. To make it even easier, I'll use a GPIO Breakout Board. When combined with a ribbon cable, it connects the Pi's GPIO pins to the breadboard, and it includes handy labels for each pin.

Now I'm ready to build my LED circuit. The components I'll need are jumper wires, a 5mm LED, and a resistor. The tutorial in the .NET IoT docs says to use a 330 ohm resistor, but I'll be using a 1K resistor to make the LED appear less overpowering on camera.

I'll start by connecting one of the ground pins to the negative rail on the edge of the breadboard. Then I'll connect pin 18 to an empty row. On that same row, I'll connect the longer of the LED's 2 legs. This is the positive input on the LED, called the cathode. I'll arrange the LED so that the shorter negative leg, called the anode, is inserted into the neighboring empty row. Finally, I'll connect that row with the anode to the ground rail using a resistor. This completes the circuit.

[Command prompt]

Now I can create a new .NET console app using the .NET 7 SDK. I'll name it Blink, then I'll set my location to the new directory and open it in VS Code.

[VS]

If you're using Visual Studio, you'll use the Create New Project dialog instead.

[VS Code]

Here's the empty console app. Looking at the project file, there are no NuGet packages installed yet. In order to interact with the GPIO header, we'll need the System.Device.Gpio package. I'll open a terminal and use the dotnet add package command to install it.

[VS]

If you're using Visual Studio, adding a package is done using the NuGet Package Manager. I'll search for the package online, then install it.

[VS Code]

Now I'll write my code. To speed things up, I'll get the code from the "Blink an LED" tutorial in the .NET IoT docs and paste it into my Program.cs  Let's review it.

This using declaration creates an instance of the GpioController class. This class is used to interact with the GPIO header. A using declaration ensures that the instance is disposed when the program exits.

Next I'm calling the contoller's OpenPin method to open a connection to pin 18 for output.

Then I set a boolean varible ledOn to true. This will be used to keep track of the LED's state.

Finally, I'm using a while loop to turn the LED on and off. The loop uses a ternary expression to set the LED's state based on the value of ledOn. The Pinvalue.High and .Low values written to the pin correspond to on and off. Then it waits for 1000 milliseconds, and finally it inverts the value of ledOn.

The loop runs indefinitely.

Now I'll save and build the app. The app builds, so I'll deploy to my device as a self-contained app. If you need a reminder of how to do this, check out the previous video. To save time, let's skip ahead a little.

The app is deployed! I've opened another terminal window, where I've connected to the device over SSH. I'll mark the file as executable, and then I'll run it.

It looks like my program is working! GPIO pin 18 is being toggled on and off, and the LED is blinking. After a few seconds, I'll stop the app with Ctrl+C.

[Narrator]

That's it! That's how to blink an LED with .NET. Remember earlier when I said that I think of this as the IoT equivilent of "Hello, World"? This is actually a little bit better than Hello World, because when combined with a relay like this, it has a real-world application.

[Desk view]

A relay is an electromechanical switch that can be controlled by a small current. When the relay is energized, the internal magnetic switch closes. This way, you can control a much larger current with a much smaller current. For example, I could use this relay to control a 120V light bulb or fan.

To use the relay, I'll first connect jumper wires to the screw terminals on the control end of the relay. I've cleared my breadboard, and now I'll connect DC POSITIVE jumper wire to one of the 5V pins on the device and I'll connect the DC NEGATIVE jumper wire to the ground rail. These connections are strictly to power the relay. Finally, I'll connect the INPUT jumper wire to pin 18, which is what will actuate the relay.

I'll test the relay now. It has an output LED we can observe. I'll run my app again, and the LED on the relay is blinking. This means the relay is working.

[Narrator]

That's all there is for this video! In the next video, I'll show you how to use the GPIO pins to read input. Thanks for watching, and I'll see you next time!
