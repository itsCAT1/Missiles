﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissilesController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    public Transform planePos;
    public PlaneManager planeManager;
    public GameObject explosionPrefab;
    public float speedRotate;
    public float speedMoving;
    private void Start()
    {
        rigid2D = this.GetComponent<Rigidbody2D>();
        planeManager = GameObject.Find("PlaneManager").GetComponent<PlaneManager>();
        planePos = planeManager.planes[planeManager.currentPlaneIndex].GetComponent<Transform>();
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
        Destroy(this.gameObject);
    }
}
