using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Sprite[][] sprites;

    private int size = 4;
    protected int puzzleCreated = 0;

    public DragDrop dp;

    private Dictionary<int , JigsawsGroups> jigsawGroups = new Dictionary<int ,JigsawsGroups>();
    // TODO 
    // change this too check valid
    private void getJigsaw()
    {
        GameObject[] jigsaws = GameObject.FindGameObjectsWithTag("Jigsaw");
        foreach (GameObject jigsaw in jigsaws)
        {
            PuzzlePiece tmp = jigsaw.GetComponent<PuzzlePiece>();

            if (!tmp && tmp.jigsawGroup == -1)
            {
                continue;
            }

            if (!jigsawGroups.ContainsKey(tmp.jigsawGroup))
            {
                jigsawGroups[tmp.jigsawGroup] = new JigsawsGroups();
            }
            else
            {
                 jigsawGroups[tmp.jigsawGroup].add(jigsaw);
            }
        }
    }


    

}

class JigsawsGroups
{

    private int size = 4; 
    public Dictionary<string, GameObject> db;

    public void add(GameObject toAdd)
    {
        string token = toAdd.transform.position.x + "-" + toAdd.transform.position.y;
        db[token] = toAdd;
    }

    public int Check()
    {
        int solve = 0;
        foreach (KeyValuePair<string, GameObject> ele in db)
        {
            string[] token = ele.Key.Split('-');
            int pieceType = ele.Value.GetComponent<PuzzlePiece>().pieceType;

            int x = int.Parse(token[0]);
            int y = int.Parse(token[1]);

            bool fail = false;

            //check 3 connor 
            if (!db.ContainsKey($"{x + size}-{y + size}") || !db.ContainsKey($"{x + size}-{y}") || !db.ContainsKey($"{x}-{y + size}"))
            {
                continue;
            }

            for (int i = x; i < x + size; i++)
            {
                for (int j = y; j < y + size; j++)
                {
                    string key = $"{i}-{j}";

                    if (db[key].GetComponent<PuzzlePiece>().pieceType != pieceType)
                    {
                        fail = true;
                        break;
                    }

                }

                if (fail)
                {
                    break;
                }
            }

            if (fail)
            {
                continue;
            }

            solve++;
        }

        return solve;

    }

}
