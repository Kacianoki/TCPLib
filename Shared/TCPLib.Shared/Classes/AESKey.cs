﻿// This file uses Protocol Buffers from Google, which is licensed under BSD-3-Clause.

using Google.Protobuf;
using TCPLib.Net;
using System.Linq;

namespace TCPLib.Classes
{
    public struct AESKey : IProtobufSerializable<AESKey>
    {
        public byte[] Key;
        public byte[] IV;

        public AESKey FromBytes(byte[] bytes)
        {
            var aes = Protobuf.AESKey.Parser.ParseFrom(bytes);

            return new AESKey() { Key = aes.Key.ToArray(), IV = aes.IV.ToArray() };
        }

        public byte[] ToByteArray() =>
            new Protobuf.AESKey() { Key = ByteString.CopyFrom(Key), IV = ByteString.CopyFrom(IV) }.ToByteArray();

    }
}
