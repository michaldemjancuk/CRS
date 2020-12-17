using RestSharp;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace UI
{
	public static class VersionChecker
	{

		private static string downloadUrl = "http://michaldemjancuk.cz/newest.php";

		public static bool ActualVersion()
		{
			try
			{
				string versionString = CheckOnlineVersion();
				var newest = new Version(versionString.Replace("CRS v", string.Empty).Replace(".zip", string.Empty));
				var actual = new Version(GetActualVersion());
				switch (newest.CompareTo(actual))
				{
					case 1:
						return false;
					case 0:
						return true;
					case -1:
						MessageBox.Show("Tvoje verze CRS.exe je novější než na serveru?! WTF?", "Ahaaa?!?", MessageBoxButtons.OK, MessageBoxIcon.Question);
						return true;
					default:
						return false;
				}
			}
			catch
			{
				return false;
			}
		}

		private static string GetActualVersion()
		{
#if DEBUG
			string devPath = @"D:\_MyFiles\Programing\ClashOfClans\UI\bin\Debug\netcoreapp3.1\CRS.exe";
			if (File.Exists(devPath))
				return FileVersionInfo.GetVersionInfo(devPath).FileVersion;
#endif
			if (File.Exists("CRS.exe"))
				return FileVersionInfo.GetVersionInfo("CRS.exe").FileVersion;
			else
				return "0.0.0.0";
		}


		private static string CheckOnlineVersion()
		{
			var client = new RestClient
				(downloadUrl);
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
	}
}
