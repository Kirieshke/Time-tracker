using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using System.Windows.Threading;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace Time_tracker
{
    public partial class MainWindow : Window
    {
        private int time;
        private int breakTime;
        private DispatcherTimer dispatcherTimer;
        private DispatcherTimer breakDispatcher;
        SoundPlayer soundPlayer;
        public event Action<DispatcherTimer> Ended;
        public class Task
        {
            public String task { get; set; }
        }
        
        public MainWindow()
        {
            InitializeComponent();
            continueTb.IsEnabled = false;
            offTbStudy.IsEnabled = false;
            stopTb.IsEnabled = false;
       
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            time = int.Parse(tb1.Text) * 60;
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            tb1.IsEnabled = false;
            bt1.IsEnabled = false;
            continueTb.IsEnabled = true;
            offTbStudy.IsEnabled = true;
            stopTb.IsEnabled = true;
            breakDispatcher = new DispatcherTimer();
            breakDispatcher.Tick += breakDispatcher_Tick;
            breakDispatcher.Interval = new TimeSpan(0, 0, 1);
        }
        
        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                time--;
                timeLable.Content = string.Format("00:0{0}:{1}",time/60,time%60);
                offTbStudy.Visibility = Visibility.Visible;
                offTbBreak.Visibility = Visibility.Hidden;
            }
            else
            {
                dispatcherTimer.Stop();
                offTbStudy.Visibility = Visibility.Hidden;
                offTbBreak.Visibility = Visibility.Visible;
                soundPlayer = new SoundPlayer(@"E:\C# Proj\Time tracker\timeout.wav");
                soundPlayer.Play();
                timeLable.Visibility = Visibility.Hidden;
                breakLabel.Visibility = Visibility.Visible;
                if (time > 20 && time <= 60)
                {
                    breakTime = 900;
                }
                else if(time > 60 && time <= 120)
                {
                    breakTime = 1800;
                }
                else if(time > 120)
                {
                    breakTime = 3600;
                }
                else if(time < 20)
                {
                    breakTime = 10;
                }
                
                breakDispatcher.Start();
            }
        }
        void breakDispatcher_Tick(object sender, EventArgs e)
        {
            if (breakTime > 0)
            {
                breakTime--;
                breakLabel.Content = string.Format("00:0{0}:{1}", breakTime / 60, breakTime % 60);
                continueTb.IsEnabled = false;
                stopTb.IsEnabled = false;
            }
            else
            {
                breakDispatcher.Stop();
                soundPlayer = new SoundPlayer(@"D:\C# Proj\Time tracker\timeout.wav");
                soundPlayer.Play();
                timeLable.Visibility = Visibility.Visible;
                breakLabel.Visibility = Visibility.Hidden;
                dispatcherTimer.Start();
                time = int.Parse(tb1.Text);
            }
        }   
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
            continueTb.IsEnabled = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Start();
            continueTb.IsEnabled = false;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            tb1.IsEnabled = true;
            bt1.IsEnabled = true;
            continueTb.IsEnabled = false;
            stopTb.IsEnabled = false;
            time = 0;
            dispatcherTimer.Stop();
            dispatcherTimer.Tick += deleteStudyTimer_Tick;
            timeLable.Content = string.Format("00:0{0}:{1}", 0 / 60, 0 % 60);
            breakTime = 0;
           
        }

        private void deleteStudyTimer_Tick(object sender, EventArgs e)
        {
            Ended.Invoke(dispatcherTimer);
        }
        private void deleteBreakTimer_Tick(object sender, EventArgs e)
        {
            Ended.Invoke(breakDispatcher);
        }
        private void offTbBreak_Click(object sender, RoutedEventArgs e)
        {
            breakTime = 0;
            time = 0;
            tb1.IsEnabled = true;
            bt1.IsEnabled = true;
            continueTb.IsEnabled = false;
            stopTb.IsEnabled = false;
            breakDispatcher.Stop();
            breakDispatcher.Tick += deleteBreakTimer_Tick;
            timeLable.Visibility = Visibility.Visible;
            breakLabel.Visibility = Visibility.Hidden;
            timeLable.Content = string.Format("00:0{0}:{1}", time / 60, time % 60);
        }
        public void WriteToFile()
        {
            using (StreamWriter writer = File.AppendText(@"D:/C# Proj/Time tracker/Time tracker/data.txt"))
            {
                writer.WriteLine(addTaskTb.Text);
                
            }
        }
        
        
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            WriteToFile();
   
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            string delrlm = listBox1.SelectedItem.ToString();
            listBox1.Items.Remove(delrlm);
        }

        private void tb1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
