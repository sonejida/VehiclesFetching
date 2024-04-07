using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDarshitSoneji
{
    public abstract class Vehicle
    {
        public string Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int YearOfManufacture { get; set; }
        public string Color { get; set; }

        public Vehicle(string id, string make, string model, int yearOfManufacture, string color)
        {
            Id = id;
            Make = make;
            Model = model;
            YearOfManufacture = yearOfManufacture;
            Color = color;
        }

        public abstract decimal AnnualInsuranceCost();
    }
}
