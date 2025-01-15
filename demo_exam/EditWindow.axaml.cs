using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using demo_exam.Models;

namespace demo_exam;

public partial class EditWindow : Window
{
    private Product Currenproduct;
    public EditWindow()
    {
        InitializeComponent();
        Currenproduct = new Product();
    }
    public EditWindow(Product product)
    {
        InitializeComponent();
        Currenproduct = product;
        ModelProduct.DataContext = Currenproduct;

    }
}