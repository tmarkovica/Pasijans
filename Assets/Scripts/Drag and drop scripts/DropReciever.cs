using UnityEngine;
using UnityEngine.EventSystems;

public class DropReciever : MonoBehaviour, IDropHandler
{
    public Droppable DropType
    {
        get;
        set;
    }

    public TypeOfStacking TypeOfStacking
    {
        get;
        set;
    }

    public void SetDropType(Droppable dropType) { this.DropType = dropType; }

    public void SetTypeOfStacking(TypeOfStacking typeOfStacking) { this.TypeOfStacking = typeOfStacking; }

    public void OnDrop(PointerEventData eventData) // recieve card
    {
        if (eventData.pointerDrag != null)
        {
            Debug.Log("dropping card = " + eventData.pointerDrag.transform.name + "; typeOfStacking = " + this.TypeOfStacking);

            if (this.TypeOfStacking == TypeOfStacking.NONE)
                return;
                        
            this.DropType.Drop(eventData.pointerDrag.transform, this.transform, this.TypeOfStacking); // void OnDrop("dragged card", "recieving card/foundation", TypeOfStacking)
        }
    }
}