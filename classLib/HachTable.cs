
namespace cProject.classLib;
public class HachTable
{
    private Item[] items;
    private int size;
    private int count;

    private int initial_size;

    public HachTable(int size)
    {
        items = new Item[size];
        this.size = size;
        this.count = 0;
        this.initial_size = size;

    }
    public void Remove(Key key)
    {
        int hash = HachOne(key);
        Item item = new Item(key);
        if (key == items[hash].key)
        {
            items[hash] = item;
            this.count--;
        }
        else
        {
            Collision collision = new Collision(hash, size);
            collision.CollisionRemove(key, ref items, ref count);

        }
        float capacity = (float)count / size;
        if (capacity < 0.25 && initial_size < size)
        {
            this.size = this.size / 2;
            Item[] arr = new Item[size];
            for (int j = 0; j < size * 2; j++)
            {
                if (items[j].status == 1)
                {
                    hash = HachOne(items[j].key);
                    if (arr[hash].status == 0)
                    {
                        item = new Item(items[j].key, items[j].value);
                        arr[hash] = item;
                        count++;
                    }
                    else
                    {
                        Collision collision = new Collision(hash, size);
                        collision.CollisionAdd(item, ref arr, ref count);
                    }
                }
            }
            items = new Item[size];
            Array.Copy(arr, items, items.Length);

        }
    }
    public void Add(Key key, int value)
    {
        Item item = new Item(key, value);
        int hash = HachOne(key);
        if (items[hash].status == 0)
        {
            items[hash] = item;
            this.count++;
        }
        else
        {
            Collision collision = new Collision(hash, size);
            collision.CollisionAdd(item, ref items, ref count);
        }
        float capacity = (float)count / size;
        if (capacity > 0.75)
        {
            count = 0;
            this.size = this.size * 2;
            Item[] arr = new Item[size];
            for (int j = 0; j < size / 2; j++)
            {
                if (items[j].status == 1)
                {
                    hash = HachOne(items[j].key);
                    if (arr[hash].status == 0)
                    {
                        item = new Item(items[j].key, items[j].value);
                        arr[hash] = item;
                        count++;
                    }
                    else
                    {
                        Collision collision = new Collision(hash, size);
                        collision.CollisionAdd(item, ref arr, ref count);
                    }
                }
            }
            items = new Item[size];
            Array.Copy(arr, items, items.Length);

        }
    }
    public int Search(Key key)
    {
        int hash = HachOne(key);
        if (key == items[hash].key)
        {
            return items[hash].value;
        }
        else
        {
            Collision collision = new Collision(hash, size);
            return collision.CollisionSearch(key, items);
        }
    }
    public void Print()
    {
        for (int j = 0; j < size; j++)
        {
            if (items[j].status == 1)
            {
                Console.WriteLine($"{j}|{items[j].key.key1} {items[j].key.key2} => {items[j].value} |{items[j].status}");
            }
            else
            {
                Console.WriteLine($"{j}|{items[j].status}");
            }

        }

    }
    private int HachOne(Key key)
    {
        string str = key.key1 + key.key2;
        int i = 0;
        for (int j = 0; j < str.Length; j++)
            i += str[j];

        return i % this.size;

    }

}
