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
using System.IO;

namespace ForClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var path = txt.Text;
            var info = new DirectoryInfo(path);

            DirectoryInfo[] list = info.GetDirectories();
            //MessageBox.Show(list[70].Name);

            var random = new Random();

            var r = random.Next(list.Count());

            lbl.Content = list[r].Name;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var path = txt.Text;
            var info = new DirectoryInfo(path);

            DirectoryInfo[] list = info.GetDirectories();

            var listAll = new List<String>();
            //var i = list[1].Name.IndexOf(' ');
            //MessageBox.Show(i.ToString());
            foreach (var index in list)
            {
                var str = index.Name;
                var i = str.IndexOf(' ');
                if (i==-1)
                {
                    listAll.Add(str);
                }
                else
                {
                    listAll.Add(str.Substring(0, i));
                }
            }
            cbAll.ItemsSource = listAll;
            

            var listTop = new List<string>();
            foreach (var index in list)
            {
                var str = index.Name;
                if (str.Contains("top"))
                {
                    var i = str.IndexOf(' ');
                    if (i == -1)
                    {
                        listTop.Add(str);
                    }
                    else
                    {
                        listTop.Add(str.Substring(0, i));
                    }
                }
            }
            cbTop.ItemsSource = listTop;

            var listAdc = new List<string>();
            foreach (var index in list)
            {
                var str = index.Name;
                if (str.Contains("adc"))
                {
                    var i = str.IndexOf(' ');
                    if (i == -1)
                    {
                        listAdc.Add(str);
                    }
                    else
                    {
                        listAdc.Add(str.Substring(0, i));
                    }
                }
            }
            cbAdc.ItemsSource = listAdc;

            var listMid = new List<string>();
            foreach (var index in list)
            {
                var str = index.Name;
                if (str.Contains("mid"))
                {
                    var i = str.IndexOf(' ');
                    if (i == -1)
                    {
                        listMid.Add(str);
                    }
                    else
                    {
                        listMid.Add(str.Substring(0, i));
                    }
                }
            }
            cbMid.ItemsSource = listMid;

            var listSpt = new List<string>();
            foreach (var index in list)
            {
                var str = index.Name;
                if (str.Contains("spt"))
                {
                    var i = str.IndexOf(' ');
                    if (i == -1)
                    {
                        listSpt.Add(str);
                    }
                    else
                    {
                        listSpt.Add(str.Substring(0, i));
                    }
                }
            }
            cbSpt.ItemsSource = listSpt;

            var listJungle = new List<string>();
            foreach (var index in list)
            {
                var str = index.Name;
                if (str.Contains("jungle"))
                {
                    var i = str.IndexOf(' ');
                    if (i == -1)
                    {
                        listJungle.Add(str);
                    }
                    else
                    {
                        listJungle.Add(str.Substring(0, i));
                    }
                }
            }
            cbJungle.ItemsSource = listJungle;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Img imgWindow = new Img();
            imgWindow.ShowDialog();
        }
    }
}
