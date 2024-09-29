using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissilesController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    public DataPlaneManager dataPlaneManager;
    public Transform planePos;
    public PlaneManager planeManager;
    public GameObject explosionPrefab;
    public float speedRotate;
    public float speedMoving;
    private void Start()
    {
        rigid2D = this.GetComponent<Rigidbody2D>();
        dataPlaneManager = GameObject.Find("GameManager").GetComponent<DataPlaneManager>();
        planeManager = GameObject.Find("PlaneManager").GetComponent<PlaneManager>();
        planePos = planeManager.planes[dataPlaneManager.dataPlane.indexPlane].GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        Moving();
    }

    public void Moving()
    {
        Vector2 direction = (Vector2)planePos.position - (Vector2)this.transform.position;
        float rotateAmount = Vector3.Cross(direction.normalized, transform.up).z;

        rigid2D.angularVelocity = -speedRotate * rotateAmount;
        rigid2D.velocity = transform.up * speedMoving;
        StartCoroutine(TimeOutChasePlane());
        if (!planePos.gameObject.activeSelf)
        {
            StartCoroutine(PlaneExplosion());
        }
    }


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
        if(Vector2.Distance(Camera.main.transform.position, this.transform.position) > 5)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator PlaneExplosion()
    {
        speedRotate = 0;
        yield return new WaitForSeconds(3);
        if (Vector2.Distance(Camera.main.transform.position, this.transform.position) > 5)
        {
            Destroy(this.gameObject);
        }
    }
}
