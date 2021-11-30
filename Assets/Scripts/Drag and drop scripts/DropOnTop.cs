using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class DropOnTop : Droppable
    {
        public override void Drop(Transform child, Transform parent, TypeOfStacking type)
        {
            Debug.Log("DropOnTop");

            if (CanBeDropped(child, parent, type) == false)
                return;
            
            child.SetParent(parent);
            child.localPosition = new Vector3(0, 0, 0);

            SetDropType(child);
        }

        public void SetDropType(Transform transform)
        {
            transform.GetComponent<DropReciever>().SetDropType(this);

            transform.GetComponent<DropReciever>().SetTypeOfStacking(transform.parent.GetComponent<DropReciever>().TypeOfStacking);
        }

        private bool CanBeDropped(Transform child, Transform parent, TypeOfStacking type)
        {
            if (child.childCount > 0)
                return false;

            Card catchingCard = base.GetCardFromHolder(parent);
            Card droppingCard = base.GetCardFromHolder(child);

            if (Klondike.CanDrop(droppingCard, catchingCard, type))
                return true;

            return false;
        }
    }
}
