using UnityEngine;

public class Knife_animator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Animator anim;

    //SOUNDS
    public AudioSource chop_sound;
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

    public void play_chop()
    {
        chop_sound.pitch = UnityEngine.Random.Range(1f, 1.1f);
        chop_sound.Play();
    }
}
