using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager instance;

	[SerializeField]
    private GameObject player;

	private Dictionary<long, GameObject> playersList = new Dictionary<long, GameObject>();


	private void Start()
    {
        instance = this;
    }

    public void InstansiatePlayer (Vector3 position, long objectId) {

        GameObject playerObject = Instantiate(player);

        RemotePlayer remotePlayer = playerObject.GetComponent<RemotePlayer>();

		playerObject.transform.position = position;

        remotePlayer.objectId = objectId;

        playersList.Add(objectId,playerObject);

	}

    public void RemovePlayer(long objectId)
    {
		playersList.Remove(objectId);
		Destroy(playersList[objectId]);
    }

	public GameObject GetPlayer(long objectId)
	{
		return playersList[objectId];
	}
}
