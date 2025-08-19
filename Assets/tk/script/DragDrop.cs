using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
     [SerializeField] private Canvas canvas;
     private RectTransform rectTransform;
     private CanvasGroup canvasGroup;

     private GameObject[] grids;
     private GameObject[] jigsaws;

     private bool isClicked = false;


     public void OnBeginDrag(PointerEventData eventData)
     {
          GameObject target = eventData.pointerEnter;

          rectTransform = target.GetComponent<RectTransform>();
          canvasGroup = target.GetComponent<CanvasGroup>();

          canvasGroup.alpha = .6f;
          canvasGroup.blocksRaycasts = false;
     }

     public void OnEndDrag(PointerEventData eventData)
     {

          canvasGroup.alpha = 1f;
          canvasGroup.blocksRaycasts = true;

          canvasGroup = null;
          rectTransform = null;

          isClicked = false;
     }

     public void OnPointerDown(PointerEventData eventData)
     {
          isClicked = true;
          Debug.Log("OnpointerDown");
     }

     public void OnDrag(PointerEventData eventData)
     {
          Debug.Log("OnDrag");

          rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

     }
   


    private void Awake()
    {
        // DontDestroyOnLoad(this.gameObject);

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
                if (distance < 20f && !isClicked)
                {
                    // Snap jigsaw to grid
                    jigsawRect.position = gridRect.position;
                }
            }
        }
    }

}
