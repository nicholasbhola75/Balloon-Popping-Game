using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TMP_InputField PlayerNameInput;
    public void PlayGame(){
        string s = PlayerNameInput.text;
        PersistentData.Instance.SetName(s);
        SceneManager.LoadScene("Level 1");
        //SceneManager.GetActiveScene().buildIndex + 1
        Debug.Log("Start");
    }
    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");

    }
    public void Main()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void HighScores()
    {
        SceneManager.LoadScene("HighScores");
    }
    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }
}
