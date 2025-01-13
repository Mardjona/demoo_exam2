using Avalonia.Controls;
using Avalonia.Interactivity;

namespace demo_exam
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_addUser( object ? sender, RoutedEventArgs e )
        {
            Регистрация registration = new Регистрация();
            registration.Show();
            this.Close();   
        }
    }
}