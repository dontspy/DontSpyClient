﻿using DontSpy.Interfaces;
using DontSpy.Utils;
using Newtonsoft.Json;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace DontSpy.Model
{
    [Table("Message")]
    public class Message : IEntity
    {
        [PrimaryKey, Unique, Column("id"), MaxLength(40), JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [ForeignKey(typeof(Channel)), Column("channelId"), MaxLength(40), JsonProperty(PropertyName = "receivingChannel")]
        public string ChannelId { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All), JsonIgnore]
        public Channel Channel { get; set; }

        [Column("messageHeader"), MaxLength(65535), JsonProperty(PropertyName = "messageHeader")]
        public string MessageHeader { get; set; }

        [Column("timestamp"), MaxLength(11), JsonProperty(PropertyName = "timestamp")]
        public int Timestamp { get; set; }

        [Column("message"), JsonProperty(PropertyName = "message")]
        public string Text { get; set; }

        [Column("processingCounter"), MaxLength(11), JsonProperty(PropertyName = "processingCounter")]
        public int ProcessingCounter { get; set; }

        public Message()
        {
        }

        public Message(string messageHeader, string message)
        {
            Id = IdentifierCreator.UniqueDigits();
            MessageHeader = messageHeader;
            Timestamp = TimeManagement.UnixTimestampNow;
            Text = message;
            ProcessingCounter = 0;
        }
    }
}
