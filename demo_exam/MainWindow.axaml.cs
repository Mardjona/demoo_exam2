using Avalonia.Controls;
using Avalonia.Interactivity;
using demo_exam.Models;
using System.Collections.Generic;
using System.Linq;

namespace demo_exam
{
    public partial class MainWindow : Window
    {

        List<User> users = Helper.DataBase.Users.ToList();
        User currentUser; 
       
        public MainWindow()
        {
           
            InitializeComponent();
          
        }
        public MainWindow(User user)
        {

            InitializeComponent();
         
        }
      
       
        private void Enter_Button(object? sender, RoutedEventArgs args)
        {
            if (!string.IsNullOrEmpty(Login_TextBox.Text) && !string.IsNullOrEmpty(Password_TextBox.Text))
            {
               var userFind = users.Where(x =>x.UserLogin == Login_TextBox.Text && x.UserPassword == Password_TextBox.Text).FirstOrDefault();
                if (userFind != null)
                {
                    ProductWindow productWindow = new ProductWindow(userFind);
                    productWindow.Show();
                    this.Close();
                }

            }
         }
        private void Button_addUser( object?  sender, RoutedEventArgs e )
        {
            Регистрация registration = new Регистрация();
            registration.Show();
            this.Close();   
        }
        private void EnterGuest_Button(object? sender, RoutedEventArgs e)
        {
            ProductWindow productWindow = new ProductWindow();
            productWindow.Show();
            this.Close();
        }
    }
}