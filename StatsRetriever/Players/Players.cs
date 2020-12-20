using Models.Download.Players;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace StatsRetriever.Players
{

	public class Players
	{

		public Players()
		{
		}

		public _Players GetData(string playerTag)
		{
			string rawData = SendRequest(playerTag);
			return ConvertResponse(rawData);
		}

		/// <summary>
		/// Send request on downloading clan members
		/// </summary>
		/// <returns>
		///		- String | Json string response
		/// </returns>
		private string SendRequest(string playerTag)
		{
			var client = new RestClient
				("http://michaldemjancuk.cz/CRS/GetPlayerInfo.php?PlayerTag=" + (playerTag.StartsWith('#') ? playerTag.Remove(0, 1) : playerTag));
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

		private _Players ConvertResponse(string rawData)
		{
			return JsonConvert.DeserializeObject<_Players>(rawData);
		}
	}
}
