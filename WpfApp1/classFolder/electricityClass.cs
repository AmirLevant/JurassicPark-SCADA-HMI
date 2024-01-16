using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace WpfApp1.classFolder
{
    internal class electricityClass : resourceClass
    {
        private int electricityLevel;
        private bool generatorStatus;

        public electricityClass()
        {
            this.electricityLevel = 42068;
            this.generatorStatus = true;
        }

        public int getElectricityLevel()
        {
            return this.electricityLevel;
        }

        public bool getGeneratorStatus()
        {
            return this.generatorStatus;
        }

        public void setElectricityLevel(int input)
        {
            this.electricityLevel = input;
        }
        public override void updateResource(System.Windows.Controls.Label electricityDisplay, System.Windows.Controls.Image lightning, System.Windows.Controls.Button toggleButton, System.Windows.Threading.Dispatcher dispatcher)
        {
            int ElectricityLevelRandom = 0;
            Random rnd = new Random();

            if (this.generatorStatus == true)
            {
                
                this.generatorStatus = false;
                dispatcher.Invoke(() => { lightning.Source = new BitmapImage(new Uri("/images/lightning_Off.jpg", UriKind.Relative)); });

                while (this.electricityLevel > 0)
                {
                    ElectricityLevelRandom = rnd.Next(10000, 30000);
                    int NewElectricityLevel = getElectricityLevel() - ElectricityLevelRandom;
                    if (NewElectricityLevel < 0)
                    {
                        NewElectricityLevel = 0;
                    }
                    setElectricityLevel(NewElectricityLevel);
                    dispatcher.Invoke(() => { electricityDisplay.Content = this.getElectricityLevel().ToString() + " kW h"; });
                    System.Threading.Thread.Sleep(1000);
                }

                dispatcher.Invoke(() => { toggleButton.Content = "Turn On Generator"; });
              
                

            }
            else
            {
                this.generatorStatus = true;
                dispatcher.Invoke(() => { toggleButton.Content = "Turn Off Generator"; });
                dispatcher.Invoke(() => { electricityDisplay.Content = this.getElectricityLevel().ToString() + " kWH"; });
                dispatcher.Invoke(() => { lightning.Source = new BitmapImage(new Uri("/images/lightning_On.jpg", UriKind.Relative)); });

                while (this.electricityLevel < 42069)
                {
                    ElectricityLevelRandom = rnd.Next(10000, 20000);
                    int NewElectricityLevel = getElectricityLevel() + ElectricityLevelRandom;
                    if (NewElectricityLevel > 42069)
                    {
                        NewElectricityLevel = 42069;
                    }
                    setElectricityLevel(NewElectricityLevel);
                    dispatcher.Invoke(() => { electricityDisplay.Content = this.getElectricityLevel().ToString() + " kW h"; });
                    System.Threading.Thread.Sleep(1000);
                }
                
            }

        }


    }
}
