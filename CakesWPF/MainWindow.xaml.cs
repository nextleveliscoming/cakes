using CakesLibrary;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CakesWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Ingredient> Ingredients { get; } = new ObservableCollection<Ingredient>();
        Storage _storage;
        Kitchen _kitchen;


        public MainWindow()
        {
            InitializeComponent();
            _storage = new Storage();
            _kitchen = new Kitchen(_storage);
            
            DataContext = this;
            
            foreach (var item in _storage.GetAllIngredients())
            {
                Ingredients.Add(item);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Ingredient ingredient = new Ingredient();

            ingredient.Name = txtName.Text;
            ingredient.Quantity = Convert.ToInt32(txtQuantity.Text);
            ingredient.Cost = Convert.ToDecimal(txtCost.Text);

            _storage.AddIngredient(ingredient);

            Ingredients.Clear();

            foreach (var item in _storage.GetAllIngredients())
            {
                Ingredients.Add(item);
            }

            lstIngredients.ItemsSource = Ingredients;
        }

    }
}