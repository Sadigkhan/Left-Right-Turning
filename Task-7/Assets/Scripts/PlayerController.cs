using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float Horizontal;
    [Range(0, 10)]
    [SerializeField] float Speed=10f;
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform FirePoint;
    float NextAttackTime;
    [SerializeField] float AttackRate = 3f;
    [SerializeField] float AttackSecond = 1f;
    Rigidbody2D rb;
    bool FacingRight = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.AddForce(Vector2.right * Speed, ForceMode2D.Impulse);
    }


    void Update()
    {

     
        Horizontal = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(Horizontal*Speed,0,0)*Time.deltaTime;

        if (Horizontal<0&&!FacingRight)
        {
            Flip();
        }
       else if (Horizontal > 0 && FacingRight)
        {
            Flip();
        }

      



        if (Input.GetMouseButton(0))
        {

            if (Time.time >= NextAttackTime)
            {

                Instantiate(Bullet, FirePoint.position, Quaternion.Euler(0, 0, 0));
                NextAttackTime = Time.time + AttackSecond / AttackRate;
            }
            


        }
    }

    private void Flip()
    {
        FacingRight = !FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
     public bool IsRight()
    {
        return FacingRight;
    }
}


