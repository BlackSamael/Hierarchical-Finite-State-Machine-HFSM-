using UnityEngine;

public class HFSMContext
{
    public Rigidbody Rigidbody;
    public Animator Animator;

    public float MoveInput;
    public bool JumpPressed;
    public bool AttackPressed;

    public bool IsGrounded;

    public float JumpForce = 4f;
}