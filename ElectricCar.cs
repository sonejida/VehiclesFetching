using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDarshitSoneji
{
    public class ElectricCar : Car
    {
        public double BatteryCapacity { get; set; }

        public ElectricCar(string id, string make, string model, int yearOfManufacture, string color,
               int numberOfDoors, int numberOfSeats, bool isConvertible, double batteryCapacity)
        : base(id, make, model, yearOfManufacture, color, numberOfDoors, numberOfSeats, isConvertible)
        {
            BatteryCapacity = batteryCapacity;
        }

        public override decimal AnnualInsuranceCost()
        {
            decimal insuranceCost = 0;


            if (YearOfManufacture >= 2010)
                insuranceCost += 150;
            else
                insuranceCost += 350;


            if (NumberOfDoors == 2)
                insuranceCost += 50;
            else if (NumberOfDoors == 4)
                insuranceCost += 100;
            else if (NumberOfDoors >= 5)
                insuranceCost += 150;


            if (NumberOfSeats == 2)
                insuranceCost += 50;
            else if (NumberOfSeats == 4)
                insuranceCost += 100;
            else if (NumberOfSeats >= 5)
                insuranceCost += 150;


            if (IsConvertible)
                insuranceCost += 50;


            if (BatteryCapacity <= 50)
                insuranceCost += 50;
            else if (BatteryCapacity <= 75)
                insuranceCost += 100;
            else if (BatteryCapacity <= 100)
                insuranceCost += 150;
            else
                insuranceCost += 200;

            return insuranceCost * 12;
        }
    }
}
