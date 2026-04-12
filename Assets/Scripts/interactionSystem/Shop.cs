using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.UI;


public class Shop : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] public GameObject _canvas;
    [SerializeField] public CinemachineCamera _camera;

    public string InteractionPrompt => _prompt;

    private void Start()
    {
        _canvas.SetActive(false);
    }

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Opening Shop");
        if (_canvas.activeSelf)
        {
            _canvas.SetActive(false);
            _camera.GetComponent<CinemachineInputAxisController>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            _canvas.SetActive(true);
            _camera.GetComponent<CinemachineInputAxisController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }

        

        return true;
    }
}

