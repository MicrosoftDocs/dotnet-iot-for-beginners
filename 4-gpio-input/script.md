*Please note this is a shooting script and not intended to be a word-for-word representation of the final videos.*

**Narrator**

Hi friends, it's me again! In our last video, I showed you how to use GPIO pins for output. Along the way, I also showed you how breadboards and relays work. In this video, I'll show you how to use those same GPIO pins for input. Let's dive in!

**Console/VS Code**

This time I'm going to write my code first. I'll make a new project named Input and open it in my IDE. Once I'm in my new project, I'll add the `System.Device.Gpio` NuGet package. After that, I'll go to the .NET IoT docs and copy the code from the Binary Input using GPIO tutorial and paste it into Program.cs. Let's review the code.

After importing a few namespaces and defining a few constants, I create a new instance of `GpioController` with a "using" declaration so it cleans itself up when it falls out of scope.

Then I use the `GpioController` to open pin 21 for input. I use the pin mode parameter to open the pin with a pull-up resistor. When the pin is in this mode, it will read as high when it's not connected to anything, and low when it's connected to ground. In other words, "high" corresponds to maximum voltage while "low" corresponds to minimum voltage.

After that, I display the current status of the pin using a ternary expression. If the value of the pin is high, the contents of the ALERT constant will be displayed. Otherwise, the contents of the READY constant will be displayed.

After printing the initial status, I register an event handler callback for whenever the pin value changes, and then the main thread waits forever.

The event handler uses a similar ternary expression to print the new status of the pin, but instead of basing the output on the current value of the pin, it uses the event arguments to determine what to display.

Now I'll save and build. Looks good, so I'll deploy it as a self-contained app like in previous videos.

**Breadboard**

I don't really need a breadboard for this circuit, but I like to use one anyway because it makes it easier to see what's going on. I'll just connect pin 21 directly to ground and then run the app.

Since the pin is connected to ground, the pin is low and the initial status is "READY." When I disconnect the pin from ground, the pin is pulled high, and the status changes to "ALERT." When I reconnect the pin to ground, the pin goes low again, and the status changes back to "READY."

Why are there multiple messages when I reconnect the wire? This is a phenomenon called "bouncing." When I connect the wire, the mechanical connection is not initially stable, so multiple events are fired. This is a common problem with mechanical switches, and there are lots of strategies to mitigate it. 

**Code**

One strategy for mitigating bounce is simply ignoring events that occur too quickly after the previous event. To do this, I'll create a variable to store the last time an event was handled.

The event handler is defined as a static method, so it can't access the `lastEventTime` variable directly. I'll change the event handler to be a local function, which can access variables in the outer scope.

Then I'll update the event handler to check the time since the last event and simply ignore the event if it's too soon. Otherwise, I'll update the `lastEventTime` variable and print the new status.

The build is green, so the code is clean. I'll deploy it again.

**Breadboard**

Running the app with the debounce strategy, I see that the status only changes once when I connect and disconnect the wire.

**Narrator**

Now that we've seen how to detect input with GPIO pins, let's look at some practical applications of this technique.

**Desktop**

This is a magnetic reed switch. It's a switch that's activated by a magnet. These are commonly used to detect when a door or window is open or closed. I'll use some jumper wires with alligator clips to connect the reed switch to a breadboard using pin 21 as the input pin.

I can use my app with no changes to display the alert when the switch is open.

**Laser breadboard**

Here's another example of detecting input.

On one end of this piece of wood, I have a laser transmitter. It's powered by the 5V pin, and it's always on. On the other end of the wood, I have a laser receiver. It too is powered by the 5V pin. When the laser is pointed at the receiver, the middle pin, connected to the yellow wire, outputs 5V. Since my Pi can only receive 3.3V, I'm using a voltage divider to reduce the voltage before I send it to pin 21 on the green wire.

I'll include links in the description if you want to know more about how this circuit works.

**Code view**

I need to make a quick change to my app. Earlier I was trying to detect when a circuit was open and closed, so I was using the PullUp input mode. But in this case, I want to detect when the output voltage from the laser receiver pulls the pin high, so I'll use the PullDown mode instead. In this mode, the pin is pulled low when it's not connected to anything, and pulled high when it gets voltage.

**Laser breadboard**

Let's test it. As expected, when the laser is pointed at the receiver, the status is READY. When I break the laser beam, the status changes to ALERT.

**Narrator**

As we approach the end of this video, I recalled a challenge my WW1 history-loving son presented to me some time ago. He's always been curious if I could create a device to send and receive Morse code messages. Well, now seems like the perfect moment tackle that challenge using this laser setup. Let's take a look!

**Code View**

I wrote two apps, one for sending Morse code, and another for receiving it. You can find the code at this URL. The sending app uses GPIO output like in the previous video to tap out the Morse messages. The receiving app uses GPIO input to detect the messages on the laser receiver. There's a little bit of logic to detect the timing of the dots and dashes, but I won't go into that in this video. I'll just show you the final result.

**Laser breadboard**

I connected the laser transmitter to a relay. The relay is driven by pin 18 on my Pi that will send the Morse code. The laser receiver is connected to pin 21 on the receiver device that will display the Morse code.

I'll run the receiver app first, and then I'll send a string with the sender app. I'll borrow an old Monty Python joke for this demo.

I'd say that was a success!

**Narrator**

I hope you enjoyed that. I had a lot of fun making it.

That's all for this video! In the next video, I'll show you how to communicate with a sensor using the I2C protocol. See you then!
