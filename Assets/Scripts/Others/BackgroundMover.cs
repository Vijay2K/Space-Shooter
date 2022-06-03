using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField] private float verticalMoverSpeed;

    private void Update()
    {
        transform.Translate(new Vector3(0, verticalMoverSpeed * Time.deltaTime, 0));
    }

}
