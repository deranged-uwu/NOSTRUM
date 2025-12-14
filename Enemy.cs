using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    private float _direction = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * _direction, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Barrier"))
        {
            _direction *= -1;
            transform.localScale = new Vector3(_direction, 1, 1);
        }
    }
}
