using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ClimbChecker : MonoBehaviour
{
    [SerializeField] private float _gapDistance = 0.5f;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Collider _collider;
    
    public bool CanClimb { get; private set; }
    
    private void FixedUpdate()
    {
        CheckClimb();
    }

    private void CheckClimb()
    {
        Vector3 floorRay = new Vector3(_collider.bounds.center.x, _collider.bounds.max.y, _collider.bounds.center.z);
        Vector3 lowerRay = new Vector3(_collider.bounds.center.x, _collider.bounds.min.y, _collider.bounds.center.z);

        if (Physics.Raycast(lowerRay, transform.forward, _gapDistance, _layerMask))
        {
            if (Physics.Raycast(floorRay, transform.forward, _gapDistance, _layerMask))
                CanClimb = false;
            else
                CanClimb = true;
        }
        else
            CanClimb = false;
    }

    private void OnDrawGizmos()
    {
        Vector3 floorRay = new Vector3(_collider.bounds.center.x, _collider.bounds.max.y, _collider.bounds.center.z);
        Vector3 lowerRay = new Vector3(_collider.bounds.center.x, _collider.bounds.min.y, _collider.bounds.center.z);
        
        Gizmos.DrawRay(floorRay, transform.forward * _gapDistance);
        Gizmos.DrawRay(lowerRay, transform.forward * _gapDistance);
    }
}