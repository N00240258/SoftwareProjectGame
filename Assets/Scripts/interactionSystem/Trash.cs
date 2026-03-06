using UnityEngine;
using System.Collections;

public class Trash : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private int _trashSize = 1;
    [SerializeField] private ParticleSystem particleSystem;

    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        var inventory = interactor.GetComponent<Inventory>();

        if (inventory == null) return false;

        if(inventory.inventorySpace + _trashSize <= inventory.inventorySize){

            particleSystem.Play();
            inventory.inventorySpace += _trashSize;
            Debug.Log("Picking up! "+ inventory.inventorySpace);
            
            gameObject.layer = 0;
            gameObject.GetComponent<Collider>().isTrigger = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;

            Destroy(gameObject, 1);
            return true;
        }
        
        Debug.Log("Not enough space!");
        return false;
    }
}
