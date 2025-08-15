using UnityEngine;

public class Plate : MonoBehaviour
{
    //SLOT POSITIONS
    public GameObject[] slotpos;
    //FOOD COLLECTIONS

    //SINGLES LIST
    public GameObject[] singles;

    //SINGLES
    public GameObject cooked_meat;
    public GameObject cut_bread;
    public GameObject cut_lettuce;

    //COMBOS
    public GameObject Burger;

    //CHECKING FOOD 
    private int ing_put = 0;
    private bool lettuce_put = false;
    private bool meat_put = false;
    private bool bread_put = false;

    //INGREDIENT PRESENT WARNING
    public GameObject present_warning;
    private float present_time = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        if (!meat_put)
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
        Burger.SetActive(false);
    }
}
