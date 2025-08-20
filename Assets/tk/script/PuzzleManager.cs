using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotParent;
    [SerializeField] private GameObject jigsawPrefab;
    [SerializeField] private Transform puzzleArea;  


    private void Awake()
    {
        LoadPuzzle();
    }

    private void LoadPuzzle()
    {
        // Load all sliced sprites from Resources folder
        Sprite[] pieces = Resources.LoadAll<Sprite>("jigsawImage/DSC01486");

        // Debug.Log(pieces[0]);
        foreach (Sprite pieceSprite in pieces)
        {
            GameObject piece = Instantiate(jigsawPrefab, puzzleArea);

            // Set the sprite
            piece.GetComponent<UnityEngine.UI.Image>().sprite = pieceSprite;

            // Random start position
            RectTransform rect = piece.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(
                Random.Range(-20, 20),
                Random.Range(-20, 20)
            );

            // Name it for debugging
            piece.name = "Piece_" + pieceSprite.name;
        }
    }

}
