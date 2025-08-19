using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour , IPointerDownHandler , IBeginDragHandler , IEndDragHandler , IDragHandler 
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;


   public void OnBeginDrag(PointerEventData eventData)
   {
        GameObject target = eventData.pointerDrag;
        rectTransform = target.GetComponent<RectTransform>();
        canvasGroup =  target.GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            return;
        }

        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
   }

   public void OnEndDrag(PointerEventData eventData)
   {

        if (canvasGroup == null)
        {
            return;
        }
        Debug.Log("OnendDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        canvasGroup = null;
        rectTransform = null;
   }

   public void OnPointerDown(PointerEventData eventData)
   {
        Debug.Log("OnpointerDown");
   }

   public void OnDrag(PointerEventData eventData)
   {
        Debug.Log("OnDrag");
        if (!rectTransform)
        {
            return;
        }
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

   }

}
