using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(GroundChecker))]
[RequireComponent(typeof(ClimbChecker))]
[RequireComponent(typeof(EnemyRotator))]
public class EnemyMover : MonoBehaviour, IMoveable
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _stopDistance = 2f;
    [SerializeField] private Transform _target;

    private GroundChecker _groundChecker;
    private Rigidbody _rigidbody;
    private ClimbChecker _climbChecker;
    private EnemyRotator _enemyRotator;

    private void Awake()
    {
        _enemyRotator = GetComponent<EnemyRotator>();
        _climbChecker = GetComponent<ClimbChecker>();
        _groundChecker = GetComponent<GroundChecker>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move()
    {
        _enemyRotator.RotateAt(_target);
        
        if (IsEnoughClose())
            return;

        Vector3 direction = (_target.position - transform.position).normalized;
        Vector3 speedMovement = direction * _speed;
        
        if (_groundChecker.IsGrounded || _climbChecker.CanClimb)
        {
            if (_target.position.y < transform.position.y)
                speedMovement = new Vector3(speedMovement.x, 0f, speedMovement.z);

            _rigidbody.MovePosition(transform.position + speedMovement * Time.deltaTime);
        }
    }

    private bool IsEnoughClose() =>
        (transform.position - _target.position).sqrMagnitude < _stopDistance * _stopDistance;

    private void OnDrawGizmos()
    {
        Vector3 direction = (_target.position - transform.position).normalized;

        Gizmos.DrawRay(transform.position, direction * _stopDistance);
    }
}