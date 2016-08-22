namespace EntityProvider
{
    interface EntityPool
    {
        public void store(Entity entity);
        public void fetch(string entityName);
    }
}