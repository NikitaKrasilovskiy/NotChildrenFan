using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UMG_RPS : MonoBehaviour
{
    public int gameState;
    public UMG_Canvas_All canvasAll;

    public void RPS()
    {
        switch (gameState)
        {
            case 0:
                canvasAll.RpsStatePlayer = 1;
                break;
            case 1:
                canvasAll.RpsStatePlayer = 2;
                break;
            case 2:
                canvasAll.RpsStatePlayer = 3;
                break;
        }

        canvasAll.RPSStartGame();
    }
}
