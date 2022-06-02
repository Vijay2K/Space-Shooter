using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public float HorizontalMove { get; private set; }
    public float VerticalMove { get; private set; }
    public bool IsPressingFire { get; private set; }

    private void Update()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal");
        VerticalMove = Input.GetAxisRaw("Vertical");
        IsPressingFire = Input.GetMouseButtonDown(0);
    }
}
