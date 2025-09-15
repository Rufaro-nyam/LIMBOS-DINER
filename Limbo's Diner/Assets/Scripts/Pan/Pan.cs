using UnityEngine;
using UnityEngine.UI;

public class Pan : MonoBehaviour
{
    //PROGRESS BAR STUFF
    [Header("Progress Bar Variables")]
    [SerializeField] private Image progressbar;
    [SerializeField] private float max_prog = 10f;
    public  GameObject[] progress_sprites;
    private float current_prog;

    //OVERCOOK BAR STUFF
    [Header("Overcooking Bar Variables")]
    [SerializeField] private Image OVERCOOK_progressbar;
    [SerializeField] private float max_overcook_prog = 10f;
    public GameObject[] overcook_progress_sprites;
    private float current_overcook_prog;
    bool overcooking;
    [SerializeField] private GameObject overcooked_label;
    float show_time = 0;
    bool can_show = false;





    //COOKING CONDITIONS
    [Header("Food Cooking Conditions")]
    public bool cooking_meat;
    public bool cooking_fish;
    public bool cooking_sausage;

    //GFX
    [Header("Unprocessed food graphics")]
    public GameObject meat_gfx;
    public GameObject raw_fish_gfx;
    public GameObject sausage_gfx;

    [Header("Processed food graphics")]
    public GameObject cooked_meat_gfx;
    public GameObject cooked_fish_gfx;
    public GameObject cooked_sausage_gfx;

    //ANIMATION
    [Header("Animation Particles")]
    public ParticleSystem oil;
    public ParticleSystem smoke;
    private bool can_smoke = true;

    //OCCUPATION
    [Header("Slot Positions")]
    public bool occupied = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        occupied = false;
        current_prog = 0f;
        deactivate_progress();
        deactivate_overcook_progress_sprites();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (can_show) 
        {
            overcooked_label.SetActive(true);
            
            show_time += Time.deltaTime;
            if(show_time > 3) 
            {
                can_show = false;
                show_time = 0;
                overcooked_label.SetActive(false);
            }


        }
        if (cooking_meat) 
        {
            current_prog += 0.5f * Time.deltaTime;
            progressbar.fillAmount = current_prog / max_prog;
            if(current_prog >= max_prog) 
            {

                cooking_meat = true;
                current_prog = 0f;
                meat_gfx.SetActive(false);
                cooked_meat_gfx.SetActive(true);
                deactivate_progress();
                overcooking = true;

                
            }
            if (overcooking) 
            {
                //overcooking]
                activate_smoke();
                activate_overcook_progress_sprites();
                current_overcook_prog += 0.5f * Time.deltaTime;
                OVERCOOK_progressbar.fillAmount = current_overcook_prog / max_prog;
                //print("overcook prog is " + current_overcook_prog);
                if (current_overcook_prog >= max_overcook_prog)
                {
                    oil.Stop();
                    smoke.Stop();
                    can_smoke = true;
                    print("overcooked");
                    cooking_meat = false;
                    occupied = false;
                    cooked_meat_gfx.SetActive(false);
                    can_show = true;
                    overcooking = false;
                    current_prog = 0.0f;
                    current_overcook_prog = 0.0f;
                    
                    deactivate_overcook_progress_sprites();
                }
            }
        }
        if (cooking_fish)
        {
            current_prog += 0.5f * Time.deltaTime;
            progressbar.fillAmount = current_prog / max_prog;
            if (current_prog >= max_prog)
            {

                cooking_fish = true;
                current_prog = 0f;
                raw_fish_gfx.SetActive(false);
                cooked_fish_gfx.SetActive(true);
                deactivate_progress();
                overcooking = true;


            }
            if (overcooking)
            {
                //overcooking]
                activate_smoke();
                activate_overcook_progress_sprites();
                current_overcook_prog += 0.5f * Time.deltaTime;
                OVERCOOK_progressbar.fillAmount = current_overcook_prog / max_prog;
                //print("overcook prog is " + current_overcook_prog);
                if (current_overcook_prog >= max_overcook_prog)
                {
                    oil.Stop();
                    smoke.Stop();
                    can_smoke = true;
                    print("overcooked");
                    cooking_fish = false;
                    occupied = false;
                    cooked_fish_gfx.SetActive(false);
                    can_show = true;
                    overcooking = false;
                    current_prog = 0.0f;
                    current_overcook_prog = 0.0f;

                    deactivate_overcook_progress_sprites();
                }
            }
        }

        if (cooking_sausage)
        {
            current_prog += 0.5f * Time.deltaTime;
            progressbar.fillAmount = current_prog / max_prog;
            if (current_prog >= max_prog)
            {

                cooking_sausage = true;
                current_prog = 0f;
                sausage_gfx.SetActive(false);
                cooked_sausage_gfx.SetActive(true);
                deactivate_progress();
                overcooking = true;


            }
            if (overcooking)
            {
                //overcooking]
                activate_smoke();
                activate_overcook_progress_sprites();
                current_overcook_prog += 0.5f * Time.deltaTime;
                OVERCOOK_progressbar.fillAmount = current_overcook_prog / max_prog;
                //print("overcook prog is " + current_overcook_prog);
                if (current_overcook_prog >= max_overcook_prog)
                {
                    oil.Stop();
                    smoke.Stop();
                    can_smoke = true;
                    print("overcooked");
                    cooking_sausage = false;
                    occupied = false;
                    cooked_sausage_gfx.SetActive(false);
                    can_show = true;
                    overcooking = false;
                    current_prog = 0.0f;
                    current_overcook_prog = 0.0f;

                    deactivate_overcook_progress_sprites();
                }
            }
        }
    }


    private void activate_smoke() 
    {
        if (can_smoke) 
        {
            smoke.Play();
            can_smoke = false;
        }
    }
    public void cook_meat() 
    {
        oil.Play();
        activate_progress();
        meat_gfx.SetActive(true);
        cooking_meat = true;
        occupied = true;
    }

    public void cook_sausage()
    {
        oil.Play();
        activate_progress();
        sausage_gfx.SetActive(true);
        cooking_sausage = true;
        occupied = true;
    }

    public void cook_fish()
    {
        oil.Play();
        activate_progress();
        raw_fish_gfx.SetActive(true);
        cooking_fish = true;
        occupied = true;
    }

    public void food_collect() 
    {
        oil.Stop();
        smoke.Stop();
        cooked_meat_gfx.SetActive(false);
        cooked_fish_gfx.SetActive(false);
        cooked_sausage_gfx.SetActive(false);
        current_prog = 0.0f;
        cooking_meat = false;
        cooking_fish = false;
        cooking_sausage = false;
        current_prog = 0.0f;
        current_overcook_prog = 0.0f;
        overcooking = false;
        deactivate_overcook_progress_sprites();
        occupied = false;
    }

    public void activate_progress() 
    {
        foreach(GameObject p in progress_sprites) { p.SetActive(true); }
    }

    public void deactivate_progress()
    {
        foreach (GameObject p in progress_sprites) { p.SetActive(false); }
    }

    public void deactivate_overcook_progress_sprites() 
    {
        foreach (GameObject o in overcook_progress_sprites) { o.SetActive(false); }
    }

    public void activate_overcook_progress_sprites()
    {
        foreach (GameObject o in overcook_progress_sprites) { o.SetActive(true); }
    }
}
