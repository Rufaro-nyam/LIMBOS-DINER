using System.Collections;
using UnityEngine;

public class Queue : MonoBehaviour
{
    public AudioSource bell;
    public AudioSource complete;
    public AudioSource lose_sound;
    private float bell_time = 7f;
    public bool started = false;
    public bool can_ring = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ring());
    }

    // Update is called once per frame
    void Update()
    {
        float target_z = transform.position.z;

    }

    public void move_forward()
    {
        complete.Play();
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.5f);
    }

    public void lose()
    {
        lose_sound.Play();
    }
    private IEnumerator ring()
    {
        yield return new WaitForSeconds(7);
        if(started == false && can_ring)
        {
            bell.Play();
        }
        StartCoroutine(ring());
    }

    public void silence_bell()
    {
        bell.volume = 0;
        bell.Stop();
        can_ring = false;
    }
}
