using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.classFolder
{
    internal class temperatureClass
    {
        private float temperature = 26;

        public temperatureClass()
        {

        }

        public float getTemperature()
        {
            return temperature;
        }


        public void updateTemperature(System.Windows.Controls.Label temperatureDisplay, bool changeDirection, System.Windows.Threading.Dispatcher dispatcher)
        {

            string change;
            if (changeDirection == true)
            {
                if (this.temperature < 60)
                {
                    string path = string.Join(@"\", Environment.CurrentDirectory, @"textFiles\temperatureUp.txt");
                    string[] lines = System.IO.File.ReadAllLines(path);
                    for (int i = 0; i <= 12; i++)
                    {
                        change = lines[i];
                        dispatcher.Invoke(() => { temperatureDisplay.Content = (int)this.temperature + change + "°C"; });
                        System.Threading.Thread.Sleep(75);
                    }
                    this.temperature += 1;
                    dispatcher.Invoke(() => { temperatureDisplay.Content = this.temperature + ".00°C"; });
                }
            }
            else
            {
                if (this.temperature > 0)
                {
                    string path = string.Join(@"\", Environment.CurrentDirectory, @"textFiles\temperatureDown.txt");
                    string[] lines = System.IO.File.ReadAllLines(path);
                    this.temperature -= 1;
                    for (int i = 0; i <= 12; i++)
                    {
                        change = lines[i];
                        dispatcher.Invoke(() => { temperatureDisplay.Content = (int)this.temperature + change + "°C"; });
                        System.Threading.Thread.Sleep(75);
                    }

                    dispatcher.Invoke(() => { temperatureDisplay.Content = this.temperature + ".00°C"; });
                }
            }

        }
    }
}
