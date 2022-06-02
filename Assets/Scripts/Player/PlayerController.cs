using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] private float moverSpeed;

    private PlayerInputs playerInputs;
    private Vector3 screenbound;

    private void Start()
    {
        playerInputs = GetComponent<PlayerInputs>();
        screenbound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void Update()
    {
        Mover();
    }

    private void Mover()
    {
        Vector2 movement = new Vector2(playerInputs.HorizontalMove, playerInputs.VerticalMove);

        movement.Normalize();
        movement *= moverSpeed * Time.deltaTime;

        transform.position = CalculatedScreenBound(movement);        
    }
    
    private Vector2 CalculatedScreenBound(Vector2 movement)
    {
        float offsetX = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        float offsetY = GetComponent<SpriteRenderer>().bounds.size.y / 2;

        float x = Mathf.Clamp(transform.position.x + movement.x, -screenbound.x + offsetX, screenbound.x - offsetX);
        float y = Mathf.Clamp(transform.position.y + movement.y, -screenbound.y + offsetX, screenbound.y - offsetY);

        return new Vector2(x, y);
    }
}
