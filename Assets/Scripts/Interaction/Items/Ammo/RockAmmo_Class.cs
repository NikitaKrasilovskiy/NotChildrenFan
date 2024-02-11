using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockAmmo_Class : MonoBehaviour
{
    private Rigidbody2D itemRigidbody;
    private bool hasHit;
    private float speed;
    //public Vector3 launchOffset;


    private void Start()
    {
        itemRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Physics2D.IgnoreLayerCollision(14, 15);
        Physics2D.IgnoreLayerCollision(10, 11);
        Physics2D.IgnoreLayerCollision(12, 13);
        //Physics2D.IgnoreLayerCollision(14, 15);

        if (hasHit == false)
        {
            //transform.position += transform.right * Speed * Time.deltaTime;
            float angle = Mathf.Atan2(itemRigidbody.velocity.y, itemRigidbody.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    public virtual void SpawhTrowItem()
    {       
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {     
            hasHit = true;
            itemRigidbody.velocity = Vector2.zero;
            Destroy(gameObject);
    }
}
