using UnityEngine;

public class Menu : MonoBehaviour
{
    [Header("Active Dishes")]
    public bool Burger;
    public bool HotDog;
    public bool FriedFish;

    [Header("MenuListinfgs")]
    public GameObject Burger_menu;
    public GameObject HotDog_menu;
    public GameObject FriedFish_menu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void burger_active() 
    {
        Burger_menu.SetActive(true);
        HotDog_menu.SetActive(false);
        FriedFish_menu.SetActive(false);
    }

    public void hotdog_active()
    {
        Burger_menu.SetActive(false);
        HotDog_menu.SetActive(true);
        FriedFish_menu.SetActive(false);
    }

    public void friedfish_active()
    {
        Burger_menu.SetActive(false);
        HotDog_menu.SetActive(false);
        FriedFish_menu.SetActive(true);
    }
}
