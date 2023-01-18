using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;



    // ---GUI texts, panels, buttons, etc   
    public TextMeshProUGUI ScoreTxt;



    // ---Others
    int ScoreCount;


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


   public  void ScoreUpdate()
    {
        ScoreTxt.text = "Score:" + ++ScoreCount;
    }
}
