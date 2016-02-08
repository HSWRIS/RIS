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

namespace RISClient.Kongjian
{
    /// <summary>
    /// Fenyechaxun.xaml 的交互逻辑
    /// </summary>
    public partial class Fenyechaxun : UserControl
    {
        public Fenyechaxun()
        {
            InitializeComponent();
            Dangqianye = 1;
            Gongjiye = 1;
        }

        public int Gongjiye
        {
            set { gongjiyeUIlabel.Content = value; }
            get { return (int)gongjiyeUIlabel.Content; }
        }
        public int Dangqianye
        {
            set { dangqianyeUIlabel.Content = value; }
            get { return (int)dangqianyeUIlabel.Content; }
        }

        public event RoutedEventHandler Fenye_Click;

        private void shouyeUIbutton_Click(object sender, RoutedEventArgs e)
        {
            if (Fenye_Click != null)
            {
                Dangqianye = 1;
                Fenye_Click(sender, e);
            }
            else
            {
                MessageBox.Show("此功能没有实现！", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void qianyeUIbutton_Click(object sender, RoutedEventArgs e)
        {
            if (Fenye_Click != null)
            {
                Dangqianye = Math.Max(1, Dangqianye - 1);
                Fenye_Click(sender, e);
            }
            else
            {
                MessageBox.Show("此功能没有实现！", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void houyeUIbutton_Click(object sender, RoutedEventArgs e)
        {
            if (Fenye_Click != null)
            {
                Dangqianye = Math.Min(Gongjiye, Dangqianye + 1);
                Fenye_Click(sender, e);
            }
            else
            {
                MessageBox.Show("此功能没有实现！", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void weiyeUIbutton_Click(object sender, RoutedEventArgs e)
        {
            if (Fenye_Click != null)
            {
                Dangqianye = Gongjiye;
                Fenye_Click(sender, e);
            }
            else
            {
                MessageBox.Show("此功能没有实现！", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void chaxunUIbutton_Click(object sender, RoutedEventArgs e)
        {
            if (Fenye_Click != null)
            {
                Dangqianye = 1;
                Fenye_Click(sender, e);
            }
            else
            {
                MessageBox.Show("此功能没有实现！", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
