namespace Models.Download.Clans.CurrentRiverRace
{

    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Response
    {
        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("clan")]
        public Clan Clan { get; set; }

        [JsonProperty("clans")]
        public Clan[] Clans { get; set; }

        [JsonProperty("sectionIndex")]
        public long SectionIndex { get; set; }
    }

    public partial class Clan
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("badgeId")]
        public long BadgeId { get; set; }

        [JsonProperty("fame")]
        public long Fame { get; set; }

        [JsonProperty("repairPoints")]
        public long RepairPoints { get; set; }

        [JsonProperty("participants")]
        public Participant[] Participants { get; set; }

        [JsonProperty("clanScore")]
        public long ClanScore { get; set; }

        [JsonProperty("finishTime", NullValueHandling = NullValueHandling.Ignore)]
        public string FinishTime { get; set; }
    }

    public partial class Participant
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("fame")]
        public long Fame { get; set; }

        [JsonProperty("repairPoints")]
        public long RepairPoints { get; set; }

        [JsonProperty("boatAttacks")]
        public long BoatAttacks { get; set; }
    }
}