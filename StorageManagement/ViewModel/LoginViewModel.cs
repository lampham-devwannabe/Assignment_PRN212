using StorageManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace StorageManagement.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public bool IsLogin { get; set; }
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        public ICommand LoginCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public LoginViewModel()
        {
            UserName = "";
            Password = "";
            IsLogin = false;
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; },
                (p) =>
                {
                    Password = p.Password;
                });

            LoginCommand = new RelayCommand<Window>((p) => { return true; },
                (p) =>
                {
                    Login(p);
                });
            CloseCommand = new RelayCommand<Window>((p) => { return true; },
                (p) =>
                {
                    p.Close();
                });
        }
        void Login(Window p)
        {
            if (p == null) return;
            /*
            * admin
            * admin
            * 
            * staff 
            * staff
            */
            string passHash = MD5Hash(Base64Encode(Password));
            var userCount = DataProvider.Ins.DB.Users.Where(u => u.UserName == _UserName && u.Password == passHash).Count();
            if (userCount > 0)
            {
                IsLogin = true;
                p.Close();
            }
            else
            {
                IsLogin = false;
                MessageBox.Show("Incorrect credentials!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5 md5 = MD5.Create();
            byte[] bytes = md5.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
