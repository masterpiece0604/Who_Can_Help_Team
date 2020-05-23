using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoParent : MonoBehaviour
{
    public Transform informationOldParent;
    public Slot slot;

    private void Update()
    {

        if (slot.controlText == true)
        {
            informationOldParent = transform.parent;
            transform.SetParent(transform.parent.parent);
        }
        else
        {
            transform.SetParent(informationOldParent);
            transform.position = informationOldParent.position;
        }
    }
}
