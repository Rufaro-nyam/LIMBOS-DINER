using UnityEngine;

public class Knife_animator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chop() 
    {
        anim.SetTrigger("Chop");
    }

    public void idle() 
    {
        anim.SetTrigger("Idle");
    }
}
