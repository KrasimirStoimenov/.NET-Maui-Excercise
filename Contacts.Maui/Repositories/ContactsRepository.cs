namespace Contacts.Maui.Repositories;

using Models;

public sealed class ContactsRepository : IContactsRepository
{
    private readonly List<ContactModel> contacts = new()
    {
        new ContactModel(1,"First Contact", "First@email.com", "123456789", "FirstAddress"),
        new ContactModel(2, "Second Contact", "Second@email.com", "987654321", "SecondAddress"),
        new ContactModel(3, "Third Contact", "Third@email.com", "147258396",  "ThirdAddress"),
    };

    public List<ContactModel> GetAll()
        => this.contacts.ToList();

    public ContactModel? GetContactById(int contactId)
        => this.contacts.FirstOrDefault(x => x.ContactId == contactId);
}
