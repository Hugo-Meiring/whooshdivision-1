namespace EntityProvider
{
    interface EntityPool
    {
        public void store(ref Entity entity);
        public ref Entity fetch(ref string entityName);
    }
}