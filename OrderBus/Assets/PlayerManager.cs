using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager instance;

    public GameObject player;

    public List<GameObject> playersList;

    private void Start()
    {
        playersList = new List<GameObject>();
        instance = this;
    }

    public void InstansiatePlayer (Vector3 position, long objectId) {

        GameObject playerObject = Instantiate(player);

        RemotePlayer remotePlayer = playerObject.GetComponent<RemotePlayer>();

        remotePlayer.objectId = objectId;

        playersList.Add(playerObject);

	}

    public void RemovePlayer()
    {

    }
}
