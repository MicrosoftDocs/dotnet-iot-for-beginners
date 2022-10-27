*Please note this is a shooting script and not intended to be a word-for-word representation of the final videos.*

> Narrator view

Hi, friends! In our last video, you learned how to debug and deploy .NET apps to the Raspberry Pi. In this video, we're going to learn about the GPIO pins on the Raspberry Pi and how to use them to control LEDs and read sensors.

> Raspberry Pi view

This pin header on the Raspberry Pi is called the GPIO header. It's a 40-pin header that's used to connect to external devices. To make wiring easier, I like to use a breadboard and a GPIO breakout board. A breadboard is a rapid prototyping tool for circuits. 

> Breadboard view

The breadboard is organized in rows and columns called strips. The bus strips on the edges (indicated above in red) provide a continuous connection over the length of the breadboard. They're used to supply power for the circuit. The socket strips toward the middle of the breadboard allow components to be connected together without soldering or wires.

For example, any pin plugged into row 1, column a in the previous image would also be connected to any pin plugged into row 1, columns b-e. On the other side of the divider, row 1 columns f-j are similarly connected.

By connecting the GPIO breakout board to the breadboard, I can easily connect wires to the GPIO pins on the Raspberry Pi. As a bonus, the breakout board has labels next to each pin.

I'm going to construct a simple circuit to illuminate an LED. I'll start by connecting one of the ground pins to the ground rail on the side. Then I'll connect pin 21 to the anode of the LED. The anode is the longer leg of the LED. To prevent damage to the LED from overvoltage, I'll connect the cathode to a resistor, and then the resistor to ground.

> Visual Studio view

## todo: define System.Device.Gpio
I've already created a new .NET console app named blinky. I'll start by adding the System.Device.Gpio NuGet package. This package contains the APIs for GPIO access. This package contains the drivers for the Raspberry Pi. I'll add the following code to Program.cs.

```csharp