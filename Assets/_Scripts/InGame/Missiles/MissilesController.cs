using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class MissilesController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    DataManager dataManager;
    public Transform planePos;
    PlaneManager planeManager;
    public GameObject explosionPrefab;
    public float speedRotate;
    public float speedMoving;

    AudioSource audioMissileExplosionClose;
    AudioSource audioMissileExplosionMid;
    AudioSource audioMissileExplosionFar;

    private void Start()
    {
        rigid2D = this.GetComponent<Rigidbody2D>();
        dataManager = GameObject.Find("GameManager").GetComponent<DataManager>();
        planeManager = GameObject.Find("PlaneManager").GetComponent<PlaneManager>();
        planePos = planeManager.planes[dataManager.dataBase.indexPlane].GetComponent<Transform>();
        audioMissileExplosionClose = GameObject.Find("MissileExplosionClose").GetComponent<AudioSource>();
        audioMissileExplosionMid = GameObject.Find("MissileExplosionMid").GetComponent<AudioSource>();
        audioMissileExplosionFar = GameObject.Find("MissileExplosionFar").GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        Moving();
    }

    public void Moving()
    {
        Vector2 direction = (Vector2)planePos.position - (Vector2)this.transform.position;
        float rotateAmount = Vector3.Cross(direction.normalized, transform.up).z;
        float angle = Vector2.Angle(direction.normalized, transform.up);

        rigid2D.angularVelocity = -speedRotate * rotateAmount * angle;

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

            float distance = Vector2.Distance(this.transform.position, planePos.position);
            if (distance < 1)
            {
                audioMissileExplosionClose.Play();
                Debug.Log("Explosion close");
            }
            else if ((distance >= 1) && (distance < 2))
            {
                audioMissileExplosionMid.Play();
                Debug.Log("Explosion mid");
            }
            else if (distance >= 2)
            {
                audioMissileExplosionFar.Play();
                Debug.Log("Explosion far");
            }

            GameObject explosionTemp = Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    IEnumerator TimeOutChasePlane()
    {
        yield return new WaitForSecondsRealtime(10);
        speedRotate = 0;
        yield return new WaitForSecondsRealtime(3);
        if(Vector2.Distance(Camera.main.transform.position, this.transform.position) > 5)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator PlaneExplosion()
    {
        speedRotate = 0;
        yield return new WaitForSecondsRealtime(3);
        if (Vector2.Distance(Camera.main.transform.position, this.transform.position) > 5)
        {
            Destroy(this.gameObject);
        }
    }
}
