using UnityEngine;

public class trashSeller : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        // stores the inventory script in a variable
        var inventory = interactor.GetComponent<Inventory>();

        // if there is no inventory for some reason then the script stops
        if (inventory == null) return false;

        // if there is something in the inventory then allow the player to sell
        if(inventory.inventorySpace != 0) {
            Debug.Log("Selling Trash for "+ inventory.inventorySpace + "$");
            
            // adds the inventory space to the money and then resets the space to 0
            inventory.money += inventory.inventorySpace;
            inventory.inventorySpace = 0;

            return true;
        }
        
        Debug.Log("Nothing to sell!");
        return false;
    }
}
