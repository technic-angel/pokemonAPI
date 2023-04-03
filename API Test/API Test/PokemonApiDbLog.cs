using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API_Test
{
	public class PokemonApiDbLog
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]

        [BsonElement("ts")] 
        


        public string Id { get; set; }
        public BsonTimestamp TimeStamp { get; set; }
        public string StatusCode { get; set; }
        public string Data { get; set; }

    }
}

