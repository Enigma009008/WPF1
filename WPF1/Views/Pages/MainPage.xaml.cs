using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF1.Context;
using WPF1.Model;


namespace WPF1.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
      
        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            DataSource.ItemsSource = AppData.db.Player.Where(item => item.FirstName.Contains(SearchPlayer.Text) || item.LastName.Contains(SearchPlayer.Text) || item.Team.Contains(SearchPlayer.Text) || item.Position.Contains(SearchPlayer.Text) || item.Age.Contains(SearchPlayer.Text)).ToList();
        }

        private void SearchPlayer_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataSource.ItemsSource = AppData.db.Player.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ActionPlayerPage(new Player()));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var EditPlayer = (Player)DataSource.SelectedItem;
            if(EditPlayer != null)
            {
                NavigationService.Navigate(new ActionPlayerPage(EditPlayer));       
            }
           
            else
            {
                MessageBox.Show("Не выбран игрок!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var DeletePlayer = (Player)DataSource.SelectedItem;
            if(DeletePlayer != null)
            {
                if (MessageBox.Show("Вы точно хотите удалить?","Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    AppData.db.Player.Remove(DeletePlayer);
                    AppData.db.SaveChanges();
                    MessageBox.Show("Игрок удален!","Уведомление",MessageBoxButton.OK,MessageBoxImage.Information);
                    Page_Loaded(null, null);
                }
            }
            else
            {
                MessageBox.Show("Игрок не выбран!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
