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

namespace Notes
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var userAuth = EF.AppData.context.UserData.ToList().
                Where(i => i.Login == txtLogin.Text && i.Password == txtPassword.Password).
                FirstOrDefault();

            if (userAuth != null)
            {
                ClassHelper.AuthData.userData = userAuth;
                // переход
                Windows.NotesWindow notesWindow = new Windows.NotesWindow();
                this.Hide();
                notesWindow.ShowDialog();
                //this.Show();
            }
            else
            {
                MessageBox.Show("User not found", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnGuest_Click(object sender, RoutedEventArgs e)
        {
            // переход
            Windows.NotesWindow notesWindow = new Windows.NotesWindow();
            this.Hide();
            notesWindow.ShowDialog();
            //this.Show();
        }
    }
}
