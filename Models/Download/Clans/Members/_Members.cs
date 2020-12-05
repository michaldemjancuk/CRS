namespace Models.Download.Clans.Members
{
    using System;
    using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class _Members
    {

        [JsonProperty("items")]
        public Item[] Items { get; set; }

        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("role")]
        public Role Role { get; set; }

        [JsonProperty("lastSeen")]
        public string LastSeen { get; set; }

        [JsonProperty("expLevel")]
        public long ExpLevel { get; set; }

        [JsonProperty("trophies")]
        public long Trophies { get; set; }

        [JsonProperty("arena")]
        public Arena Arena { get; set; }

        [JsonProperty("clanRank")]
        public long ClanRank { get; set; }

        [JsonProperty("previousClanRank")]
        public long PreviousClanRank { get; set; }

        [JsonProperty("donations")]
        public long Donations { get; set; }

        [JsonProperty("donationsReceived")]
        public long DonationsReceived { get; set; }

        [JsonProperty("clanChestPoints")]
        public long ClanChestPoints { get; set; }
    }

    public partial class Arena
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Paging
    {
        [JsonProperty("cursors")]
        public Cursors Cursors { get; set; }
    }

    public partial class Cursors
    {
    }

    public enum Name { ChallengerI, ChallengerIi, ChallengerIii, LegendaryArena, MasterI, MasterIi, MasterIii, Unknown };

    public enum Role { CoLeader, Elder, Leader, Member };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                NameConverter.Singleton,
                RoleConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class NameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Name) || t == typeof(Name?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                default:
                    return Name.Unknown;
            }
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Name)untypedValue;
            switch (value)
            {
                case Name.Unknown:
                    serializer.Serialize(writer, "Unknown");
                    return;
            }
        }

        public static readonly NameConverter Singleton = new NameConverter();
    }

    internal class RoleConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Role) || t == typeof(Role?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "coLeader":
                    return Role.CoLeader;
                case "elder":
                    return Role.Elder;
                case "leader":
                    return Role.Leader;
                case "member":
                    return Role.Member;
            }
            throw new Exception("Cannot unmarshal type Role");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Role)untypedValue;
            switch (value)
            {
                case Role.CoLeader:
                    serializer.Serialize(writer, "coLeader");
                    return;
                case Role.Elder:
                    serializer.Serialize(writer, "elder");
                    return;
                case Role.Leader:
                    serializer.Serialize(writer, "leader");
                    return;
                case Role.Member:
                    serializer.Serialize(writer, "member");
                    return;
            }
            throw new Exception("Cannot marshal type Role");
        }

        public static readonly RoleConverter Singleton = new RoleConverter();
    }
}