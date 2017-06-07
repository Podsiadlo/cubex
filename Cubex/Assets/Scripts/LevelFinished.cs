using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class LevelFinished : MonoBehaviour {

    [SerializeField]
    private string nextLevel = "";
    private bool active = false;

    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered finish!");
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Level finished!");
            if(!active) audioSource.Play();
            active = true;
            StartCoroutine(loadNextLevel());
        }
    }

    private IEnumerator loadNextLevel()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(nextLevel);
    }

}
