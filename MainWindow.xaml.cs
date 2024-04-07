using ConsoleTables;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MTDarshitSoneji
{
    public partial class MainWindow : Window
    {
        private List<Vehicle> vehicles = new List<Vehicle>(); 
        public MainWindow()
        {
            InitializeComponent();
            btnFind.IsEnabled = false;
            
            DataInput();
            datagrdVehicles.ItemsSource = new List<Vehicle>();
        }

        private void DataInput()
        {
            // Initialize the vehicles list with sample data
            vehicles = new List<Vehicle>
            {
                new Car("1", "Toyota", "Camry", 2012, "Blue", 4, 5, false),
                new Car("2", "Honda", "Civic", 2005, "Silver", 4, 5, false),
                new Car("3", "Ford", "Mustang", 2023, "Red", 2, 4, true),
                new Car("4", "Chevrolet", "Malibu", 1980, "Black", 4, 5, false),
                new Car("5", "BMW", "X5", 2022, "White", 4, 5, true),

                new ElectricCar("6", "Tesla", "Model S", 2019, "Black", 4, 5, false, 100),
                new ElectricCar("7", "Chevrolet", "Bolt", 2020, "White", 4, 5, false, 65),
                new ElectricCar("8", "BMW", "i4", 2021, "Red", 4, 5, true, 80),
                new ElectricCar("9", "Nissan", "Leaf", 2022, "Blue", 4, 5, true, 50),

                new Truck("10", "Ford", "F-150", 2015, "Black", 4, 2000),
                new Truck("11", "Dodge", "1500", 2021, "White", 4, 2300),
                new Truck("12", "Chevrolet", "Silverado", 2007, "Red", 2, 1800)
            };
        }

        private void rdoCar_Checked(object sender, RoutedEventArgs e)
        {
            
            if (vehicles == null)
                return;

            
            var carData = vehicles.OfType<Car>().ToList();
            datagrdVehicles.ItemsSource = carData;
            ReorderDataGridColumnsForCar();
        }

        private void rdoElectricCar_Checked(object sender, RoutedEventArgs e)
        {
            if (vehicles == null)
                return;

            var electricCarData = vehicles.OfType<ElectricCar>().ToList();
            datagrdVehicles.ItemsSource = electricCarData;
            ReorderDataGridColumnsForElectricCar();
        }

        private void rdoTruck_Checked(object sender, RoutedEventArgs e)
        {
            if (vehicles == null)
                return;

            var truckData = vehicles.OfType<Truck>().ToList();
            datagrdVehicles.ItemsSource = truckData;
            ReorderDataGridColumnsForTruck();
        }

        private void ReorderDataGridColumnsForCar()
        {
          
            datagrdVehicles.Columns[0].DisplayIndex = 5; // Id
            datagrdVehicles.Columns[1].DisplayIndex = 6; // Make
            datagrdVehicles.Columns[2].DisplayIndex = 7; // Model
            datagrdVehicles.Columns[3].DisplayIndex = 0; // Year
            datagrdVehicles.Columns[4].DisplayIndex = 1; // Color
            datagrdVehicles.Columns[5].DisplayIndex = 2; // Number of Doors
            datagrdVehicles.Columns[6].DisplayIndex = 3; // Number of Seats
            datagrdVehicles.Columns[7].DisplayIndex = 4; // Is Convertible

        }

        private void ReorderDataGridColumnsForElectricCar()
        {

            datagrdVehicles.Columns[0].DisplayIndex = 5; // Id
            datagrdVehicles.Columns[1].DisplayIndex = 6; // Make
            datagrdVehicles.Columns[2].DisplayIndex = 7; // Model
            datagrdVehicles.Columns[3].DisplayIndex = 8; // Year
            datagrdVehicles.Columns[4].DisplayIndex = 0; // Color
            datagrdVehicles.Columns[5].DisplayIndex = 1; // Battery Capacity 
            datagrdVehicles.Columns[6].DisplayIndex = 2; // Number of Doors
            datagrdVehicles.Columns[7].DisplayIndex = 3; // Number of Doors
            datagrdVehicles.Columns[8].DisplayIndex = 4; // Is Convertible
        }

        private void ReorderDataGridColumnsForTruck()
        {
 
            datagrdVehicles.Columns[0].DisplayIndex = 5; // Id
            datagrdVehicles.Columns[1].DisplayIndex = 6; // Make
            datagrdVehicles.Columns[2].DisplayIndex = 0; // Model
            datagrdVehicles.Columns[3].DisplayIndex = 1; // Year
            datagrdVehicles.Columns[4].DisplayIndex = 2; // Color
            datagrdVehicles.Columns[5].DisplayIndex = 3; // Number of Axles
            datagrdVehicles.Columns[6].DisplayIndex = 4; // Load Capacity
         

        }

        private void txtVehicleId_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnFind.IsEnabled = !string.IsNullOrEmpty(txtVehicleId.Text);
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            string idEntered = txtVehicleId.Text;

            Vehicle gotVehicle = vehicles.FirstOrDefault(v => v.Id == idEntered);

            if (gotVehicle != null)
            {
                lblMake.Content = gotVehicle.Make;
                lblModel.Content = gotVehicle.Model;
                lblYear.Content = gotVehicle.YearOfManufacture;
                lblColor.Content = gotVehicle.Color;

                if (gotVehicle is Car)
                {
                    Car gotCar = (Car)gotVehicle;

                    lblDoors1.Content = "Number of Doors:";
                    lblSeats1.Content = "Number of Seats:";
                    lblDoors.Content = gotCar.NumberOfDoors;
                    lblSeats.Content = gotCar.NumberOfSeats;
                    chkConvertible.Visibility = Visibility.Visible;
                    chkConvertible.IsChecked = gotCar.IsConvertible;

                    lblCost.Content = gotVehicle.AnnualInsuranceCost().ToString("C");
                    lblBatteryCap.Visibility = Visibility.Hidden;
                    lblBatteryCap1.Visibility = Visibility.Hidden;

                    lblDoors.Visibility = Visibility.Visible;
                    lblDoors1.Visibility = Visibility.Visible;
                    lblSeats.Visibility = Visibility.Visible;
                    lblSeats1.Visibility = Visibility.Visible;
                }
                else if (gotVehicle is ElectricCar)
                {
                    ElectricCar gotElectricCar = (ElectricCar)gotVehicle;

                    lblDoors1.Content = "Number of Doors:";
                    lblSeats1.Content = "Number of Seats:";
                    lblDoors.Content = gotElectricCar.NumberOfDoors;
                    lblSeats.Content = gotElectricCar.NumberOfSeats;
                    chkConvertible.IsChecked = gotElectricCar.IsConvertible;
                    lblBatteryCap.Content = gotElectricCar.BatteryCapacity + " kWh";
                    lblCost.Content = gotVehicle.AnnualInsuranceCost().ToString("C");

                    chkConvertible.Visibility = Visibility.Visible;
                    lblBatteryCap.Visibility = Visibility.Visible;
                    lblBatteryCap1.Visibility = Visibility.Visible;
                    

                    lblDoors.Visibility = Visibility.Visible;
                    lblDoors1.Visibility = Visibility.Visible;
                    lblSeats.Visibility = Visibility.Visible;
                    lblSeats1.Visibility = Visibility.Visible;
                }
                else if (gotVehicle is Truck)
                {
                    Truck gotTruck = (Truck)gotVehicle;

                    lblDoors1.Content = "Number of Axles:";
                    lblSeats1.Content = "Load Capacity:";
                    lblDoors.Content = gotTruck.NumberOfAxles;
                    lblSeats.Content = gotTruck.LoadCapacity + " lbs";

                    lblBatteryCap.Visibility = Visibility.Hidden;
                    chkConvertible.Visibility = Visibility.Hidden;

                    lblCost.Content = gotVehicle.AnnualInsuranceCost().ToString("C");

                    chkConvertible.Visibility = Visibility.Hidden;
                    lblBatteryCap.Visibility = Visibility.Hidden;
                    lblBatteryCap1.Visibility = Visibility.Hidden;

                    lblDoors.Visibility = Visibility.Visible;
                    lblDoors1.Visibility = Visibility.Visible;
                    lblSeats.Visibility = Visibility.Visible;
                    lblSeats1.Visibility = Visibility.Visible;
                }
                else
                {
                    lblDoors.Visibility = Visibility.Visible;
                    lblDoors1.Visibility = Visibility.Visible;
                    lblSeats.Visibility = Visibility.Visible;
                    lblSeats1.Visibility = Visibility.Visible;
                    chkConvertible.Visibility = Visibility.Visible;
                    lblBatteryCap.Visibility = Visibility.Visible;
                    lblBatteryCap1.Visibility = Visibility.Visible;    
                }

            }
            else
            {
                MessageBox.Show("Invalid ID. Vehicle not found!\nPlease try again.", "Not Found", MessageBoxButton.OK, MessageBoxImage.Warning);

                lblMake.Content = "";
                lblModel.Content = "";
                lblYear.Content = "";
                lblColor.Content = "";
                lblDoors.Content = "";
                lblSeats.Content = "";
                lblCost.Content = "";
                
                chkConvertible.IsChecked = false;
            }
        }

    }
}

        
