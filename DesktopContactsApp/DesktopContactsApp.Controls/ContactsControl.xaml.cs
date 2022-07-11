using System.Windows;
using System.Windows.Controls;

using DesktopContactsApp.Data.Models;

namespace DesktopContactsApp.Controls
{
    /// <summary>
    /// Interaction logic for ContactsControl.xaml
    /// </summary>
    public partial class ContactsControl : UserControl
    {
        // Using a DependencyProperty as the backing store for Contact. This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact",
                                        typeof(Contact),
                                        typeof(ContactsControl),
                                        new PropertyMetadata(null, SetText));

        public ContactsControl()
        {
            this.InitializeComponent();
        }

        public Contact Contact
        {
            get => (Contact)this.GetValue(ContactProperty);
            set => this.SetValue(ContactProperty, value);
        }

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ContactsControl control)
            {
                control.nameTextBlock.Text = (e.NewValue as Contact)!.Name;
                control.emailTextBlock.Text = (e.NewValue as Contact)!.Email;
                control.phoneTextBlock.Text = (e.NewValue as Contact)!.PhoneNumber;
            }
        }
    }
}
