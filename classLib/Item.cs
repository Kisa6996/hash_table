    public struct Item
    {
        public Key key;
        public int value;
        public int status;

        public Item(Key key, int value)
        {
            this.key = key;
            this.value = value;
            this.status = 1;
        }
        public Item(Key key)
        {
            this.key = null;
            this.value = 0;
            this.status = 2;
        }
    };