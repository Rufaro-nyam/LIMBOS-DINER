using UnityEngine;
using UnityEngine.UI;

public class Chopping_board : MonoBehaviour
{
    //PROGRESS BAR STUFF
    [Header("Progress Bar Variables")]
    [SerializeField] private Image progressbar;
    [SerializeField] private float max_prog = 10f;
    public GameObject[] progress_sprites;
    private float current_prog;


    //COOKING CONDITIONS
    [Header("Processing Condition Variables")]
    public bool cutting_bread;
    public bool cutting_lettuce;
    public bool cutting_spinach;

    //GFX FOOD
    [Header("Food Graphics Unprocessed")]
    public GameObject bread_gfx;
    public GameObject lettuce_gfx;
    public GameObject spinach_gfx;

    //GFX PROCESSED FOOD
    [Header("Food Graphics Processed")]
    public GameObject cut_bread_gfx;
    public GameObject cut_lettuce_gfx;
    public GameObject chopped_spinach_gfx;

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

        if (cutting_bread)
        {
            current_prog += 0.5f * Time.deltaTime;
            progressbar.fillAmount = current_prog / max_prog;
            if (current_prog >= max_prog)
            {
                cutting_bread = false;
                current_prog = 0f;
                bread_gfx.SetActive(false);
                cut_bread_gfx.SetActive(true);
            }
        }

        //CUTTING LETTUCE
        if (cutting_lettuce)
        {
            current_prog += 0.5f * Time.deltaTime;
            progressbar.fillAmount = current_prog / max_prog;
            if (current_prog >= max_prog)
            {
                cutting_lettuce = false;
                current_prog = 0f;
                lettuce_gfx.SetActive(false);
                cut_lettuce_gfx.SetActive(true);
            }
        }

        if (cutting_spinach)
        {
            current_prog += 0.5f * Time.deltaTime;
            progressbar.fillAmount = current_prog / max_prog;
            if (current_prog >= max_prog)
            {
                cutting_spinach = false;
                current_prog = 0f;
                spinach_gfx.SetActive(false);
                chopped_spinach_gfx.SetActive(true);
            }
        }
    }



    public void cut_bread()
    {
        bread_gfx.SetActive(true);
        cutting_bread = true;
        occupied = true;
    }

    public void cut_lettuce()
    {
        lettuce_gfx.SetActive(true);
        cutting_lettuce = true;
        occupied = true;
    }

    public void cut_spinach()
    {
        spinach_gfx.SetActive(true);
        cutting_spinach = true;
        occupied = true;
    }

    public void food_collect()
    {
        //bread
        cut_bread_gfx.SetActive(false);
        current_prog = 0.0f;
        cutting_bread = false;
        current_prog = 0.0f;
        occupied = false;

        //lettuce
        cut_lettuce_gfx.SetActive(false);
        current_prog = 0.0f;
        cutting_lettuce = false;
        current_prog = 0.0f;

        //spinach
        chopped_spinach_gfx.SetActive(false);
        current_prog = 0.0f;
        cutting_spinach = false;
        
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
