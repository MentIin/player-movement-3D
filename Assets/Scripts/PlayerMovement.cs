using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField]private float _speed = 5f;
    
    [SerializeField] private Transform groundChecker;
    public Joystick joystick;

    [SerializeField]private float _jumpPower = 3f;
    
    private bool _isGrounded;
    private CharacterController _characterController;
    private bool _isJumping = false;
    
    [HideInInspector] public int numOfSeers=0;

    private Vector3 _playerVelocity = Vector3.zero;
    private Vector3 _gravityValue = Physics.gravity / 3;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();

    }

    
    private void Update()
    {
        Movement();
        _isJumping = false;
    }
    


    private void Movement()
    {

        _isGrounded = _characterController.isGrounded;
        if (_isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }
        
        float moveHorizontal = joystick.Horizontal;
        float moveVertical = joystick.Vertical;
        Vector3 movement =transform.forward * moveVertical + transform.right * moveHorizontal;
        
        _characterController.Move( movement * _speed *Time.deltaTime);
        
        if (_isJumping && _isGrounded)
        {
            _playerVelocity.y += Mathf.Sqrt(_jumpPower * -1.0f * _gravityValue.y);
        }
        _playerVelocity.y += _gravityValue.y * Time.deltaTime;

        _characterController.Move(_playerVelocity);
    }

    public void Jump()
    {
        _isJumping = true;
    }
    
    
    
}
