using NUnit.Framework;
using UnityEngine;

public class Animator : MonoBehaviour
{
    Animation anim;
    ThirdPersonMovement movement;
    public GameObject Player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animation>();
        movement = Player.GetComponent<ThirdPersonMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if(movement.IsGrounded()){
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.Play("Armature_Jump");
            }
            
            if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0 )
            {
                anim.Play("Armature_Run");
            }
            else
            {
                // anim.Stop();
                anim.Play("Armature_Wait");
            }
        }
    }
}
