using System;
using UnityEditor;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Collider _collider;
    [SerializeField] private LayerMask _layerMask;

    private const float GapDistance = 0.2f;
    private const int NegativeSign = -1;
    
    private Vector3 _rayOrigin;
    
    public bool IsGrounded { get; private set; }

    private void Update()
    {
        IsTouchesGround();
    }

    private void IsTouchesGround()
    {
        _rayOrigin = new Vector3(_collider.bounds.center.x, _collider.bounds.min.y, _collider.bounds.center.z);

        Vector3 direction = (Vector3.down + transform.forward).normalized;
        Vector3 direction1 = (Vector3.down + transform.forward * NegativeSign).normalized;
        
        if (Physics.Raycast(_rayOrigin, direction, GapDistance, _layerMask) ||
            Physics.Raycast(_rayOrigin, direction1, GapDistance, _layerMask))
        {
            IsGrounded = true;
        }
        else
            IsGrounded = false;
    }

    private void OnDrawGizmos()
    {
        _rayOrigin = new Vector3(_collider.bounds.center.x, _collider.bounds.min.y, _collider.bounds.center.z);

        Vector3 direction = (Vector3.down + transform.forward).normalized;
        Vector3 direction1 = (Vector3.down + transform.forward * NegativeSign).normalized;
        
        Gizmos.DrawRay(_rayOrigin, direction * GapDistance);
        Gizmos.DrawRay(_rayOrigin, direction1 * GapDistance);
    }
}