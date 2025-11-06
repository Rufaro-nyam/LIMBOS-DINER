using UnityEngine;

public class Player_stepping_sound : MonoBehaviour
{
    private AudioSource step_sound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        step_sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play_step()
    {
        step_sound.pitch = UnityEngine.Random.Range(1f, 1.5f);
        step_sound.Play();
    }
}
