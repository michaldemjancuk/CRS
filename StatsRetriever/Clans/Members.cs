using System.Net;
using RestSharp;
using Models.Download.Clans.Members;
using Newtonsoft.Json;

namespace StatsRetriever.Clans
{
	public class Members
	{

		public Members()
		{
		}

		public _Members GetData(string clanTag)
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
				("http://michaldemjancuk.cz/CRS/GetClanInfo.php?ClanTag=" + clanTag);
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

		private _Members ConvertResponse(string rawData)
		{
			return JsonConvert.DeserializeObject<_Members>(rawData);
		}
	}
}
