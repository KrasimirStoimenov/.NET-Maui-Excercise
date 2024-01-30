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

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        if (this.contact != null)
        {
            this.contact.Name = entryName.Text;
            this.contact.Email = entryEmail.Text;
            this.contact.PhoneNumber = entryPhoneNumber.Text;
            this.contact.Address = entryAddress.Text;

            this.contactsRepository.UpdateContact(this.contact.ContactId, this.contact);
        }

        //Shell.Current.GoToAsync(".."); that will bring us to previous page. same as Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
        Shell.Current.GoToAsync("..");
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        // For the Shell page (Main page, Index page etc..) if we want to route it we should you absolute path. And absolute path starts with //
        //https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/shell/navigation?view=net-maui-8.0

        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    public string ContactId
    {
        set
        {
            this.contact = this.contactsRepository.GetContactById(int.Parse(value));
            if (contact != null)
            {
                lblName.Text = contact.Name;
                entryName.Text = contact.Name;
                entryEmail.Text = contact.Email;
                entryPhoneNumber.Text = contact.PhoneNumber;
                entryAddress.Text = contact.Address;
            }
        }
    }
}