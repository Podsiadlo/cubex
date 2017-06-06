using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class LevelFinished : MonoBehaviour {

    [SerializeField]
    private string nextLevel = "";

    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered finish!");
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Level finished!");
            audioSource.Play();
            StartCoroutine(loadNextLevel());
        }
    }

    private IEnumerator loadNextLevel()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(nextLevel);
    }

}
