using UnityEngine;

public class Trash : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private int _trashSize;

    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        var inventory = interactor.GetComponent<Inventory>();


        if (inventory == null) return false;

        if(inventory.inventorySpace + _trashSize <= inventory.inventorySize){
            inventory.inventorySpace += _trashSize;
            Debug.Log("Picking up! "+ inventory.inventorySpace);
            Destroy(gameObject);
            return true;
        }
        
        Debug.Log("Not enough space!");
        return false;
    }
}
