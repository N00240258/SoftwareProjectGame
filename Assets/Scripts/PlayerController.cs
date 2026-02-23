using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private GroundController _groundController;
    //private UnityEngine.Vector3 _rotatedVector;
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
        float xValue = Input.GetAxis("Horizontal");
        float zValue = Input.GetAxis("Vertical");

        transform.Translate(xValue,0 ,zValue);


        //MovePlayer();
        
    }

    void MovePlayer()
    {
        UnityEngine.Vector3 direction = moveAction.ReadValue<UnityEngine.Vector3>();
        var rotationAngle = transform.localRotation.eulerAngles.y;
        transform.rotation = UnityEngine.Quaternion.Euler(UnityEngine.Vector3.up, 0);
        transform.position +=  new UnityEngine.Vector3(direction.x, 0, direction.y) * speed * Time.deltaTime;


        //_rotatedVector = UnityEngine.Quaternion.AngleAxis(rotationAngle, Vector3.up) * speed;
        if(_groundController.isGrounded){
            transform.position += new UnityEngine.Vector3(0, direction.z * jump , 0) * speed * Time.deltaTime;
        }
    }
}
