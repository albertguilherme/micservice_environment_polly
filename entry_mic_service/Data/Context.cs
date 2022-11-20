using entry_mic_service.Data.Model;
using entry_mic_service.Extensions;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SharpCompress.Common;

namespace entry_mic_service.Data
{
    public class Context
    {
        private string _version = "DEV_0.0";
        private readonly MongoServiceDatabaseSettings _mongoServiceDatabaseSettings;
        private readonly IMongoDatabase _mongoDatabase;

        public Context(IOptionsMonitor<MongoServiceDatabaseSettings> mongoServiceDatabaseSettings)
        {
            _mongoServiceDatabaseSettings = mongoServiceDatabaseSettings.CurrentValue;

            var mongoClient = new MongoClient(_mongoServiceDatabaseSettings.ConnectionString);

            _mongoDatabase = mongoClient.GetDatabase(_mongoServiceDatabaseSettings.DatabaseName);

            Results = _mongoDatabase.GetCollection<Result>($"Result_v{_version}");
            Services = _mongoDatabase.GetCollection<Service>($"Service_v{_version}");
            ServiceResults = _mongoDatabase.GetCollection<ServiceResult>($"ServiceResult_v{_version}");
            ServiceTypes = _mongoDatabase.GetCollection<ServiceType>($"ServiceType_v{_version}");
            Solicitations = _mongoDatabase.GetCollection<Solicitation>($"Solicitation_v{_version}");
        }

        public IMongoCollection<Service> Services { get; internal set; }
        public IMongoCollection<ServiceResult> ServiceResults { get; internal set; }
        public IMongoCollection<Result> Results { get; internal set; }
        public IMongoCollection<ServiceType> ServiceTypes { get; internal set; }
        public IMongoCollection<Solicitation> Solicitations { get; internal set; }

        public IMongoCollection<T> GetCollection<T>() where T : Base
        {
            return _mongoDatabase.GetCollection<T>(typeof(T).FullName);
        }
    }
}
