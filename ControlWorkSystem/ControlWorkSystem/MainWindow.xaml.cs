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

namespace ControlWorkSystem
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int countArraySize;
        private Thread thread;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveToDatabaseButton(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(nameAuthor.Text) && !string.IsNullOrWhiteSpace(nameBook.Text) && !string.IsNullOrWhiteSpace(price.Text))
            {
                Task.Run(() => Save());
                MessageBox.Show("Книга добавлена");
            }
            else
            {
                MessageBox.Show("Норм введи");
                return;
            }
        }

        public async void Save()
        {
            using (var context = new BookContext())
            {
                Dispatcher.Invoke(() => context.Authors.Add(new Author
                {
                    NameAuthor = nameAuthor.Text,
                    NameBook = nameBook.Text,
                    PriceBook = price.Text
                }));

                await context.SaveChangesAsync();
            }
        }

        private void InitArrayButton(object sender, RoutedEventArgs e)
        {
            
            if (!string.IsNullOrWhiteSpace(count.Text) && count.Text.Length != 0)
            {
                int.TryParse(count.Text, out countArraySize);
                CreateThread();
                thread.Start();
            }
            else
            {
                MessageBox.Show("Норм введи");
                return;
            }
        }

        public void CreateThread()
        {
            var threads = new Thread[countArraySize];

            for(int i = 0; i < countArraySize; i++)
            {
                thread = new Thread(new ThreadStart(InitArray));
                threads[i] = thread;
                
            }
            
        }

        public void InitArray()
        {
            
            var array = new int[countArraySize];

            for (int i = 0; i < countArraySize; i++)
            {
                array[i] = i;
            }
        }
    }
}
