using UnityEngine;
using UnityEngine.UI;


public class Shop : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] public GameObject _canvas;

    public string InteractionPrompt => _prompt;

    private void Start()
    {
        _canvas.SetActive(false);
    }

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Opening Shop");
        _canvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;

        return true;
    }
}

