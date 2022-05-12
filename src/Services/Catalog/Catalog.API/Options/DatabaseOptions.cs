namespace Catalog.API.Options
{
    public class DatabaseOptions
    {
        public static DatabaseOptions _Current;
        public DatabaseOptions()
        {
            _Current = this;
        }

        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        public string CollectionName { get; set; }
    }
}
