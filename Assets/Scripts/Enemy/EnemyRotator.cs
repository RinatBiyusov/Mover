using UnityEngine;

public class EnemyRotator : MonoBehaviour
{
    public void RotateAt(Transform target)
    {
        Vector3 rotation = Quaternion.LookRotation(target.position - transform.position).eulerAngles;

        transform.rotation = Quaternion.Euler(new Vector3(0f, rotation.y, 0f));
    }
}