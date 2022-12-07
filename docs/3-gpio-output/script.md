*Please note this is a shooting script and not intended to be a word-for-word representation of the final videos.*

> Narrator view

Hi, friends! In our last video, you learned how to debug and deploy .NET apps to the Raspberry Pi. In this video, we're going to learn about the GPIO pins on the Raspberry Pi and how to use them to control LEDs and other devices.

> Raspberry Pi view

This pin header on the Raspberry Pi is called the GPIO header. It's a 40-pin header that's used to connect to external devices. To make wiring easier, I like to use a breadboard and a GPIO breakout board. A breadboard is a rapid prototyping tool for circuits. 

> Breadboard view

The breadboard is organized in rows and columns called strips. The bus strips on the edges (indicated above in red) provide a continuous connection over the length of the breadboard. They're used to supply power for the circuit. The socket strips toward the middle of the breadboard allow components to be connected together without soldering or wires.

For example, any pin plugged into row 1, column a in the previous image would also be connected to any pin plugged into row 1, columns b-e. On the other side of the divider, row 1 columns f-j are similarly connected.

By connecting the GPIO breakout board to the breadboard, I can easily connect wires to the GPIO pins on the Raspberry Pi. As a bonus, the breakout board has labels on each pin.

I'm going to construct a simple circuit to illuminate an LED. I'll start by connecting one of the ground pins to the ground rail on the side. Then I'll connect pin 21 to the anode of the LED. The anode is the longer leg of the LED. To prevent damage to the LED from overvoltage, I'll connect the cathode to a resistor, and then the resistor to ground.

> Visual Studio view

I've already created a new .NET console app named Blink. Before I write any code, I'll start by adding the System.Device.Gpio NuGet package. This package contains the APIs for GPIO access.

With the package added, I can start writing code. First, I'll create a new instance of the GpioController class. This class is used to interact with the GPIO pins on the Raspberry Pi. I'll use the default constructor, which will use the board numbering scheme. The board numbering scheme uses the physical pin numbers on the board.

Next, I'll open the pin I want to use. I'll use pin 21, which is the anode of the LED. I'll set the pin mode to Output, which means the pin will be used to output data. I'll also set the initial value to Low, which means the pin will start in the off state.

Now I'll write a loop that will turn the LED on and off. I'll use the Write method to set the pin value to High, which will turn the LED on. I'll then wait for one second. Then I'll set the pin value to Low, which will turn the LED off. I'll wait for one second, and then repeat the loop.

I'll deploy the code to the Raspberry Pi and run it.

> Breadboard view

The LED should blink on and off.

> Relay view

Now that you've seen how to control an LED, let's look at how to control a relay. A relay is an electromechanical switch that can be controlled by a small electrical signal. The relay I'm using has a normally open (NO) and normally closed (NC) contact. The NO contact is open when the relay is off, and the NC contact is closed when the relay is off. When the relay is turned on, the NO contact closes and the NC contact opens.

I'll start by providing power to the relay using the rails on the breadboard. The IN terminal is the input for the relay. I'll connect it to pin 21.

To show the relay in action. I'll connect the NO and COM terminals to my tester. I'll turn the tester to continuity mode. When the relay is activated, the tester will beep.

> Terminal view

I don't even have to make any changes to the code. I'll just run the app again.

> Relay view (with tester)

This looks good. The relay is turning on and off.

> Narrator view

That's it for this video. In the next video, we'll learn how to use the GPIO pins to read input.
