using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLocationUpdate : SendablePacket {

    public ObjectLocationUpdate(float posX, float posY, float posZ, float time) {

        WriteShort(12); // Packet id.
        WriteDouble(posX); // TODO: WriteFloat
        WriteDouble(posY); // TODO: WriteFloat
        WriteDouble(posZ); // TODO: WriteFloat
        WriteDouble(time); // TODO: WriteFloat
    }
}
