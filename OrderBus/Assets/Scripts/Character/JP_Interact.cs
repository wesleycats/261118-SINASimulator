﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JP_Interact : MonoBehaviour {

    private PlayerInput playerInput;
    private BoxCollider2D boxCollider2D;

    private ContactFilter2D filter;
    private float distance;

    // Use this for initialization
    void Start () {
        /*
        playerInput = GetComponent<PlayerInput>();
        playerInput.OnInput += Interact;
        */

        boxCollider2D = GetComponent<BoxCollider2D>();

        distance = .5f;

        filter = new ContactFilter2D
        {
            useLayerMask = true
        };

        filter.SetLayerMask(LayerMask.GetMask("Interactable"));
	}
	
	// Update is called once per frame
	void Update () {

        /* // INPUT
        if (!Input.GetKeyDown(KeyCode.E)) return; 
        Interact(InputActions.Use, 0);
        */
    }

    public void Interact(InputActions action, float axis)
    {
        if (action != InputActions.Use) return;

        RaycastHit2D[] raycastHits = new RaycastHit2D[10];

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

        if (closestGameObject != null)
        {
            //Debug.Log(closestGameObject.name);

            closestGameObject.GetComponent<JP_Interactable>().Use();
        }
    }

    
}