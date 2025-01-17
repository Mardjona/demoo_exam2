using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using demo_exam.Models;
using System.Collections.Generic;
using System.Linq;

namespace demo_exam;

public partial class EditWindow : Window
{
    private Product Currenproduct;
    User Currentuser;

    /*  public EditWindow()
      {
          InitializeComponent();

          Currenproduct = new Product();
      }

      public EditWindow(Product product)
      {
          InitializeComponent();
          Currenproduct = product;
          ModelProduct.DataContext = Currenproduct;
          List<string> list = Helper.DataBase.Products.Select(x => x.ProductCategory).ToList();
          ComboBoxCategory.ItemsSource = Helper.DataBase.Products.GroupBy(x => x.ProductCategory).Select(g => g.First()).ToList();
          List<string> facture = Helper.DataBase.Products.Select(x =>x.ProductFacturer).ToList();
          ComboBoxFacture.ItemsSource = Helper.DataBase.Products.GroupBy(x =>x.ProductFacturer).Select(g => g.First()).ToList();



      }
      public EditWindow(User user)
      {
          InitializeComponent();
          Currentuser = user;
          Currenproduct = new Product();
      }

      public EditWindow(Product product, User user)
      {
          InitializeComponent();
          Currentuser = user;
          Currenproduct = product;
          ModelProduct.DataContext = Currenproduct;
          List<string> list = Helper.DataBase.Products.Select(x => x.ProductCategory).ToList();
          ComboBoxCategory.ItemsSource = Helper.DataBase.Products.GroupBy(x => x.ProductCategory).Select(g => g.First()).ToList();
          List<string> facture = Helper.DataBase.Products.Select(x => x.ProductFacturer).ToList();
          ComboBoxFacture.ItemsSource = Helper.DataBase.Products.GroupBy(x => x.ProductFacturer).Select(g => g.First()).ToList();



      }*/
    public EditWindow() { }
    //ПРоверка на пользователя
    public EditWindow(User? user = null, Product? product = null)
    {
        InitializeComponent();
        Currentuser = user ?? new User();
        Currenproduct = product ?? new Product();
        ModelProduct.DataContext = Currenproduct;

       /* List<string> list = Helper.DataBase.Products.Select(x => x.ProductCategory).ToList();
        ComboBoxCategory.SelectedIndex = 0;
        ComboBoxCategory.ItemsSource = Helper.DataBase.Products.GroupBy(x => x.ProductCategory).Select(g => g.First()).ToList();
        List<string> facture = Helper.DataBase.Products.Select(x => x.ProductFacturer).ToList();
        ComboBoxFacture.ItemsSource = Helper.DataBase.Products.GroupBy(x => x.ProductFacturer).Select(g => g.First()).ToList();
        ComboBoxFacture.SelectedItem = Currenproduct.ProductCategory;*/

    }

    private void Save_Button( object? sender, RoutedEventArgs e ) 
    {
        Helper.DataBase.Update(Currenproduct);
        Helper.DataBase.SaveChanges();
        ProductWindow productWindow = Currentuser == null ? new ProductWindow() : new ProductWindow(Currentuser);
        productWindow.Show();
        this.Close();

    }
    private void Cansel_Button(object? sender, RoutedEventArgs e)
    {

        ProductWindow productWindow = Currentuser == null ? new ProductWindow() : new ProductWindow(Currentuser);
        productWindow.Show();
        this.Close();
    }
}