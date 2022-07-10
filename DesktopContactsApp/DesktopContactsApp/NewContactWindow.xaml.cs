using System.Windows;

using DesktopContactsApp.Data;
using DesktopContactsApp.Data.Models;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            this.InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact()
            {
                Name = this.nameTextBox.Text,
                Email = this.emailTextBox.Text,
                PhoneNumber = this.phoneTextBox.Text
            };

            using DesktopContactsAppDbContext context = new DesktopContactsAppDbContext();
            context.Contacts.Add(contact);
            context.SaveChanges();

            this.Close();
        }
    }
}
