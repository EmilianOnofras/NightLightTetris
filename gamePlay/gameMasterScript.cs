using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameMasterScript : MonoBehaviour
{
    public GameObject[] uiBlocks = new GameObject[240];
    public GameObject[] previewTableOne = new GameObject[16]; 
    public GameObject[] previewTableTwo = new GameObject[16]; 
    public GameObject[] previewTableThree = new GameObject[16];  
    TableBehaviour tableSystem ;
    tetrominoAdministrator tetAdmin;

    public GameObject ScorePanel;

    tetrominoPreview previewTable;
    Tetromino currentPiece;
    Dictionary<char,int[][,]> RotationLibrary;
    public Text score;

    public PlayerInput player_Input;

    private pointManager pointSystem;

    public void startGame()
    {
        pointSystem = new pointManager(score);
        tableSystem = new TableBehaviour(uiBlocks,pointSystem);
        previewTable = new tetrominoPreview(previewTableOne,previewTableTwo,previewTableThree);  
        tetAdmin = new tetrominoAdministrator(previewTable);
      
        RotationLibrary = tetAdmin.getRotationLibrary();
        generateNewPiece();
        tableSystem.refreshPosition(currentPiece.getPieceLocation());

        TableBehaviour.newRoundEvent+=generateNewPiece;
        InvokeRepeating("moveDownAuto",0f,0.85f);
    }

    public void pauseGame(){
        player_Input.SwitchCurrentActionMap("UI"); 
        CancelInvoke();
    }

    public void resumeGame(){
        player_Input.SwitchCurrentActionMap("Player");
        InvokeRepeating("moveDownAuto",0f,0.85f);
    }

    public void generateNewPiece(){
        currentPiece = tetAdmin.newPiece();
        if(tableSystem.validMove(currentPiece.getPieceLocation())){
            tableSystem.newPiecePosition(currentPiece.getPieceLocation());
        }else{
            ScorePanel.SetActive(true);
            ScorePanel.GetComponent<scoreBoard>().gameIsDone();
            player_Input.SwitchCurrentActionMap("UI"); 
            Debug.Log("U did good");
            CancelInvoke();
        }

    }

    public void moveLeft(InputAction.CallbackContext context){
        if(context.performed){
            if(tableSystem.validMove(currentPiece.moveLeft())){
                currentPiece.confirmBasicMove();
                tableSystem.refreshPosition(currentPiece.getPieceLocation());
            }else{
                currentPiece.cancelMove();
            }
        }
    }

    public void moveRight(InputAction.CallbackContext context){
        if(context.performed){
            if(tableSystem.validMove(currentPiece.moveRight())){
                currentPiece.confirmBasicMove();
                tableSystem.refreshPosition(currentPiece.getPieceLocation());
            }else{
                currentPiece.cancelMove();
            }
        }
    }

    public void moveDown(InputAction.CallbackContext context){
        if(context.performed){
            if(tableSystem.validMove(currentPiece.moveDown())){
                currentPiece.confirmBasicMove();
                tableSystem.refreshPosition(currentPiece.getPieceLocation());
            }else{
                currentPiece.cancelMove();
            }

            if(!tableSystem.freeSpaceUnderneath(currentPiece.getPieceLocation())){
                StartCoroutine(waitBeforeFinalizingPlacement());
            }
        } 
    }

    public void moveDownAuto(){
        if(tableSystem.validMove(currentPiece.moveDown())){
            currentPiece.confirmBasicMove();
            tableSystem.refreshPosition(currentPiece.getPieceLocation());
            }else{
            currentPiece.cancelMove();
        }

        if(!tableSystem.freeSpaceUnderneath(currentPiece.getPieceLocation())){
            StartCoroutine(waitBeforeFinalizingPlacement());
        }
    }

    public void rotatePiece(InputAction.CallbackContext context){
        if(context.performed){
            var possibleRotations = currentPiece.rotatate();
            bool foundNew = false;
            int i=0;

            while(!foundNew && i<possibleRotations.GetLength(0)){
                if(tableSystem.validMove(possibleRotations[i])){
                    currentPiece.confirmRotation(possibleRotations[i]);
                    tableSystem.refreshPosition(currentPiece.getPieceLocation());
                    foundNew=true;
                }
                i++;
            }

            if(foundNew==false){
                currentPiece.cancelMove();  
            }
        }
    }

    public void fastDown(InputAction.CallbackContext context){
        if(context.performed){
            while(tableSystem.freeSpaceUnderneath(currentPiece.getPieceLocation())){
                moveDownAuto();
            }
        }
    }

    IEnumerator waitBeforeFinalizingPlacement(){
        yield return new WaitForSeconds(1.5f);

        if(!tableSystem.freeSpaceUnderneath(currentPiece.getPieceLocation())){                    
                currentPiece.cancelMove();
                tableSystem.finalizedPiecePlacement();
            }
    }
}