using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject[] grids;
    private GameObject[] jigsaws;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        // Get tagged objects AFTER the scene has loaded
        grids = GameObject.FindGameObjectsWithTag("Grid");
        jigsaws = GameObject.FindGameObjectsWithTag("Jigsaw");
    }

    private void Update()
    {
        foreach (GameObject grid in grids)
        {
            RectTransform gridRect = grid.GetComponent<RectTransform>();

            foreach (GameObject jigsaw in jigsaws)
            {
                RectTransform jigsawRect = jigsaw.GetComponent<RectTransform>();

                // Check distance between their positions
                float distance = Vector3.Distance(gridRect.position, jigsawRect.position);


                // Debug.Log(grid.name + " " + distance + " " + jigsaw.name);
                if (distance < 20f)
                {
                    // Snap jigsaw to grid
                    jigsawRect.position = gridRect.position;
                }
            }
        }
    }
}
