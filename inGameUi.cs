using UnityEngine;
using UnityEngine.SceneManagement;

public class inGameUi : MonoBehaviour
{
    public GameObject gMaster;
    public GameObject startPan;
    public void pauseButton(){
        gMaster.GetComponent<gameMasterScript>().pauseGame();
        startPan.SetActive(true);
    }
}
