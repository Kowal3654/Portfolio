using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;

    Item item;

    public void AddItem(Item newitem)
    {
        item = newitem;

        icon.sprite = item.icon;
        icon.enabled = true;
        //Button staje się widzialny 
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        //Button przestaje działać
    }
}
