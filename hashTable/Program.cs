using cProject.classLib;

namespace cProject.hashtable;
internal class Program
{

    private static void Main(string[] args)
    {
        string path = "input.txt";

        Ticket[] data = Input.read(path);

        int size = data.Length;

        Key key;

        var table = new HachTable(11);

        void output(string key1, string key2)
        {
            key = new Key(key1, key2);
            int index = table.Search(key);
            Console.WriteLine($"{data[index].date} {data[index].name} {data[index].route} {data[index].nameCapitan}");

        }


        // for (int j = 0; j < size; j++)
        // {
        //     key = new Key(data[j].name, data[j].route);
        //     table.Add(key, j);
        // }

        // output("Clarence King", "BN69049");
        Key key1 = new Key("MAA", "N");
        Key key2 = new Key("MNA", "A");
        Key key3 = new Key("ANA", "M");
        Key key4 = new Key("AAN", "M");
        Key key5 = new Key("NAA", "M");
        table.Add(key1, 1);
        table.Add(key2, 2);
        table.Add(key3, 3);
        table.Add(key4, 4);
        table.Remove(key1);
        table.Remove(key3);
        table.Remove(key4);
        table.Remove(key2);
        table.Remove(key1);
        table.Print();


    }
}