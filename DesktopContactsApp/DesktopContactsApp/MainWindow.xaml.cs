using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using DesktopContactsApp.Data;
using DesktopContactsApp.Data.Models;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Contact> contacts;

        public MainWindow()
        {
            this.InitializeComponent();

            this.contacts = new List<Contact>();

            this.ReadDatabase();
        }

        private void NewContactButton_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow contactWindow = new NewContactWindow();
            contactWindow.ShowDialog();

            this.ReadDatabase();
        }

        private void ReadDatabase()
        {
            using DesktopContactsAppDbContext context = new DesktopContactsAppDbContext();
            this.contacts = context.Contacts
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.Id)
                .ToList();

            this.contactsListView.ItemsSource = this.contacts;
            this.filterTextBox.Text = string.Empty;
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filterText = this.filterTextBox.Text;

            List<Contact> filteredList = this.contacts
                .Where(x => x.Name.ToLower().Contains(filterText.ToLower()) && x.IsDeleted == false)
                .ToList();

            this.contactsListView.ItemsSource = filteredList;
        }

        private void ContactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact contact = (Contact)this.contactsListView.SelectedItem;

            if (contact != null)
            {
                ContactDetailsWindow detailsWindow = new ContactDetailsWindow(contact);
                detailsWindow.ShowDialog();
            }

            this.ReadDatabase();
        }
    }
}
