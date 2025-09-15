using UnityEngine;
using UnityEngine.UI;

public class Pot : MonoBehaviour
{
    //PROGRESS BAR STUFF
    [Header("Progress Bar Variables")]
    [SerializeField] private Image progressbar;
    [SerializeField] private float max_prog = 10f;
    public GameObject[] progress_sprites;
    private float current_prog;


    //COOKING CONDITIONS
    [Header("Processing Condition Variables")]
    public bool boiling_potatoes;


    //GFX FOOD
    [Header("Food Graphics Unprocessed")]
    public GameObject potatoes_gfx;


    //GFX PROCESSED FOOD
    [Header("Food Graphics Processed")]
    public GameObject boiled_potatoes_gfx;

    //ANIMATION
    public ParticleSystem stemgfx1;
    public ParticleSystem stemgfx2;

    //OCCUPATION
    public bool occupied = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        current_prog = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (boiling_potatoes)
        {
            current_prog += 0.5f * Time.deltaTime;
            progressbar.fillAmount = current_prog / max_prog;
            if (current_prog >= max_prog)
            {
                stemgfx1.Stop();
                stemgfx2.Stop();
                boiling_potatoes = false;
                current_prog = 0f;
                potatoes_gfx.SetActive(false);
                boiled_potatoes_gfx.SetActive(true);
            }
        }

        
    }



    public void cook_potatoes()
    {
        stemgfx1.Play();
        stemgfx2.Play();
        potatoes_gfx.SetActive(true);
        boiling_potatoes = true;
        occupied = true;
    }




    public void food_collect()
    {
        //bread
        boiled_potatoes_gfx.SetActive(false);
        current_prog = 0.0f;
        boiling_potatoes = false;
        current_prog = 0.0f;
        occupied = false;



        deactivate_progress();
    }

    public void activate_progress()
    {
        foreach (GameObject p in progress_sprites) { p.SetActive(true); }
    }

    public void deactivate_progress()
    {
        foreach (GameObject p in progress_sprites) { p.SetActive(false); }
    }
}
