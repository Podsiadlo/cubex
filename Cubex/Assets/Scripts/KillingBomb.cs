using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingBomb : KillingObject {

    [SerializeField]
    private float timeToDestroy = 10.0f;

	// Use this for initialization
	void Start () {
        Debug.Log("Init killing bomb.");
        Destroy(gameObject, timeToDestroy);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Debug.Log("Collision with player!");
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player.removeHealth(damage);
        }
    }

}
