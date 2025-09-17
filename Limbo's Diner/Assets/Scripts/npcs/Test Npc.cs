using UnityEngine;
using UnityEngine.UIElements;

public class TestNpc : MonoBehaviour
{
    
    public GameObject text1;
    public GameObject text2;
    private bool satisfied = false;
    public GameObject next_npc;
    public ParticleSystem win_particles;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text1.SetActive(false);
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
        win_particles.Play();
        text1.SetActive(false);
        text2.SetActive(true);
        satisfied = true;
        next_npc.SetActive(true);
    }
}
