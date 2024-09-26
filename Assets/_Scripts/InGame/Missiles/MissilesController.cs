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

    private void FixedUpdate()
    {
        Moving();
    }

    public void Moving()
    {
        Vector2 planePos = (Vector2)Camera.main.transform.position + new Vector2(0, 0.84f);
        Vector2 direction = (Vector2)planePos - (Vector2)this.transform.position;
        float rotateAmount = Vector3.Cross(direction.normalized, transform.up).z;

        rigid2D.angularVelocity = -speedRotate * rotateAmount;
        rigid2D.velocity = transform.up * speedMoving;
        StartCoroutine(TimeOutChasePlane());
    }

    /*void Moving()
    {
        Vector2 direction = (Vector2)PlaneController.planePos.transform.position - (Vector2)this.transform.position;
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg -90;
        Debug.Log(targetAngle);
        //float newAngle = Mathf.LerpAngle(currentAngle, targetAngle, speedRotate * Time.deltaTime);
        //Debug.Log($"Target Angle: {targetAngle}, Current Angle: {currentAngle}, New Angle: {newAngle}");

        transform.rotation = Quaternion.Euler(0, 0, targetAngle);
        //rigid2D.angularVelocity = -speedRotate * rotateAmout;
        rigid2D.velocity = transform.up * speedMoving;
        //StartCoroutine(TimeOutChasePlane());
    }*/


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("missile"))
        {
            GameManager.bonusCoin += 5;
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
