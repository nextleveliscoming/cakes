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

        public Dictionary<string, Dictionary<string, int>> AvailableRecipes { get; } = new Dictionary<string, Dictionary<string, int>>();

        Storage _storage;
        Kitchen _kitchen;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            _storage = new Storage();
            _kitchen = new Kitchen(_storage);

            foreach (var item in _storage.GetAllIngredients())
            {
                Ingredients.Add(item);
            }


            foreach (var item in _kitchen.GetAvailableRecipes())
            {
                AvailableRecipes.Add(item.Key, item.Value);
            }

        }

        private void btnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            Ingredient ingredient = new Ingredient()
            {
                Name = txtName.Text,
                Quantity = Convert.ToInt32(txtQuantity.Text),
                Cost = Convert.ToDecimal(txtCost.Text)
            };

            _storage.AddIngredient(ingredient);

            Ingredients.Clear();

            foreach (var item in _storage.GetAllIngredients())
            {
                Ingredients.Add(item);
            }

            lstIngredients.ItemsSource = Ingredients;

        }

        private void btnTakeOrder_Click(object sender, RoutedEventArgs e)
        {

            string input = txtCakeName.Text.ToLower();

            if (!AvailableRecipes.Keys.Contains(input))
            {
                MessageBox.Show("Вы ввели некорректное название. Пожалуйста, введите название из списка.");
                return;
            }

            MessageBox.Show("Ваш заказ принят, ожидайте");
            
            _kitchen.MakeCake(input);
            
            foreach (var item in _storage.GetAllIngredients())
            {
                Ingredients.Add(item);
            }

        }
    }
}