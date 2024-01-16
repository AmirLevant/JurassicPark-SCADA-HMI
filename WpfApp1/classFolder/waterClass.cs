using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.classFolder
{
    internal class waterClass : resourceClass
    {
        private int waterLevel;
        private bool valveStatus;

        public waterClass()
        {
            waterLevel = 100; // means it is 100 %
            valveStatus = true; // means it is open
        }

        public int getWaterLevel()
        {
            return waterLevel;
        }
        public bool getValveStatus()
        {
            return valveStatus;
        }
        public void setWaterLevel(int input)
        {
            waterLevel = input;
        }

        public override void updateResource(System.Windows.Controls.Label waterDisplay, System.Windows.Controls.Button toggleButton, System.Windows.Threading.Dispatcher dispatcher)
        { // valve is already at a status, it should not be at that status anymore
            int WaterLevelRandom = 0;
            Random rnd = new Random();
            dispatcher.Invoke(() => { toggleButton.Content = "Open Valve"; });

            if (valveStatus == true)
            {

                valveStatus = false;
                while (waterLevel > 0)
                {
                    WaterLevelRandom = rnd.Next(0, 40);
                    int NewWaterLevel = getWaterLevel() - WaterLevelRandom;
                    if (NewWaterLevel < 0)
                    {
                        NewWaterLevel = 0;
                    }
                    setWaterLevel(NewWaterLevel); // decrements it
                    dispatcher.Invoke(() => { waterDisplay.Content = this.getWaterLevel().ToString() + " %"; });
                    System.Threading.Thread.Sleep(1000);

                    // ask team how to display it going down
                }
                dispatcher.Invoke(() => { waterDisplay.Content = this.getWaterLevel().ToString() + " %"; });


            }
            else
            {
                valveStatus = true;
                dispatcher.Invoke(() => { toggleButton.Content = "Close Valve"; });
                

                while (waterLevel < 100)
                {
                    WaterLevelRandom = rnd.Next(0, 40);
                    int NewWaterLevel = getWaterLevel() + WaterLevelRandom;
                    if (NewWaterLevel > 100)
                    {
                        NewWaterLevel = 100;
                    }
                    setWaterLevel(NewWaterLevel); // decrements it
                    dispatcher.Invoke(() => { waterDisplay.Content = this.getWaterLevel().ToString() + " %"; });
                    System.Threading.Thread.Sleep(1000);

                    // ask team how to display it going down
                }
            
                dispatcher.Invoke(() => { waterDisplay.Content = this.getWaterLevel().ToString() + " %"; });
            }

        }
    }
}
