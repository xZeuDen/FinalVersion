using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; 
    private PlayerController playerControllerScript;
    public TextMeshProUGUI meterText; // UI for displaying meters
     public TextMeshProUGUI gameOVerText;
    private int meters; // Track player progress in meters
    public float spawnDistance = 50f;
    public float spawnInterval = 0.7f;
    public Transform player; 
    public bool gameOver;
  
    

    // Define fixed X positions for each lane
    private float[] lanePositions = new float[] {-17, -12.96f, -7.94f, -3.81f }; //these values represent the X positions of lanes
    private float spawnHeight = 0.5f; //The height to spawn obstacles above the road

    // Start is called before the first frame update
    void Start()
    {
        // Start spawning obstacles
        InvokeRepeating("SpawnObstacle", 1f, spawnInterval);

        // Reference the player controller to check game over state
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        // Initialize score and meters
        UpdateMeters(0);

        // Start meter increment coroutine
        StartCoroutine(IncrementMeters());
    }
 
        public void SpawnObstacle()
        {
            if (playerControllerScript.gameOver == false)
            {
                // Randomly choose a lane for the obstacle to spawn in
                int laneIndex = Random.Range(0, lanePositions.Length);
                float laneXPosition = lanePositions[laneIndex];

                // Set spawn position on the chosen lane
                Vector3 spawnPosition = new Vector3(laneXPosition, spawnHeight, player.position.z + spawnDistance);

                // Randomly choose an obstacle from the array
                int randomIndex = Random.Range(0, obstaclePrefabs.Length);
                GameObject selectedObstacle = obstaclePrefabs[randomIndex];

                // Instantiate the obstacle at the chosen lane position
                Instantiate(selectedObstacle, spawnPosition, selectedObstacle.transform.rotation);
            }
        }



 
    // Update meter UI
    public void UpdateMeters(int metersToAdd)
    {
        meters += metersToAdd;
        meterText.text = "Meters: " + meters;
    }

    // Coroutine to increment meters every 0.5 seconds
    IEnumerator IncrementMeters()
    {
        while (!playerControllerScript.gameOver)
        {
            yield return new WaitForSeconds(0.1f);
            UpdateMeters(1);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

     public void StartGame()
    {
        gameOver = false;
    }
}
