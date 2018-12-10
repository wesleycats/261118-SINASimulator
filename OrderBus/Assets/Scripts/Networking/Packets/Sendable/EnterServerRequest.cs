using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterServerRequest : SendablePacket {

    public EnterServerRequest()
    {
        WriteShort(7); // Packet id.
    }
}
