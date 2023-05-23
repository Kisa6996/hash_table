    public struct Item
    {
        public int key;
        public string value;
        public int status;

        public int hash1;

        public int k;

        public Item(int key, string value, int hash)
        {
            this.k = 0;
            this.hash1 = hash;
            this.key = key;
            this.value = value;
            this.status = 1;
        }
        public Item(int key)
        {
            this.key = 0;
            this.value = "";
            this.status = 2;
        }
    };