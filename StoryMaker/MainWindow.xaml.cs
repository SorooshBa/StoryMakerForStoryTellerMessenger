using ChatRoomStoryTeller;
using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ScrollBar sv;
        ScrollBar sh;
        public static List<User> users = new List<User>();
        public static MainWindow _instance;
        public MainWindow()
        {
            _instance = this;
            InitializeComponent();
            scrl.ApplyTemplate();
            sv = scrl.Template.FindName("PART_VerticalScrollBar", scrl) as ScrollBar;
            sh = scrl.Template.FindName("PART_HorizontalScrollBar", scrl) as ScrollBar;

        }
        List<DialgoueControl> dialgoues = new List<DialgoueControl>();
        private void createNewDialogue(object sender, MouseButtonEventArgs e)
        {
            DialgoueControl dc = new DialgoueControl();
            var p = Mouse.GetPosition(this);
            dc.MouseDoubleClick += Dc_MouseDoubleClick;
            dc.RectQ1.MouseDown += RectQ_MouseDown;
            dc.RectQ2.MouseDown += RectQ_MouseDown;
            dc.RectQ3.MouseDown += RectQ_MouseDown;
            dc.RectAns.MouseDown += RectAns_MouseDown;
            dc.Padding = new Thickness(sh.Value + p.X, sv.Value + p.Y, 0, 0);
            dc.VerticalAlignment = VerticalAlignment.Top;
            dc.HorizontalAlignment = HorizontalAlignment.Left;
            gridMain.Children.Add(dc);
            dialgoues.Add(dc);
        }



        DialgoueControl DcQ;
        Rectangle DcQrect;
        private void RectQ_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DcQ = (DialgoueControl)(((Border)((Grid)(((Rectangle)sender).Parent)).Parent).Parent);
            DcQrect = (Rectangle)sender;
            if(DcQrect.Name== "RectQ1"&&DcQ.q1Answer!=null)
            {
                DcQ.q1Answer = null;
                gridMain.Children.Remove(DcQ.q1Line);
                DcQ = null;
                DcQrect = null;
            }
            else if(DcQrect.Name== "RectQ2" && DcQ.q2Answer != null)
            {
                DcQ.q2Answer = null;
                gridMain.Children.Remove(DcQ.q2Line);
                DcQ = null;
                DcQrect = null;
            }
            else if(DcQrect.Name== "RectQ3" && DcQ.q3Answer != null)
            {
                DcQ.q3Answer = null;
                gridMain.Children.Remove(DcQ.q3Line);
                DcQ = null;
                DcQrect = null;
            }

        }
        
        private void RectAns_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (DcQ != null)
            {
                var l = CreateArrowBetween(DcQrect, (FrameworkElement)sender, gridMain);
                switch (DcQrect.Name)
                {
                    case "RectQ1":
                        DcQ.q1Answer = (DialgoueControl)(((Border)((Grid)(((Rectangle)sender).Parent)).Parent).Parent);
                        DcQ.q1Line = l;
                        break;
                    case "RectQ2":
                        DcQ.q2Answer = (DialgoueControl)(((Border)((Grid)(((Rectangle)sender).Parent)).Parent).Parent);
                        DcQ.q2Line = l;
                        break;
                    case "RectQ3":
                        DcQ.q3Answer = (DialgoueControl)(((Border)((Grid)(((Rectangle)sender).Parent)).Parent).Parent);
                        DcQ.q3Line = l;
                        break;
                    default:
                        break;
                }
                DcQ = null;
                DcQrect = null;
            }
        }
        DialgoueControl DcToMove;
        private void Dc_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DcToMove != sender)
            {
                DcToMove = (DialgoueControl)sender;
            }
            else
                DcToMove = null;
        }

        private void scrl_MouseMove(object sender, MouseEventArgs e)
        {
            if (DcToMove != null)
            {
                var p = Mouse.GetPosition(this);
                DcToMove.Padding = new Thickness(sh.Value + p.X - 200, sv.Value + p.Y - 30, 0, 0);

                for (var i = gridMain.Children.Count - 1; i >= 0; i--)
                {
                    if(gridMain.Children[i].GetType()==typeof(Line))
                    {
                        gridMain.Children.RemoveAt(i);
                    }
                }
                for (var i = gridMain.Children.Count - 1; i >= 0; i--)
                {
                    if (gridMain.Children[i].GetType() == typeof(DialgoueControl))
                    {
                        DialgoueControl temp = (DialgoueControl)gridMain.Children[i];
                        if(temp.q1Answer!=null)
                        {
                            temp.q1Line = CreateArrowBetween(temp.RectQ1, temp.q1Answer.RectAns, gridMain);
                        }
                        if (temp.q2Answer != null)
                        {
                            temp.q2Line = CreateArrowBetween(temp.RectQ2, temp.q2Answer.RectAns, gridMain);
                        }
                        if (temp.q3Answer != null)
                        {
                            temp.q3Line = CreateArrowBetween(temp.RectQ3, temp.q3Answer.RectAns, gridMain);
                        }
                    }
                }

            }
        }
        private Line CreateArrowBetween(FrameworkElement startElement, FrameworkElement endElemend, Panel parentContainer)
        {
            SolidColorBrush arrowBrush = Brushes.Red;

            // Center the line horizontally and vertically.
            // Get the positions of the controls that should be connected by a line.
            Point centeredArrowStartPosition = startElement.TransformToAncestor(parentContainer)
              .Transform(new Point(startElement.ActualWidth / 2, startElement.ActualHeight / 2));

            Point centeredArrowEndPosition = endElemend.TransformToAncestor(parentContainer)
              .Transform(new Point(endElemend.ActualWidth / 2, endElemend.ActualHeight / 2));

            // Draw the line between two controls
            var arrowLine = new Line()
            {
                Stroke = Brushes.Red,
                StrokeThickness = 2,
                X1 = centeredArrowStartPosition.X,
                Y2 = centeredArrowEndPosition.Y,
                X2 = centeredArrowEndPosition.X,
                Y1 = centeredArrowStartPosition.Y
            };
            parentContainer.Children.Add(
              arrowLine);

            // Create the arrow tip of the line. The arrow has a width of 8px and a height of 8px,
            // where the position of arrow tip and the line's end are the same
            var leftRectanglePoint = new Point(centeredArrowEndPosition.X - 4, centeredArrowEndPosition.Y + 8);
            var rightRectanglePoint = new Point(
              centeredArrowEndPosition.X + 4,
              centeredArrowEndPosition.Y + 8);
            var rectangleTipPoint = new Point(centeredArrowEndPosition.X, centeredArrowEndPosition.Y);
            var myPointCollection = new PointCollection
    {
      leftRectanglePoint,
      rightRectanglePoint,
      rectangleTipPoint
    };

            return arrowLine;
        }

        private void ChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "PNG file|*.png|JPEG file|*.jpg";
            if (op.ShowDialog() == true)
            {
                System.IO.File.Copy(op.FileName, Environment.CurrentDirectory+"/img/" + System.IO.Path.GetFileName(op.FileName),true);
                imgAddr.Text = "/img/"+System.IO.Path.GetFileName(op.FileName);
            }
        }

        private void AddUser_clicked(object sender, RoutedEventArgs e)
        {
            users.Add(new User() { id = new Random().Next(1, Int32.MaxValue), Image = imgAddr.Text, Name = txtName.Text });
            loadUser();
        }
        public void loadUser()
        {
            stckUser.Children.Clear();
            foreach (var item in users)
            {
                stckUser.Children.Add(new UserinList()
                {
                    Margin = new Thickness(10),
                    Width = 370,
                    Height = 80,
                    Username = item.Name,
                    ProflePic = new BitmapImage(new Uri(Environment.CurrentDirectory + "/" + item.Image, UriKind.Relative)),
                    id = item.id              
                });
                ((UserinList)stckUser.Children[stckUser.Children.Count - 1]).btnDel.Click += BtnDelUser_Click;
                ((UserinList)stckUser.Children[stckUser.Children.Count - 1]).btnDel.Tag = ((UserinList)stckUser.Children[stckUser.Children.Count - 1]).id;
            }
        }

        private void BtnDelUser_Click(object sender, RoutedEventArgs e)
        {
            users.Remove(users.Where(x => x.id == (int)(((Button)sender).Tag)).First());
            loadUser();
        }
    }

}