namespace Contacts.Maui.Views;

using Contacts.Maui.Repositories;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
    private readonly IContactsRepository contactsRepository;

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
            var contactModel = this.contactsRepository.GetContactById(int.Parse(value));
            if (contactModel != null)
            {
                lblName.Text = contactModel.Name;
                entryName.Text = contactModel.Name;
                entryEmail.Text = contactModel.Email;
                entryPhoneNumber.Text = contactModel.PhoneNumber;
                entryAddress.Text = contactModel.Address;
            }
        }
    }
}