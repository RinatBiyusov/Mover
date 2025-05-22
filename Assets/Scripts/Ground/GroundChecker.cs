using System;
using UnityEditor;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private const float GapDistance = 0.2f;
    private const int NegativeSign = -1;

    [SerializeField] private Collider _collider;
    [SerializeField] private LayerMask _layerMask;

    private Vector3 _rayOrigin;

    public bool IsGrounded { get; private set; }

    private void Update()
    {
        CheckGround();
    }

    private void CheckGround()
    {
        _rayOrigin = new Vector3(_collider.bounds.center.x, _collider.bounds.min.y, _collider.bounds.center.z);

        Vector3 frontCheckDirection  = (Vector3.down + transform.forward).normalized;
        Vector3 backCheckDirection  = (Vector3.down + transform.forward * NegativeSign).normalized;

        IsGrounded = Physics.Raycast(_rayOrigin, frontCheckDirection , GapDistance, _layerMask) ||
                     Physics.Raycast(_rayOrigin, backCheckDirection , GapDistance, _layerMask);
    }

    private void OnDrawGizmos()
    {
        _rayOrigin = new Vector3(_collider.bounds.center.x, _collider.bounds.min.y, _collider.bounds.center.z);

        Vector3 frontCheckDirection  = (Vector3.down + transform.forward).normalized;
        Vector3 backCheckDirection  = (Vector3.down + transform.forward * NegativeSign).normalized;

        Gizmos.DrawRay(_rayOrigin, frontCheckDirection  * GapDistance);
        Gizmos.DrawRay(_rayOrigin, backCheckDirection  * GapDistance);
    }
}