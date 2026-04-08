public class SimpleInventory : PersistentSingleton<SimpleInventory>
{
    public int scrap = 0;
    public int shields = 0;

    public bool hasMacGuffin = false;
}
