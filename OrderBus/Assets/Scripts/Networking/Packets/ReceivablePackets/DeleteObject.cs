using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObject {

    public static void notify(ReceivablePacket packet) {
        long objectId = packet.ReadLong();
        WorldManager.instance.DeleteObject(objectId);
    }
}
