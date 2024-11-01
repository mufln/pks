namespace pks_sem3;
class Client
{
    private int _clientId;
    private static int _id;
    private string _name;
    private int _phoneNumber;

    public Client(string name, int phoneNumber)
    {
        _name = name;
        _phoneNumber = phoneNumber;
        _clientId = GetId();
    }

    private int GetId()
    {
        _id++;
        return _id;
    }
    public string GetName()
    {
        return _name;
    }
    
    public int GetPhoneNumber()
    {
        return _phoneNumber;
    }
    public string GetFormattedProperties()
    {
        return string.Format("ID:{0}, {1}, {2}", _clientId, _name, _phoneNumber);
    }
    
    public static Client GenerateClients()
    {
        List<string> names = [];
        List<string> surnames = [];
        names.Add("Aboba");
        names.Add("Biba");
        names.Add("Boba");
        names.Add("Petya");
        names.Add("Vanya");
        surnames.Add("Abobovich");
        surnames.Add("Bibovich");
        surnames.Add("Bobovich");
        surnames.Add("Petich");
        surnames.Add("Vanich");
        Random random = new Random();
        int nameIndex = random.Next(0, names.Count);
        int surnameIndex = random.Next(0, surnames.Count);
        int phoneNumber = random.Next(100000000, 999999999);
        return new Client(names[nameIndex] + " " + surnames[surnameIndex], phoneNumber);
    }
}

