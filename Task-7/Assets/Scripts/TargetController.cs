using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] int ObjHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetDamage(int damage)
    {
        ObjHealth -= damage;
        if (ObjHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
