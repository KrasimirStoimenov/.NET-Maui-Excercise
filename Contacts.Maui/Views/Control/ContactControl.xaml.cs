namespace Contacts.Maui.Views.Control;

public partial class ContactControl : ContentView
{
    public event EventHandler<List<string>>? OnError;
    public event EventHandler<EventArgs>? OnSave;
    public event EventHandler<EventArgs>? OnCancel;

    public ContactControl()
    {
        InitializeComponent();
    }

    public string Name { get => entryName.Text; set => entryName.Text = value; }

    public string Email { get => entryEmail.Text; set => entryEmail.Text = value; }

    public string PhoneNumber { get => entryPhoneNumber.Text; set => entryPhoneNumber.Text = value; }

    public string Address { get => entryAddress.Text; set => entryAddress.Text = value; }

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        var validationErrors = new List<string>();
        if (nameValidator.IsNotValid)
        {
            validationErrors.Add("Name is required.");

            //OnError?.Invoke(sender, "Name is required.");
            //return;
        }

        if (emailValidator.IsNotValid)
        {
            foreach (var error in emailValidator.Errors!)
            {
                validationErrors.Add(error!.ToString()!);
            }

            //var errorsJoined = string.Join("\n", emailValidator.Errors!);
            //OnError?.Invoke(sender, errorsJoined);
            //return;
        }

        if (phoneNumberValidator.IsNotValid)
        {
            validationErrors.Add("Phone number is required.");

            //OnError?.Invoke(sender, "Phone number is required.");
            //return;
        }


        if (addressValidator.IsNotValid)
        {
            validationErrors.Add("Address is required.");

            //OnError?.Invoke(sender, "Address is required.");
            //return;
        }

        if (validationErrors.Any())
        {
            OnError?.Invoke(sender, validationErrors);
            return;
        }

        OnSave?.Invoke(sender, e);
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        OnCancel?.Invoke(sender, e);
    }
}