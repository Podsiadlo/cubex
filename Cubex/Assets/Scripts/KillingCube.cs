using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class KillingCube : KillingObject {

    [SerializeField]
    private float timeToDestroy = 10.0f;

    public AudioSource audioSource;

    void Start () {
        Debug.Log("Init killing bomb.");
        StartCoroutine(destroy());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            audioSource.Play();
            StartCoroutine(killCharacter(player));
        }
    }

    private IEnumerator killCharacter(PlayerController player)
    {
        yield return new WaitForSeconds(0.5f);
        player.kill();
    }

    private IEnumerator destroy()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject, timeToDestroy);
    }

}
