
using System;
using UnityEngine;

public class PlayerInformation {

    public static void Notify(ReceivablePacket packet) {

        long objectId = packet.ReadLong();
        float posX = packet.ReadFloat();
        float posY = packet.ReadFloat();
        float posZ = packet.ReadFloat();

        Debug.Log("Player joined");

		PlayerManager.instance.InstansiatePlayer(new Vector3(posX,posY), objectId);
    }
}
