using UnityEngine;
using System;

public class TableBehaviour
{
   public delegate void roundDelegate();
   public static event roundDelegate newRoundEvent;
   private GameObject[] newTable;
   pointManager pointSystem;
   
   public int[,] boardLogic {get; protected set;} = new int[24,10];

   int[,] currentTetrominoPosition =new int[4,2];

   // updates the position of the piece on the board UI
   public void refreshPosition(int[,] newPosition){
      refreshLogicPosition(0);
      refreshVisualPieceProjection(true);
      coordinateCopy(newPosition,currentTetrominoPosition);
      refreshLogicPosition(2);
      refreshVisualPieceProjection(false);
   }

   public void newPiecePosition(int[,] newPosition){
      coordinateCopy(newPosition,currentTetrominoPosition);
      refreshLogicPosition(2);
      refreshVisualPieceProjection(false);
   }

   private void refreshLogicPosition(int a){
      for(int i=0;i<currentTetrominoPosition.GetLength(0);i++){
         boardLogic[currentTetrominoPosition[i,0],currentTetrominoPosition[i,1]]=a;
      }
   }

   // updates the ui of the entire board
   public void refreshVisualBoardProjection(){
      for(int i=0;i<boardLogic.GetLength(0);i++){
           for(int j=0;j<boardLogic.GetLength(1);j++){
              if(boardLogic[i,j]!=0){
                 newTable[i*10+j].SetActive(false);
              }else{
                 newTable[i*10+j].SetActive(true);
              }
           }
        }
   }

   //updates the ui of the currently moving piece
   private void refreshVisualPieceProjection(bool a){
      for(int i=0;i<currentTetrominoPosition.GetLength(0);i++){
         newTable[currentTetrominoPosition[i,0]*10+currentTetrominoPosition[i,1]].SetActive(a);
      }     
   }

   private bool checkRow(int scrutinezedRow){
      for(int i=0;i< boardLogic.GetLength(1);i++){
         if(boardLogic[scrutinezedRow,i]==0){
            return false;
         }
      }
      return true;
   }

   // writes over a row with the data of the preceding row
   private void overwriteRows(int a){
      for(int i=0;i<boardLogic.GetLength(1);i++){
            boardLogic[a,i]=boardLogic[a-1,i];
      }
   }

   private void removeRow(int completeRow){
      // moves all rows down one increment 
      for(int i=completeRow;i>1;i--){ 
         overwriteRows(i);   
      }
      // resets the first row
      for(int j=0;j<boardLogic.GetLength(1);j++){
         boardLogic[4,j]=0;
      }
   }
   
   // when the piece reaches its final position
   // we check if any of the rows have been completed
   public void finalizedPiecePlacement(){
      int[] temporaryArray= new int[4];

      refreshLogicPosition(1);
      int rowsfreed=0;
      for (int i =0;i<currentTetrominoPosition.GetLength(0);i++){
         temporaryArray[i]=currentTetrominoPosition[i,0];
      }
      
      Array.Sort(temporaryArray);

      foreach (var item in temporaryArray)
      {
          if(checkRow(item)){
            removeRow(item);
            rowsfreed++;
         }
      }
      pointSystem.pointsAquired(rowsfreed);
      newRoundEvent.Invoke();
      refreshVisualBoardProjection();      
   }

   //initializes the array with in-game assets
   public TableBehaviour(GameObject[] Blocks,pointManager points){
      newTable = Blocks;
      pointSystem = points;
   }

   public bool validMove(int[,] newPosition){
        for(int i=0;i<newPosition.GetLength(0);i++){
            if(newPosition[i,0]>23 || newPosition[i,0]<0 || newPosition[i,1]>9 || newPosition[i,1]<0){
                return false;
            }
            if(boardLogic[newPosition[i,0],newPosition[i,1]]==1){
                return false;
            }
        }
      return true;
   }
   
   public bool freeSpaceUnderneath(int[,] newPosition){
        for(int i=0;i<newPosition.GetLength(0);i++){
            if((newPosition[i,0]==23 || boardLogic[newPosition[i,0]+1,newPosition[i,1]]==1)){
                return false;
            }
        }
        return true;
    }

   void coordinateCopy(int[,] a,int[,] b){
      for(int i=0;i<4;i++){
         for(int j=0;j<2;j++){
            b[i,j]=a[i,j];
         }
      }
   }
}
