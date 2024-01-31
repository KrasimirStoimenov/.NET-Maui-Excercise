namespace Contacts.Maui.Views;

using Contacts.Maui.Models;
using Contacts.Maui.Repositories;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
    private readonly IContactsRepository contactsRepository;
    private ContactModel? contact;

    public EditContactPage(IContactsRepository contactsRepository)
    {
        InitializeComponent();

        this.contactsRepository = contactsRepository;
    }
    public string ContactId
    {
        set
        {
            this.contact = this.contactsRepository.GetContactById(int.Parse(value));
            if (contact != null)
            {
                contactControl.Name = contact.Name;
                contactControl.Name = contact.Name;
                contactControl.Email = contact.Email;
                contactControl.PhoneNumber = contact.PhoneNumber;
                contactControl.Address = contact.Address;
            }
        }
    }

    private void contactControl_OnSave(object sender, EventArgs e)
    {
        if (this.contact != null)
        {
            this.contact.Name = contactControl.Name;
            this.contact.Email = contactControl.Email;
            this.contact.PhoneNumber = contactControl.PhoneNumber;
            this.contact.Address = contactControl.Address;

            this.contactsRepository.UpdateContact(this.contact.ContactId, this.contact);
        }

        //Shell.Current.GoToAsync(".."); that will bring us to previous page. same as Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
        Shell.Current.GoToAsync("..");
    }

    private void contactControl_OnCancel(object sender, EventArgs e)
    {
        // For the Shell page (Main page, Index page etc..) if we want to route it we should you absolute path. And absolute path starts with //
        //https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/shell/navigation?view=net-maui-8.0

        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    private void contactControl_OnError(object sender, List<string> errors)
    {
        var joinedValidationErrors = string.Join("\n", errors);
        DisplayAlert("Error", joinedValidationErrors, "OK");
    }
}