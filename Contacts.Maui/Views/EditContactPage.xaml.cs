namespace Contacts.Maui.Views;

public partial class EditContactPage : ContentPage
{
    public EditContactPage()
    {
        InitializeComponent();
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        // For the Shell page (Main page, Index page etc..) if we want to route it we should you absolute path. And absolute path starts with //
        //https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/shell/navigation?view=net-maui-8.0

        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }
}