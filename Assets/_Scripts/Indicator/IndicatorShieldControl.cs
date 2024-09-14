using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorShieldControl : MonoBehaviour
{
    Rigidbody2D rigid2D;
    SpriteRenderer spriteRenderer;
    public Transform shieldPos;
    public float speedMoving;
    public float speedRotate;
    public float angleOffset;

    void Start()
    {
        rigid2D = this.GetComponent<Rigidbody2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Moving();
    }

    void Moving()
    {
        Vector3 direction = shieldPos.position - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + angleOffset;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rigid2D.velocity = direction.normalized * speedMoving;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MainCamera"))
        {
            this.spriteRenderer.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("shield"))
        {
            Destroy(this.gameObject);
        }
    }
}
