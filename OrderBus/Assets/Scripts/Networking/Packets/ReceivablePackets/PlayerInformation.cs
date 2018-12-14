
using System;
using UnityEngine;

public class PlayerInformation {

    public static void Notify(ReceivablePacket packet) {

        long objectId = packet.ReadLong();
        float posX = (float) packet.ReadDouble();
        float posY = (float) packet.ReadDouble();
        float posZ = (float) packet.ReadDouble();

        Debug.Log("Player joined");

        UnityMainThreadDispatcher.Instance().Enqueue(() => PlayerManager.instance.InstansiatePlayer(new Vector3(posX,posY, posZ), objectId));
    }
}
