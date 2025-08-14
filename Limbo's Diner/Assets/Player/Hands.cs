using UnityEngine;
using System.Collections;

public class Hands : MonoBehaviour
{
    public Pan pan;
    public Plate plate;
    public Chopping_board chopping_board;
    public TestNpc npc;

    Transform cam;
    [SerializeField] float range = 50f;

    public Transform food_pos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //FOOD GFX
    public GameObject[] foods;

    public GameObject meat_gfx;
    public GameObject bread_gfx;
    public GameObject lettuce_gfx;


    //FOOD PROCESSED GFX
    public GameObject[] processed_foods;

    public GameObject cooked_meat_gfx;
    public GameObject cut_bread_gfx;
    public GameObject cut_lettuce_gfx;

    //COMPLETE DISH GFX
    public GameObject[] complete_dishes;

    public GameObject burger_gfx;

    //Hand occupation
    private bool occupied = false;

    //RAW FOOD ACTIVE
    private bool meat_active = false;
    private bool bread_active = false;
    private bool lettuce_active = false;

    //PROCESSED FOOD ACTIVE
    private bool cooked_meat_active = false;
    private bool cut_bread_active = false;
    private bool cut_lettuce_active = false;

    // complete dish occupation
    private bool Burger_active = false;

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
            //print("unocupied");
            if (Physics.Raycast(cam.position, cam.forward, out hit, range) )
            {
                print(hit.collider.name);
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
                if (hit.transform.tag == "Lettuce")
                {
                    disable_rest();
                    lettuce_gfx.SetActive(true);
                    occupied = true;
                    lettuce_active = true;
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
                        disable_rest();
                        //bread_gfx.SetActive(false);
                        occupied = false;
                        chopping_board.cut_bread();
                        bread_active = false;
                    }
                    if (lettuce_active)
                    {
                        disable_rest();
                        //bread_gfx.SetActive(false);
                        occupied = false;
                        chopping_board.cut_lettuce();
                        lettuce_active = false;
                    }

                }
                //PUTTING DOWN - PLATE
                if (hit.transform.tag == "Plate" && pan.occupied == false)
                {
                    if (cooked_meat_active) 
                    {
                        disable_rest();
                        cooked_meat_active = false;
                        occupied = false;
                        //cooked_meat_gfx.SetActive(false);
                        plate.add_cooked_meat();
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
    }


}
