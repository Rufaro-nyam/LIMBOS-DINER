using UnityEngine;

public class Hands : MonoBehaviour
{
    public Pan pan;
    public Plate plate;
    public Chopping_board chopping_board;

    Transform cam;
    [SerializeField] float range = 50f;

    public Transform food_pos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //FOOD GFX
    public GameObject meat_gfx;
    public GameObject bread_gfx;


    //FOOD PROCESSED GFX
    public GameObject cooked_meat_gfx;
    public GameObject cut_bread_gfx;

    //Hand occupation
    private bool occupied = false;

    //RAW FOOD ACTIVE
    private bool meat_active = false;
    private bool bread_active = false;

    //PROCESSED FOOD ACTIVE
    private bool cooked_meat_active = false;
    private bool cut_bread_active = false;
    private void Awake()
    {
        cam = Camera.main.transform;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    public void shoot() 
    {
        RaycastHit hit;
        //PICKING UP
        if(occupied == false) 
        {
            print("unocupied");
            if (Physics.Raycast(cam.position, cam.forward, out hit, range) )
            {
                print(hit.collider.name);
                if (hit.transform.tag == "Meat")
                {
                    meat_gfx.SetActive(true);
                    occupied = true;
                    meat_active = true;
                }
                if (hit.transform.tag == "Cooked_meat")
                {
                    cooked_meat_gfx.SetActive(true);
                    occupied = true;
                    pan.food_collect();
                    meat_active = false;
                    cooked_meat_active = true;
                }
                if (hit.transform.tag == "Bread")
                {
                    bread_gfx.SetActive(true);
                    occupied = true;
                    bread_active = true;
                    
                }
                if (hit.transform.tag == "Cut_bread")
                {
                    bread_gfx.SetActive(false);
                    occupied = true;
                    bread_active = false;
                    cut_bread_active = true;
                    cut_bread_gfx.SetActive(true);
                    chopping_board.food_collect();
                    

                }

            }
        }

        
        else if (occupied == true) 
        {
            print("ocupied");
            if (Physics.Raycast(cam.position, cam.forward, out hit, range) )
            {
                print(hit.collider.name);
                //PUTING DOWN - PAN
                if (hit.transform.tag == "Pan" && pan.occupied == false)
                {
                    if (meat_active) 
                    {
                        meat_gfx.SetActive(false);
                        occupied = false;
                        pan.cook_meat();
                        meat_active = false;
                    }

                }
                //PUTING DOWN - CHOPPING BOARD
                if (hit.transform.tag == "Chopping_board" && pan.occupied == false)
                {
                    if (bread_active)
                    {
                        bread_gfx.SetActive(false);
                        occupied = false;
                        chopping_board.cut_bread();
                        bread_active = false;
                    }

                }
                //PUTTING DOWN - PLATE
                if (hit.transform.tag == "Plate" && pan.occupied == false)
                {
                    if (cooked_meat_active) 
                    {
                        cooked_meat_active = false;
                        occupied = false;
                        cooked_meat_gfx.SetActive(false);
                        plate.add_cooked_meat();
                    }
                    if (cut_bread_active)
                    {
                        cut_bread_active = false;
                        occupied = false;
                        cut_bread_gfx.SetActive(false);
                        plate.add_chopped_bread();
                    }
                }
            }
        }

        

    }


}
