using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] private float moverSpeed;
    [SerializeField] private int hitPoints; 

    private Vector3 screenBound;

    private void Start()
    {
        screenBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void Update()
    {
        if (transform.position.y < -screenBound.y || transform.position.x > screenBound.x || transform.position.x < -screenBound.x)
        {
            PoolManager.instance.ReturnToPool(this.gameObject);
        }

        Move();
    }

    private void Move()
    {
        transform.Translate(-transform.up * moverSpeed * Time.deltaTime);
    }

    public void TakeDamage()
    {
        FindObjectOfType<HUD>().UpdateScoreUI(hitPoints);
        PoolManager.instance.ReturnToPool(this.gameObject);
    }

    public void TakeDamage(float damage)
    {

    }
}
