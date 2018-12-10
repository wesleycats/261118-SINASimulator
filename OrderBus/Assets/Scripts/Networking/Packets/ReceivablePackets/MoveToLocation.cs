using UnityEngine;

public class MoveToLocation {

    public static void Notify(ReceivablePacket packet) {
        long objectId = packet.ReadLong();

        float posX = packet.ReadFloat();
        float posY = packet.ReadFloat();
        float posZ = packet.ReadFloat();
        float time = packet.ReadFloat();

        UnityMainThreadDispatcher.Instance().Enqueue(() => WorldManager.instance.MoveObject(objectId, posX, posY, posZ, time));
    }
}