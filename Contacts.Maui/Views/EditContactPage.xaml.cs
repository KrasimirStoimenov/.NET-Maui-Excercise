namespace Contacts.Maui.Views;

using Contacts.Maui.Models;
using Contacts.Maui.Repositories;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
    private readonly IContactsRepository contactsRepository;
    private ContactModel? contactModel;

    public EditContactPage(IContactsRepository contactsRepository)
    {
        InitializeComponent();

        this.contactsRepository = contactsRepository;
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
            this.contactModel = this.contactsRepository.GetContactById(int.Parse(value));
            lblName.Text = this.contactModel!.Name;
        }
    }
}