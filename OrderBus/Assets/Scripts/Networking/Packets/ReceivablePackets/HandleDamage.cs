using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDamage {

    public static void Notify(ReceivablePacket packet)
    {
        int health = packet.ReadInt();


        HealthDisplay.instance.SetLives(health);

    }
}
