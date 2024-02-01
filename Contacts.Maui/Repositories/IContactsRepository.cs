namespace Contacts.Maui.Repositories;

using Models;

public interface IContactsRepository
{
    public List<ContactModel> GetAll();

    public ContactModel? GetContactById(int contactId);

    public void AddContact(ContactModel contact);

    public void UpdateContact(int contactId, ContactModel contact);

    public void DeleteContact(int contactId);

    public int GetMaxIdValue();
}
