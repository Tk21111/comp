using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    public float snapDistance = 1f;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private GameObject target;

    private GameObject[] grids;
    private GameObject[] jigsaws;

    private float grid = 1;

    public void OnBeginDrag(PointerEventData eventData)
    {
        target = eventData.pointerEnter;

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

        //check when place
        Collider2D[] nearby = Physics2D.OverlapCircleAll(target.transform.position, snapDistance);

        foreach (Collider2D col in nearby)
        {
            Vector2 diff = target.transform.position - col.gameObject.transform.position;

            if (col.gameObject.CompareTag("Jigsaw") && col.gameObject != target && Math.Abs(diff.x) < 2f && Math.Abs(diff.y) < 2f)
            {
                //normalize it => ( 1,0 ) appile size and change pos
                Vector2 normalize = diff.normalized;
                normalize = new Vector2(Mathf.Round(normalize.x), Mathf.Round(normalize.y)) * grid;
                target.transform.position = col.transform.position + (Vector3)normalize;
            }
        }
    }

    //here because override
    public void OnPointerDown(PointerEventData eventData)
    {
        // Debug.Log("OnpointerDown");
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (rectTransform == null) return;

        Vector2 localPoint;

        // Convert the screen position of the pointer into a local point on the canvas
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera,
            out localPoint))
        {
            // Move the rectTransform into that local position
            // Debug.Log(rectTransform.localPosition);
            // Debug.Log(localPoint);
            rectTransform.localPosition = localPoint;
        }
    }



    //TODO 
    //change this too check valid
    // private void Awake()
    // {
    //     // Get tagged objects AFTER the scene has loaded
    //     grids = GameObject.FindGameObjectsWithTag("Grid");
    //     jigsaws = GameObject.FindGameObjectsWithTag("Jigsaw");
    // }



}
