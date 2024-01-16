using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.classFolder
{
    internal class foodClass : resourceClass
    {

        private int foodAmmount = 100;

        public foodClass()
        {

        }

        public int getFoodAmmount()
        {
            return this.foodAmmount;
        }

        public override void updateResource(Label displayLabel)
        {
            if(this.foodAmmount >= 1)
            {
                this.foodAmmount -= 1;
            }
            else
            {

            }

        }

        public void resupplyFood(Label foodDisplay, System.Windows.Threading.Dispatcher dispatcher)
        {
            String path = string.Join(@"\", Environment.CurrentDirectory, @"\textFiles\foodRestock.txt");
            // read all lines
            String[] lines = File.ReadAllLines(path);
            foreach (String line in lines)
            {
                if (int.Parse(line) > foodAmmount)
                {
                    foodAmmount = int.Parse(line);
                    dispatcher.Invoke(() => { foodDisplay.Content = this.getFoodAmmount().ToString() + " Kg"; });
                    System.Threading.Thread.Sleep(500);
                }
            }

        }
    }
}
