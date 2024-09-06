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

namespace ChatRoomStoryTeller
{
    /// <summary>
    /// Interaction logic for UserinList.xaml
    /// </summary>
    public partial class UserinList : UserControl
    {
        public string Username { get { return lblName.Content.ToString(); } set { lblName.Content = value; } }
        public int id { get; set; }
        public string ChatPreview { get { return lblChat.Content.ToString(); } set { lblChat.Content = value; } }
        public ImageSource ProflePic { get { return imgProf.ImageSource; } set { imgProf.ImageSource = value; } }
        public void SetAsNotReaded()
        {
            lblChat.FontWeight = FontWeights.Bold;
            lblChat.Foreground = Brushes.White;
            lblName.Foreground = Brushes.Gold;

        }
        public void SetAsReaded()
        {
            lblChat.FontWeight = FontWeights.Light;
            lblChat.Foreground = Brushes.Gray;
            lblName.Foreground = Brushes.White;
        }
        public UserinList()
        {
            InitializeComponent();
        }
    }
}
