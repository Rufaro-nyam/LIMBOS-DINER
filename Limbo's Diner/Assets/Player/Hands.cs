using UnityEngine;
using System.Collections;

public class Hands : MonoBehaviour
{
    [Header("Scripts To Interact With")]
    public Pan pan;
    public Plate plate;
    public Pot pot;
    public Chopping_board chopping_board;
    public TestNpc npc;

    Transform cam;
    [Header("Interaction Range")]
    [SerializeField] float range = 50f;

    public Transform food_pos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //FOOD GFX
    [Header("List of unprocessed foods")]
    public GameObject[] foods;

    public GameObject meat_gfx;
    public GameObject bread_gfx;
    public GameObject lettuce_gfx;
    public GameObject raw_fish_gfx;
    public GameObject spinach_gfx;
    public GameObject potatoes_gfx;


    //FOOD PROCESSED GFX
    [Header("List of processed foods")]
    public GameObject[] processed_foods;

    public GameObject cooked_meat_gfx;
    public GameObject cut_bread_gfx;
    public GameObject cut_lettuce_gfx;
    public GameObject cooked_fish_gfx;
    public GameObject chopped_spinach_gfx;
    public GameObject cooked_potatoes_gfx;

    //COMPLETE DISH GFX
    [Header("List of complete dishes")]
    public GameObject[] complete_dishes;

    public GameObject burger_gfx;

    //Hand occupation
    private bool occupied = false;

    //RAW FOOD ACTIVE
    private bool meat_active = false;
    private bool bread_active = false;
    private bool lettuce_active = false;
    private bool raw_fish_active = false;
    private bool spinach_active = false;
    private bool potatoes_active = false;

    //PROCESSED FOOD ACTIVE
    private bool cooked_meat_active = false;
    private bool cut_bread_active = false;
    private bool cut_lettuce_active = false;
    private bool cooked_fish_active = false;
    private bool chopped_spinach_active = false;
    private bool cooked_potatoes_active = false;

    // complete dish occupation
    private bool Burger_active = false;

    private void Awake()
    {
        cam = Camera.main.transform;
    }
    void Start()
    {
        
    }

     void Update()
    {

    }

    // Update is called once per frame
    public void shoot() 
    {
        RaycastHit hit;
        //PICKING UP
        if(occupied == false) 
        {
            //print("unocupied");
            if (Physics.Raycast(cam.position, cam.forward, out hit, range) )
            {
                //print(hit.collider.name);
                if (hit.transform.tag == "Meat")
                {
                    disable_rest();
                    meat_gfx.SetActive(true);
                    occupied = true;
                    meat_active = true;
                }
                if (hit.transform.tag == "Cooked_meat")
                {
                    disable_rest();
                    cooked_meat_gfx.SetActive(true);
                    occupied = true;
                    pan.food_collect();
                    cooked_meat_active = true;
                }
                if (hit.transform.tag == "Bread")
                {
                    disable_rest();
                    bread_gfx.SetActive(true);
                    occupied = true;
                    bread_active = true;  
                }
                if (hit.transform.tag == "Cut_bread")
                {
                    disable_rest();
                    bread_gfx.SetActive(false);
                    occupied = true;
                    bread_active = false;
                    cut_bread_active = true;
                    cut_bread_gfx.SetActive(true);
                    chopping_board.food_collect();
                }
                if (hit.transform.tag == "Potatoe")
                {
                    disable_rest();
                    potatoes_gfx.SetActive(true);
                    occupied = true;
                    potatoes_active = true;
                }
                if (hit.transform.tag == "Cooked_potatoe")
                {
                    disable_rest();
                    bread_gfx.SetActive(false);
                    occupied = true;
                    cooked_potatoes_active = true;
                    cooked_potatoes_gfx.SetActive(true);
                    pot.food_collect();
                }
                if (hit.transform.tag == "Lettuce")
                {
                    disable_rest();
                    lettuce_gfx.SetActive(true);
                    occupied = true;
                    lettuce_active = true;
                }
                if (hit.transform.tag == "Spinach")
                {
                    disable_rest();
                    spinach_gfx.SetActive(true);
                    occupied = true;
                    spinach_active = true;
                }
                if (hit.transform.tag == "Cut_letuce")
                {
                    disable_rest();
                    occupied = true;
                    bread_active = false;
                    cut_lettuce_active = true;
                    cut_lettuce_gfx.SetActive(true);
                    chopping_board.food_collect();
                }
                if (hit.transform.tag == "Chopped_spinach")
                {
                    disable_rest();
                    occupied = true;
                    chopped_spinach_active = true;
                    chopped_spinach_gfx.SetActive(true);
                    chopping_board.food_collect();
                }
                if (hit.transform.tag == "Fish")
                {
                    disable_rest();
                    occupied = true;
                    raw_fish_gfx.SetActive(true);
                    raw_fish_active = true;
                }
                if (hit.transform.tag == "Cooked_fish")
                {
                    disable_rest();
                    cooked_fish_gfx.SetActive(true);
                    occupied = true;
                    pan.food_collect();
                    cooked_fish_active = true;
                }
                //COMPLETE DISHES
                if (hit.transform.tag == "Burger")
                {
                    disable_rest();
                    occupied = true;
                    bread_active = false;
                    Burger_active = true;
                    burger_gfx.SetActive(true);
                    plate.food_collect();
                }

            }
        }

        
        if (occupied == true) 
        {
            //print("ocupied");
            if (Physics.Raycast(cam.position, cam.forward, out hit, range) )
            {
                //print(hit.collider.name);
                //PUTING DOWN - PAN
                if (hit.transform.tag == "Pan" && pan.occupied == false)
                {
                    if (meat_active) 
                    {
                        disable_rest();
                        meat_gfx.SetActive(false);
                        occupied = false;
                        pan.cook_meat();
                        meat_active = false;
                    }
                    if (raw_fish_active)
                    {
                        disable_rest();
                        raw_fish_gfx.SetActive(false);
                        occupied = false;
                        pan.cook_fish();
                        raw_fish_active = false;
                        
                    }


                }
                //PUTING DOWN - CHOPPING BOARD
                if (hit.transform.tag == "Chopping_board" && chopping_board.occupied == false)
                {
                    if (bread_active)
                    {
                        disable_rest();
                        //bread_gfx.SetActive(false);
                        occupied = false;
                        chopping_board.cut_bread();
                        chopping_board.activate_progress();
                        bread_active = false;
                    }
                    if (lettuce_active)
                    {
                        disable_rest();
                        //bread_gfx.SetActive(false);
                        occupied = false;
                        chopping_board.cut_lettuce();
                        chopping_board.activate_progress();
                        lettuce_active = false;
                    }
                    if (spinach_active)
                    {
                        disable_rest();
                        //bread_gfx.SetActive(false);
                        occupied = false;
                        chopping_board.cut_spinach();
                        chopping_board.activate_progress();
                        spinach_active = false;
                    }

                }
                //PUTTING DOWN - POT
                if (hit.transform.tag == "Pot" && pot.occupied == false) 
                {
                    if (potatoes_active)
                    {
                        disable_rest();
                        //bread_gfx.SetActive(false);
                        occupied = false;
                        pot.cook_potatoes();
                        pot.activate_progress();
                        potatoes_active = false;
                    }
                }

                    //PUTTING DOWN - PLATE
                    if (hit.transform.tag == "Plate")
                {
                    if (cooked_meat_active) 
                    {
                        disable_rest();
                        cooked_meat_active = false;
                        occupied = false;
                        //cooked_meat_gfx.SetActive(false);
                        plate.add_cooked_meat();
                    }
                    if (cooked_fish_active)
                    {
                        disable_rest();
                        cooked_fish_active = false;
                        occupied = false;
                        //cooked_meat_gfx.SetActive(false);
                        plate.add_cooked_fish();
                    }
                    if (cut_bread_active)
                    {
                        disable_rest();
                        cut_bread_active = false;
                        occupied = false;
                        //cut_bread_gfx.SetActive(false);
                        plate.add_chopped_bread();
                    }
                    if (cut_lettuce_active)
                    {
                        disable_rest();
                        cut_lettuce_active = false;
                        occupied = false;
                        plate.add_cut_lettuce();
                        //cut_bread_gfx.SetActive(false);
                        //plate.add_chopped_bread();
                    }
                    if (chopped_spinach_active)
                    {
                        disable_rest();
                        chopped_spinach_active = false;
                        occupied = false;
                        plate.add_chopped_spinach();
                        //cut_bread_gfx.SetActive(false);
                        //plate.add_chopped_bread();
                    }
                    if (cooked_potatoes_active)
                    {
                        disable_rest();
                        cooked_potatoes_active = false;
                        occupied = false;
                        plate.add_cooked_potatoe();
                        //cut_bread_gfx.SetActive(false);
                        //plate.add_chopped_bread();
                    }



                }
                //NPC
                if(hit.transform.tag == "NPC") 
                {
                    if (Burger_active) 
                    {
                        npc.win();
                        disable_rest();
                        occupied = false;
                    }
                }
            }
        }

        

    }

    public void drop() 
    {
        
        if (occupied) 
        {
            disable_rest();
            occupied = false;
            
        }

    }
    public void disable_rest() 
    {
        foreach (GameObject f in foods) { f.SetActive(false); }
        foreach (GameObject p in processed_foods) { p.SetActive(false); }
        foreach (GameObject c in complete_dishes) { c.SetActive(false); }
        bread_active = false;
        cut_bread_active = false;
        meat_active = false;
        cooked_meat_active = false;
        lettuce_active = false;
        cut_lettuce_active = false;
        cooked_fish_active = false;
        raw_fish_active = false;
        spinach_active = false;
        chopped_spinach_active = false;
        potatoes_active = false;
        cooked_potatoes_active = false;
    }


}
