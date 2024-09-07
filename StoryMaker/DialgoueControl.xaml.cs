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

namespace StoryMaker
{
    /// <summary>
    /// Interaction logic for DialgoueControl.xaml
    /// </summary>
    public partial class DialgoueControl : UserControl
    {
        public DialgoueControl q1Answer {  get; set; }
        public Line q1Line { get; set; }
        public DialgoueControl q2Answer {  get; set; }
        public Line q2Line { get; set; }
        public DialgoueControl q3Answer {  get; set; }
        public Line q3Line { get; set; }
        public DialgoueControl()
        {
            InitializeComponent();
            btnDel.Tag = this;
            checkStartPoint.Tag = this;
            foreach (var item in MainWindow.users)
            {
                comboUser.Items.Add(item.Name);
            }
        }

        private void RefreshUsers_clicked(object sender, RoutedEventArgs e)
        {
            comboUser.Items.Clear();
            foreach (var item in MainWindow.users)
            {
                comboUser.Items.Add(item.Name);
            }
        }
    }
}
