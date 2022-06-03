using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float damage;
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
            DisableGameObject(this.gameObject);
        }
    }

    public void Launch(Vector3 direction, float speed)
    {
        GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Enemy"))
        {
            Enemy enemy = col.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage();
            }

            DisableGameObject(this.gameObject);
        }
    }

    private void DisableGameObject(GameObject obj)
    {
        PoolManager.instance.ReturnToPool(obj);
    }
}
