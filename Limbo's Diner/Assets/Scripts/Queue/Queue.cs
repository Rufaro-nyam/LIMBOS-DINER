using UnityEngine;

public class Queue : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float target_z = transform.position.z;
        
    }

    public void move_forward()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.5f);
    }
}
