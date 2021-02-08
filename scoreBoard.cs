using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class scoreBoard : MonoBehaviour
{

    public Text firstHighScoreName,secondHighScoreName,thirdHighScoreName,fourthHighScoreName,fifthHighScoreName;
    public Text firstHighScoreValue,secondHighScoreValue,thirdHighScoreValue,fourthHighScoreValue,fifthHighScoreValue;
    public Text finalCurrentScore;
    public GameObject Disclaimer;
    public GameObject inputPanel;

    public InputField newName;
    public Button finalizeNewAddition;

    Dictionary<string,int> newHierarchy = new Dictionary<string, int>();

    void Start(){
        finalCurrentScore.text="0";
        newName.characterLimit=3;

        newHierarchy.Add(PlayerPrefs.GetString("highScoreOneName","AAA"),PlayerPrefs.GetInt("highScoreOneValue",0));
        newHierarchy.Add(PlayerPrefs.GetString("highScoreTwoName","BBB"),PlayerPrefs.GetInt("highScoreTwoValue",0));
        newHierarchy.Add(PlayerPrefs.GetString("highScoreThreeName","CCC"),PlayerPrefs.GetInt("highScoreThreeValue",0));
        newHierarchy.Add(PlayerPrefs.GetString("highScoreFourName","DDD"),PlayerPrefs.GetInt("highScoreFourValue",0));
        newHierarchy.Add(PlayerPrefs.GetString("highScoreFiveName","EEE"),PlayerPrefs.GetInt("highScoreFiveValue",0));
            
        firstHighScoreName.text=PlayerPrefs.GetString("highScoreOneName","AAA");
        firstHighScoreValue.text=PlayerPrefs.GetInt("highScoreOneValue",0).ToString();
        secondHighScoreName.text=PlayerPrefs.GetString("highScoreTwoName","BBB");
        secondHighScoreValue.text=PlayerPrefs.GetInt("highScoreTwoValue",0).ToString();
        thirdHighScoreName.text=PlayerPrefs.GetString("highScoreThreeName","CCC");
        thirdHighScoreValue.text=PlayerPrefs.GetInt("highScoreThreeValue",0).ToString();
        fourthHighScoreName.text=PlayerPrefs.GetString("highScoreFourName","DDD");
        fourthHighScoreValue.text=PlayerPrefs.GetInt("highScoreFourValue",0).ToString();
        fifthHighScoreName.text=PlayerPrefs.GetString("highScoreFiveName","EEE");
        fifthHighScoreValue.text=PlayerPrefs.GetInt("highScoreFiveValue",0).ToString();
    }

    public void gameIsDone(){
        if(int.Parse(finalCurrentScore.text) < int.Parse(finalCurrentScore.text)){
            inputPanel.SetActive(false);
        }
    }

    public void addCurrentValues(){
        bool validName=true;

        foreach(var a in newHierarchy){
            if(newName.text==a.Key){
                Disclaimer.SetActive(true);
                validName=false;
            }
        }

        if(validName){
            newHierarchy.Add(newName.text,int.Parse(finalCurrentScore.text));
            inputPanel.SetActive(false);
            
            //these should not be here but it respects the execution order
            var sortedDictionary = from entry in newHierarchy orderby entry.Value descending select entry;
            setNewScoreBoard(sortedDictionary);
        }


    }

    void setNewScoreBoard(IOrderedEnumerable<KeyValuePair<string,int>> orderedResults){

        firstHighScoreName.text=orderedResults.ElementAt(0).Key;
        firstHighScoreValue.text=orderedResults.ElementAt(0).Value.ToString();
        secondHighScoreName.text=orderedResults.ElementAt(1).Key;
        secondHighScoreValue.text=orderedResults.ElementAt(1).Value.ToString();
        thirdHighScoreName.text=orderedResults.ElementAt(2).Key;
        thirdHighScoreValue.text=orderedResults.ElementAt(2).Value.ToString();
        fourthHighScoreName.text=orderedResults.ElementAt(3).Key;
        fourthHighScoreValue.text=orderedResults.ElementAt(3).Value.ToString();

        if(orderedResults.ElementAt(4).Value==orderedResults.ElementAt(5).Value &&
            orderedResults.ElementAt(5).Key==newName.text){
                fifthHighScoreName.text=orderedResults.ElementAt(5).Key;
                fifthHighScoreValue.text=orderedResults.ElementAt(5).Value.ToString();
        }else{ //if the new name is in the 5th placement it's going to display anyway;
                fifthHighScoreName.text=orderedResults.ElementAt(4).Key;
                fifthHighScoreValue.text=orderedResults.ElementAt(4).Value.ToString();
        }

        Debug.Log("It happened after this");
        
        PlayerPrefs.SetString("highScoreOneName",firstHighScoreName.text);
        PlayerPrefs.SetString("highScoreTwoName",secondHighScoreName.text);
        PlayerPrefs.SetString("highScoreThreeName",thirdHighScoreName.text);
        PlayerPrefs.SetString("highScoreFourName",fourthHighScoreName.text);
        PlayerPrefs.SetString("highScoreFiveName",fifthHighScoreName.text);

        PlayerPrefs.SetInt("highScoreOneValue",int.Parse(firstHighScoreValue.text));
        PlayerPrefs.SetInt("highScoreTwoValue",int.Parse(secondHighScoreValue.text));
        PlayerPrefs.SetInt("highScoreThreeValue",int.Parse(thirdHighScoreValue.text));
        PlayerPrefs.SetInt("highScoreFourValue",int.Parse(fourthHighScoreValue.text));
        PlayerPrefs.SetInt("highScoreFiveValue",int.Parse(fifthHighScoreValue.text));
    }

}
