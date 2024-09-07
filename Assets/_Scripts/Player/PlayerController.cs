using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speedMoving;
    public float speedRotate;
    public static Transform playerPos;
    Rigidbody2D rigid2D;
    public Text coinCount;
    public int coins = 0;
    void Awake()
    {
        rigid2D = this.GetComponent<Rigidbody2D>();
        playerPos = this.GetComponent<Transform>();
    }
    
    void FixedUpdate()
    {
        Moving();
    }

    void Moving()
    {
        //Ridgid2D.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * _speed, Input.GetAxisRaw("Vertical") * _speed, 0);
        Quaternion rotate = transform.rotation;
        float angle = rotate.eulerAngles.z - Input.GetAxisRaw("Horizontal") * speedRotate;
        rotate.eulerAngles = new Vector3(0, 0, angle);
        transform.rotation = rotate;

        rigid2D.velocity = this.transform.up * speedMoving;
        //Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
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
