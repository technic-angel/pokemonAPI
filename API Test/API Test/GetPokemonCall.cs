using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;
using MongoDB.Driver;




namespace API_Test
{
	public class GetPokemonCall
	{
		static string connectionString = "mongodb://127.0.0.1:27017";
		static string databaseName = "pokemon_log_db";
		static string logName = "log";


        static HttpClient client = new HttpClient();
		static MongoClient clientDb = new MongoClient("mongodb://127.0.0.1:27017");

        static public async Task<string> GetPokemon(string pokemon)
		{
			HttpResponseMessage response = await client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{pokemon}");
			string result = await response.Content.ReadAsStringAsync();

            IMongoDatabase db = clientDb.GetDatabase(databaseName);
			var collection = db.GetCollection<PokemonApiDbLog>(logName);

			var log = new PokemonApiDbLog { StatusCode = response.StatusCode.ToString(), Data = result };

			collection.InsertOne(log);

            return await response.Content.ReadAsStringAsync();
		}
	}
}

