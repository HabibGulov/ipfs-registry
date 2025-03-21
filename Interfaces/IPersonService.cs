public interface IPersonService
{
    Task<string> SavePerson(Person person);
    Task<Person> GetPerson(string cid);
}
