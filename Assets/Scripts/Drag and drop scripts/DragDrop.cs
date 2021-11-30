using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerUpHandler //IDropHandler
{
    [SerializeField] public Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private Vector2 startingPosition;
    private Transform tempParent;

    private bool dragging = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("OnPointerDown"); 
        this.startingPosition = this.transform.localPosition;
    }

    private void InFrontForDragging()
    {
        this.tempParent = this.rectTransform.parent;
        this.rectTransform.SetParent(canvas.transform);
        this.rectTransform.SetAsLastSibling();
    }

    private void ToLocationBeforeDragging()
    {
        this.rectTransform.SetParent(tempParent);
        this.rectTransform.localPosition = startingPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
        this.dragging = true;

        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        //this.startingPosition = this.transform.localPosition;

        /*this.tempParent = this.rectTransform.parent;
        this.rectTransform.SetParent(canvas.transform);
        this.rectTransform.SetAsLastSibling();*/
        InFrontForDragging();


        Debug.Log("DraggingCard = " + this.transform.GetComponent<CardHolder>().Card.GetCardImageName());
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    /*
    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("OnDrop"); // if there is something to drop on, then is called OnDrop in DropReciever and then OnEndDrag
    }*/

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;


        FlipParent(tempParent);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("OnPointerUp");

        if (dragging == true)
        {
            /*this.rectTransform.SetParent(tempParent);
            this.rectTransform.localPosition = startingPosition;*/
            ToLocationBeforeDragging();

            this.dragging = false;
        }
    }

    private void FlipParent(Transform parent)
    {
        if (tempParent.parent != this.canvas.transform) // top parent is foundation and you can't flip it
            if (parent.childCount == 0)
                parent.GetComponentInParent<CardHolder>().FlipCard();
    }
}