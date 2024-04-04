using BGInventory.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGInventory.ViewModels
{
    internal class UserViewModel : ObservableObject
    {
        private User _user;
        public UserViewModel() 
        {
            this._user = UserDAO.Show();
        }
        public User User
        {
            get
            {
                return this._user;
            }
            set { this.SetProperty(ref _user, value); }
        }
    }
}
