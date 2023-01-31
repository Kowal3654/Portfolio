using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    void Awake()
    {   
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 2;

    public List<Item> items = new List<Item>();

    public bool Add (Item item)
    {   
        if(items.Count < space){
            items.Add(item);

            if(onItemChangedCallback != null){
                onItemChangedCallback.Invoke();
                }
            return true;
        }
        else {
            Debug.Log("Not enough room in the inventory.");
            return false;
        }
    }

    public void Remove (Item item)
    {
        items.Remove(item);

        if(onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
