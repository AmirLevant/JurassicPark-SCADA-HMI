using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp1.classFolder
{
    internal class supplyClass: resourceClass
    {
        private int supplyAmmount = 100;

        public supplyClass()
        {

        }

        public int getSupplyAmmount()
        {
            return this.supplyAmmount;
        }

        public override void updateResource(System.Windows.Controls.Label displayLabel)
        {
            if (this.supplyAmmount >= 1)
            {
                this.supplyAmmount -= 1;
            }
            else
            {

            }

        }

        public void resupplySupplies(System.Windows.Controls.Label Display, System.Windows.Threading.Dispatcher dispatcher)
        {
            String path = string.Join(@"\", Environment.CurrentDirectory, @"\textFiles\resupply.txt");
            // read all lines
            String[] lines = File.ReadAllLines(path);
            foreach (String line in lines)
            {
                if (int.Parse(line) > supplyAmmount)
                {
                    supplyAmmount = int.Parse(line);
                    dispatcher.Invoke(() => { Display.Content = this.getSupplyAmmount().ToString() + " Units"; });
                    System.Threading.Thread.Sleep(500);
                }
                
            }
                
        }
    }
}
