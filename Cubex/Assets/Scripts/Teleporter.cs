using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    //public AudioSource audioSource;
    [SerializeField]
    private float teleportationX = 0.0f;
    [SerializeField]
    private float teleportationY = 0.0f;
    [SerializeField]
    private float teleportationZ = 0.0f;
    [SerializeField]
    private float rotation = 0.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            //Debug.Log("TP!");
           // audioSource.Play();
            PlayerController player =  other.GetComponent<PlayerController>();
            StartCoroutine(TeleportCharacter(player));
        }
    }

    private IEnumerator TeleportCharacter(PlayerController player)
    {
        yield return new WaitForSeconds(0.2f);
        Vector3 teleportationVector = new Vector3(teleportationX, teleportationY, teleportationZ);
        player.Move(teleportationVector, rotation);
    }
}
