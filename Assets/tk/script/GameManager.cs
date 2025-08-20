using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Sprite[][] sprites;
    private GameObject[] jigsaws;
    private int size;
    protected int puzzleCreated = 0;

    private string[][][] key;
    // TODO 
    // change this too check valid
    private void getJigsaw()
    {

        jigsaws = GameObject.FindGameObjectsWithTag("Jigsaw");
    }

    public bool check()
    {
        int puzzleFinish = 0;
        foreach (GameObject jigsaw in jigsaws)
        {
            Vector2 pos = jigsaw.transform.position;

            int pieceType = jigsaw.GetComponent<PuzzlePiece>().pieceType;

            if (pieceType == 0)
            {
                continue;
            }

            int count = 0;
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - 1; j++)
                {
                    foreach (GameObject obj in jigsaws)
                    {
                        PuzzlePiece tmp = obj.GetComponent<PuzzlePiece>();
                        if (pieceType == tmp.pieceType && key[pieceType][i][j] == tmp.pieceId)
                        {
                            count++;
                        }
                    }
                }
            }

            if (count == size * size)
            {
                puzzleFinish++;
            }

        }

        if (puzzleFinish == puzzleCreated)
        {
            return true;
        }

        return false;

    }

}
