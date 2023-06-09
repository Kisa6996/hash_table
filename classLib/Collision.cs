public class Collision
{
    private int flag;
    private int index;

    private int hash_2;
    private int j;

    private int hash;
    private int k;

    private int size;
    private int Prime(int index)
    {
        for (int i = 2; i < index; i++)
        {
            if (index % i != 0)
            {
                return i;
            }
        }
        return -1;

    }
    public Collision(int hash, int size)
    {
        flag = 1;
        hash_2 = 0;
        j = 1;
        index = hash;
        this.hash = hash;
        this.size = size;
        this.k = Prime(size);

    }
    private int HachTwo(int j)
    {
        return (hash + j * k) % this.size;
    }
    public void CollisionAdd(Item item, ref Item[] items, ref int count)
    {
        while (items[index].status != 0 && flag != 0)
        {
            // Ячейка занята
            if (items[index].status == 1)
            {
                // Сравниваем их ключи
                if (item.key == items[index].key)
                {
                    flag = 0;
                }

            }
            // Ячейка свободна
            else
            {
                // Если встретился статус 2, запоминаем его
                if (flag == 1)
                {
                    hash_2 = index;
                    flag = 2;
                }

            }
            // Двигаемся дальше
            if (flag != 0)
            {
                index = HachTwo(j);
                j++;
            }

        }
        if (flag == 1)
        {
            Item item_1 = new Item(item.key, item.value);
            items[index] = item_1;
            count++;
        }
        if (flag == 2)
        {
            Item item_1 = new Item(item.key, item.value);
            items[hash_2] = item_1;
            count++;
        }

    }
    public int CollisionSearch(Key key, Item[] items)
    {
        while (items[index].status != 0 && flag == 1)
        {
            if (key == items[index].key)
            {
                flag = 0;
                hash_2 = index;
            }
            else
            {
                index = HachTwo(j);
                j++;
            }
        }
        if (flag == 0)
        {
            return items[hash_2].value;
        }
        else
        {
            return -1;
        }
    }

    public void CollisionRemove(Key key, ref Item[] items, ref int count)
    {
        while (items[index].status != 0 && flag == 1)
        {
            if (key == items[index].key)
            {
                flag = 0;
                hash_2 = index;
            }
            else
            {
                index = HachTwo(j);
                j++;
            }
        }
        if (flag == 0)
        {
            Item item_1 = new Item(key);
            items[hash_2] = item_1;
            count--;
        }
    }
}