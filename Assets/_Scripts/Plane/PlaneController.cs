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
    void Awake()
    {
        rigid2D = this.GetComponent<Rigidbody2D>();
        playerPos = this.GetComponent<Transform>();
        animator = this.GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
        Moving();
        FlipPlane();
        UpdateAnimation();
    }

    public void Moving()
    {
        Quaternion rotate = transform.rotation;
        float angle = rotate.eulerAngles.z - Input.GetAxisRaw("Horizontal") * speedRotate;
        rotate.eulerAngles = new Vector3(0, 0, angle);
        transform.rotation = rotate;

        rigid2D.velocity = this.transform.up * speedMoving;
    }

    public void FlipPlane()
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

    public void UpdateAnimation()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            animator.SetBool("Rotate", true);
        }
        else animator.SetBool("Rotate", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("shield"))
        {
            Destroy(collision.gameObject);
            shieldReceive.SetActive(true);
            Debug.Log("nhanshield");
        }
        if (collision.gameObject.CompareTag("missile") && shieldReceive)
        {
            Destroy(collision.gameObject);
            shieldReceive.SetActive(false);
            Debug.Log("matshield");
        }
        if (collision.gameObject.CompareTag("missile") && !shieldReceive)
        {
            Destroy(this.gameObject);
            Debug.Log("chuacoshield");
        }
    }
}
