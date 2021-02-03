using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tetrominoAdministrator {

    System.Random rnd = new System.Random();

    tetrominoPreview previewTable;
    Queue<char> nextPiece = new Queue<char>();
    
    //Contains a letter to identify piece, an array coressponding to a rotation state 
    //and a matrix containing values that added to the coordinates of a piece will cicle said piece through it's rotations
    Dictionary<char,int[][,]> RotationLibrary = new Dictionary<char, int[][,]>();
    
    //Contains letter to identify piece, and it's initial position
    Dictionary<char,int[,]> allTetrominos = new  Dictionary<char,int[,]>(); 

    //All the letters and a coresponding number to help random generation
    Dictionary<int,char> randomPickHelper = new Dictionary<int, char>();
    
    //verticalSwap and horizontal swap are specific tools to do the rotation for the 'I' piece
    int[,] verticalSwap(int[,] a){
        int[,] temp = new int[4,2];
        temp[0,0]-=1;
        temp[0,1]+=2;
        temp[1,0]+=0;
        temp[1,1]+=1;
        temp[2,0]+=1;
        temp[2,1]+=0;
        temp[3,0]+=2;
        temp[3,1]-=1;
        return temp;
    }
    int[,] horizontalSwap(int[,] a){
        int[,] temp = new int[4,2];
        temp[0,0]+=1;
        temp[0,1]-=2;
        temp[1,0]+=0;
        temp[1,1]-=1;
        temp[2,0]-=1;
        temp[2,1]+=0;
        temp[3,0]-=2;
        temp[3,1]+=1;
        return temp;
    }
    int[][,] computeRotationForI(int[,] a){ 

        int[][,] rotationProcedure= new int[4][,];

        rotationProcedure[0] = verticalSwap(a);

        rotationProcedure[1] =  tetrominoSubCoordinateXY(horizontalSwap(rotationProcedure[0]),+1,0);

        rotationProcedure[2] = tetrominoSubCoordinateXY(verticalSwap(rotationProcedure[1]),-1,-1);

        rotationProcedure[3] = tetrominoSubCoordinateXY(horizontalSwap(rotationProcedure[2]),0,+1);

        return rotationProcedure;
    }

    // O does not rotate so we create an appropriate "map" full of 0 values
    int[][,] createRotationForO(){
        int[][,] rotationProcedure= new int[4][,];

        for(int i = 0;i<4;i++){
            rotationProcedure[i]= new int[4,2];
        }

        return rotationProcedure;
    }

    //moves a piece on the xy axis a predifined amount, helps superRotation
    public static int[,] tetrominoSubCoordinateXY(int[,] a,int x,int y){
        int[,] temp = new int[4,2];

        for(int i=0;i<4;i++){
            temp[i,0]=a[i,0]+x;
            temp[i,1]=a[i,1]+y;
        }
        return temp;
    }
    
    //Create a lookup table of values that when added to the current rotation rezult in the next rotation
    public int[][,] tetrominoCenterRotation(int[,] tetroCoordinats){

        int [][,] rotationProcedure = new int[4][,];

        //initialize null of apropriate size
        for(int i = 0;i<4;i++){
            rotationProcedure[i]= new int[4,2];
        }

        //compute the position of each square (for every roation) in the piece exept the middle one (middle does not move in rotation)
        for(int x=0;x<4;x++){
            if(x==1){
                continue;
            }

            //there are 2 classes of rotation relative to the center (for this class of pieces)
            //all of the 3 mooving squares will always be in one of the 2 classes each containing 4 states  
            int[,] corners = {{-1,-1},{-1,+1},{+1,+1},{+1,-1}};
            int[,] edges = {{0,-1},{-1,0},{0,+1},{+1,0}};

            //calculate relative position
            int[] relativePosition = new int[2];
            int rotationCounter=-1;
            relativePosition[0] = tetroCoordinats[x,0] - tetroCoordinats[1,0];
            relativePosition[1] = tetroCoordinats[x,1] - tetroCoordinats[1,1]; 

            //distinguish wich of the two relative position classes this square belongs to
            for(int i=0;i<4;i++){
                if(relativePosition[0]==corners[i,0] && relativePosition[1]==corners[i,1]){
                    rotationCounter = i;
                    computePieceRotation(corners,relativePosition,rotationCounter,x,rotationProcedure);
                    break;
                }
                if(relativePosition[0]==edges[i,0] && relativePosition[1]==edges[i,1]){
                    rotationCounter = i;
                    computePieceRotation(edges,relativePosition,rotationCounter,x,rotationProcedure);
                    break;
                }
            }
        }
        return rotationProcedure;
    }

    //compute the positions of the square
    void computePieceRotation(int[,] componentType,int[] relativePosition,int rotationCounter,int tetrominoNumber, int[][,] rotationProcedure){
       
        for(int i=0;i<rotationProcedure.GetLength(0);i++){
            rotationCounter=(++rotationCounter)%4;


            for(int j=i;j>=0;j--){
                rotationProcedure[i][tetrominoNumber,0] -= rotationProcedure[j][tetrominoNumber,0];
                rotationProcedure[i][tetrominoNumber,1] -= rotationProcedure[j][tetrominoNumber,1];
            }

            // the position where the square should be at this step deducting the initial relative position
            // and from the above instruction deducting the previous steps that occured
            // resulting in the previous step to this step relative(generalized) directions
            rotationProcedure[i][tetrominoNumber,0] += componentType[rotationCounter,0]-relativePosition[0];
            rotationProcedure[i][tetrominoNumber,1] += componentType[rotationCounter,1]-relativePosition[1];
        }
    }

    void initializeTetrominoList(){
        allTetrominos.Add('T',new int[,]{{4,5},{5,5},{5,4},{5,6}});
        allTetrominos.Add('L',new int[,]{{4,5},{5,5},{6,5},{6,6}});
        allTetrominos.Add('J',new int[,]{{5,4},{5,5},{5,6},{6,6}});
        allTetrominos.Add('S',new int[,]{{4,5},{5,5},{5,6},{6,6}});
        allTetrominos.Add('Z',new int[,]{{5,4},{5,5},{6,5},{6,6}});
        allTetrominos.Add('O',new int[,]{{5,6},{5,5},{6,5},{6,6}});
        allTetrominos.Add('I',new int[,]{{5,4},{5,5},{5,6},{5,7}});
    }
    void initializeRotationLibrary(){
        foreach (var s in allTetrominos){
            if(s.Key!='I' && s.Key!='O'){
                RotationLibrary.Add(s.Key,tetrominoCenterRotation(s.Value));
            }
        }
        RotationLibrary.Add('O',createRotationForO());   
        RotationLibrary.Add('I',computeRotationForI(allTetrominos['I']));    
    }
    void initializeRandomPickHelper(){
        int i=0;
        foreach (var s in allTetrominos){
            randomPickHelper.Add(i++,s.Key);
        }
    }

    public Tetromino newPiece()
    {
        char currentLetter = nextPiece.Dequeue();
        char temp = randomPickHelper[rnd.Next(0, randomPickHelper.Count)];
        previewTable.nextRound(temp);
        nextPiece.Enqueue(temp);
        return new Tetromino(currentLetter, RotationLibrary[currentLetter], allTetrominos[currentLetter]);
    }

    public Dictionary<char,int[][,]> getRotationLibrary(){
        return RotationLibrary;
    }
    
    public tetrominoAdministrator(tetrominoPreview tablePreview){
        previewTable=tablePreview;

        initializeTetrominoList();
        initializeRotationLibrary();
        initializeRandomPickHelper();

        char temp;
        
        for(int i=0;i<3;i++){
            temp = randomPickHelper[rnd.Next(0,randomPickHelper.Count)];
            previewTable.nextRound(temp);
            nextPiece.Enqueue(temp);
        }
    }
}
