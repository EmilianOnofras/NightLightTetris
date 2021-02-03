using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tetrominoPreview
{
    GameObject[] firstPanel;
    GameObject[] secondPanel;
    GameObject[] thirdPanel;

    Dictionary<char,int[,]> letterValueTable = new Dictionary<char, int[,]>();

    public tetrominoPreview(GameObject[] previewTableOne,GameObject[] previewTableTwo,GameObject[] previewTableThree){
        firstPanel = previewTableOne;
        secondPanel = previewTableTwo;
        thirdPanel = previewTableThree;
        initializeDictionary();
    }

    public void nextRound(char newCharacter){
        transferPanelValue(firstPanel,secondPanel);
        transferPanelValue(secondPanel,thirdPanel);
        diplayPieceOnPanel(thirdPanel,newCharacter);
    }

    void initializeDictionary(){
        letterValueTable.Add('T',new int[,]{{0,1},{1,1},{1,0},{1,2}});
        letterValueTable.Add('L',new int[,]{{0,1},{1,1},{2,1},{2,2}});
        letterValueTable.Add('J',new int[,]{{1,0},{1,1},{1,2},{2,2}});
        letterValueTable.Add('S',new int[,]{{0,1},{1,1},{1,2},{2,2}});
        letterValueTable.Add('Z',new int[,]{{1,0},{1,1},{2,1},{2,2}});
        letterValueTable.Add('O',new int[,]{{1,2},{1,1},{2,1},{2,2}});
        letterValueTable.Add('I',new int[,]{{1,0},{1,1},{1,2},{1,3}});
    }

    void diplayPieceOnPanel(GameObject[] targetPanel,char pieceLetter){

        resetPanel(targetPanel);

        switch(pieceLetter){
            case 'I':
                setPanel(targetPanel,letterValueTable['I']);                
                break;
            case 'J':
                setPanel(targetPanel,letterValueTable['J']);
                break;
            case 'L':
                setPanel(targetPanel,letterValueTable['L']);
                break;
            case 'S':
                setPanel(targetPanel,letterValueTable['S']);
                break;
            case 'Z':
                setPanel(targetPanel,letterValueTable['Z']);
                break;
            case 'T':
                setPanel(targetPanel,letterValueTable['T']);
                break;
            case 'O':
                setPanel(targetPanel,letterValueTable['O']);
                break;
        }
    }

    void setPanel(GameObject[] targetPanel, int[,] letter)
    {
        for (int i = 0; i < targetPanel.Length; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (i == letter[j, 0] * 4 + letter[j, 1])
                {
                    targetPanel[i].SetActive(false);
                }
            }
        }
    }

    void resetPanel(GameObject[] targetPanel){
        for(int i=0;i<targetPanel.Length;i++){
            targetPanel[i].SetActive(true);
        }
    }

    void transferPanelValue(GameObject[] targetPanel,GameObject[] OriginalPanel){
        resetPanel(targetPanel);
        for(int i=0; i<targetPanel.Length;i++){
            if(OriginalPanel[i].activeSelf==false){
                targetPanel[i].SetActive(false);
            }
        }
    }
}
