using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Finish : MonoBehaviour {

    [SerializeField]
    private string nextLevel = "";

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered finish!");
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Level finished!");
            SceneManager.LoadScene(nextLevel);
        }
    }

}
