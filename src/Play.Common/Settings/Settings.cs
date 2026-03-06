namespace Play.Common.Settings
{
    public class MongoDbSettings
    {
        //since the value of Host and Port is not expected to change during the execution of the application, we can use init only properties
        public string? Host { get; init; }
        public int Port { get; init; }
        public string ConnectionString => $"mongodb://{Host}:{Port}";
    }

    public class ServiceSettings
    {
        public string? Name { get; set; }
    }

    public class RabbitMqSettings
    {
        public string? Host { get; init; } //init so that it cant bre changed after initialization, but can be set during object creation
    }
}