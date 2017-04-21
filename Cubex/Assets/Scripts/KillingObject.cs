using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingObject : MonoBehaviour {

    [SerializeField]
    protected int damage = 10;


    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collision type: " + collision.gameObject.name);

        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Collision with player!");
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player.removeHealth(10);
        }
    }
}
