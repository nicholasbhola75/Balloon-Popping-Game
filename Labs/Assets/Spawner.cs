using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    const int NUM_BALLOONS = 10;
    int count = 0;
    [SerializeField] GameObject balloon;
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject bombs;
    [SerializeField] bool isFinishedSpawning;
    [SerializeField] Scene scene;
   // [SerializeField] bool gameover;
    //[SerializeField] float fireRate = 0.5f;
    //[SerializeField] float nextspawn = 0.0f;
    private float interval = 2.0f;
    private float interval2 = 3.0f;
    private float interval3 = 3.0f;
    float timer = 0;
    float timer2 = 0;
    float timer3 = 0;
 
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        isFinishedSpawning = false;
        timer = 0;
        timer2 = 0;
        timer3 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        timer3 += Time.deltaTime;
        Spawn();
    }

    void Spawn(){
        float xMin = -40.0f;
        float xMax = 40.0f;
        float yMin = 38.0f;
        float yMax = 45.0f;
        
        if(count <= NUM_BALLOONS && timer >= interval && scene.name!="Bonus"){        
            Vector2 position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            GameObject newballoon = Instantiate(balloon, position, Quaternion.identity);

            timer = 0;
            count++;
        }
        if(count == NUM_BALLOONS){
            isFinishedSpawning = true;
        }
        if(scene.name == "Level 2" || scene.name == "Level 3"){
            if(timer2 >= interval2){
                Vector3 position2 = new Vector2(68, 6);
                Vector3 position3 = new Vector2(68, 0);
                GameObject arrow1 = Instantiate(arrow, position2, Quaternion.Euler(new Vector3(0, 0, 90)));
                GameObject arrow2 = Instantiate(arrow, position3, Quaternion.Euler(new Vector3(0, 0, 90)));
                timer2 = 0;
                Destroy(arrow1, 5f);
                Destroy(arrow2, 5f);
            }
        }
        if(scene.name == "Level 3"){
            if(timer3 >= interval3){
                Vector2 position4 = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
                GameObject newbomb = Instantiate(bombs, position4, Quaternion.identity);
                timer3 = 0;
            }
        }
        if(scene.name == "Bonus"){
            if(timer3 >= 0.2f){
                Vector2 position4 = new Vector2(Random.Range(xMin, 400), Random.Range(yMin, yMax));
                GameObject newbomb = Instantiate(bombs, position4, Quaternion.identity);
                timer3 = 0;
            }
        }



    }
        

        /*
        if(count = NUM_BALLOONS && score < ptw){
            gameover = true;
        }       
        */ 

    public bool getStatus(){
        return isFinishedSpawning;
    }
}
