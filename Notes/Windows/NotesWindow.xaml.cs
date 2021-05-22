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
using System.Windows.Shapes;

namespace Notes.Windows
{
    /// <summary>
    /// Логика взаимодействия для NotesWindow.xaml
    /// </summary>
    public partial class NotesWindow : Window
    {
        public NotesWindow()
        {
            InitializeComponent();

            if (ClassHelper.AuthData.userData == null)
            {
                btnAdd.Visibility = Visibility.Collapsed;
                btnEdit.Visibility = Visibility.Collapsed;
                btnDel.Visibility = Visibility.Collapsed;
            }

            lvNote.ItemsSource = EF.AppData.context.Note.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddNoteWindow addNoteWindow = new AddNoteWindow();
            this.Hide();
            addNoteWindow.ShowDialog();
            lvNote.ItemsSource = EF.AppData.context.Note.ToList();
            this.Show();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lvNote.SelectedItem is EF.Note noteEdit)
            {
                Windows.EditNoteWindow editNoteWindow = new EditNoteWindow(noteEdit);
                this.Hide();
                editNoteWindow.ShowDialog();
                lvNote.ItemsSource = EF.AppData.context.Note.ToList();
                this.Show();
            }
            else
            {
                MessageBox.Show("Note is not found");
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (lvNote.SelectedItem is EF.Note noteDel)
            {
                var resultMess = MessageBox.Show("Are you sure?", "delete request", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resultMess == MessageBoxResult.Yes)
                {
                    EF.AppData.context.Note.Remove(noteDel);
                    EF.AppData.context.SaveChanges();
                    MessageBox.Show("Note delete");
                    lvNote.ItemsSource = EF.AppData.context.Note.ToList();
                }
                
            }
            else
            {
                MessageBox.Show("Note is not found");
            }
        }
    }
}
