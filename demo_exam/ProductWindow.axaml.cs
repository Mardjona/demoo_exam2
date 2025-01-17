using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using demo_exam.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace demo_exam;

public partial class ProductWindow : Window
{
    List<User> users = Helper.DataBase.Users.ToList();
    User curentRole;
    public ProductWindow()
    {
        curentRole = new User() { RoleId = 0 };
        InitializeComponent();
        ProductLoad();
        
    }
    public ProductWindow(User user)
    {
        curentRole = user;
      
        InitializeComponent();
        ProductLoad();
        TextBlock_UserSurname1.DataContext = user;

        if (!string.IsNullOrEmpty(TextBlock_UserSurname.Text))
        {
           users = users.Where( x =>x.UserSurname ==  TextBlock_UserSurname.Text).ToList();
          
        }
        if (!string.IsNullOrEmpty(TextBlock_UserName.Text))
        {
            users = users.Where(x => x.UserName == TextBlock_UserName.Text).ToList();

        }



    }
    private void ProductLoad()
    {
        List<Product> products = Helper.DataBase.Products.Include(x=> x.ProductFacturerNavigation).ToList();
        if (Searche_Textbox == null || Search_combobox == null || Fiter_combobox == null) return;

        if(!string.IsNullOrEmpty(Searche_Textbox.Text))
        {
            products = products.Where(x => x.ProdductDscription.ToLower().Contains(Searche_Textbox.Text.ToLower()) || x.ProductCost.ToString().ToLower().Contains(Searche_Textbox.Text) 
           || x.ProductName.ToLower().Contains(Searche_Textbox.Text.ToLower()) || x.ProductFacturer.ToString().ToLower().Contains(Searche_Textbox.Text.ToLower())
            || x.ProductQuantityInstock.ToString().ToLower().Contains(Searche_Textbox.Text)).ToList();
        }
        else
        {
            products = products.ToList();
        }
        switch(Fiter_combobox.SelectedIndex)
        {
            case 0: products = products.ToList(); break;
            case 1: products = products.OrderBy(x => x.ProductCost).ToList(); break;
            case 2:products = products.OrderByDescending(x => x.ProductCost).ToList(); break;
            default: products = products.ToList(); break;    

        }
        
       

        




        //if (!string.IsNullOrEmpty(Searche_Textbox.Text))
        //{
        //    var sterms = Searche_Textbox.Text.Split();
        //    var list = products.Where(x =>
        //    {
        //        string[] fields = new string[]
        //        {
        //            x.ProdductDscription.ToLower(),
        //            x.ProductName.ToLower()
        //        };

        //        return sterms.Select(term => term.ToLower()).Any(term => fields.Any(x => x.Contains(term)));
        //    });
        //}
        ProductListbox.ItemsSource = products.ToList();
    }
    private void Text_Changed(object? sender, TextChangedEventArgs textChangedEventArgs) => ProductLoad();
    private void Fiter_ComboBox(object? sender, SelectionChangedEventArgs selectionChangedEventArgs) => ProductLoad();
    private void Search_ComboBox(object? sender, SelectionChangedEventArgs selectionChangedEventArgs) => ProductLoad();

    private void EditProduct(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
        var product = ProductListbox?.SelectedItem as Product;
       
        if (curentRole.RoleId == 1)
        {
            EditWindow editWindow = new EditWindow(curentRole, product);
           // EditWindow editWindow = curentRole == null ? new  EditWindow(product):new EditWindow(product, curentRole);
            editWindow.Show();
            this.Close();
        }
    }
    private void Enter_button( object? sender, RoutedEventArgs routedEventArgs)
    {
        MainWindow mainWindow = new MainWindow();   
        mainWindow.Show();  
        this.Close();
    }
}