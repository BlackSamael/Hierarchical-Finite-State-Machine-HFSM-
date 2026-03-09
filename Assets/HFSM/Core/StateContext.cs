using UnityEngine;

public class StateContext
{
    public Transform Transform;
    public Rigidbody Rigidbody;
    public Animator Animator;

    public float MoveInput;
    public bool JumpPressed;
    public bool AttackPressed;

    public bool IsGrounded;
}