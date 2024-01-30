namespace Contacts.Maui.Models;

public sealed record ContactModel
{
    public ContactModel(int contactId, string name, string email, string phoneNumber, string address)
    {
        this.ContactId = contactId;
        this.Name = name;
        this.Email = email;
        this.PhoneNumber = phoneNumber;
        this.Address = address;
    }

    public int ContactId { get; init; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Address { get; set; }

    public override string ToString()
    {
        return $"{this.Name}: {this.Email}";
    }
}
