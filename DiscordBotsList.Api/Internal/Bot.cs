﻿using DiscordBotsList.Api.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DiscordBotsList.Api.Internal
{
    public class Bot : Entity, IDblBot
    {
        internal DiscordBotListApi api;

        [JsonPropertyName("lib")] public string library { get; set; }

        [JsonPropertyName("prefix")] public string prefix { get; set; }

        [JsonPropertyName("shortDesc")] public string shortDescription { get; set; }

        [JsonPropertyName("longDesc")] public string longDescription { get; set; }

        [JsonPropertyName("tags")] public List<string> tags { get; set; }

        [JsonPropertyName("website")] public string websiteUrl { get; set; }

        [JsonPropertyName("support")] public string SupportInviteCode { get; set; }

        [JsonPropertyName("github")] public string githubUrl { get; set; }

        [JsonPropertyName("owners")] public List<ulong> owners { get; set; }

        [JsonPropertyName("invite")] public string customInvite { get; set; }

        [JsonPropertyName("date")] public DateTime approvedAt { get; set; }

        [JsonPropertyName("certified")] public bool certified { get; set; }

        [JsonPropertyName("vanity")] public string vanity { get; set; }

        [JsonPropertyName("points")] public int points { get; set; }

        public string VanityTag => vanity;

        public DateTime ApprovedAt => approvedAt;

        public string GithubUrl => githubUrl;

        public string InviteUrl => customInvite ?? $"https://discord.com/oauth2/authorize?&client_id={Id}&scope=bot";

        public bool IsCertified => certified;

        public string LibraryUsed => library;

        public string LongDescription => longDescription;

        public string PrefixUsed => prefix;

        public List<ulong> OwnerIds => owners.ToList();

        public int Points => points;

        public string ShortDescription => shortDescription;

        public List<string> Tags => tags.ToList();

        public string SupportUrl => "https://discord.gg/" + SupportInviteCode;
        public string VanityUrl => "https://top.gg/bot/" + vanity;

        public string WebsiteUrl => websiteUrl;

        public async Task<IDblBotStats> GetStatsAsync()
        {
            return await api.GetBotStatsAsync(Id);
        }
    }
}