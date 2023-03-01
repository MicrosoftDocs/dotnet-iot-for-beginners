*Please note this is a shooting script and not intended to be a word-for-word representation of the final videos.*

[Narrator view]

Hi, friends! In our last video, I showed how to debug and deploy .NET apps on ARM devices like Raspberry Pi. In this video, I'm going to show you how to use the pins on the device to control external devices. I'll be using a Raspberry Pi, but the concepts are the same for other ARM devices.

[Raspberry Pi view]

This row of pins is called the General Purpose Input/Output (GPIO) header. As the name implies, these pins have a variety of uses. They can be used to control external devices, read sensor input, and more. There's a pinout diagram on the Raspberry Pi website that shows the function of each pin. If you're using a different device, the manufacturer probably publishes a similar diagram.

[Narrator view]

To start small, I'm going to show you what I consider to be the IoT equivilent of "Hello, World," blinking an LED. Before I start, though, let me introduce you to my friend, the breadboard. It's a tool for prototyping circuits, and I'll be using it a lot in these videos.

[Breadboard view]

The breadboard is organized in rows and columns called strips. These strips on the edges provide a continuous connection over the length of the breadboard. They're used to supply power for the circuit. They're usually color-coded for positive and ground.

The socket strips toward the middle of the breadboard allow components to be connected together without soldering or wires. For example, any pin plugged into row 1 anywhere between column a and e is connected to any other pin plugged into that same strip. On the other side of the divider, the strip located at row 1 columns f-j works the same way. This pattern applies to all the rows on the breadboard.


- Construct a simple circuit to illuminate an LED
- Use the `System.Device.Gpio` NuGet package to interact with GPIO pins on Raspberry Pi
- Create a new instance of `GpioController` class, set pin mode to output, and write a loop to turn LED on and off
- Control a relay using IN terminal and pin 21, and connect NO and COM terminals to tester to demonstrate relay activation
- No changes to code needed to run relay, and it turns on and off correctly
