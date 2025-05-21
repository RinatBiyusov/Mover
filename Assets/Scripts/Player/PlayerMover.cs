using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class PlayerMover : MonoBehaviour, IMoveable
{
    [SerializeField] private float _speed;

    private PlayerInput _playerInput;
    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerInput = GetComponent<PlayerInput>();
    }

    public void Move()
    {
        Vector3 direction = new Vector3(_playerInput.HorizontalInput, 0, _playerInput.VerticalInput);
        direction *= Time.deltaTime * _speed;

        Vector3 gravityFactor = Physics.gravity * Time.deltaTime;

        if (_characterController.isGrounded)
            _characterController.Move(direction + gravityFactor);
        else
            _characterController.Move(gravityFactor);
    }
}