using BGInventory.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BGInventory.ViewModels
{
    internal class TransitViewModel : ObservableObject
    {
        private List<Product> _products;
        private List<Storage> _storages;
        private Storage _storage;
        private Transit _newTransit;
        private Visibility _storageStatus=Visibility.Collapsed;
        private Visibility _numberStatus = Visibility.Collapsed;
        private Visibility _dateStatus = Visibility.Collapsed;
        private Visibility _buttonStatus = Visibility.Collapsed;
        public RelayCommand<object> DateSelectedCommand { get; private set; }
        public RelayCommand<object> ProductRowSelectedCommand { get; private set; }
        public RelayCommand<object> StorageRowSelectedCommand { get; private set; }
        public RelayCommand<object> NumberChangedCommand { get; private set; }
        public RelayCommand<object> TransitCreateCommand { get; private set; }
        public TransitViewModel() 
        {
            this._products = ProductDAO.All();
            this._storages = StorageDAO.All();
            this._storage = UserDAO.Show().Storage;
            this.ProductRowSelectedCommand = new RelayCommand<object>(ProductRowSelectedAction);
            this.StorageRowSelectedCommand = new RelayCommand<object>(StorageRowSelectedAction);
            this.NumberChangedCommand = new RelayCommand<object>(NumberChangedAction);
            this.DateSelectedCommand = new RelayCommand<object>(DateSelectedAction);
            this.TransitCreateCommand = new RelayCommand<object>(TransitCreateAction);
            NewTransit = new Transit(Storage,new Storage(0,"","",""), new Product(0, "", "", "", "0", "", Storage, new Supplier(0, "", "", "", "")),0,"");
        }
        private void ProductRowSelectedAction(object SelectedItem)
        {
            if (SelectedItem != null)
            {
                Console.WriteLine("ProductRowSelectedAction");
                Console.WriteLine(((Product)SelectedItem).Name);
                Console.WriteLine(((Product)SelectedItem).Id);
                this.NewTransit.Product = (Product)SelectedItem;
                this.StorageStatus = Visibility.Visible;
                this.DateStatus = Visibility.Hidden;
                this.ButtonStatus = Visibility.Hidden;
                this.NumberStatus = Visibility.Hidden;
            }
            else
            {
                Products = ProductDAO.All();
            }

        }
        private void StorageRowSelectedAction(object SelectedItem)
        {
            if (SelectedItem != null)
            {
                Console.WriteLine("StorageRowSelectedAction");
                Console.WriteLine(((Storage)SelectedItem).StreetAddress);
                Console.WriteLine(((Storage)SelectedItem).City);
                this.NewTransit.StorageTo = (Storage)SelectedItem;
                this.NumberStatus = Visibility.Visible;
                this.ButtonStatus = Visibility.Hidden;
            }
            else
            {
                Storages = StorageDAO.All();
            }

        }
        private void NumberChangedAction(object Value)
        {
            Console.WriteLine("DateSelectedAction");
            Console.WriteLine(Value.ToString());
            this.DateStatus = Visibility.Visible;
        }
        private void DateSelectedAction(object Text)
        {
            Console.WriteLine("DateSelectedAction");
            Console.WriteLine(Text.ToString());
            this.NewTransit.DateTime = Text.ToString();
            this.ButtonStatus = Visibility.Visible;
        }
        private void TransitCreateAction(object SelectedItem)
        {
            TransitDAO.Create(this.NewTransit);
        }
        public List<Storage> Storages
        {
            get
            {
                return this._storages;
            }
            set { this.SetProperty(ref _storages, value); }
        }
        public List<Product> Products
        {
            get
            {
                return this._products;
            }
            set { this.SetProperty(ref _products, value); }
        }
        public Storage Storage
        {
            get
            {
                return this._storage;
            }
            set { this.SetProperty(ref _storage, value); }
        }
        public Transit NewTransit
        {
            get
            {
                return this._newTransit;
            }
            set { this.SetProperty(ref _newTransit, value); }
        }

        public Visibility StorageStatus { get => _storageStatus; set => SetProperty(ref _storageStatus, value); }
        public Visibility NumberStatus { get => _numberStatus; set => SetProperty(ref _numberStatus, value); }
        public Visibility DateStatus { get => _dateStatus; set => SetProperty(ref _dateStatus, value); }
        public Visibility ButtonStatus { get => _buttonStatus; set => SetProperty(ref _buttonStatus, value); }

    }
}
