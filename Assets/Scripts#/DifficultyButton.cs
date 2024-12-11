using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;

    private ObstacleSpawner obstacleSpawner;

    void Start()
    {
        button = GetComponent<Button>();
        obstacleSpawner = GameObject.Find("Obstacle Spawner").GetComponent<ObstacleSpawner>();

        button.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        Debug.Log(gameObject.name + " was clicked");
        obstacleSpawner.StartGame();
    }
}
