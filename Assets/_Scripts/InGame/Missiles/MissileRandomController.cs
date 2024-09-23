using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileRandomController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    public float speedRotate;
    public float speedMoving;
    private void Start()
    {
        rigid2D = this.GetComponent<Rigidbody2D>();
        speedRotate = 360;
    }

    void FixedUpdate()
    {
        Moving();
    }

    void Moving()
    {
        rigid2D.velocity = transform.up * speedMoving;
        StartCoroutine(TimeOutMissile());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("missile"))
        {
            GameManager.bonusCoin += 15;
            Debug.Log("bonusCoin");
        }
        Destroy(this.gameObject);
    }

    IEnumerator TimeOutMissile()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
