using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInBound : MonoBehaviour
{
    private Rigidbody playerRb; //rigid body
    public float xRangeL = -18.5f; //left range
    public float xRangeR = -1.85f;//right range
    private PlayerController playerControllerScript;
    
    // Start is called before the first frame update
    void Start()
    {
         playerRb = GetComponent<Rigidbody>();
            playerControllerScript =GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
        if (transform.position.x < xRangeL){
            transform.position = new Vector3(xRangeL, transform.position.y, transform.position.z);//to find the range for left
        }
        if (transform.position.x > xRangeR){
                transform.position = new Vector3(xRangeR, transform.position.y, transform.position.z);// to find the range for right
        }
        }
    }
}
