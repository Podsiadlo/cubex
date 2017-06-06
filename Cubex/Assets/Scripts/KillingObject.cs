using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingObject : MonoBehaviour {

    [SerializeField]
    protected int damage = 10;

    protected void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Collision with player!");
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player.kill();
        }
    }
}
