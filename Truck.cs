using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDarshitSoneji
{
    public class Truck : Vehicle
    {
        public int NumberOfAxles { get; set; }
        public int LoadCapacity { get; set; }

        public Truck(string id, string make, string model, int yearOfManufacture, string color,
                 int numberOfAxles, int loadCapacity)
        : base(id, make, model, yearOfManufacture, color)
        {
            NumberOfAxles = numberOfAxles;
            LoadCapacity = loadCapacity;
        }
        public override decimal AnnualInsuranceCost()
        {
            decimal insuranceCost = 0;

            if (YearOfManufacture >= 2010)
                insuranceCost += 200;
            else if (YearOfManufacture >= 2000)
                insuranceCost += 400;
            else if (YearOfManufacture >= 1990)
                insuranceCost += 800;
            else
                insuranceCost += 1000;


            if (NumberOfAxles == 2)
                insuranceCost += 50;
            else if (NumberOfAxles == 4)
                insuranceCost += 100;
            else if (NumberOfAxles >= 5)
                insuranceCost += 150;


            if (LoadCapacity <= 1000)
                insuranceCost += 50;
            else if (LoadCapacity <= 2000)
                insuranceCost += 100;
            else if (LoadCapacity <= 3000)
                insuranceCost += 150;
            else
                insuranceCost += 200;

            return insuranceCost * 12;
        }
    }
}
