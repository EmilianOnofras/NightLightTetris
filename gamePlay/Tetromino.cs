public class Tetromino
{
    public static readonly  int[,,] superRotation = new int[,,] {{{0,0},{-1,0},{-1,1},{0,-2},{-1,-2}},
                                                {{0,0},{1,0},{1,-1},{0,2},{1,2}},
                                                {{0,0},{1,0},{1,1},{0,-2},{1,-2}},
                                                {{0,0},{-1,0},{-1,-1},{0,2},{-1,2}}};

    // public static readonly int[,,] superReverseRotation = new int[,,] {{{0,0},{1,0},{1,-1},{0,2},{1,2}},
    //                                                         {{0,0},{-1,0},{-1,1},{0,-2},{-1,-2}},
    //                                                         {{0,0},{-1,0},{-1,-1},{0,2},{-1,2}},
    //                                                         {{0,0},{1,0},{1,1},{0,-2},{1,-2}}};

    public static readonly int[,,] pieceIsuperRotation = new int[,,] {{{0,0},{-2,0},{1,0},{-2,-1},{1,2}},
                                                {{0,0},{-1,0},{2,0},{-1,2},{2,-1}},
                                                {{0,0},{2,0},{-1,0},{2,1},{-1,-2}},
                                                {{0,0},{1,0},{-2,0},{1,-2},{-2,1}}};

    // public static readonly int[,,] pieceIsuperReverseRotation = new int[,,] {{{0,0},{2,0},{-1,0},{2,1},{-1,-2}},
    //                                                         {{0,0},{1,0},{-2,0},{1,-2},{-2,1}},
    //                                                         {{0,0},{-2,0},{1,0},{-2,-1},{1,2}},
    //                                                         {{0,0},{-1,0},{2,0},{-1,2},{2,-1}}};                    

    private int[,] pieceLocation;
    private int[,] nextMove;

    char letterDesignation;
    
    int[][,] rotationTable;
    int nextRotation=0;

    private void horizontalMovement(int direction){
        nextMove[0,1]+=direction;
        nextMove[1,1]+=direction;
        nextMove[2,1]+=direction;
        nextMove[3,1]+=direction;
    }

    public int[,] moveLeft(){
        horizontalMovement(-1);
        return nextMove;
    }

    public int[,] moveRight(){
        horizontalMovement(1);
        return nextMove;
    }

    public int[,] moveDown(){
        nextMove[0,0]++;
        nextMove[1,0]++;
        nextMove[2,0]++;
        nextMove[3,0]++;
        return nextMove;
    }

    public int[][,] rotatate(){
        for(int i=0;i<4;i++){
            for(int j=0;j<2;j++){
                nextMove[i,j]+=rotationTable[nextRotation][i,j];
            }
        }
        int[][,] rotationOpportunities= new int[5][,];

        if(letterDesignation!='I'){
            for(int i=0;i<rotationOpportunities.GetLength(0);i++){
                rotationOpportunities[i] = tetrominoAdministrator.tetrominoSubCoordinateXY(nextMove,superRotation[nextRotation,i,0],superRotation[nextRotation,i,0]);
            }
        }else{
            for(int i=0;i<rotationOpportunities.GetLength(0);i++){
                rotationOpportunities[i] = tetrominoAdministrator.tetrominoSubCoordinateXY(nextMove,pieceIsuperRotation[nextRotation,i,0],pieceIsuperRotation[nextRotation,i,0]);
            }            
        }


        return rotationOpportunities; 
    }


    //The above methods send a potential new position to the gamemaster
    //After validation the new position is accepted or declined 
    public void confirmBasicMove(){
        updateLocationState(nextMove,pieceLocation);
    }
    public void confirmRotation(int[,] newRotation){
        updateLocationState(newRotation,nextMove); 
        updateLocationState(nextMove,pieceLocation);
        nextRotation=(++nextRotation)%4;
    }
    public void cancelMove(){
         updateLocationState(pieceLocation,nextMove);
    }


    public int[,] getPieceLocation(){
        return pieceLocation;
    }
    public int[,] nextLocation(){
        return nextMove;
    }
    private void updateLocationState(int[,] a, int[,] b){
        for(int i=0;i<4;i++){
            for(int j=0;j<2;j++){
                b[i,j]=a[i,j];
            }
        }
    }

    public Tetromino(char corespondingLetter,int[][,] rotationTbl,int[,] location){

        pieceLocation = new int[,] {{location[0,0],location[0,1]},{location[1,0],location[1,1]},
                                    {location[2,0],location[2,1]},{location[3,0],location[3,1]}};

        nextMove = new int[,] {{location[0,0],location[0,1]},{location[1,0],location[1,1]},
                                {location[2,0],location[2,1]},{location[3,0],location[3,1]}};

        rotationTable = rotationTbl;
        letterDesignation = corespondingLetter; 
    }
}
