using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowUsebleItem_Class : MonoBehaviour
{
    public GameObject spawnItem;
    private Rigidbody2D itemRigidbody;
    private bool hasHit;
    private float speed;
    public Vector3 launchOffset;


    private void Start()
    {
        itemRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (hasHit == false)
        {
            float angle = Mathf.Atan2(itemRigidbody.velocity.y, itemRigidbody.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    public virtual void SpawhTrowItem()
    {
        Instantiate(spawnItem, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Floor")
        {
            hasHit = true;
            itemRigidbody.velocity = Vector2.zero;
            Invoke("SpawhTrowItem", 0.3f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Floor")
        {

        }
    }
}
