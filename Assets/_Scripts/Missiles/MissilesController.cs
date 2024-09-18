using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class MissilesController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    public GameObject explosionPrefab;
    public float speedRotate;
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
        float cosAngle = Vector3.Dot(direction, transform.up) /direction.magnitude;
        float angleRotate = Mathf.Acos(cosAngle);
        
        rigid2D.angularVelocity = -speedRotate * angleRotate;
        rigid2D.velocity = transform.up * speedMoving;
        //StartCoroutine(TimeOutChasePlane());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("missile"))
        {
            GameManager.bonusCoin += 15;
            Debug.Log("bonusCoin");
            GameObject explosionTemp = Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);

        }
    }

    IEnumerator TimeOutChasePlane()
    {
        yield return new WaitForSeconds(10);
        speedRotate = 0;
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
