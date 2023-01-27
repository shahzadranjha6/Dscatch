using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;



    // ---GUI texts, panels, buttons, etc   
    public TextMeshProUGUI ScoreTxt;
    public TextMeshProUGUI TimeTxt;
    public TextMeshProUGUI GameOverTxt;
    // game over menu
    [SerializeField] private GameObject gameoverMenu;





    // ---Others
    int ScoreCount;
    float Minutes = 0f;
    public int Seconds = 20;
    public bool IsGameover = false;


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        ScoreCount = 0;
        ScoreTxt.text = "DSL Tokens:" + ScoreCount;
        
        StartCoroutine("TimerCounter");

    }


    void GameOver()
    {
        Time.timeScale = 0;
        GameOverTxt.gameObject.SetActive(true);
        IsGameover = true;
        gameoverMenu.SetActive(true);
    }




    public IEnumerator TimerCounter()
    {
        if (Seconds > 0 || Minutes > 0)
        {
            if (Seconds <= 0)   //-- 1 minute deducted
                {
                    Minutes--;

                    Seconds = 59;
                }

                        Seconds -= 1;

            TimeTxt.text = string.Format("{0:00}:{1:00}", Minutes, Seconds);
        }
        else
        {
            StopCoroutine("TimerCounter");
            GameOver();
        }

        yield return new WaitForSeconds(1);

        StartCoroutine("TimerCounter");     //---- calling the coroutine again // recursion

    }




    public void ScoreUpdate()
    {
        ScoreTxt.text = "DSL Tokens:" + ++ScoreCount;
    }
    public void ScoreUpdateMinus()
    {
        --ScoreCount;
        if (ScoreCount < 0) 
        {
            ScoreCount = 0;
        }
        ScoreTxt.text = "DSL Tokens:" + ScoreCount;
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    //restartgame button mechanics
    public void restartGame()
    {
        gameoverMenu.SetActive(false);
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

}
