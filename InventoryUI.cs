using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif
using StarterAssets;

public class InventoryUI : MonoBehaviour
{
    private StarterAssetsInputs _input;

    public Transform itemsParent;
    public GameObject inventoryUI;

    Inventory inventory;

    InventorySlot[] slots;

    void Start()
    {
        _input = GameObject.Find("PlayerCapsule").GetComponent<StarterAssetsInputs>();

        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_input.openInventory)
        {   
			inventoryUI.SetActive(!inventoryUI.activeSelf);
            _input.openInventory = false;
		}
    }

    void UpdateUI()
    {   
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }

        Debug.Log("UPDATING UI");
    }
}
