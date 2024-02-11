using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowItem_Class : MonoBehaviour
{
    public GameObject spawnItem;
    private Rigidbody2D itemRigidbody;
    private bool hasHit;
    private float speed;
    public Vector3 launchOffset;
    protected bool spawnorNot;
    protected bool spawnInPlase;
    protected Vector3 spawnTransform;

    public virtual void Start()
    {
        itemRigidbody = GetComponent<Rigidbody2D>();
        speed = 4;
    }

    private void Update()
    {
        if (hasHit == false)
        {
            //transform.position += transform.right * Speed * Time.deltaTime;
            float angle = Mathf.Atan2(itemRigidbody.velocity.y, itemRigidbody.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    public virtual void SpawhTrowItem()
    {
        if(spawnorNot == false)
        {
            Instantiate(spawnItem, transform.position, transform.rotation);
        }
        if(spawnInPlase == true)
        {
            Instantiate(spawnItem, spawnTransform, transform.rotation = new Quaternion(0, 0, 0, 0));
        }
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Floor")
        {
            hasHit = true;
            itemRigidbody.velocity = Vector2.zero;
            Invoke("SpawhTrowItem", 1);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Floor")
        {
 
        }
    }
}
