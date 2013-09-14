using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace TaskProgramming_1
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var factory = new TaskFactory();
            Debug.WriteLine("Task Starting - Current Thread Id = {0}", Thread.CurrentThread.ManagedThreadId);
            var t = new Task<string>(() =>
            {
                var sw = new Stopwatch();
                sw.Start();
                Thread.Sleep(10000);
                
                for (int i = 0; i < 10000; i++)
                {
                    new Object();

                }
                sw.Stop();
                var timeTaken = sw.ElapsedMilliseconds;
                return "Time taken to complete the task = " + timeTaken / 1000;
                

            });
            t.ContinueWith((t1) =>
            {
                this.tbStatus.Text = string.Format(t1.Result, Thread.CurrentThread.ManagedThreadId);
            },TaskScheduler.FromCurrentSynchronizationContext());
            var t2 = new Task(() =>
            {
                Thread.Sleep(5000);
                Debug.WriteLine("t2 complete");
            });
            t.Start();
            t2.Start();            
            Debug.WriteLine("Task continuing...- Current Thread Id = {0}", Thread.CurrentThread.ManagedThreadId);
            Task.WaitAll(t, t2);
            Debug.WriteLine("All the tasks are completed");

        }
    }
}
