using UnityEngine;

public class Player_mesh_anim : MonoBehaviour
{
    private Animator anim;
    public bool walking = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        //walk();
    }

    // Update is called once per frame
    void Update()
    {
        if (walking)
        {
            anim.speed = 1f;
        }
        else
        {
            anim.speed = 0f;
        }
    }


}
