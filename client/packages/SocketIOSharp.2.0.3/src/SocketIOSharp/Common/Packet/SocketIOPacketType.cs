﻿namespace SocketIOSharp.Common.Packet
{
    public enum SocketIOPacketType
    {
        UNKNOWN = -1,
        CONNECT = 0,
        DISCONNECT = 1,
        EVENT = 2,
        ACK = 3,
        ERROR = 4,
        BINARY_EVENT = 5,
        BINARY_ACK = 6,
        CONTROL = 7,
    }
}
