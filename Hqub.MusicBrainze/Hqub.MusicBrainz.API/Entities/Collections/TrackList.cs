﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Hqub.MusicBrainz.API.Entities.Collections
{
    [XmlType(Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    [XmlRoot("track-list", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class TrackList : BaseList
    {
        [XmlElement("track")]
        public List<Track> Items { get; set; }
    }
}