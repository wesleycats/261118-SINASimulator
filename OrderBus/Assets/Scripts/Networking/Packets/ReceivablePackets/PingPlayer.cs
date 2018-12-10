using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPlayer {

    public static void Notify(ReceivablePacket packet) {
        NetworkManager.instance.ChannelSend(new PingServer());
    }
}
