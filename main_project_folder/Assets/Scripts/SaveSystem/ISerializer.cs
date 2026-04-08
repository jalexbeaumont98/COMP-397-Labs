public interface ISerializer
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    string Serialize<T>(T obj); //this will receive the obj and serialize it

    T Deserialize<T>(string json);

}
