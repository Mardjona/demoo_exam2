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
            ����������� registration = new �����������();
            registration.Show();
            this.Close();   
        }
    }
}