using Models.Download.Players;
using Newtonsoft.Json;
using RestSharp;
using StatsRetriever.AppData;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace StatsRetriever.Players
{

	public class Players
	{
		private DownloadConfig _DownloadConfig;

		public Players()
		{
			_DownloadConfig = DownloadConfig.Default;
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
				(_DownloadConfig.playersInfo_URL
					.Replace("{{PLAYER_TAG}}", playerTag.StartsWith('#') ? playerTag.Remove(0,1) : playerTag));
			client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", _DownloadConfig._Token));
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
