using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterServerRequest : SendablePacket {

    public EnterServerRequest(string characterName)
    {
        WriteShort(7); // Packet id.
        WriteString(characterName);
    }
}
