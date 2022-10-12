using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float _Speed;
    [SerializeField] int BulletDamage = 5;
    [SerializeField] GameObject PlayerControler;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerControler = GameObject.FindGameObjectWithTag("Player");
        PlayerController pc=PlayerControler.GetComponent<PlayerController>();
        if (pc.IsRight())
        {
            rb.AddForce(Vector2.left * _Speed, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(Vector2.right * _Speed, ForceMode2D.Impulse);
        }
      
    }

    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Target"))
        {
            collision.transform.GetComponent<TargetController>().GetDamage(BulletDamage);
            Destroy(gameObject);
        }
        if (collision.transform.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
