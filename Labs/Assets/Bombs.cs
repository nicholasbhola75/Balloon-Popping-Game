using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombs : MonoBehaviour
{
    [SerializeField] bool isGrounded = false;
    public GameObject explosion;
    void Update(){
        if(isGrounded){
            Vector2 position = new Vector2(transform.position.x, transform.position.y);
            var explode = Instantiate(explosion, position, Quaternion.identity);
            Destroy(gameObject);
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
