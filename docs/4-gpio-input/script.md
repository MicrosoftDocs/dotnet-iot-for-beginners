*Please note this is a shooting script and not intended to be a word-for-word representation of the final videos.*

> Narrator view

Hi, friends! In our last video, you learned how to use GPIO pins for output by turning on and off an LED. In this video, we'll learn how to use GPIO pins for input by detecting the opening and closing of a circuit. Let's go to the breadboard.

> Breadboard view

We'll start by using a jumper wire to connect pin 21 to ground. I'm going to write code to detect when the wire is removed and the circuit is open.

> Code view

I've already created an empty .NET console project named GpioInput. I'll start by importing the System.Device.Gpio namespace. Like in the previous video, I'll create an instance of the GpioController class, but this time I'll open pin 21 for input with a pull-down resistor. In this mode, the pin will read as low when the circuit is open and high when the circuit is closed.

I'll use the Read method on the GpioController class print the initial message. I could use that method poll for changes every few milliseconds, but that would be inefficient. Instead, I'll register a callback that will be called whenever the pin changes value.

I'll pass the callback method as an argument to the RegisterCallbackForPinValueChangedEvent method. The callback method will be called with a PinValueChangedEventArgs object that contains the new value. I'll use that value to print a message to the console. If the ChangeType property of the PinValueChangedEventArgs object is Rising, that means the pin changed from low to high. If the ChangeType property is Falling, that means the pin changed from high to low. I'll use a ternary operator to print a different message depending on the value.

> Narrator view

That's all the code we need. I've built and deployed my app, so let's run it and see what happens.

> Breadboard view

The app sees that the circuit is closed. Let's see what happens when I remove the jumper wire. As expected, the app sees that the circuit is open. When I put the wire back, the app sees that the circuit is closed again.

> Narrator view

That's all there is to it. You can use this technique for all kinds of things, like detecting when a button is pressed or when a door is opened. Let's look at a few examples.

> Breadboard view with switch

Here I've connected a household light switch between pin 21 and ground.

> Breadboard view with reed switch

Here's a reed switch. It's a switch that's normally open, but it closes when a magnet is nearby. I've connected it between pin 21 and ground. You can use this to detect when a door or window is opened.

> Breadboard view with laser

This example a little more complicated to wire up. I've got a laser emitter and a receiver module. When the module detects a laser, it closes the circuit between pin 21 and ground, creating a laser tripwire. If you want to try building your own, I've included a link to some documetation in the description.

> Narrator view

That's all for this video. In the next video, we'll learn how to use device bindings to communicate with temperature and humidity sensors.
