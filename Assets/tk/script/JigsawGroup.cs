// using System;
// using UnityEngine;

// ================================================
// i decide not too ;)
// ================================================

// public class JigsawGroup
// {
//     public int size = 4;
//     private string[][] jigsawGroup = new string[4][];
    


//     public JigsawGroup(string id)
//     {
//         Init(jigsawGroup);
//         jigsawGroup[0][0] = id;
//     }
//     public void addJigsaw(int x, int y, string id)
//     {
//         if (x < 0)
//         {
//             //need push 

//         }
//         else if (y < 0)
//         {

//         }
//         else if (x > size - 1 || y > size - 1)
//         {
//             //out of range
//         }
//         else
//         {
//             jigsawGroup[x][y] = id;
//         }
//     }

//     public void remove(string id)
//     {
//         for (int i = 0; i < size; i++)
//         {
//             for (int j = 0; j < size; j++)
//             {
//                 if (jigsawGroup[i][j] == id)
//                 {
//                     jigsawGroup[i][j] = null;
//                 }
//             }
//         }
//     }

//     // =============== helper =====================
//     private void pushIRight()
//     {
//         size = jigsawGroup.Length + 1; 
//         string[][] newData = new string[size][];

//         newData = Init(newData);

//         for (int i = 0; i < jigsawGroup.Length; i++)
//         {
//             for (int j = 0; j < jigsawGroup[i].Length; j++)
//             {
//                 newData[i + 1][j] = jigsawGroup[i][j];
//             }
//         }

//         jigsawGroup = newData;
//     }

//     private string[][] Init(string[][] toInit)
//     {
//         for (int i = 0; i < size; i++)
//             toInit[i] = new string[size];
//         return toInit;
//     }

//     private void pushJRight()
//     {
//         string[][] newData = new string[4][];

//         for (int i = 0; i < size - 1; i++)
//         {
//             for (int j = 0; j < size - 2; j++)
//             {
//                 newData[i][j + 1] = jigsawGroup[i][j];
//             }
//         }

//         jigsawGroup = newData;
//     }
// }
