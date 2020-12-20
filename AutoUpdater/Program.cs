using RestSharp;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.IO.Compression;

namespace AutoUpdater
{
	class Program
	{
		private static string downloadUrl = "http://michaldemjancuk.cz/newest.php";

		static void Main(string[] args)
		{
			string versionString = CheckOnlineVersion();
			var newest = new Version(versionString.Replace("CRS v", string.Empty).Replace(".zip", string.Empty));
			var actual = new Version(GetActualVersion());
			switch (newest.CompareTo(actual))
			{
				case 1:
					Console.WriteLine("Tvoje verze CRS.exe je zastaralá!\nZahajuji aktualizaci...");
					Update(downloadUrl.Replace("newest.php", versionString));
					break;
				case 0:
					Console.WriteLine("Tvoje verze CRS.exe je aktuální!");
					break;
				case -1:
					Console.WriteLine("Tvoje verze CRS.exe je novější než na serveru?! WTF?");
					break;
			}

			Console.WriteLine("Update done");

			Console.ReadLine();
		}

		private static void Update(string fileUrl)
		{
			if (File.Exists("_update.zip"))
				File.Delete("_update.zip");
			if (Directory.Exists("update/"))
				Directory.Delete("update/", true);

			Console.WriteLine(fileUrl);
			using (var client = new WebClient())
			{
				client.DownloadFile(fileUrl, "_update.zip");
			}

			ZipFile.ExtractToDirectory("_update.zip", "update/", true);

			File.Delete("_update.zip");
			foreach (string d in Directory.GetDirectories("update/", "*", SearchOption.AllDirectories))
			{
				Directory.CreateDirectory(d.Replace("update/", string.Empty));
			}
			foreach (string f in Directory.GetFiles("update/", "*.*", SearchOption.AllDirectories))
			{
				try
				{
					if (File.Exists(f.Replace("update/", string.Empty)))
						File.Delete(f.Replace("update/", string.Empty));
					File.Move(f, f.Replace("update/", string.Empty));
				}
				catch(Exception e)
				{
					Console.WriteLine($"Neúspěch:\n'{f}'\n'{e.Message}'\n");
				}
			}

			Directory.Delete("update/", true);

		}

		private static string GetActualVersion()
		{
#if DEBUG
			//string devPath = @"D:\_MyFiles\Programing\ClashOfClans\UI\bin\Debug\netcoreapp3.1\CRS.exe";
			//if (File.Exists(devPath))
			//	return FileVersionInfo.GetVersionInfo(devPath).FileVersion;
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
