using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingBomb : MonoBehaviour {

    [SerializeField]
    private float timeToDestroy = 10.0f;


	// Use this for initialization
	void Start () {
        Debug.Log("Init killing bomb.");
        Destroy(gameObject, timeToDestroy);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collision type: " + collision.gameObject.name);

        if(collision.gameObject.name == "Player")
        {
            Debug.Log("Collision with player!");
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player.removeHealth(10);
        }
    }

}
