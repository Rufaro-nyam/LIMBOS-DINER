using UnityEngine;
using UnityEngine.UI;

public class Pan : MonoBehaviour
{
    //PROGRESS BAR STUFF
    [SerializeField] private Image progressbar;
    [SerializeField] private float max_prog = 10f;
    public  GameObject[] progress_sprites;
    private float current_prog;

    //OVERCOOK BAR STUFF
    [SerializeField] private Image OVERCOOK_progressbar;
    [SerializeField] private float max_overcook_prog = 10f;
    public GameObject[] overcook_progress_sprites;
    private float current_overcook_prog;
    bool overcooking;





    //COOKING CONDITIONS
    public bool cooking_meat;

    //GFX
    public GameObject meat_gfx;
    public GameObject cooked_meat_gfx;

    //OCCUPATION
    public bool occupied = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        current_prog = 0f;
        deactivate_progress();
        deactivate_overcook_progress_sprites();
    }

    // Update is called once per frame
    void Update()
    {
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
                activate_overcook_progress_sprites();
                current_overcook_prog += 0.5f * Time.deltaTime;
                OVERCOOK_progressbar.fillAmount = current_overcook_prog / max_prog;
                print("overcook prog is " + current_overcook_prog);
                if (current_overcook_prog >= max_overcook_prog)
                {
                    print("overcooked");
                }
            }
        }
    }



    public void cook_meat() 
    {
        activate_progress();
        meat_gfx.SetActive(true);
        cooking_meat = true;
        occupied = false;
    }

    public void food_collect() 
    {
        cooked_meat_gfx.SetActive(false);
        current_prog = 0.0f;
        cooking_meat = false;
        current_prog = 0.0f;
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
