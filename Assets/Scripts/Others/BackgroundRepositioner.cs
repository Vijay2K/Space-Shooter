using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepositioner : MonoBehaviour
{
    [SerializeField] private float respositionPoint;

    private void Update()
    {
        if(transform.position.y < -respositionPoint)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        Vector2 offset = new Vector2(0, respositionPoint * 2f);
        transform.position = (Vector2)transform.position + offset;
    }
}
