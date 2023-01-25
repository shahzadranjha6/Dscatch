using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenus : MonoBehaviour
{
    public static InGameMenus instance;
    // PauseMenu and PauseButton fields to get reference
    [SerializeField] private GameObject pauseButton;
    [SerializeField] public GameObject pauseMenu;
    
    // quitgame button mechanics
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    //resumegame button mechanics
    public void resumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false); 
        pauseButton.SetActive(true);
        
    }
    //pausegame button mechanics and active pause panel
    public void pauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
    }
    //restartGame button mechanics
    public void restartGame()
    {
        pauseMenu.SetActive(false);
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    //Mainmenu Play button method
    public void mainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
