
using System;
using UnityEngine;

public class PlayerInformation {

    public static void notify(ReceivablePacket packet) {

        long objectId = packet.ReadLong();
        int classId = packet.ReadShort();
        string playerName = packet.ReadString();
        float posX = packet.ReadFloat();
        float posY = packet.ReadFloat();
        float posZ = packet.ReadFloat();

        Debug.Log("Player joined");

        //TODO: Manage PlayerInformation
        UnityMainThreadDispatcher.Instance().Enqueue(() => WorldManager.instance.UpdateObject(objectId, classId, posX, posY, posZ));
    }
}
