namespace Contacts.Maui.Repositories;

using Models;

public interface IContactsRepository
{
    public List<ContactModel> GetAll();

    public ContactModel? GetContactById(int contactId);
}
