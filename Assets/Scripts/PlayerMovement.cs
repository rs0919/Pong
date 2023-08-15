using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float playerSpeed;
    
    private Vector3 playerPos;
    private Rigidbody2D rb;
    private BoxCollider2D playerCollider;
  
    private bool touchingLeftEdge = false;
    private bool touchingRightEdge = false;

    private Collision2D rightEdge;
    private Collision2D leftEdge;
    
    // Start is called before the first frame update
    void Start()
    {
        playerPos = this.transform.position;
        rb = this.GetComponent<Rigidbody2D>();
        playerCollider = this.GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && (!touchingRightEdge))
        {
            playerPos.x += playerSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && (!touchingLeftEdge))
        {
            playerPos.x -= playerSpeed * Time.deltaTime;
        }

        this.transform.position = playerPos;
        this.transform.rotation = Quaternion.identity;

}

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "LeftEdge")
        {
            //Debug.Log("touching left edge");
            touchingLeftEdge = true;
        }
        else if (collision.gameObject.name == "RightEdge")
        {
            //Debug.Log("touching right edge");
            touchingRightEdge = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        touchingLeftEdge = false;
        touchingRightEdge = false;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log("trigger");
    //}
}
