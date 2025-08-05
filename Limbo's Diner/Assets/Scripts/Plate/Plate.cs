using UnityEngine;

public class Plate : MonoBehaviour
{
    //SLOT POSITIONS
    public GameObject[] slotpos;
    //FOOD COLLECTIONS

    //SINGLES
    public GameObject cooked_meat;
    public GameObject cut_bread;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void add_cooked_meat() 
    {
        cooked_meat.SetActive(true);
        for (int i = 0; i < slotpos.Length; i ++)
        {
            if (slotpos[i].activeSelf == true) 
            {
                cooked_meat.transform.position = slotpos[i].transform.position;
                slotpos[i].SetActive(false);
                print(slotpos[i]);
                break;
            }
        }
    }

    public void add_chopped_bread()
    {
        cut_bread.SetActive(true);
        for (int i = 0; i < slotpos.Length; i++)
        {
            if (slotpos[i].activeSelf == true)
            {
                cut_bread.transform.position = slotpos[i].transform.position;
                slotpos[i].SetActive(false);
                print(slotpos[i]);
                break;
            }
        }
    }
}
