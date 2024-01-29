namespace Contacts.Maui.Views;

using Contacts.Maui.Models;
using Contacts.Maui.Repositories;

public partial class ContactsPage : ContentPage
{
    public ContactsPage(IContactsRepository contactsRepository)
    {
        InitializeComponent();

        List<ContactModel> contacts = contactsRepository.GetAll();

        listContacts.ItemsSource = contacts;
    }
    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (listContacts.SelectedItem != null)
        {
            //DisplayAlert("Test", $"Item selected {e.SelectedItem}", "OK");
            await Shell.Current.GoToAsync(nameof(EditContactPage));
        }
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listContacts.SelectedItem = null;
    }

    private async void btnAddContact_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private async void btnEditContact_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(EditContactPage));
    }
}