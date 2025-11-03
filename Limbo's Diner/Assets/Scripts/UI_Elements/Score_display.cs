using UnityEngine;
using TMPro;

public class Score_display : MonoBehaviour
{
    private Animator anim;
    public GameObject great;
    public GameObject satisfied;
    public GameObject bad;
    private int score = 0;
    public TextMeshProUGUI score_display;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void show_great()
    {
        anim.SetTrigger("Show");
        great.SetActive(true);
        score += 30;
        score_display.text = score.ToString();

    }

    public void show_satisfied()
    {
        anim.SetTrigger("Show");
        satisfied.SetActive(true);
        score += 20;
        score_display.text = score.ToString();
    }

    public void show_tardy()
    {
        anim.SetTrigger("Show");
        bad.SetActive(true);
        score += 10;
        score_display.text = score.ToString();
    }

    public void Reset_reciept()
    {
        bad.SetActive(false);
        satisfied.SetActive(false);
        great.SetActive(false);
    }
}
