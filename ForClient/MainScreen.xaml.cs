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

        #region LoadEvent
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Lấy info path
            var path = txt.Text;
            var info = new DirectoryInfo(path);

            DirectoryInfo[] list = info.GetDirectories();

            // Add data cho từng combobox (all,top,mid,jungle,spt,adc)

            var listAll = new List<String>();
            //var i = list[1].Name.IndexOf(' ');
            //MessageBox.Show(i.ToString());
            int c = 1;
            foreach (var index in list)
            {
                var str = index.Name;
                var i = str.IndexOf(' ');
                if (i==-1)
                {
                    listAll.Add((c++).ToString() + "." + str);
                }
                else
                {
                    listAll.Add((c++).ToString() + "." + str.Substring(0, i));
                }
            }
            cbAll.ItemsSource = listAll;


            c = 1;
            var listTop = new List<string>();
            foreach (var index in list)
            {
                var str = index.Name;
                if (str.Contains("top"))
                {
                    var i = str.IndexOf(' ');
                    if (i == -1)
                    {
                        listTop.Add((c++).ToString() + "." + str);
                    }
                    else
                    {
                        listTop.Add((c++).ToString() + "." + str.Substring(0, i));
                    }
                }
            }
            cbTop.ItemsSource = listTop;

            c = 1;
            var listAdc = new List<string>();
            foreach (var index in list)
            {
                var str = index.Name;
                if (str.Contains("adc"))
                {
                    var i = str.IndexOf(' ');
                    if (i == -1)
                    {
                        listAdc.Add((c++).ToString() + "." + str);
                    }
                    else
                    {
                        listAdc.Add((c++).ToString() + "." + str.Substring(0, i));
                    }
                }
            }
            cbAdc.ItemsSource = listAdc;

            c = 1;
            var listMid = new List<string>();
            foreach (var index in list)
            {
                var str = index.Name;
                if (str.Contains("mid"))
                {
                    var i = str.IndexOf(' ');
                    if (i == -1)
                    {
                        listMid.Add((c++).ToString() + "." + str);
                    }
                    else
                    {
                        listMid.Add((c++).ToString() + "." + str.Substring(0, i));
                    }
                }
            }
            cbMid.ItemsSource = listMid;

            c = 1;
            var listSpt = new List<string>();
            foreach (var index in list)
            {
                var str = index.Name;
                if (str.Contains("spt"))
                {
                    var i = str.IndexOf(' ');
                    if (i == -1)
                    {
                        listSpt.Add((c++).ToString() + "." + str);
                    }
                    else
                    {
                        listSpt.Add((c++).ToString() + "." + str.Substring(0, i));
                    }
                }
            }
            cbSpt.ItemsSource = listSpt;

            c = 1;
            var listJungle = new List<string>();
            foreach (var index in list)
            {
                var str = index.Name;
                if (str.Contains("jungle"))
                {
                    var i = str.IndexOf(' ');
                    if (i == -1)
                    {
                        listJungle.Add((c++).ToString() + "." + str);
                    }
                    else
                    {
                        listJungle.Add((c++).ToString() + "." + str.Substring(0, i));
                    }
                }
            }
            cbJungle.ItemsSource = listJungle;

            // Load alphabet
            for (char ch='A';ch<='Z';ch++)
            {
                Button btn = new Button();
                btn.Name = "btn" + ch.ToString();
                btn.Content = ch.ToString();
                btn.Margin = new Thickness(5, 10, 5, 10);
                btn.Width = 30;
                btn.Height = 30;
                btn.IsEnabled = checkButton(ch);
                btn.Click += Btn_Click;
                stackAlphabet.Children.Add(btn);
            }    
        }
        #endregion

        #region ButtonClick
        private void Button_Random_Click(object sender, RoutedEventArgs e)
        {
            var path = txt.Text;
            var info = new DirectoryInfo(path);

            DirectoryInfo[] list = info.GetDirectories();
            //MessageBox.Show(list[70].Name);

            var random = new Random();

            var r = random.Next(list.Count());

            lbl.Content = list[r].Name;
        }

        private void Button_View_Image(object sender, RoutedEventArgs e)
        {
            Img imgWindow = new Img();
            imgWindow.ShowDialog();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            //MessageBox.Show(btn.Name);
            var ch = btn.Name[3];

            var path = txt.Text;
            var info = new DirectoryInfo(path);
            DirectoryInfo[] list = info.GetDirectories();
            var str = new StringBuilder();
            foreach (var item in list)
            {
                var firstCharacter = item.Name.ToUpper()[0];
                if (firstCharacter == ch)
                {
                    str.Append(item.Name + "\n");
                }    
            } 
            MessageBox.Show(str.ToString(), "Alert", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        #endregion

        #region function
        private bool checkButton(char ch)
        {
            var path = txt.Text;
            var info = new DirectoryInfo(path);
            DirectoryInfo[] list = info.GetDirectories();
            int count = 0;
            foreach (var item in list)
            {
                var firstCharacter = item.Name.ToUpper()[0];
                if (firstCharacter == ch) count++;
            }
            return count == 0 ? false : true;
        }
        #endregion
    }
}
