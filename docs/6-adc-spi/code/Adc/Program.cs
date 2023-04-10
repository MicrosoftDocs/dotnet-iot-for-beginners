using System.Device.I2c;
using Iot.Device.Ads1115;
using UnitsNet;

I2cConnectionSettings settings = new(1, (int)I2cAddress.GND);
I2cDevice device = I2cDevice.Create(settings);

using var adc = new Iot.Device.Ads1115.Ads1115(device, InputMultiplexer.AIN0, MeasuringRange.FS6144);

while (true)
{
    Console.Clear();

    short raw = adc.ReadRaw();
    ElectricPotential voltage = adc.RawToVoltage(raw);

    Console.WriteLine($"ADS1115 Raw Data: {raw}");
    Console.WriteLine($"Voltage: {voltage}");
    Thread.Sleep(500);
}