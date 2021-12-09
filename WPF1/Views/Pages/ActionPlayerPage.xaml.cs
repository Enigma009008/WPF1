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
    /// Логика взаимодействия для ActionPlayerPage.xaml
    /// </summary>
    public partial class ActionPlayerPage : Page
    {
        public Player Player { get; set; }
        public ActionPlayerPage(Player player)
        {
            InitializeComponent();
            this.Player = player;
            this.DataContext = this;

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TxbFirstName.Text) && !string.IsNullOrEmpty(TxbLastName.Text) &&
              !string.IsNullOrEmpty(TxbTeam.Text) &&
              !string.IsNullOrEmpty(TxbPosition.Text) &&
              !string.IsNullOrEmpty(TxbAge.Text))
            {
                try
                {
                    if (Player.ID == 0)
                    {
                        AppData.db.Player.Add(Player);
                    }
                    AppData.db.SaveChanges();
                    MessageBox.Show("Успешно выполнено!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Не введены данные!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}