using System.Net;
using RestSharp;
using Newtonsoft.Json;
using Models.Download.Clans.CurrentRiverRace;

namespace StatsRetriever.Clans
{
	public class CurrentRiverRace
	{

		public CurrentRiverRace()
		{
		}

		public Response GetData(string clanTag)
		{
			string rawData = SendRequest(clanTag);
			return ConvertResponse(rawData);
		}

		/// <summary>
		/// Send request on downloading clan members
		/// </summary>
		/// <returns>
		///		- String | Json string response
		/// </returns>
		private string SendRequest(string clanTag)
		{
			var client = new RestClient
				("http://michaldemjancuk.cz/CRS/GetCurrentCW.php?ClanTag=" + clanTag);
			// client.Authenticator = new HttpBasicAuthenticator(username, password);
			var request = new RestRequest();
			var response = client.Get(request);
			switch (response.StatusCode)
			{
				case HttpStatusCode.OK:
					return response.Content;
				default:
					throw new HttpListenerException();
			}
		}

		private Response ConvertResponse(string rawData)
		{
			return JsonConvert.DeserializeObject<Response>(rawData);
		}
	}
}
