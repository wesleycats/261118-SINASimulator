using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterServerRequest : SendablePacket {

    public EnterServerRequest()
    {
        WriteShort(7); // Packet id.

        Vector3 position = NetworkManager.instance.gameObject.transform.position;

        WriteDouble(position.x);
        WriteDouble(position.y);
        WriteDouble(position.z);

    }
}
