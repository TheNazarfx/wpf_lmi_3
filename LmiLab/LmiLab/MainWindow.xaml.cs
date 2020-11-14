using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace LmiLab
{

    public class Person
    {
        static int count = 0;
        private int id;
        public int Id { get { return id; } set { id = count++; } }
        public string Name { get; set; }
        public string Address { get; set; }
    }
    public partial class MainWindow : Window
    {
        private ObservableCollection<Person> person;
        public MainWindow()
        {
            InitializeComponent();
            person = new ObservableCollection<Person>()
         {
             new Person(){Id=1, Name="Prabhat",Address="India"},

             new Person(){Id=1, Name="Smith",Address="US"}
         };
            lstNames.ItemsSource = person;
        }
        private void btnNames_Click(object sender, RoutedEventArgs e)
        {
            person.Add(new Person() { Name = txtName.Text, Address = txtAddress.Text });
            txtName.Text = string.Empty;
            txtAddress.Text = string.Empty;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if(DeleteByIdTextBox.Text != string.Empty)
            {
                var deletePerson = (from p in person
                                    where p.Id == Convert.ToInt32(DeleteByIdTextBox.Text)
                                    select p).FirstOrDefault();
                person.Remove(deletePerson);
                DeleteByIdTextBox.Text = string.Empty;
            }
        }
    }
}