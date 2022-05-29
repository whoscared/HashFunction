namespace Hash.HashFunctions
{
    class HashTableElement
    {
        public string name;
        public bool presence = false;

        public HashTableElement (string name)
        {
            this.name = name;
            presence = true;
        }

        public HashTableElement()
        {
            name = "";

        }

        public void Delete()
        {
            name = "";
            presence = true;
        }
    }
}
