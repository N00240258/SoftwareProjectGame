using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ShopPurchases : MonoBehaviour
{
    [SerializeField] private int _sizePrice;
    [SerializeField] private int _speedPrice;
    
    [SerializeField] private int _sizeIncrease;
    [SerializeField] private int _speedIncrease;

    [SerializeField] private TextMeshProUGUI _sizeButtonText;
    [SerializeField] private TextMeshProUGUI _speedButtonText;

    [SerializeField] public GameObject _canvas;
    [SerializeField] private VariableDisplay _variableDisplay;
    public GameObject _player;
    private Inventory inventory;
    private ThirdPersonMovement movement;

    private void Start()
    {
        inventory = _player.GetComponent<Inventory>();
        movement = _player.GetComponent<ThirdPersonMovement>();
        _sizeButtonText.text = "Price: " + _sizePrice + "$";
        _speedButtonText.text = "Price: " + _speedPrice + "$";
    }

    public void IncreaseSize()
    {
        if(inventory.money >= _sizePrice)
        {
            inventory.money -= _sizePrice;
            _sizePrice += 1;
            inventory.inventorySize += _sizeIncrease;
            _variableDisplay.inventoryUpdate(inventory);

            _sizeButtonText.text = "Price: " + _sizePrice + "$";
        }
    }

    public void IncreaseSpeed()
    {
        if(inventory.money >= _speedPrice)
        {
            inventory.money -= _speedPrice;
            _speedPrice += 1;
            movement.speed += _speedIncrease;
            _variableDisplay.inventoryUpdate(inventory);

            _speedButtonText.text = "Price: " + _speedPrice + "$";
        }
    }
}