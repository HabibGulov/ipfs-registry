using Ipfs.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

public class PersonService : IPersonService
{
    private const string IpfsApiUrl = "http://127.0.0.1:5002/api/v0/";
    private readonly IpfsClient ipfs;
    static readonly HttpClient httpClient = new HttpClient();

    public PersonService()
    {
        ipfs = new IpfsClient("http://127.0.0.1:5002");
    }

    public async Task<string> SavePerson(Person person)
    {
        string json = JsonConvert.SerializeObject(person);  
        var file = await ipfs.FileSystem.AddTextAsync(json); 
        return file.Id.ToString(); 
    }

    public async Task<Person> GetPerson(string cid)
    {
        try
        {
            var response = await httpClient.PostAsync($"{IpfsApiUrl}cat?arg={cid}", null);

            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Person>(jsonContent)!;
            }

            throw new Exception($"Failed to retrieve file content");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

}