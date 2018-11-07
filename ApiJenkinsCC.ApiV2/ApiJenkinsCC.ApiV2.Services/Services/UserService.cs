using AutoMapper;
using ApiJenkinsCC.ApiV2.API.Common.Settings;
using ApiJenkinsCC.ApiV2.Services.Contracts;
using ApiJenkinsCC.ApiV2.Services.Model;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace ApiJenkinsCC.ApiV2.Services
{
    public class UserService : IUserService
    {
        private string _connectionString = string.Empty;
        private string _databasename = string.Empty;
        private readonly IMapper _mapper;

        public UserService(IOptions<AppSettings> settings, IMapper mapper)
        {
            _connectionString = settings?.Value?.ConnectionString;
            _databasename = settings?.Value?.DatabaseName;
            _mapper = mapper;
        }

        public Task<string> CreateAsync(User user)
        {

            var client = new MongoClient(new MongoUrl(_connectionString));
            client.StartSession();
            var collection = client.GetDatabase(_databasename).GetCollection<User>("Users");
            collection.InsertOne(user);

            return Task.FromResult<string>("Ok");
        }

        public Task<bool> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(string id)
        {
            var client = new MongoClient(new MongoUrl(_connectionString));
            client.StartSession();
            //var userL = client.GetDatabase(_databasename).GetCollection<User>("Users").FindAsync(u=>u.Id == id);
            var userL = client.GetDatabase(_databasename).GetCollection<User>("Users").Find(u => u.Id == id);
            User user = userL.ToList().Find(u => u.Id == id);

            return Task.FromResult<User>(user);
        }
    }
}
