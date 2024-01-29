namespace Contacts.Maui.Repositories;

using Models;

public sealed class ContactsRepository : IContactsRepository
{
    private readonly List<ContactModel> contacts = new()
    {
        new ContactModel(1,"First Contact", "First Email"),
        new ContactModel(2, "Second Contact", "Second Email"),
        new ContactModel(3, "Third Contact", "Third Email"),
    };

    public List<ContactModel> GetAll()
        => this.contacts.ToList();

    public ContactModel? GetContactById(int contactId)
        => this.contacts.FirstOrDefault(x => x.ContactId == contactId);
}
