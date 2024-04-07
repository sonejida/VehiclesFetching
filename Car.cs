using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace MTDarshitSoneji
{
    public class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }
        public int NumberOfSeats { get; set; }
        public bool IsConvertible { get; set; }

        public Car(string id, string make, string model, int yearOfManufacture, string color,
               int numberOfDoors, int numberOfSeats, bool isConvertible)
        : base(id, make, model, yearOfManufacture, color)
        {
            NumberOfDoors = numberOfDoors;
            NumberOfSeats = numberOfSeats;
            IsConvertible = isConvertible;
        }
        public override decimal AnnualInsuranceCost()
        {
            decimal insuranceCost = 0;

            if (YearOfManufacture >= 2010)
                insuranceCost += 100;
            else if (YearOfManufacture >= 2000)
                insuranceCost += 200;
            else if (YearOfManufacture >= 1990)
                insuranceCost += 300;
            else
                insuranceCost += 400;


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
                insuranceCost += 100;

            return insuranceCost * 12;
        }
    }
}
