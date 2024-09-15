using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlaneController : MonoBehaviour
{
    public float speedMoving;
    public float speedRotate;
    public static Transform playerPos;
    Rigidbody2D rigid2D;
    Animator animator;
    public GameObject shieldReceive;
    public GameObject particle;
    public bool haveShield;
    public bool haveSpeedUp;
    void Awake()
    {
        rigid2D = this.GetComponent<Rigidbody2D>();
        playerPos = this.GetComponent<Transform>();
        animator = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
        Moving();
        FlipPlane();
        UpdateAnimation();
    }

    void Moving()
    {
        Quaternion rotate = transform.rotation;
        float angle = rotate.eulerAngles.z - Input.GetAxisRaw("Horizontal") * speedRotate;
        rotate.eulerAngles = new Vector3(0, 0, angle);
        transform.rotation = rotate;

        rigid2D.velocity = this.transform.up * speedMoving;
    }

    void FlipPlane()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void UpdateAnimation()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            animator.SetBool("Rotate", true);
        }
        else animator.SetBool("Rotate", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("shield") && !haveShield)
        {
            Destroy(collision.gameObject);
            shieldReceive.SetActive(true);
            haveShield = true;
        }
        else if (collision.gameObject.CompareTag("missile"))
        {
            if (haveShield)
            {
                Destroy(collision.gameObject);
                shieldReceive.SetActive(false);
                haveShield = false;
            }
            else
            {
                this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                StartCoroutine(StateExplosion());
            }
        }

        if (collision.gameObject.CompareTag("speedup") && !haveSpeedUp)
        {
            Debug.Log("speedup");
            Destroy(collision.gameObject);
            StartCoroutine(StateSpeedUp());
        }
    }

    IEnumerator StateSpeedUp()
    {
        haveSpeedUp = true;
        float oldSpeed = speedMoving;
        speedMoving = oldSpeed * 2;
        yield return new WaitForSeconds(5);
        speedMoving = oldSpeed;
        haveSpeedUp = false;
    }

    IEnumerator StateExplosion()
    {
        this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }

}
