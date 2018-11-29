using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JP_Interact : MonoBehaviour {

    private PlayerInput playerInput;
    private Rigidbody2D rigidbody2D;
    private BoxCollider2D boxCollider2D;

    public Vector2 direction;

	// Use this for initialization
	void Start () {
        /*
        playerInput = GetComponent<PlayerInput>();
        playerInput.OnInput += Interact;
        */

        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();


        rigidbody2D.velocity = new Vector2(0, -1);
	}
	
	// Update is called once per frame
	void Update () {
        if (!Input.GetKeyDown(KeyCode.E)) return; 
        Interact(InputActions.Use, 0);
    }

    public void Interact(InputActions action, float axis)
    {
        if (action != InputActions.Use) return;

        float distance = .5F;

        RaycastHit2D[] raycastHits = new RaycastHit2D[10];

        ContactFilter2D filter = new ContactFilter2D()
        {

        };

        int numHits = boxCollider2D.Cast(new Vector2(-1, 0), filter, raycastHits, distance);

        numHits += boxCollider2D.Cast(new Vector2(1, 0), filter, raycastHits, distance);
        numHits += boxCollider2D.Cast(new Vector2(0, 1), filter, raycastHits, distance);
        numHits += boxCollider2D.Cast(new Vector2(0, -1), filter, raycastHits, distance);

        GameObject closestGameObject = null;

        for (int i = 0; i < numHits; i++)
        {
            if (raycastHits[i].collider.isTrigger) continue;

            if (closestGameObject == null)
            {
                closestGameObject = raycastHits[i].collider.gameObject;
                continue;
            }

            if (Vector3.Distance(gameObject.transform.position, closestGameObject.transform.position) > Vector3.Distance(gameObject.transform.position, raycastHits[i].transform.position))
            {
                closestGameObject = raycastHits[i].collider.gameObject;
            }
        }

        if (closestGameObject == null)
        {
            Debug.Log("No object");
        }
        else
        {
            Debug.Log(closestGameObject.name);
        }
    }

    
}
