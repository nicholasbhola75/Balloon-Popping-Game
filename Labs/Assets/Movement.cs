using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] float movement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] int speed;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] float jumpForce = 2000.0f;
    [SerializeField] bool isGrounded = true;
    [SerializeField] float fireRate = 0.5f;
    [SerializeField] float nextFire = 0.0f;
    [SerializeField] int health = 20;
    [SerializeField] Text Hp;
    [SerializeField] Scene scene;
    [SerializeField] AudioSource audiosource1;
    [SerializeField] GameObject controller;
    public GameObject bullet;
    public GameObject leftbullet;
    public GameObject upbullet;
   // [SerializeField] bool shiftPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        speed = 15;
        if (scene.name == "Bonus"){
            speed = 30;
        }
        if (audiosource1 == null)
        {
            audiosource1 = GetComponent<AudioSource>();
        }
        if (controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("ScoreManager");
        }
        Debug.Log(health);
    }

    // Update is called once per frame
    void Update()
    {
        Hp.text = "Health: " + health.ToString();
        movement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
            jumpPressed = true;
        if (Input.GetButton("Fire1") && Time.time > nextFire){
            if(isFacingRight){
                nextFire = Time.time + fireRate;
                Vector2 position = new Vector2(transform.position.x, transform.position.y);
                var clonebullet = Instantiate(bullet, position, Quaternion.identity);
                Destroy(clonebullet, 2f);
            }
            if(!isFacingRight){
                nextFire = Time.time + fireRate;
                 Vector2 position1 = new Vector2(transform.position.x, transform.position.y);
                var clonebullet1 = Instantiate(leftbullet, position1, Quaternion.identity);
                Destroy(clonebullet1, 2f);
            }
            
        }
        if(Input.GetButtonDown("Fire2") && Time.time > nextFire){
                nextFire = Time.time + fireRate;
                 Vector2 position2 = new Vector2(transform.position.x, transform.position.y);
                var clonebullet2 = Instantiate(upbullet, position2, Quaternion.identity);
                Destroy(clonebullet2, 2f);
        }
        if(health <= 0){
            controller.GetComponent<ScoreManager>().DeductPoints(5);
            if (scene.name == "Bonus"){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            SceneManager.LoadScene(scene.name);
        }
    }

    //called potentially multiple times per frame
    //used for physics & movement
    void FixedUpdate()
    { 
        rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);
        if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight)
            Flip();
        if (jumpPressed && isGrounded)
            Jump();
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;

    }

    void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, jumpForce));
        isGrounded = false;
        jumpPressed = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
        
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Arrow"){
            health -= 2;
            AudioSource.PlayClipAtPoint(audiosource1.clip, transform.position);
            Debug.Log(health);
        }
        if(collision.gameObject.tag == "Explosion"){
            health -= 8;
            AudioSource.PlayClipAtPoint(audiosource1.clip, transform.position);
            Debug.Log(health);
        }
    }
}