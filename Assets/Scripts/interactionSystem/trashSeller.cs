using UnityEngine;

public class trashSeller : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        var inventory = interactor.GetComponent<Inventory>();

        if (inventory == null) return false;

        if(inventory.inventorySpace != 0) {
            Debug.Log("Selling Trash for "+ inventory.inventorySpace + "$");
            
            inventory.money += inventory.inventorySpace;
            inventory.inventorySpace = 0;

            return true;
        }
        
        Debug.Log("Nothing to sell!");
        return false;
    }
}
