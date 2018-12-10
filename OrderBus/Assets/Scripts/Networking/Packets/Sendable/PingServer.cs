using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingServer : SendablePacket {


    public PingServer()
    {
        WriteShort(0); // Packet id
    }
}
