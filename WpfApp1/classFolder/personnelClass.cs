using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WpfApp1.classFolder
{

    internal class personnelClass : resourceClass
    {

        private int personnelCount;
        private int newPersonnelCount;
        private Random r = new Random();
        string filePath = string.Join(@"\", Environment.CurrentDirectory, @"\textFiles\personnelData.txt");
        public personnelClass()
        {
            this.personnelCount = 0;
            this.newPersonnelCount = 0;
        }

        public int getPersonnelCount()
        {
            return this.personnelCount;
        }

        public override void updateResource(bool doorStatus)
        {
            int difference = Math.Abs(newPersonnelCount - personnelCount);

            if (doorStatus == true)
            {

                if (personnelCount < newPersonnelCount) personnelCount = personnelCount + r.Next(difference + 1); 
                else if (personnelCount > newPersonnelCount) personnelCount = personnelCount - r.Next(difference + 1);
                else
                {
                    if (File.Exists(filePath))
                    {
                        string[] dataFromFile = File.ReadAllLines(filePath);
                        int randomLine = r.Next(0, dataFromFile.Length);
                        this.newPersonnelCount = Convert.ToInt32(dataFromFile[randomLine]);
                    }
                    else File.Create(filePath);
                }
            }
            return;
        }
    }
}