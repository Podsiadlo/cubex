using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingCubeSpawner : MonoBehaviour {

    #region Inspector Variables
    [SerializeField]
    private GameObject _CubePrefab;
    [SerializeField]
    private float spawningRate = 5.0f;
    #endregion Inspector Variables

    // Use this for initialization
    void Start () {
        Debug.Log("Initialized KillingCube spawner");
        InvokeRepeating("spawnBall", 2.0f, spawningRate);
    }

    private void spawnBall()
    {
        Debug.Log("Spawning a ball");
        GameObject ballPrefab = Instantiate(_CubePrefab) as GameObject;

        //default initialization is like 2.0f higher than current "ground" object
        //so we need to add some
        Vector3 newPosition = new Vector3(
            transform.position.x,
            transform.position.y + 10.0f,
            transform.position.z
            );

        ballPrefab.transform.position = newPosition;
    }

}
