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

namespace NoPlaceToHide
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(
                new Uri(@"C:\Users\P\Dropbox\IT\Algorithms\NoPlaceToHide\NoPlaceToHide\Network.png", UriKind.Absolute));
            networkCanvas.Background = ib;

        }

        private void LetsFlow(object sender, RoutedEventArgs e)
        {
            bool minError = false ;
            bool maxError = false;

            int min, max;
            if (!int.TryParse(minVal.Text, out min))
            {
                minErrorMsg.Text = "incorrect value";
                minError = true;
            }
            else if(min<0)
            {
                minErrorMsg.Text = "incorrect value";
                minError = true;
            }

            if (minVal.Text.Length == 0)
            {
                minErrorMsg.Text = "value is empty";
                minError = true;
            }

            if (!int.TryParse(maxVal.Text, out max))
            {
                maxErrorMsg.Text = "incorrect value";
                maxError = true;
            }
            else if(max<0)
            {
                maxError = true;
                maxErrorMsg.Text = "incorrect value";
            }

            if (maxVal.Text.Length == 0)
            {
                maxErrorMsg.Text = "value is empty";
                maxError = true;
            }

            if(minError || maxError)
            {
                maxErrorMsg.Visibility = Visibility.Visible;
                minErrorMsg.Visibility = Visibility.Visible;
                minVal.Text = "";
                maxVal.Text = "";
                return;
            }
            else
            {
                maxErrorMsg.Visibility = Visibility.Hidden;
                minErrorMsg.Visibility = Visibility.Hidden;
            }

            int nodesCount = 6;
            Network net = new Network();
            Graph graph = net.makeGraph(nodesCount);

            int[,] capacity = net.generateCapacities(nodesCount, min, max);

            networkCanvas.Children.RemoveRange(0,networkCanvas.Children.Count);

            EdmondsKarp ek = new EdmondsKarp();
            int[,] flow = new int[graph.vertciesCount(), graph.vertciesCount()];
            var maxFlow = ek.getMaximumFlow(graph, capacity, ref flow, 0, 5);

            insertText(100, 65, flow[0,1].ToString() + "/" + capacity[0, 1].ToString(), Color.FromRgb(0, 0, 0));
            insertText(110, 195, flow[0, 2].ToString() + "/" + capacity[0, 2].ToString(), Color.FromRgb(0, 0, 0));
            insertText(160, 130, flow[1, 2].ToString() + "/" + capacity[1, 2].ToString(), Color.FromRgb(0, 0, 0));
            insertText(290, 30, flow[1, 3].ToString() + "/" + capacity[1, 3].ToString(), Color.FromRgb(0, 0, 0));
            insertText(230, 170, flow[2, 3].ToString() + "/" + capacity[2, 3].ToString(), Color.FromRgb(0, 0, 0));
            insertText(280, 235, flow[2, 4].ToString() + "/" + capacity[2, 4].ToString(), Color.FromRgb(0, 0, 0));
            insertText(280, 85, flow[1, 4].ToString() + "/" + capacity[1, 4].ToString(), Color.FromRgb(0, 0, 0));
            insertText(455, 195, flow[4, 5].ToString() + "/" + capacity[4, 5].ToString(), Color.FromRgb(0, 0, 0));
            insertText(400, 145, flow[4, 3].ToString() + "/" + capacity[4, 3].ToString(), Color.FromRgb(0, 0, 0));


            wMaxFlow.Text = maxFlow.ToString();
        }

        private void insertText(double x, double y, string text, Color color)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            textBlock.FontSize = 18;
            textBlock.Foreground = new SolidColorBrush(color);
            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);
            networkCanvas.Children.Add(textBlock);
        }

        private void w_KeyDown(Object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LetsFlow(sender, e);
            }
        }
    }
}
