using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Kamenpaper
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Player _1 = new Player(10);
        Player _2 = new Player(10);

        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0,0,0,0,5);
            timer.Tick += new EventHandler(round);
        }

        public void round(object sender, EventArgs e)
        {
            _1.Rukec();
            Thread.Sleep(645);
            _2.Rukec();

            switch(_1.last)
            {
                case 0:
                    vis_1.Source = new BitmapImage(new Uri("Images/rock.png", UriKind.Relative));
                    break;
                case 1:
                    vis_1.Source = new BitmapImage(new Uri("Images/paper.png", UriKind.Relative));
                    break;
                case 2:                  
                    vis_1.Source = new BitmapImage(new Uri("Images/sizors.png", UriKind.Relative));
                    break;      
            }
            switch (_2.last)
            {
                case 0:
                    vis_2.Source = new BitmapImage(new Uri("Images/rock.png", UriKind.Relative));
                    break;
                case 1:
                    vis_2.Source = new BitmapImage(new Uri("Images/paper.png", UriKind.Relative));
                    break;
                case 2:
                    vis_2.Source = new BitmapImage(new Uri("Images/sizors.png", UriKind.Relative));
                    break;
            }

            whowins();
        }

        public void whowins()
        {
            if (_1.last == _2.last)
            {
                round(null, null);
            }
            else
            {
                if ((_1.last == (int)thing.rock) && (_2.last ==(int)thing.sizors))
                {
                    win(1);
                }
                else if(_1.last == (int)thing.rock && _2.last == (int)thing.paper)
                {
                    win(2);
                }
                else if(_1.last == (int)thing.paper && _2.last == (int)thing.rock)
                {
                    win(1);
                }
                else if(_1.last == (int)thing.paper && _2.last == (int)thing.sizors)
                {
                    win(2);
                }
                else if(_1.last == (int)thing.sizors && _2.last == (int)thing.paper)
                {
                    win(1);
                }
                else if(_1.last == (int)thing.sizors && _2.last == (int)thing.rock)
                {
                    win(2);
                }
            }
        }

        public void win(int i)
        {
            if(i == 1)
            {
                _1.money++;
                _2.money--;
            }
            else if(i == 2)
            {
                _1.money--;
                _2.money++;
            }

            _1label.Content = _1.money;
            _2label.Content = _2.money;

            if(_1.money == 0 || _2.money == 0)
            {
                gamestop();
            }
        }

        public void gamestop()
        {
            timer.Stop();
            if(_1.money == 0)
            {
                _1label.Content = "number 2 has won";
                _2label.Content = "number 2 has won";
            }
            else
            {
                _1label.Content = "number 1 has won";
                _2label.Content = "number 1 has won";
            }

        }

        private void start_Click(object sender, RoutedEventArgs e)
        {           
            timer.Start();

            
        }

        private void fsfsdfsd(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            Close();
        }
    }
}
