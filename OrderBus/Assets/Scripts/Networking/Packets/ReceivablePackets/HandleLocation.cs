using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleLocation : SendablePacket {

    public static void Notify(ReceivablePacket packet)
    {
        long objectId = packet.ReadLong();

        float posX = (float) packet.ReadDouble();
        float posY = (float) packet.ReadDouble();
        float posZ = (float) packet.ReadDouble();
        float time = (float) packet.ReadDouble();

        UnityMainThreadDispatcher.Instance().Enqueue(() => PlayerManager.instance.MovePlayer(objectId, posX, posY, posZ, time));
    }
}
