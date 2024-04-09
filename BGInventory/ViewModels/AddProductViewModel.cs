using BGInventory.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BGInventory.ViewModels
{
    internal class AddProductViewModel : ObservableObject
    {
        private List<Supplier> _suppliers;
        private Supplier _supplier;
        private Storage _storage;
        private Product _product;
        public RelayCommand<object> ProductCreateCommand { get; private set; }
        public RelayCommand<object> SupplierRowSelectedCommand { get; private set; }
        public AddProductViewModel()
        {
            this.ProductCreateCommand = new RelayCommand<object>(ProductCreateAction);
            this.SupplierRowSelectedCommand = new RelayCommand<object>(SupplierRowSelectedAction);
            _suppliers = SupplierDAO.All();
            Supplier = new Supplier(1, "", "", "", "");
            Storage = new Storage(0, "", "", "");
            NewProduct = new Product(0,"","","","0","",Storage,Supplier);
        }
        private void ProductCreateAction(object SelectedItem)
        {
            Console.WriteLine("CategoryCreateAction");
            this.NewProduct.Supplier = this.Supplier;
            ProductDAO.Create(this.NewProduct);
        }
        private void SupplierRowSelectedAction(object SelectedItem)
        {
            this._supplier = (Supplier)SelectedItem;
            Console.WriteLine("SupplierRowSelectedAction");
        }
        public Product NewProduct
        {
            get
            {
                return this._product;
            }
            set { this.SetProperty(ref _product, value); }
        }
        public Supplier Supplier
        {
            get
            {
                return this._supplier;
            }
            set { this.SetProperty(ref _supplier, value); }
        }
        public Storage Storage
        {
            get
            {
                return this._storage;
            }
            set { this.SetProperty(ref _storage, value); }
        }
        public List<Supplier> Suppliers
        {
            get
            {
                return this._suppliers;
            }
            set { this.SetProperty(ref _suppliers, value); }
        }
    }
}
