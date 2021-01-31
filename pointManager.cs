using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointManager 
{
    Text gameScore;
    int currentPoints;
    public pointManager(Text a ){
        gameScore = a;
        gameScore.text="0";
        currentPoints = 0;;
    }

    public void pointsAquired(int numberOfRows){
        if(numberOfRows==1){
            currentPoints += 100;
            gameScore.text = currentPoints.ToString();
        }else{
            currentPoints += numberOfRows * 200;
            gameScore.text = currentPoints.ToString();
        }
    }
}
