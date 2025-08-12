using UnityEngine;

public class TestNpc : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void win() 
    {
        text1.SetActive(false);
        text2.SetActive(true);
    }
}
