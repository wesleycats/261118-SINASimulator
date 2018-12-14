using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public static PlayerManager instance;

    [SerializeField]
    private GameObject player;

    private Dictionary<long, GameObject> playersList = new Dictionary<long, GameObject>();


    private void Start()
    {
        instance = this;
    }

    public void InstansiatePlayer(Vector3 position, long objectId)
    {

        GameObject playerObject = Instantiate(player, position, player.transform.rotation);

        playerObject.GetComponent<WorldObject>().objectId = objectId;

        playersList.Add(objectId, playerObject);

        Debug.Log("Test spawn player");

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

    public void MovePlayer(long objectId, float posX, float posY, float posZ, float time)
    {
        GameObject gameObject = GetPlayer(objectId);

        if (gameObject == null) return;

        Vector3 toLoc = new Vector3(posX, posY, posZ);

        if (Vector3.Distance(gameObject.transform.position, toLoc) > 10)
        {

            gameObject.transform.position = toLoc;

        }
        else
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, toLoc, 1);
        }
    }
}
