using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] string playerName;
    [SerializeField] Text sceneText;
    [SerializeField] Text scoreText;
    [SerializeField] Scene scene;
    [SerializeField] int pointstowin;
    [SerializeField] GameObject spawn;
    [SerializeField] bool isFinishedSpawning;
    
    [SerializeField] Text highscoreText;
    const int DEFAULT_POINTS = 1;

    // Start is called before the first frame update
    void Start()
    {
        
        //score = 0;
        
        score = PersistentData.Instance.GetScore();
        playerName = PersistentData.Instance.GetName();
        scene = SceneManager.GetActiveScene();
        if(scene.name == "Level 1"){
            pointstowin = 5;
        }
        if(scene.name == "Level 2"){
            pointstowin = 10;
        }
        if(scene.name == "Level 3"){
            pointstowin = 15;
        }
        if (spawn == null){
            spawn = GameObject.FindGameObjectWithTag("Spawn");
        }
        isFinishedSpawning = spawn.GetComponent<Spawner>().getStatus();
        string scenename = scene.name;
        sceneText.text = scenename.ToString();
        DisplayScore();
        Debug.Log(scene.name);
        Debug.Log(pointstowin);
    }

    // Update is called once per frame
    void Update()
    {
        DisplayScore();
        PersistentData.Instance.SetScore(score);
        /*
        if (score >= pointstowin){
           // SceneManager.LoadScene("Level 2");
        }
        */
        isFinishedSpawning = spawn.GetComponent<Spawner>().getStatus();
    }
    void FixedUpdate() {
        
        //if(GameObject.FindGameObjectWithTag("Balloon") == null && score ){

       // }
    }
     public void AddPoints()
    {
        AddPoints(DEFAULT_POINTS);

    }
    public void AddPoints(int addend)
    {
        score += addend;
        if(score >= pointstowin && isFinishedSpawning){
            AdvanceLevel();
        }
        if(score < pointstowin && isFinishedSpawning){
            SceneManager.LoadScene(scene.name);
        }
        Debug.Log("score " + score);
        
    }
    public void DeductPoints(int penalty)
    {
        score -= penalty;
    }
    public void DisplayScore()
    {
        scoreText.text = "Name: " + playerName + " Score: " + score.ToString();
    }
    public int GetScore(){
        return score;
    }
    public int GetPointsToWin(){
        return pointstowin;
    }
    public void AdvanceLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
