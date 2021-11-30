using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class DropOnFoundation : Droppable
    {
        public Droppable dropOnTop;
        public Droppable dropShifted;

        public override void Drop(Transform child, Transform parent, TypeOfStacking type)
        {
            // ako je temelj(4) / ASC - prima samo aseve, i jednu jedinu kartu (bez djece)
            // ako je temelj(7) / DSC - prima samo kraljeve
            Debug.Log("DropOnFoundation");

            if (CanBeDropped(child, parent, type) == false)
                return;



            child.SetParent(parent);
            child.localPosition = new Vector3(0, 0, 0);

            SetDropType(child);
        }

        public void SetDropType(Transform transform)
        {
            if (transform.parent.GetComponent<DropReciever>().TypeOfStacking == TypeOfStacking.ASC)
            {
                transform.GetComponent<DropReciever>().SetDropType(dropOnTop);
                transform.GetComponent<DropReciever>().SetTypeOfStacking(transform.parent.GetComponent<DropReciever>().TypeOfStacking);
            }
            else if (transform.parent.GetComponent<DropReciever>().TypeOfStacking == TypeOfStacking.DSC)
            {
                transform.GetComponent<DropReciever>().SetDropType(dropShifted);
                transform.GetComponent<DropReciever>().SetTypeOfStacking(transform.parent.GetComponent<DropReciever>().TypeOfStacking);
            }
        }

        private bool CanBeDropped(Transform child, Transform parent, TypeOfStacking type)
        {
            if (parent.childCount != 0)
                return false;

            if (child.childCount != 0 && type == TypeOfStacking.ASC)
                return false;                     

            Card droppingCard = base.GetCardFromHolder(child);
            Card catchingCard = base.GetCardFromHolder(parent);

            if (catchingCard != null)
                return false;

            if (Klondike.CanDrop(droppingCard, type))
                return true;

            return false;
        }
    }
}
