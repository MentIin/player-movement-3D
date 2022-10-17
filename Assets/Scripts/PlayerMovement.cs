using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float Speed = 5f;
    
    [SerializeField] private Transform groundChecker;
    public Joystick joystick;

    public float JumpForce = 300f;
    
    private bool _isGrounded;
    private Rigidbody _rb;
    [HideInInspector] public bool isJumping = false;
    
    [HideInInspector] public int numOfSeers=0;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();

    }

    
    private void Update()
    {
        IsGroundedUpdate();
        Movement();
    }
    


    private void Movement()
    {
        float moveHorizontal = joystick.Horizontal;
        float moveVertical = joystick.Vertical;
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        
        transform.Translate(movement * Speed * Time.deltaTime);
    }

    public void Jump()
    {
        if (_isGrounded)
            {
                _rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            }
    }
    

    private void IsGroundedUpdate()
    {
        RaycastHit[] hits = Physics.SphereCastAll(groundChecker.position, 0.1f, Vector3.down, 0.1f);

        foreach (var item in hits)
        {
            if ( item.collider.CompareTag("Ground"))
            {
                _isGrounded = true;
                return;
            }
        }
        _isGrounded = false;

    }
    
}
