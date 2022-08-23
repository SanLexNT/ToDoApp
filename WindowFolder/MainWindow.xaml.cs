using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using ToDoApp.ClassFolder;
using ToDoApp.Models;

namespace ToDoApp.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}//data.json";
        BindingList<ToDoModel> toDoList;
        private FileIOService fileIOService;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MinimizedBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxClass.ExitMessageBox();
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            toDoList = new BindingList<ToDoModel>();
            fileIOService.SaveData(toDoList);
            LoadData();
        }
        private void LoadData()
        {
            fileIOService = new FileIOService(PATH);
            try
            {
                toDoList = fileIOService.LoadData();
            }
            catch (Exception ex)
            {
                MessageBoxClass.ErrorMessageBox(ex);
            }

            ToDoDg.ItemsSource = toDoList;
            toDoList.ListChanged += ToDoList_ListChanged;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void ToDoList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded ||
                e.ListChangedType == ListChangedType.ItemDeleted ||
                e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    fileIOService.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBoxClass.ErrorMessageBox(ex);
                }
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if(ToDoDg.SelectedItem is ToDoModel task)
            {
                toDoList.Remove(task);
                ToDoDg.ItemsSource = toDoList;
            }
        }

    }
}
