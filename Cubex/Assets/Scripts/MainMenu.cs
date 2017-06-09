using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    [SerializeField]
    private string firstLevel;
    [SerializeField]
    private bool isStart;
    [SerializeField]
    private bool isQuit;

    void OnMouseUp()
    {
        if (isStart)
        {
            SceneManager.LoadScene(firstLevel);
        }
        if (isQuit)
        {
            Application.Quit();
        }
        GetComponent<Renderer>().material.color = Color.yellow;
    }
}
