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

        var table = new HachTable(10);
        table.Add(0, "Толя");
        table.Remove(0, "Толя");
        table.Add(1, "Толя");
        table.Remove(1, "Толя");
        table.Add(2, "Петя");
        table.Remove(2, "Петя");
        table.Add(3, "Вася");
        table.Remove(3, "Вася");
        table.Add(4, "Толя");
        table.Remove(4, "Толя");
        table.Add(5, "Толя");
        table.Remove(5, "Толя");
        table.Add(6, "Петя");
        table.Remove(6, "Петя");
        table.Add(7, "Вася");
        table.Remove(7, "Вася");
        table.Add(8, "Вася");
        table.Remove(8, "Вася");
        table.Add(9, "Вася");
        table.Remove(9, "Вася");
        table.Add(9, "Вася");

        table.Print();

        // void output(string key1, string key2)
        // {
        //     key = new Key(key1, key2);
        //     int index = table.Search(key);
        //     Console.WriteLine($"{data[index].date} {data[index].name} {data[index].route} {data[index].nameCapitan}");

        // }


        // for (int j = 0; j < size; j++)
        // {
        //     key = new Key(data[j].name, data[j].route);
        //     table.Add(key, j);
        // }

        // output("Clarence King", "BN69049");


    }
}