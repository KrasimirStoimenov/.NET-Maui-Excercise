namespace Contacts.Maui.Models;

public sealed record ContactModel
{
    public ContactModel(int contactId, string name, string email)
    {
        this.ContactId = contactId;
        this.Name = name;
        this.Email = email;
    }

    public int ContactId { get; init; }
    public string Name { get; init; }

    public string Email { get; init; }

    public override string ToString()
    {
        return $"{this.Name}: {this.Email}";
    }
}
