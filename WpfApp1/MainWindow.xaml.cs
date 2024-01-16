using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.classFolder;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        buildingClass building = new buildingClass();

        BackgroundWorker updateWorker = new BackgroundWorker();
        BackgroundWorker temperatureWorker = new BackgroundWorker();
        BackgroundWorker waterWorker = new BackgroundWorker();
        BackgroundWorker electricityWorker = new BackgroundWorker();
        BackgroundWorker foodWorker = new BackgroundWorker();
        BackgroundWorker supplyWorker = new BackgroundWorker();


        public MainWindow()
        {
            InitializeComponent();
            updateWorker.DoWork += updateWorker_DoWork;
            temperatureWorker.DoWork += temperatureWorker_DoWork;
            waterWorker.DoWork += waterWorker_DoWork;
            electricityWorker.DoWork += electricityWorker_DoWork;
            foodWorker.DoWork += foodWorker_DoWork;
            supplyWorker.DoWork += supplyWorker_DoWork;
            updateWorker.RunWorkerAsync();
            temperatureDispay.Content = building.getTemperature().getTemperature() + ".00°C" ;
            
        }


        private void updateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while(true)
            {
                building.getPersonnel().updateResource(building.getDoor().getDoorStatus());
                this.Dispatcher.Invoke(() => { personelDisplay.Content = building.getPersonnel().getPersonnelCount().ToString(); });
                building.getFood().updateResource(foodDisplay);
                this.Dispatcher.Invoke(() => { foodDisplay.Content = building.getFood().getFoodAmmount().ToString() + " Kg"; });
                building.getSupply().updateResource(supplyDisplay);
                this.Dispatcher.Invoke(() => { supplyDisplay.Content = building.getSupply().getSupplyAmmount().ToString() + " Units"; });


                System.Threading.Thread.Sleep(1000);
            }
        }

        private void foodWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            building.getFood().resupplyFood(foodDisplay, this.Dispatcher);
            
        }

        private void waterWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            building.getWater().updateResource(waterDisplay, waterToggelButton, this.Dispatcher);
        }
        private void electricityWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            building.getElectricity().updateResource(energyDisplay, lightning, energyToggelButton, this.Dispatcher);
        }
        private void supplyWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            building.getSupply().resupplySupplies(supplyDisplay, this.Dispatcher);
        }
        private void temperatureWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            bool direction = (bool)e.Argument;
            building.getTemperature().updateTemperature(temperatureDispay, direction , this.Dispatcher);
        }


        private void waterToggelButton_Click(object sender, RoutedEventArgs e)
        {
            if (!waterWorker.IsBusy)
            {
                waterWorker.RunWorkerAsync();
            }

        }

        private void doorDisplayButton_Click(object sender, RoutedEventArgs e)
        {
            building.getDoor().updateDoorStatus(doorDisplayButton, lock_Image);
        }

        private void temperatureUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (!temperatureWorker.IsBusy)
            {
                temperatureWorker.RunWorkerAsync(argument: true);
            }

        }

        private void temperatureDownButton_Click(object sender, RoutedEventArgs e)
        {
            if (!temperatureWorker.IsBusy)
            {
                temperatureWorker.RunWorkerAsync(argument: false);
            }
        }

        private void energyToggelButton_Click(object sender, RoutedEventArgs e)
        {
            if (!electricityWorker.IsBusy)
            {
                electricityWorker.RunWorkerAsync();
            }

        }

        private void foodResupplyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!foodWorker.IsBusy)
            {
                foodWorker.RunWorkerAsync();
            }
        }

        private void SupplyResupplyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!supplyWorker.IsBusy)
            {
                supplyWorker.RunWorkerAsync();
            }
        }
    }
}
