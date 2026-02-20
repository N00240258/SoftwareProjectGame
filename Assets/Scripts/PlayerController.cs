using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private GroundController _groundController;

    PlayerInput playerInput;
    InputAction moveAction;
    [SerializeField] float speed = 5;
    [SerializeField] float jump = 2 ;


    private void Awake(){
        _groundController = GetComponent<GroundController>();
    }
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
    }

    void Update()
    {
        
        MovePlayer();
        
    }

    void MovePlayer()
    {
        UnityEngine.Vector3 direction = moveAction.ReadValue<UnityEngine.Vector3>();
        transform.position += new UnityEngine.Vector3(direction.x, 0, direction.y) * speed * Time.deltaTime;
        if(_groundController.isGrounded){
            transform.position += new UnityEngine.Vector3(0, direction.z * jump , 0) * speed * Time.deltaTime;
        }
    }
}
