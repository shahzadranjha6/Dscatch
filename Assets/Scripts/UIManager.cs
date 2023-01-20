using System.Collections;
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
    float Minutes = 0f;
    float Seconds = 10f;
    public bool IsGameover = false;


    // Start is called before the first frame update
    void Start()
    {
        


        if (instance == null)
        {
            instance = this;
        }

        ScoreCount = 0;
        ScoreTxt.text = "Score:" + ScoreCount;
    }


    void GameOver()
    {
        StopAllCoroutines();
        Time.timeScale = 0;
        GameOverTxt.gameObject.SetActive(true);
    }
    private void FixedUpdate()
    {
        StartCoroutine("TimerCounter");
    }
    public IEnumerator TimerCounter()
    {





        if (Seconds > 0 || Minutes > 0)
        {
            if (Seconds <= 0)
            {
                Minutes--;
                Seconds = 59f;

            }
            Seconds -= 0.01f;

            TimeTxt.text = string.Format("{0:00}:{1:00}", Minutes, Seconds);
        }
        else
        {
            GameOver();
        }


        yield return new WaitForSeconds(1);










        // for seconds


    }




    public void ScoreUpdate()
    {

        ScoreTxt.text = "Score:" + ++ScoreCount;
    }

}
