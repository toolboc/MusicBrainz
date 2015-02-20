﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Hqub.MusicBrainz.API.Entities.Collections;
using System.Threading.Tasks;


namespace Hqub.MusicBrainz.API.Entities
{
    [XmlType(Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    [XmlRoot("artist", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class Artist : Entity
    {
        public const string EntityName = "artist";

        #region Properties

        [XmlAttribute("type")]
        public string ArtistType { get; set; }

        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("sort-name")]
        public string SortName { get; set; }

        [XmlElement("life-span")]
        public LifeSpanNode LifeSpan { get; set; }

        [XmlElement("country")]
        public string Country { get; set; }

        [XmlAttribute("score", Namespace = "http://musicbrainz.org/ns/ext#-2.0")]
        public int Score { get; set; }

        [XmlElement("disambiguation")]
        public string Disambiguation { get; set; }

        [XmlElement("rating")]
        public Rating Rating { get; set; }

        #endregion

        #region Subqueries

        [XmlArray("recording-list", ElementName = "recording-list")]
        [XmlArrayItem("recording")]
        public RecordingList Recordings { get; set; }

        [XmlArray("release-group-list")]
        [XmlArrayItem("release-group")]
        public ReleaseGroupList ReleaseGroups { get; set; }

        [XmlArray("release-list")]
        [XmlArrayItem("release")]
        public ReleaseList ReleaseLists { get; set; }

        [XmlArray("work-list")]
        [XmlArrayItem("work")]
        public WorkList Works { get; set; }

        [XmlArray("tag-list")]
        [XmlArrayItem("tag")]
        public TagList Tags { get; set; }

        #endregion

		#region Static Methods

        [Obsolete("Use GetAsync() method.")]
		public static Artist Get(string id, params string[] inc)
		{
			return GetAsync<Artist>(id, WebRequestHelper.CreateLookupUrl(EntityName,
                id, CreateIncludeQuery(inc))).Result;
		}

        [Obsolete("Use SearchAsync() method.")]
		public static ArtistList Search(string query, int limit = 25, int offset = 0)
		{
			return SearchAsync<Metadata.ArtistMetadataWrapper>(EntityName,
                query, limit, offset).Result.Collection;
		}

		public async static Task<Artist> GetAsync(string id, params string[] inc)
		{
			return await GetAsync<Artist>(id, WebRequestHelper.CreateLookupUrl(EntityName,
                id, CreateIncludeQuery(inc)));
		}

		public async static Task<ArtistList> SearchAsync(string query, int limit = 25, int offset = 0)
		{
            return (await SearchAsync<Metadata.ArtistMetadataWrapper>(EntityName,
                query, limit, offset)).Collection;
		}

        public async static Task<ArtistList> BrowserAsync(string relatedEntity, string value, int limit=25, int offset=0, params  string[] inc)
        {
            return
                (await
                    BrowseAsync<Metadata.ArtistMetadataWrapper>(EntityName, relatedEntity, value,
                        limit, offset, inc)).Collection;
        }

		#endregion
	}

    #region Include entities

    [XmlType(Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    [XmlRoot("life-span", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class LifeSpanNode
    {
        [XmlElement("begin")]
        public string Begin { get; set; }

        [XmlElement("ended")]
        public bool Ended { get; set; }
    }

    #endregion

}
