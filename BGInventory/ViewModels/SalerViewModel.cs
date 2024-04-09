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
    internal class SalerViewModel : ObservableObject
    {
        private List<Product> _products;
        private Product _product;
        private Visibility details_visibility = Visibility.Collapsed;
        private Visibility edit_visibility = Visibility.Collapsed;
        public RelayCommand<object> ProductRowSelectedCommand { get; private set; }
        public RelayCommand<object> ProductEditCommand { get; private set; }
        public RelayCommand<object> ProductUpdateCommand { get; private set; }
        public SalerViewModel()
        {
            this.ProductRowSelectedCommand = new RelayCommand<object>(ProductRowSelectedAction);
            this.ProductEditCommand = new RelayCommand<object>(ProductEditAction);
            this.ProductUpdateCommand = new RelayCommand<object>(ProductUpdateAction);
            this._products = ProductDAO.All();
        }
        private void ProductRowSelectedAction(object SelectedItem)
        {
            if (SelectedItem != null)
            {
                Console.WriteLine("CategoryRowSelectedAction");
                Console.WriteLine(((Product)SelectedItem).Name);
                Console.WriteLine(((Product)SelectedItem).Id);
                this.Product = ProductDAO.Show(((Product)SelectedItem).Id);
                this.EditStatus = Visibility.Hidden;
                Console.WriteLine(((Product)SelectedItem).Storage.City);
                this.DetailsStatus = Visibility.Visible;
            }
            else
            {
                Products = ProductDAO.All();
            }

        }
        private void ProductEditAction(object SelectedItem)
        {
            Console.WriteLine("CategoryEditAction");
            this.EditStatus = Visibility.Visible;
        }
        private void ProductUpdateAction(object SelectedItem)
        {
            Console.WriteLine("CategoryUpdateAction");
            ProductDAO.UpdatePrice(this.Product);
            Products = ProductDAO.All();
        }
        public Visibility DetailsStatus
        {
            get
            {
                return details_visibility;
            }
            set => this.SetProperty(ref details_visibility, value);
        }
        public Visibility EditStatus
        {
            get
            {
                return edit_visibility;
            }
            set => this.SetProperty(ref edit_visibility, value);
        }
        public List<Product> Products
        {
            get
            {
                return this._products;
            }
            set { this.SetProperty(ref _products, value); }
        }
        public Product Product
        {
            get
            {
                return this._product;
            }
            set { this.SetProperty(ref _product, value); }
        }
    }
}
