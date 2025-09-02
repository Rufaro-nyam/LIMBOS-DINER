using UnityEngine;

public class Plate : MonoBehaviour
{
    //SLOT POSITIONS
    [Header("Slot Positions")]
    public GameObject[] slotpos;

    //FOOD COLLECTIONS
    [Header("List of Complete Dishes")]
    public GameObject[] Combos;

    //SINGLES LIST
    [Header("List Of Single Ingredients")]
    public GameObject[] singles;

    //SINGLES
    public GameObject cooked_meat;
    public GameObject cut_bread;
    public GameObject cut_lettuce;
    public GameObject cooked_fish;
    public GameObject chopped_spinach;
    public GameObject cooked_potatoes;

    //COMBOS
    [Header("Complete Dishes")]
    public GameObject Burger;
    public GameObject Fish_dish;
    public GameObject Hotdog;

    //CURRENT DISHED
    [Header("Active Dishes")]
    public bool Burger_active;
    public bool HotDog_active;
    public bool FriedFish_active;

    //CHECKING FOOD 
    private int ing_put = 0;
    private bool lettuce_put = false;
    private bool meat_put = false;
    private bool bread_put = false;
    private bool fish_put = false;
    private bool spinach_put = false;
    private bool potatoes_put = false;

    //INGREDIENT PRESENT WARNING
    public GameObject present_warning;
    private float present_time = 0f;

    //MENU LISTS
    public Menu menu;

    void Start()
    {
        Burger_active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(present_warning.activeSelf == true) 
        {
            present_time += Time.deltaTime;
            if(present_time > 3) 
            {
                present_warning.SetActive(false);
                present_time = 0;
            }
        }
        
    }

    public void add_cooked_meat() 
    {
        if (!meat_put )
        {

            cooked_meat.SetActive(true);
            for (int i = 0; i < slotpos.Length; i++)
            {
                if (slotpos[i].activeSelf == true)
                {
                    cooked_meat.transform.position = slotpos[i].transform.position;
                    slotpos[i].SetActive(false);
                    print(slotpos[i]);
                    check_food();
                    meat_put = true;
                    break;
                }
            }
        }
        else 
        {
            present_warning.SetActive(true);
        }



    }

    public void add_cooked_fish() 
    {
        if (!fish_put)
        {

            cooked_fish.SetActive(true);
            for (int i = 0; i < slotpos.Length; i++)
            {
                if (slotpos[i].activeSelf == true)
                {
                    cooked_fish.transform.position = slotpos[i].transform.position;
                    slotpos[i].SetActive(false);
                    print(slotpos[i]);
                    check_food();
                    fish_put = true;
                    break;
                }
            }
        }
        else
        {
            present_warning.SetActive(true);
        }
    }

    public void add_chopped_bread()
    {
        if (!bread_put)
        {
            cut_bread.SetActive(true);
            for (int i = 0; i < slotpos.Length; i++)
            {
                if (slotpos[i].activeSelf == true)
                {
                    cut_bread.transform.position = slotpos[i].transform.position;
                    slotpos[i].SetActive(false);
                    print(slotpos[i]);
                    check_food();
                    bread_put = true;
                    break;
                }
            }
        }
        else
        {
            present_warning.SetActive(true);
        }


    }

    public void add_cut_lettuce()
    {
        if (!lettuce_put)
        {
            cut_lettuce.SetActive(true);
            for (int i = 0; i < slotpos.Length; i++)
            {
                if (slotpos[i].activeSelf == true)
                {
                    cut_lettuce.transform.position = slotpos[i].transform.position;
                    slotpos[i].SetActive(false);
                    print(slotpos[i]);
                    check_food();
                    lettuce_put = true;
                    break;
                }
            }
        }
        else
        {
            present_warning.SetActive(true);
        }


    }

    public void add_chopped_spinach()
    {
        if (!spinach_put)
        {
            chopped_spinach.SetActive(true);
            for (int i = 0; i < slotpos.Length; i++)
            {
                if (slotpos[i].activeSelf == true)
                {
                    chopped_spinach.transform.position = slotpos[i].transform.position;
                    slotpos[i].SetActive(false);
                    print(slotpos[i]);
                    check_food();
                    spinach_put = true;
                    break;
                }
            }
        }
        else
        {
            present_warning.SetActive(true);
        }


    }
    public void add_cooked_potatoe()
    {
        if (!potatoes_put)
        {
            cooked_potatoes.SetActive(true);
            for (int i = 0; i < slotpos.Length; i++)
            {
                if (slotpos[i].activeSelf == true)
                {
                    cooked_potatoes.transform.position = slotpos[i].transform.position;
                    slotpos[i].SetActive(false);
                    print(slotpos[i]);
                    check_food();
                    potatoes_put = true;
                    break;
                }
            }
        }
        else
        {
            present_warning.SetActive(true);
        }


    }

    public void deactivate() 
    {
        foreach(GameObject s in singles) 
        {
            s.SetActive(false);
        }
    }

    public void check_food() 
    {

        
        print(ing_put);
        ing_put += 1;
        if(ing_put == 3) 
        {
            deactivate();
            Burger.SetActive(true);
        }
    }

    public void food_collect() 
    {
        foreach (GameObject s in singles)
        {
            s.gameObject.SetActive(false);
        }
        foreach (GameObject c in Combos)
        {
            c.gameObject.SetActive(false);
        }
        if (Burger_active) 
        {
            FriedFish_active = true;
            Burger_active = false;
            menu.Burger_menu.SetActive(false);
            menu.FriedFish_menu.SetActive(true);
        }
        
    }
}
