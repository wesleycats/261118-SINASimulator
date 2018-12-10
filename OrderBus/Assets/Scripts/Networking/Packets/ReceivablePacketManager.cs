using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceivablePacketManager {

    public static void handle(ReceivablePacket packet) {

        switch (packet.ReadShort())  {
            case 0:
                PingPlayer.Notify(packet);
                break;
            case 1:
               // AccountAuthenticationResult.notify(packet);
                break;

            case 2:
               // CharacterSelectionInfoResult.notify(packet);
                break;

            case 3:
               // CharacterCreationResult.notify(packet);
                break;

            case 4:
               // CharacterDeletionResult.notify(packet);
                break;

            case 5:
                EnterServerInformation.Notify(packet);
                break;

            case 6:
                PlayerInformation.Notify(packet);
                break;

            case 7:
                //DeleteObject.Notify(packet);
                break;

            case 8:
               // Logout.notify(packet);
                break;

            case 9:
                MoveToLocation.Notify(packet);
                break;

            case 10:
               // ChatResult.notify(packet);
                break;
        }
    }
}