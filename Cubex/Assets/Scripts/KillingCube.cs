using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingCube : MonoBehaviour {

    [SerializeField]
    private float timeToDestroy = 10.0f;

    // Use this for initialization
    void Start () {
        Debug.Log("Init killing bomb.");
        Destroy(gameObject, timeToDestroy);
    }

}
