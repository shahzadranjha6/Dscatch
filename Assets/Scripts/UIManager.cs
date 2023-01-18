using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI Score;
    int ScoreCount;
    public static UIManager instance;


    // Start is called before the first frame update
    void Start()
    {
        instance = FindObjectOfType<UIManager>();
        ScoreCount = 0;
        Score.text = "Score:" + ScoreCount;
    }

    // Update is called once per frame
  
   public  void ScoreUpdate()
    {
        ScoreCount++;
        Score.text = "Score:" + ScoreCount;
    }
}
