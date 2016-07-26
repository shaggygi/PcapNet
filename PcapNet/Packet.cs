﻿using System;
using BinarySerialization;

namespace Pcap
{
    public class Packet
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);

        [FieldOrder(0)]
        public uint TimestampSeconds { get; set; }

        [FieldOrder(1)]
        public uint TimestampMicroseconds { get; set; }

        [FieldOrder(2)]
        public uint Length { get; set; }

        [FieldOrder(3)]
        public uint OriginalLength { get; set; }

        [FieldOrder(4)]
        [FieldLength("Length")]
        public byte[] Data { get; set; }

        [Ignore]
        public DateTime Timestamp => Epoch + TimeSpan.FromSeconds(TimestampSeconds) +
                                     TimeSpan.FromMilliseconds((double) TimestampMicroseconds/1000);
    }
}
