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
    {

        var contact = this.contacts.FirstOrDefault(x => x.ContactId == contactId);
        if (contact != null)
        {
            //Returning new ContactModel cuz we are using InMemory collection and pass the contact by reference but we don't want this.
            return new ContactModel(contact.ContactId, contact.Name, contact.Email, contact.PhoneNumber, contact.Address);
        }

        return null;
    }

    public void AddContact(ContactModel contact)
        => this.contacts.Add(contact);

    public void UpdateContact(int contactId, ContactModel contact)
    {
        if (contactId != contact.ContactId)
        {
            return;
        }

        var contactToUpdate = this.contacts.FirstOrDefault(x => x.ContactId == contactId);
        if (contactToUpdate != null)
        {
            //TODO: Use AutoMapper
            contactToUpdate.Name = contact.Name;
            contactToUpdate.Email = contact.Email;
            contactToUpdate.PhoneNumber = contact.PhoneNumber;
            contactToUpdate.Address = contact.Address;
        }
    }
    public void DeleteContact(int contactId)
    {
        var contact = this.contacts.FirstOrDefault(x => x.ContactId == contactId);
        if (contact != null)
        {
            this.contacts.Remove(contact);
        }
    }

    public int GetMaxIdValue()
        => this.contacts.Any() ? this.contacts.Max(x => x.ContactId) : 0;
}
