using UnityEngine;

public class EnemyRotator : MonoBehaviour
{
    private Transform _target;

    public void Init(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        Vector3 rotation = Quaternion.LookRotation(_target.position - transform.position).eulerAngles;
        
        transform.rotation = Quaternion.Euler(new  Vector3(0f, rotation.y, 0f));
    }
}