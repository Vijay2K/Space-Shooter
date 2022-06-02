using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 screenBound;
    
    private void Start()
    {
        screenBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void Update()
    {
        if(transform.position.y > screenBound.y || transform.position.y < -screenBound.y || 
            transform.position.x > screenBound.x || transform.position.x < -screenBound.x)
        {
            PoolManager.instance.ReturnToPool(this.gameObject);
        }
    }

    public void Launch(Vector3 direction, float speed)
    {
        GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
    }
}
