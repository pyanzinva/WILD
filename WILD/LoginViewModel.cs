using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WILD.Models;
using System.Windows;

namespace WILD
{
    public class LoginViewModel
    {
        private DataBase _dataBase;

        public ICommand LoginCommand { get; private set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public LoginViewModel()
        {
            _dataBase = new DataBase();
            LoginCommand = new RelayCommand(Login, CanLogin);
        }

        private bool CanLogin(object parameter)
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        }

        private void Login(object parameter)
        {
            string role = _dataBase.GetUserRole(Username, Password);
            if (role != null)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Application.Current.Windows[0].Close();
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль");
            }
        }
    }
}
