namespace csStorage.Shared;

public class KeyValueModel
{
    public KeyValueModel(string key)
    {
        csKeyValue = key;
    }
    public string csKeyValue { get; set; }
}
