 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{

    [SerializeField] bool isFacingRight = true;
    [SerializeField] Vector3 scaleChange = new Vector3(0.05f, 0.05f);
    [SerializeField] Vector3 maxSize = new Vector3(4.0f, 4.0f);
     [SerializeField] AudioSource audios;
    [SerializeField] GameObject controller;

   // [SerializeField] AudioSource audiosource;
  
    //[SerializeField] float speed = 20f;
    //[SerializeField] Vector2 target;
    // Start is called before the first frame update
   // [SerializeField] bool isGrounded = false;
 
    void Start()
    {

        if (controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("ScoreManager");
        }
        
        if (audios == null)
        {
            audios = GetComponent<AudioSource>();
        }
        

        /*
if (audiosource == null)
        {
            audiosource = GetComponent<AudioSource>();
        }
        */
        
        InvokeRepeating("changeSize", 0.3f, 0.3f);

    }

    // Update is called once per frame
    
    void FixedUpdate()
    {  
        if(isFacingRight){
            transform.position = new Vector2(transform.position.x + .1f, transform.position.y);
            if(transform.position.x >= 50){
                Flip();
            }
        }
        if(!isFacingRight){
            transform.position = new Vector2(transform.position.x + -.1f, transform.position.y);
            if (transform.position.x <= -50){
                Flip();
            }
        }
        if (transform.localScale.x > maxSize.x){

            Destroy(gameObject);
        }
        
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    private void OnTriggerEnter2D(Collider2D c){
        if(c.gameObject.tag == "Bullet"){
         AudioSource.PlayClipAtPoint(audios.clip, transform.position);
        if(transform.localScale.x < 2.0){
             controller.GetComponent<ScoreManager>().AddPoints();
             
            // SFXManager.Instance.PopSound();
            //AudioSource.PlayClipAtPoint(, this.gameObject.transform.position);
            // AudioSource.PlayClipAtPoint(audiosource.clip, transform.position);
             Destroy(gameObject);
        }
        else if(transform.localScale.x > 2.0){
             controller.GetComponent<ScoreManager>().AddPoints(2);

             //SFXManager.Instance.PopSound();
            /// AudioSource.PlayClipAtPoint(audiosource.clip, transform.position);
          //  AudioSource.PlayClipAtPoint(pop.clip, this.gameObject.transform.position);
             Destroy(gameObject);

        }
        else if(transform.localScale.x > 3.0){
             controller.GetComponent<ScoreManager>().AddPoints(3);

            // AudioSource.PlayClipAtPoint(audiosource.clip, transform.position);
        //    AudioSource.PlayClipAtPoint(pop.clip, this.gameObject.transform.position);
        //SFXManager.Instance.PopSound();
             Destroy(gameObject);
        }
        }
    }

    private void changeSize(){
        transform.localScale += scaleChange;
    }

}
