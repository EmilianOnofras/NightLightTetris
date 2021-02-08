using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class startPanel : MonoBehaviour
{
    public Button startButton;
    public Button resumeButton;
    public Button restartButton;

    public GameObject gMaster;
    public GameObject thisPanel;
    
    public void gamePaused(){
        startButton.interactable=false;
        resumeButton.interactable=true;
        restartButton.interactable=true;
    }

    public void gameFinished(){
        startButton.interactable=true;
        resumeButton.interactable=false;
        restartButton.interactable=false;
    }

    public void startGame(){ // i probably can expect a function that restarts the scene to work right
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        thisPanel.SetActive(false);
        gMaster.GetComponent<gameMasterScript>().startGame();
    }

    public void resumeGame(){
        gMaster.GetComponent<gameMasterScript>().resumeGame();
        thisPanel.SetActive(false);
    }

    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        thisPanel.SetActive(false);
        gMaster.GetComponent<gameMasterScript>().startGame();
    }

    public void Quit(){
        Debug.Log("Y THO");
        Application.Quit();
    }

}
