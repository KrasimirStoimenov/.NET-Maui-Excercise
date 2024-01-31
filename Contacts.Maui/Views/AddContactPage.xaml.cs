namespace Contacts.Maui.Views;

using Contacts.Maui.Models;
using Contacts.Maui.Repositories;

public partial class AddContactPage : ContentPage
{
    private readonly IContactsRepository contactsRepository;
    public AddContactPage(IContactsRepository contactsRepository)
    {
        InitializeComponent();

        this.contactsRepository = contactsRepository;
    }

    protected override void OnAppearing()
    {
        contactControl.Name = null;
        contactControl.Email = null;
        contactControl.PhoneNumber = null;
        contactControl.Address = null;

        base.OnAppearing();
    }

    private void contactControl_OnSave(object sender, EventArgs e)
    {
        var contactId = this.contactsRepository.GetMaxIdValue() + 1;
        var contact = new ContactModel(
            contactId,
            contactControl.Name,
            contactControl.Email,
            contactControl.PhoneNumber,
            contactControl.Address);

        this.contactsRepository.AddContact(contact);
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    private void contactControl_OnCancel(object sender, EventArgs e)
    {
        // For the Shell page (Main page, Index page etc..) if we want to route it we should you absolute path. And absolute path starts with //
        //https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/shell/navigation?view=net-maui-8.0
        //Shell.Current.GoToAsync(".."); that will bring us to previous page.

        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    private void contactControl_OnError(object sender, List<string> errors)
    {
        var joinedValidationErrors = string.Join("\n", errors);
        DisplayAlert("Error", joinedValidationErrors, "OK");
    }
}