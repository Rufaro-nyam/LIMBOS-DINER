using UnityEngine;
using UnityEngine.UIElements;

public class TestNpc : MonoBehaviour
{
    
    public GameObject text1;
    public GameObject text2;
    private bool satisfied = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (satisfied)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1f * Time.deltaTime, transform.position.z);
        }
        
    }

    public void win() 
    {
        text1.SetActive(false);
        text2.SetActive(true);
        satisfied = true;
    }
}
