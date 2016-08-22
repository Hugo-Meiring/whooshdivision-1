namespace EntityProvider
{
    interface EntityPool
    {
        public void store(ref Entity entity);
        public void fetch(ref string entityName);
    }
}