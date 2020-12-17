using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Download.Players
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Clan
    {
        public string tag { get; set; }
        public string name { get; set; }
        public int badgeId { get; set; }
    }

    public class Arena
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class CurrentSeason
    {
        public int trophies { get; set; }
        public int bestTrophies { get; set; }
    }

    public class PreviousSeason
    {
        public string id { get; set; }
        public int trophies { get; set; }
        public int bestTrophies { get; set; }
    }

    public class BestSeason
    {
        public string id { get; set; }
        public int trophies { get; set; }
    }

    public class LeagueStatistics
    {
        public CurrentSeason currentSeason { get; set; }
        public PreviousSeason previousSeason { get; set; }
        public BestSeason bestSeason { get; set; }
    }

    public class Badge
    {
        public string name { get; set; }
        public int progress { get; set; }
        public int? level { get; set; }
        public int? maxLevel { get; set; }
        public int? target { get; set; }
    }

    public class Achievement
    {
        public string name { get; set; }
        public int stars { get; set; }
        public int value { get; set; }
        public int target { get; set; }
        public string info { get; set; }
        public object completionInfo { get; set; }
    }

    public class IconUrls
    {
        public string medium { get; set; }
    }

    public class Card
    {
        public string name { get; set; }
        public int id { get; set; }
        public int level { get; set; }
        public int maxLevel { get; set; }
        public int count { get; set; }
        public IconUrls iconUrls { get; set; }
    }

    public class IconUrls2
    {
        public string medium { get; set; }
    }

    public class CurrentDeck
    {
        public string name { get; set; }
        public int id { get; set; }
        public int level { get; set; }
        public int maxLevel { get; set; }
        public int count { get; set; }
        public IconUrls2 iconUrls { get; set; }
    }

    public class IconUrls3
    {
        public string medium { get; set; }
    }

    public class CurrentFavouriteCard
    {
        public string name { get; set; }
        public int id { get; set; }
        public int maxLevel { get; set; }
        public IconUrls3 iconUrls { get; set; }
    }

    public class _Players
    {
        public string tag { get; set; }
        public string name { get; set; }
        public int expLevel { get; set; }
        public int trophies { get; set; }
        public int bestTrophies { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int battleCount { get; set; }
        public int threeCrownWins { get; set; }
        public int challengeCardsWon { get; set; }
        public int challengeMaxWins { get; set; }
        public int tournamentCardsWon { get; set; }
        public int tournamentBattleCount { get; set; }
        public string role { get; set; }
        public int donations { get; set; }
        public int donationsReceived { get; set; }
        public int totalDonations { get; set; }
        public int warDayWins { get; set; }
        public int clanCardsCollected { get; set; }
        public Clan clan { get; set; }
        public Arena arena { get; set; }
        public LeagueStatistics leagueStatistics { get; set; }
        public List<Badge> badges { get; set; }
        public List<Achievement> achievements { get; set; }
        public List<Card> cards { get; set; }
        public List<CurrentDeck> currentDeck { get; set; }
        public CurrentFavouriteCard currentFavouriteCard { get; set; }
    }
}
