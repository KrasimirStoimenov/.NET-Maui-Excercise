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

    public string Name { get; init; }

    public string Email { get; init; }

    public string PhoneNumber { get; init; }

    public string Address { get; init; }

    public override string ToString()
    {
        return $"{this.Name}: {this.Email}";
    }
}
