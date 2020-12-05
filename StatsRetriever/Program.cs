using Models.Download.Clans.CurrentRiverRace;
using Models.Download.Clans.Members;
using StatsRetriever.Clans;
using System;

namespace StatsRetriever
{
	public class Program
	{
		
		static void Main(string[] args)
		{
			_Members membersResponse = new Members().GetData();              // Member stats retriever
			Response currentRiverRaceResponse = new CurrentRiverRace().GetData();

			Console.ReadKey();
		}
	}
}
