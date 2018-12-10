using Boo.Lang.Runtime.DynamicDispatching;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{

    public GameObject playerCharacter;

    [HideInInspector]
    public static WorldManager instance;
    [HideInInspector]
    ArrayList gameObjects = new ArrayList();
    [HideInInspector]
    private static readonly int visibilityRange = 3000;

    private void Start()
    {

        if (NetworkManager.instance == null) // Offline mode.
        {
            // Set player model to male.


            // Set position.
            playerCharacter.transform.position = new Vector3(0f, 0f, 0f); // Spawn location.
        }
        else // Online mode.
        {
            // Return if account name is empty.
            if (PlayerManager.instance == null || PlayerManager.instance.accountName == null)
            {
                return; // Return to login?
            }

            // Set instance.
            instance = this;

            // Change music.
            //MusicManager.instance.PlayMusic(MusicManager.instance.EnterWorld);

            // Set position.
            playerCharacter.transform.position = new Vector3(PlayerManager.instance.selectedCharacterData.GetX(), PlayerManager.instance.selectedCharacterData.GetY(), PlayerManager.instance.selectedCharacterData.GetZ());

            // Request world info from server.
            NetworkManager.instance.ChannelSend(new EnterServerRequest(PlayerManager.instance.selectedCharacterData.GetName()));

            // Object distance forget task.
            StartCoroutine(DistanceCheck());
        }
    }

    public void UpdateObject(long objectId, int classId, float posX, float posY, float posZ)
    {

        classId = 0;

        // Check for existing objects.
        foreach (GameObject gameObject in gameObjects)
        {
            if (gameObject.GetComponent<WorldObject>().objectId == objectId)
            {
                // TODO: Update object info.
                return;
            }
        }


        // Object does not exist. Instantiate.
        GameObject obj = Instantiate(GameObjectManager.instance.gameObjectList[classId], new Vector3(posX, posY, posZ), Quaternion.identity) as GameObject;

        // TODO: Proper appearance.

        // Assign object id.
        obj.AddComponent<WorldObject>();
        obj.GetComponent<WorldObject>().objectId = objectId;

        // Add to game object list.
        gameObjects.Add(obj);
    }

    public void MoveObject(long objectId, float posX, float posY, float posZ, float time)
    {
        foreach (GameObject gameObject in gameObjects)
        {
            if (gameObject.GetComponent<WorldObject>().objectId == objectId)
            {

                Vector3 toLoc = new Vector3(posX, posY, posZ);

                if (Vector3.Distance(gameObject.transform.position, toLoc) > 10)
                {

                    gameObject.transform.position = toLoc;

                }
                else
                {

                    // gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, toLoc, 40 * Time.deltaTime);

                    UserMovement userMovement = gameObject.GetComponent<UserMovement>();

                    if (userMovement != null)
                    {
                        userMovement.MoveUser(new Vector3(posX, posY, posZ), time);
                    }
                    else
                    {
                        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, toLoc, 40 * Time.deltaTime);
                    }
                }

                Vector3 theScale = transform.localScale;

                if (posX > gameObject.transform.position.x && gameObject.transform.localScale.x < 0)
                {
                    theScale.x *= -1;
                    gameObject.transform.localScale = new Vector2(2, gameObject.transform.localScale.y);
                }
                else if (posX < gameObject.transform.position.x && gameObject.transform.localScale.x > 0)
                {
                    theScale.x *= -1;
                    gameObject.transform.localScale = new Vector2(-2, gameObject.transform.localScale.y);
                }

                return;
            }
        }

        // Request unknown object info from server.
        NetworkManager.instance.ChannelSend(new ObjectInfoRequest(objectId));
    }

    public void DeleteObject(long objectId)
    {
        foreach (GameObject gameObject in gameObjects)
        {
            if (gameObject.GetComponent<WorldObject>().objectId == objectId)
            {
                DeleteObject(gameObject);
                return;
            }
        }
    }

    private void DeleteObject(GameObject gameObject)
    {
        // Remove from objects list.
        gameObjects.Remove(gameObject);

        // Delete game object from world.
        Destroy(gameObject);
    }

    IEnumerator DistanceCheck()
    {
        while (true)
        {
            foreach (GameObject gameObject in gameObjects)
            {
                if (Vector3.Distance(playerCharacter.transform.position, gameObject.transform.position) > visibilityRange)
                {
                    DeleteObject(gameObject);
                }
            }
            yield return new WaitForSeconds(3);
        }
    }
}

