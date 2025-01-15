using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using demo_exam.Models;

namespace demo_exam;

public partial class Регистрация : Window
{
    
    public Регистрация()
    {
        InitializeComponent();
       
    }
    
    private void BackButton ( object? sender, RoutedEventArgs e )
    {
        MainWindow mainWindow = new MainWindow();   
        mainWindow.Show();
        this.Close();
    }
}