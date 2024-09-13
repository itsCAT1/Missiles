using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class MissilesController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    public float angleChangingSpeed;
    public float speedMoving;
    private void Start()
    {
        rigid2D = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Moving();
    }

    void Moving()
    {
        Vector2 direction = (Vector2)PlaneController.playerPos.position - (Vector2)transform.position;
        float rotateAmount = Vector3.Cross(direction.normalized, transform.up).z;
        rigid2D.angularVelocity = -angleChangingSpeed * rotateAmount;
        rigid2D.velocity = transform.up * speedMoving;
        StartCoroutine(TimeOutChasePlane());
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

    IEnumerator TimeOutChasePlane()
    {
        yield return new WaitForSeconds(10);
        angleChangingSpeed = 0;
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
    }
}
