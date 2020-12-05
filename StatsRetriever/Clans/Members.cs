using StatsRetriever.AppData;
using System.Net;
using System.Collections.Specialized;
using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using Models.Download.Clans.Members;
using Newtonsoft.Json;
using System.Linq;

namespace StatsRetriever.Clans
{
	public class Members
	{
		private DownloadConfig _DownloadConfig;

		public Members()
		{
			_DownloadConfig = DownloadConfig.Default;
		}

		public _Members GetData()
		{
			string rawData = SendRequest();
			return ConvertResponse(rawData);
		}

		/// <summary>
		/// Send request on downloading clan members
		/// </summary>
		/// <returns>
		///		- String | Json string response
		/// </returns>
		private string SendRequest()
		{
			var client = new RestClient
				(_DownloadConfig.members_URL
					.Replace("{{CLAN_TAG}}", _DownloadConfig.CLAN_TAG));
			client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", _DownloadConfig._Token));
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

		private _Members ConvertResponse(string rawData)
		{
			return JsonConvert.DeserializeObject<_Members>(rawData);
		}
	}
}
