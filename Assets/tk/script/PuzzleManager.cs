using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotParent;
    [SerializeField] private GameObject jigsawPrefab;  // your prefab with DragDrop + CanvasGroup
    [SerializeField] private Transform puzzleArea;     // parent (Canvas Panel or empty GameObject)


    private void Awake()
    {
        LoadPuzzle();
        GenerateGrid();
    }

    private void LoadPuzzle()
    {
        // Load all sliced sprites from Resources folder
        Sprite[] pieces = Resources.LoadAll<Sprite>("jigsawImage/DSC01486");

        // Debug.Log(pieces[0]);
        foreach (Sprite pieceSprite in pieces)
        {
            Debug.Log("mewo");
            GameObject piece = Instantiate(jigsawPrefab, puzzleArea);

            // Set the sprite
            piece.GetComponent<UnityEngine.UI.Image>().sprite = pieceSprite;

            // Random start position
            RectTransform rect = piece.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(
                Random.Range(-300, 300),
                Random.Range(-200, 200)
            );

            // Name it for debugging
            piece.name = "Piece_" + pieceSprite.name;
        }
    }

    private void GenerateGrid()
    {
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                GameObject slot = Instantiate(slotPrefab, slotParent);

                RectTransform rt = slot.GetComponent<RectTransform>();

                rt.anchoredPosition = new Vector2(x * (100 + 0), y * (100 + 0));

                slot.name = "Slot" + x + y;
            }
        }
    }
}
