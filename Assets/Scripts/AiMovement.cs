using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour
{

    public bool impossibleMode;
    [SerializeField] private float movementSpeed;

    [SerializeField] private float leftEdge, rightEdge;
    // Edges makes sure that the top paddle doesn't try to push through the hitboxes
    // on the side (looks better and prevents bug where you can beat impossible difficulty)

    private float ballX;


    // Update is called once per frame
    void Update()
    {
        ballX = GameObject.Find("Ball").transform.position.x;
        Vector3 newPosition = new Vector3(ballX, this.transform.position.y, this.transform.position.z);

        this.transform.rotation = Quaternion.identity;

        if (!impossibleMode)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, newPosition, movementSpeed * Time.deltaTime);

        }
        else if (impossibleMode)
        {
            // paddle is always directly in front of ball
            // Check edges so paddle doesn't go past edge
            if (ballX <= leftEdge)
            {
                ballX = leftEdge;
            }
            if (ballX >= rightEdge)
            {
                ballX = rightEdge;
            }
            this.transform.position = new Vector3(ballX, this.transform.position.y, this.transform.position.z);
            
        }
        
        // add boundries
    }
}
