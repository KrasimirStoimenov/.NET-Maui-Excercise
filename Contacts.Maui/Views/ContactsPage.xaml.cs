namespace Contacts.Maui.Views;

public partial class ContactsPage : ContentPage
{
    public ContactsPage()
    {
        InitializeComponent();

        List<Contact> contacts = new()
        {
            new Contact("First Contact", "First Email"),
            new Contact("Second Contact", "Second Email"),
            new Contact("Third Contact", "Third Email"),
        };

        listContacts.ItemsSource = contacts;
    }

    private void btnAddContact_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private void btnEditContact_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(EditContactPage));
    }

    public class Contact
    {
        public Contact(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }

        public string Name { get; init; }

        public string Email { get; init; }
    }
}