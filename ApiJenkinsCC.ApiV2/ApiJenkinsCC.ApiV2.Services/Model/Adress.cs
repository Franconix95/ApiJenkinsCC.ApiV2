using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiJenkinsCC.ApiV2.Services.Model
{
    public class Adress
    {
        [BsonElement("City")]
        public string City { get; set; }
        [BsonElement("Street")]
        public string Street { get; set; }
        [BsonElement("ZipCode")]
        public string ZipCode { get; set; }
        [BsonElement("Country")]
        public string Country { get; set; }
    }
}
