using UnityEngine;
using UnityEngine.UI;

public class Chopping_board : MonoBehaviour
{
    //PROGRESS BAR STUFF
    [SerializeField] private Image progressbar;
    [SerializeField] private float max_prog = 10f;

    private float current_prog;


    //COOKING CONDITIONS
    public bool cutting_bread;

    //GFX
    public GameObject bread_gfx;
    public GameObject cut_bread_gfx;

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
    }



    public void cut_bread()
    {
        bread_gfx.SetActive(true);
        cutting_bread = true;
        occupied = false;
    }

    public void food_collect()
    {
        cut_bread_gfx.SetActive(false);
        current_prog = 0.0f;
        cutting_bread = false;
        current_prog = 0.0f;
    }
}
