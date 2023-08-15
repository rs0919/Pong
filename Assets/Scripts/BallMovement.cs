using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    [SerializeField] private float ballSpeed;
    [SerializeField] private float speedMult;

    [SerializeField] private AudioSource ball_sfx;
    [SerializeField] private AudioSource pointScored_sfx;

    private Vector3 ballPos;
    
    private bool startGame = true; // if nothing has collided w/ the ball yet
    private Rigidbody2D rb;

    private float player1PosX; // tracks the position of the bottom paddle
    private float player2Posx; // tracks the position of the top paddle

    private float randOffset;
    // Applies random effect to y component of ball's velocity to prevent the ball
    // from moving horizontally.

    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        randOffset = Random.Range(0, 2);
        if (rb.velocity.y < 0) 
        // randOffset should be in the same direction as the ball.
        {
            randOffset *= -1f;
        }

        this.transform.rotation = Quaternion.identity;

        ballPos = this.transform.position;

       // Debug.Log("x vel: " + rb.velocity.x + ", y vel: " + rb.velocity.y);

        player1PosX = GameObject.Find("Player").GetComponent<Transform>().position.x;

        if (startGame)
        {
            StartGame();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //startGame = false;


        if (collision.gameObject.name == "Player")
        {
            ball_sfx.Play();
            // calculate distance from where ball hit to center of paddle
            float distance = ballPos.x - player1PosX;
            rb.velocity = new Vector2(distance * speedMult, ballSpeed * Time.deltaTime); // change x value
        }

        if (collision.gameObject.name == "TopPlayer")
        {
            ball_sfx.Play();
            // calculate distance from where ball hit to center of paddle
            float distance = ballPos.x - player1PosX;
            rb.velocity = new Vector2(distance * speedMult, -1.0f * ballSpeed * Time.deltaTime); // change x value
        }

        if (collision.gameObject.name == "LeftEdge")
        {
            ball_sfx.Play();
            // flip x velocity
            //Debug.Log("hit left");
            //float xVel = rb.velocity.x;
            //float yVel = rb.velocity.y;
            //rb.velocity = new Vector2(-1.0f * rb.velocity.x, rb.velocity.y);
            rb.velocity = new Vector2(ballSpeed * Time.deltaTime, rb.velocity.y + randOffset);

        }

        if (collision.gameObject.name == "RightEdge")
        {
            ball_sfx.Play();
            //Debug.Log("right edge");
            rb.velocity = new Vector2(-1.0f * ballSpeed * Time.deltaTime, rb.velocity.y + randOffset);
        }

        if (collision.gameObject.name == "BottomEdge")
        {
            pointScored_sfx.Play();

            //this.transform.position = new Vector3(0, 0, 0);
            //rb.velocity = new Vector2(0, 0);
            startGame = true;
            ScoreManager.instance.IncreasePlayerTwoScore();
        }

        if (collision.gameObject.name == "TopEdge")
        {
            pointScored_sfx.Play();

            //this.transform.position = new Vector3(0, 0, 0);
            //rb.velocity = new Vector2(0, 0);
            startGame = true;
            ScoreManager.instance.IncreasePlayerOneScore();
        }
    
    }



    private void StartGame()
    {
        // Ball spawns in the center of the screen and goes toward player
        
        this.transform.position = new Vector3(0, 0, 0);
        rb.velocity = Vector2.zero;

        timer += Time.deltaTime;
        if (timer >= 1.5f)
        {
            timer = 0f;
            rb.velocity = new Vector2(0, -1.0f * ballSpeed * Time.deltaTime);
            startGame = false;
        }
    }

}
