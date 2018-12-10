using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterServerInformation {

    public static void Notify(ReceivablePacket packet)
    {

        long objectId = packet.ReadLong();

        Player.instance.objectId = objectId;

        Debug.Log("objectId: " + objectId);
    }
}
