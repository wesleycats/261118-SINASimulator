using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mr_Interaction : MonoBehaviour {

    private float castRange;
    private float castSpeed;
    private bool castHitDetect;

    Collider castCollider;
    RaycastHit castHit;


    void Start () {
        castCollider = GetComponent<Collider>();
        castRange = 10f;
        castSpeed = 20f;
	}
	
	void FixedUpdate () {
        castHitDetect = Physics.BoxCast(castCollider.bounds.center, transform.localScale, transform.forward, out castHit, transform.rotation, castRange);
        if (castHitDetect)
        {
            Debug.Log("Hit : " + castHit.collider.name);
        }
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        if (castHitDetect)
        {
            Gizmos.DrawRay(transform.position, transform.forward * castRange);
            Gizmos.DrawWireCube(transform.position + transform.forward * castRange, transform.localScale);
        } else
        {
            Gizmos.DrawRay(transform.position, transform.forward * castRange);
            Gizmos.DrawWireCube(transform.position + transform.forward * castRange, transform.localScale);
        }
    }
}
