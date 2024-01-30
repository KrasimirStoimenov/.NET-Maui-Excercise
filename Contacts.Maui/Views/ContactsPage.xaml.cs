namespace Contacts.Maui.Views;

using System.Collections.ObjectModel;

using Contacts.Maui.Models;
using Contacts.Maui.Repositories;

public partial class ContactsPage : ContentPage
{
    private readonly IContactsRepository contactsRepository;
    public ContactsPage(IContactsRepository contactsRepository)
    {
        InitializeComponent();

        this.contactsRepository = contactsRepository;
    }

    protected override void OnAppearing()
    {
        var contacts = new ObservableCollection<ContactModel>(this.contactsRepository.GetAll());
        listContacts.ItemsSource = contacts;

        base.OnAppearing();
    }

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (listContacts.SelectedItem != null)
        {
            //DisplayAlert("Test", $"Item selected {e.SelectedItem}", "OK");
            await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((ContactModel)e.SelectedItem).ContactId}");
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