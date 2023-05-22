
public class Input
{

    public static Ticket[] read(string path)
    {

        StreamReader reader = new StreamReader(path);

        int count = int.Parse(reader.ReadLine()); // Преобразование строку в число

        Ticket[] data = new Ticket[count]; // Создаём массив с размером count

        // Записываем данные в массив
        for (int i = 0; i < count; i++)
        {
            string[] person = reader.ReadLine().Split('/');
            Ticket ticket = new Ticket(person[0], person[1], person[2], person[3]);
            data[i] = ticket;
        }
        return data;
    }

}
