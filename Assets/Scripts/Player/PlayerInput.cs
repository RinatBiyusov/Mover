using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    public event Action SpacePressed;
    
    public float HorizontalInput { get; private set; }
    public float VerticalInput { get; private set; }

    private void Update()
    {
        HorizontalInput = Input.GetAxis(Horizontal);
        VerticalInput = Input.GetAxis(Vertical);
        
        if (Input.GetKeyDown(KeyCode.Space))
            SpacePressed?.Invoke();
    }
}