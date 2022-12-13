*Please note this is a shooting script and not intended to be a word-for-word representation of the final videos.*

Write a video script that instructs the viewer on how to use .NET and Raspberry Pi to read a BME280 temperature/humidity sensor. Assume the video is part of a series and a previous video already showed the viewer how to deploy .NET apps to Raspberry Pi. Include notes on what the camera should show during the narration. Assume the viewer already knows how to install the .NET runtime. Include notes interspersed in the script on what the camera should show. I prefer to use a breadboard instead of connecting the BME280 directly.

You previously started a script that I liked, but we were disconnected before you finished it. Please finish it. Here's what you had:

Hello and welcome to this tutorial on how to use .NET and Raspberry Pi to read a BME280 temperature/humidity sensor. In this video, we'll be building on the knowledge you gained in the previous video on how to deploy .NET apps to Raspberry Pi, so if you haven't watched that one yet, be sure to check it out first.

[Opening shot: the .NET logo and the Raspberry Pi logo on a white background]

First, let's start by setting up our BME280 sensor. If you're using a breadboard like I am, you'll want to carefully insert the BME280 into the breadboard with the pins facing down. Make sure that the pins are aligned with the holes on the breadboard and gently press down to make sure it's securely in place.

[Camera zooms in on the breadboard, showing the BME280 inserted into it]

Next, we need to connect the BME280 to the Raspberry Pi. You'll need to use jumper wires for this. Start by connecting the VCC pin on the BME280 to the 3.3V power pin on the Raspberry Pi. Then, connect the GND pin on the BME280 to a GND pin on the Raspberry Pi. Finally, connect the SDA and SCL pins on the BME280 to the SDA and SCL pins on the Raspberry Pi.

[Camera zooms out to show the whole setup, with the jumper wires connecting the BME280 to the Raspberry Pi]

Now that we have our BME280 sensor connected to the Raspberry Pi, let's start by installing the necessary libraries. We'll be using the .NET I2C library to communicate with the BME280 sensor, so you'll need to install that first. You can do this by running the following command on your Raspberry Pi:

[Camera shows the command being typed into the Raspberry Pi terminal]

sudo dotnet add package I2C

Once the library is installed, we can start writing our .NET app to read data from the BME280 sensor. We'll start by creating a new .NET console app using the following command:

[Camera shows the command being typed into the Raspberry Pi terminal]

dotnet new console

Now, open the project in your preferred code editor and let's start by adding the necessary using statements at the top of the file:

[Camera shows the code editor with the using statements being added]

using I2C;
using System.Threading;

Next, let's create a new I2C bus instance, which we'll use to communicate with the BME280 sensor. Add the following code to your Main method:

[Camera shows the code editor with the code being added to the Main method]

I2CBus bus = new I2CBus();

Now, let's create a new instance of the BME280 sensor, using the I2C address of the sensor. You can find this address by running the following command on your Raspberry Pi:

sudo i2cdetect -y 1

The I2C address of the BME280 sensor will be displayed in the output. Add the following code to create a new instance of the BME280 sensor, using the I2C address you found:

[Camera shows the code editor with the code being added]

BME280 sensor = new BME280(bus, 0x76);

Next, we'll create a loop that will continuously read data from the BME280 sensor and print it to the console. Add the following code to your Main method:

[Camera shows the code editor with the code being added]

while (true)
{
var data = sensor.ReadTemperatureAndHumidity();
Console.WriteLine($"Temperature: {data.Temperature} Humidity: {data.Humidity}");
Thread.Sleep(1000);
}

Now, let's run our app and see if we can read data from the BME280 sensor. Go back to the terminal and run the following command to build and run your app:

[Camera shows the terminal with the command being run]

dotnet run

If everything was set up correctly, you should see the temperature and humidity readings from the BME280 sensor being printed to the console.

[Camera shows the terminal with the temperature and humidity readings being printed]

That's it! You've successfully set up and used .NET and Raspberry Pi to read a BME280 temperature/humidity sensor. In future videos, we'll explore more advanced uses for .NET and Raspberry Pi, so be sure to subscribe and stay tuned for more. Thanks for watching!