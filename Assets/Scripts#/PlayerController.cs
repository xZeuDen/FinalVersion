    
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public bool gameOver = false;
    public float moveSpeed = 5f; //speed
    public float turnSpeed = 0f; //turn
    public float speedIncrease = 1f; //amount to increase speed
    private float elapsedTime = 0f; //timer
    private PlayerController playerControllerScript;
    public TextMeshProUGUI gameOVerText;
    public Button restartButton;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public AudioClip crashSound;
    public AudioClip carSound;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        playerAudio.PlayOneShot(carSound, 1.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        float adjustedTurnSpeed = turnSpeed * (moveSpeed / 5f);
        if (playerControllerScript.gameOver == false) {
        //turn the car
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) //a or arrow to turn left
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))//d or arrow to turn right
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }
        
        elapsedTime += Time.deltaTime;

        //Make the car go faster every 10 seconds 
        if (elapsedTime >= 10f)
        {
            // Increase the move speed
            moveSpeed += speedIncrease;
            turnSpeed += speedIncrease;

            // Reset the timer
            elapsedTime = 0f;
        }
        //move the car forward constantly
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    
    }

    public void GameOver()
    {
        gameOVerText.gameObject.SetActive(true);
    }
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("CarObstacle")) {
            gameOver = true;
            Debug.Log("You lost! Your score has been reset"); }
            gameOVerText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            explosionParticle.Play(); 
            playerAudio.Stop();
            playerAudio.PlayOneShot(crashSound, 3.0f);
    }

}

