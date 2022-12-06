using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenBalloon : MonoBehaviour
{
    [SerializeField] GameObject controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("ScoreManager");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x + .3f, transform.position.y);
        if(transform.position.x == 400f){
            controller.GetComponent<ScoreManager>().AdvanceLevel();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D c){
        if(c.gameObject.tag == "Bullet"){
            controller.GetComponent<ScoreManager>().AddPoints(100);
            controller.GetComponent<ScoreManager>().AdvanceLevel();
            Destroy(gameObject);
        }
    }
}
