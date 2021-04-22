using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class startPanel : MonoBehaviour
{
    public Button startButton;
    public Button resumeButton;
    public Button restartButton;
    public Button goToScore;

    public GameObject gMaster;
    public GameObject thisPanel;
    public GameObject scorePanel;
    
    public void gamePaused(){
        startButton.interactable=false;
        resumeButton.interactable=true;
        restartButton.interactable=true;
    }

    public void gameFinished(){
            thisPanel.SetActive(true);
            startButton.interactable=true;
            resumeButton.interactable=false;
            restartButton.interactable=false;
    }

    public void startGame(){
        thisPanel.SetActive(false);
        gMaster.GetComponent<gameMasterScript>().startGame();
    }

    public void resumeGame(){
        gMaster.GetComponent<gameMasterScript>().resumeGame();
        thisPanel.SetActive(false);
    }

    public void restartGame(){
        gMaster.GetComponent<gameMasterScript>().restartGame();
        thisPanel.SetActive(false);
    }

    public void showScore(){
        thisPanel.SetActive(false);
        scorePanel.SetActive(true);
    }

    public void showMenu(){
        thisPanel.SetActive(true);
    }

    public void Quit(){
        Debug.Log("Y THO");
        Application.Quit();
    }

}
