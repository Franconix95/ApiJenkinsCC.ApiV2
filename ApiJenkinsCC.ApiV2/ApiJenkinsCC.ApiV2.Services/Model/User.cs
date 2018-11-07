using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiJenkinsCC.ApiV2.Services.Model
{
    public class User
    {
        [BsonElement("Id")]
        public string Id { get; set; }
        [BsonElement("Firstname")]
        public string Firstname { get; set; }
        [BsonElement("Lastname")]
        public string Lastname { get; set; }
        [BsonElement("Adress")]
        public Adress Adress { get; set; }

    }
}
