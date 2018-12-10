
using System;
using UnityEngine;

public class PlayerInformation {

    public static void Notify(ReceivablePacket packet) {

        long objectId = packet.ReadLong();
        float posX = packet.ReadFloat();
        float posY = packet.ReadFloat();
        float posZ = packet.ReadFloat();

        Debug.Log("Player joined");

        //TODO: Manage PlayerInformation
        //UnityMainThreadDispatcher.Instance().Enqueue(() => UnityEngine.XR.WSA.WorldManager.instance.UpdateObject(objectId, classId, posX, posY, posZ));
    }
}
