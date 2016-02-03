using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RISClient.Kongjian
{
    public class Jichuyemian : Page
    {
        protected Shujuku.Shujuku shujuku { set; get; }

        public Jichuyemian()
        {
            this.shujuku = new Shujuku.Shujuku();

            IsVisibleChanged += Jichuyemian_IsVisibleChanged;
        }

        //页面不可见时
        private void Jichuyemian_IsVisibleChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            //释放数据库
            var kejian = (bool)e.NewValue;
            if (kejian==false)
            {
                shujuku.Dispose();
#if DEBUG
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("-              释放数据库               -");
                Console.WriteLine("-----------------------------------------");
#endif
            }
        }
    }
}
