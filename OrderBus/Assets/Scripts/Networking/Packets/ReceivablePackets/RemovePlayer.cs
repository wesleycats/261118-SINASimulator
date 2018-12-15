using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovePlayer {

    public static void Notify(ReceivablePacket packet)
    {

        long objectId = packet.ReadLong();

        UnityMainThreadDispatcher.Instance().Enqueue(() => PlayerManager.instance.RemovePlayer(objectId));
    }
}
