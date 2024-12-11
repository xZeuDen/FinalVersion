using UnityEngine;

public class RepeatRoad : MonoBehaviour
{
    public float roadLength = 150f;
    public Transform playerCar;

    // Start is called before the first frame update
     void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z + roadLength < playerCar.position.z) //when i pass the end of road
        {
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + roadLength * 2);
            transform.position = newPosition;
        }
    }
}
