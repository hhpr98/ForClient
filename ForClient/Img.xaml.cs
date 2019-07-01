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
using System.IO;
using Microsoft.Win32;

namespace ForClient
{
    /// <summary>
    /// Interaction logic for Img.xaml
    /// </summary>
    public partial class Img : Window
    {
        public Img()
        {
            InitializeComponent();
        }

        /*
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //var path = "..\\..\\Image\\Capture.jpg";
            //if (File.Exists(path))
            //{
            //    MessageBox.Show("File is exists");
            //}
            //else
            //{
            //    MessageBox.Show("File does not exists");
            //}

            var path = "ms-appx:///Image/Capture.jpg";
            BitmapImage bm = new BitmapImage(new Uri(path, UriKind.Relative));
            
            img.Source = bm;
        }
        */

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = @"C:\Users\nguyenhuuhoa\Desktop\ForClient\ForClient\Image";
            dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == true)
            {
                string selectedFileName = dlg.FileName;
                FileNameLabel.Content = selectedFileName;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();
                ImageViewer1.Source = bitmap;
            }
        }
    }
}
