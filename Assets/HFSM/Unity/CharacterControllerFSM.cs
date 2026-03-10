using UnityEngine;

public class CharacterControllerFSM : MonoBehaviour
{
    public HFSMStateMachine machine;
    private HFSMContext context;
    private RootState root;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.2f;
    [SerializeField] LayerMask groundLayer;

    void Start()
    {
        context = new HFSMContext
        {
            Rigidbody = GetComponent<Rigidbody>(),
            Animator = GetComponent<Animator>()
        };

        machine = FSMGraphBuilder.Build(context);
    }
    void Update()
    {
        context.MoveInput = Input.GetAxisRaw("Horizontal");
        context.JumpPressed = Input.GetKeyDown(KeyCode.Space);
        context.AttackPressed = Input.GetMouseButton(0);
        context.ForceDeath = Input.GetKeyDown(KeyCode.K);
        context.IsGrounded = CheckGround();
        machine.Tick();
    }


    bool CheckGround()
    {
        return Physics.Raycast(groundCheck.position, Vector3.down, groundDistance, groundLayer);
    }
}