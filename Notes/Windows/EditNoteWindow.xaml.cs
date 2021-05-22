﻿using System;
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
    /// Логика взаимодействия для EditNoteWindow.xaml
    /// </summary>
    public partial class EditNoteWindow : Window
    {
        EF.Note noteEdit = new EF.Note();
        
        public EditNoteWindow()
        {
            InitializeComponent();
        }

        public EditNoteWindow(EF.Note note)
        {
            InitializeComponent();
            txtTopic.Text = note.Topic;
            txtMessage.Text = note.Message;

            noteEdit = note;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            noteEdit.Topic = txtTopic.Text;
            noteEdit.Message = txtMessage.Text;
            noteEdit.DateAndTime = DateTime.Now;

            EF.AppData.context.SaveChanges();

            MessageBox.Show("Note edited");

            this.Close();
        }
    }
}
