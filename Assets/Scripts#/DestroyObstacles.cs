using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
    private Transform player;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform; //find player
    }

    // Update is called once per frame
    private void Update()
    {
    
        if (transform.position.z < player.position.z - 10f)
        {
            Destroy(gameObject); //destroys the object 
        }
    }
}
