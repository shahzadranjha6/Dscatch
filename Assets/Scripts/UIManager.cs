using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;



    // ---GUI texts, panels, buttons, etc   
    public TextMeshProUGUI ScoreTxt;
    public TextMeshProUGUI TimeTxt;
    public TextMeshProUGUI GameOverTxt;
   
    



    // ---Others
    int ScoreCount;
    float TimeCount=30;
    float Minutes;
    float Seconds;
    public bool IsGameover = false;


    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
            {
                instance = this;
            }

        ScoreCount = 0;
        ScoreTxt.text = "Score:" + ScoreCount;
    }
    private void Update()
    {
        if (TimeCount > 0)
        {

            Minutes = Mathf.FloorToInt(TimeCount / 60);
            Seconds = Mathf.FloorToInt(TimeCount % 60);
            TimeTxt.text = string.Format("{0:00}:{1:00}", Minutes, Seconds);
            TimeCount -= Time.deltaTime;

        }
        else
        {
            IsGameover = true;
            GameOverTxt.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

    }


    public  void ScoreUpdate()
    {
        
        ScoreTxt.text = "Score:" + ++ScoreCount;
    }
    
}
