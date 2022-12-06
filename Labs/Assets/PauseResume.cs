using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseResume : MonoBehaviour
{
    [SerializeField] GameObject[] pauseModeObjects;
    //public bool isPaused = false;
    [SerializeField] GameObject[] resumeModeObjects;
    // Start is called before the first frame update
    void Start()
    {
        pauseModeObjects = GameObject.FindGameObjectsWithTag("ShowWhenPaused");
        resumeModeObjects = GameObject.FindGameObjectsWithTag("ShowWhenResumed");
        foreach (GameObject g in pauseModeObjects)
            g.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetKeyDown())
        {
            Debug.Log("bb");
            if(isPaused)
            {
                

                Resume();
            }
            else
            {
                Pause();
            }
        }
        */

    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        //isPaused = true;
        foreach(GameObject g in pauseModeObjects)
            g.SetActive(true);
        foreach(GameObject g in resumeModeObjects)
            g.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        //isPaused = false;
        foreach (GameObject g in pauseModeObjects)
            g.SetActive(false);
        foreach(GameObject g in resumeModeObjects)
            g.SetActive(true);
    }

    public void Main()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
