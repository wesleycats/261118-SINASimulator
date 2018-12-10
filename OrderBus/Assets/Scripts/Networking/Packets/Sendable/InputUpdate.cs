using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputUpdate : SendablePacket {

    public InputUpdate(InputActions inputActions, float axisAmount)
    {
        WriteShort(8); // Packet id.

        WriteInt((int) inputActions);
        WriteDouble(axisAmount); //TODO Write float
    }
}
