using System.Linq;
using System.Windows;

using DesktopContactsApp.Data;
using DesktopContactsApp.Data.Models;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        private readonly Contact contact;

        public ContactDetailsWindow(Contact contact)
        {
            this.InitializeComponent();

            this.Owner = Application.Current.MainWindow;
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            this.contact = contact;

            this.nameTextBox.Text = this.contact.Name;
            this.emailTextBox.Text = this.contact.Email;
            this.phoneTextBox.Text = this.contact.PhoneNumber;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            using DesktopContactsAppDbContext context = new DesktopContactsAppDbContext();
            Contact contact = context.Contacts
                .Find(this.contact.Id);
            contact.Name = this.nameTextBox.Text;
            contact.Email = this.emailTextBox.Text;
            contact.PhoneNumber = this.phoneTextBox.Text;

            context.SaveChanges();

            this.Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = 
                MessageBox.Show($"Are you sure you want to delete {this.contact.Name} from the contacts?",
                                "Warning!",
                                MessageBoxButton.YesNo,
                                MessageBoxImage.Warning);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                using DesktopContactsAppDbContext context = new DesktopContactsAppDbContext();
                Contact contact = context.Contacts
                    .Find(this.contact.Id);
                contact.IsDeleted = true;
                context.SaveChanges();
            }

            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
