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
    public Text coinCount;
    public int coins = 0;
    Animator animator;
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
        if (collision.gameObject.CompareTag("star"))
        {
            Debug.Log("Trigger");
            coins += 1;
            coinCount.text = coins.ToString();
            Destroy(collision.gameObject);
        }
    }
}
