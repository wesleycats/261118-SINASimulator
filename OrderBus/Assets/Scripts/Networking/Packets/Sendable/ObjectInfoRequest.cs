using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInfoRequest : SendablePacket {

    public ObjectInfoRequest(long objectId)
    {
        WriteShort(9); // Packet id.
        WriteLong(objectId);
    }
}
