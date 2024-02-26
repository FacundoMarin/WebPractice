namespace TodoApi;

public class Client(string name, string surname, string adress)
{
    public long Id { get; set; }
    public string Name { get; set; } = name;
    public string Surname { get; set; } = surname;
    public string Adress { get; set; } = adress;
}
