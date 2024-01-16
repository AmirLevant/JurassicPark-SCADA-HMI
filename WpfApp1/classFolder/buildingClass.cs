using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace WpfApp1.classFolder
{
    internal class buildingClass
    {
        private temperatureClass temperature  = new temperatureClass();
        private doorClass door = new doorClass();
        private foodClass food = new foodClass();
        private waterClass water = new waterClass();
        private supplyClass supply = new supplyClass();
        private electricityClass electricity = new electricityClass();
        private personnelClass personnel = new personnelClass();

        public temperatureClass getTemperature()
        {
            return temperature;
        }

        public doorClass getDoor()
        {
            return door;
        }

        public foodClass getFood()
        {
            return food;
        }

        public waterClass getWater()
        {
            return water;
        }

        public supplyClass getSupply()
        {
            return supply;
        }

        public electricityClass getElectricity()
        {
            return electricity;
        }

        public personnelClass getPersonnel()
        {
            return personnel;
        }

    }
}
