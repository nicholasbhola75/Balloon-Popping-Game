using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //for sidescrolling camera
     public Transform player;

    // Update is called once per frame
    void Update () {
        Vector3 back = -player.transform.forward;
    back.y = 0.5f; // this determines how high. Increase for higher view angle.
    transform.position = player.transform.position - back * 1;

    transform.forward = player.transform.position - transform.position;
    }
}
