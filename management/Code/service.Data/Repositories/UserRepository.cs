using service.Data.Interfaces;
using service.Entities.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Bindings;
using System;
using System.Collections.Generic;
using System.Text;

namespace service.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IGateway _gateway;
        private string _collectionName = "User";

        public UserRepository(IGateway gateway)
        {
            _gateway = gateway;
        }
        public IEnumerable<User> GetAll()
        {
            var result = _gateway.GetMongoDB().GetCollection<User>(_collectionName)
                            .Find(new BsonDocument())
                            .ToList();
            return result;
        }

        public bool Save(User entity)
        {
            _gateway.GetMongoDB().GetCollection<User>(_collectionName)
                .InsertOne(entity);
            return true;
        }

        public User Update(string id, User entity)
        {
            var update = Builders<User>.Update
                .Set(e => e.username, entity.username )
                .Set(e => e.id, entity.id );

            var result = _gateway.GetMongoDB().GetCollection<User>(_collectionName)
                .FindOneAndUpdate(e => e.Id == id, update);
            return result;
        }

        public bool Delete(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<User>(_collectionName)
                         .DeleteOne(e => e.Id == id);
            return result.IsAcknowledged;
        }
    }
}
