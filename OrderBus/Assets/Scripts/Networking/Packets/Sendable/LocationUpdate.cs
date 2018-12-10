using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationUpdate : SendablePacket {

    public LocationUpdate(float posX, float posY, float posZ, float time) {

        WriteShort(8); // Packet id.
        WriteDouble(posX); // TODO: WriteFloat
        WriteDouble(posY); // TODO: WriteFloat
        WriteDouble(posZ); // TODO: WriteFloat
        WriteDouble(time); // TODO: WriteFloat
    }
}
