using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleInput {

    public static void Notify(ReceivablePacket packet)
    {
        long objectId = packet.ReadLong();

        int actionId = packet.ReadInt();
        float axis = packet.ReadFloat();

        InputActions action = (InputActions) actionId;

       // UnityMainThreadDispatcher.Instance().Enqueue(() => WorldManager.instance.MoveObject(objectId, posX, posY, posZ, time));
    }
}
