using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlaneController : MonoBehaviour
{
    public float speedMoving;
    public float speedRotate;
    public static Transform planePos;

    public Rigidbody2D rigid2D;
    Animator animator;

    public GameObject shieldReceive;
    bool haveShield;
    bool haveSpeedUp;

    public GameObject explosionPrefab;
    public GameObject explosionMissilePrefab;

    public JoystickController joystickController;
    
    public ButtonArrowController buttonArrowController;

    float previousAngle = 0f;
    Vector3 directionNormalized;
    void Awake()
    {
        rigid2D = this.GetComponent<Rigidbody2D>();
        animator = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
        planePos = this.transform;
        previousAngle = this.transform.eulerAngles.z;
    }

    public void MovingInMenu()
    {
        rigid2D.velocity = this.transform.up * 3;
    }

    public void MovingInputJoystick()
    {
        rigid2D.velocity = this.transform.up * speedMoving;

        Vector2 directionNormalized = joystickController.direction.normalized;

        float targetAngle = this.transform.eulerAngles.z;
        
        targetAngle = Mathf.Atan2(directionNormalized.y, directionNormalized.x) * Mathf.Rad2Deg - 90;
        Debug.Log($"targetAngle: {targetAngle}");
        Quaternion rotate = this.transform.rotation;
        
        float currentAngle = Mathf.LerpAngle(rotate.eulerAngles.z, targetAngle, speedRotate * Time.deltaTime);
        
        rotate = Quaternion.Euler(0, 0, currentAngle);
        this.transform.rotation = rotate;
        float rotateAmount = Vector3.Cross(directionNormalized, transform.up).z;
        if (rotateAmount > 0)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }

        if (previousAngle != (int)currentAngle)
        {
            animator.SetBool("Rotate", true);
        }
        else animator.SetBool("Rotate", false);
        previousAngle = (int)currentAngle;
        
    }

    public void MovingInputButtonArrow()
    {
        Quaternion rotate = transform.rotation;
        float angle = rotate.eulerAngles.z - buttonArrowController.rotateAmount * speedRotate;
        rotate.eulerAngles = new Vector3(0, 0, angle);
        this.transform.rotation = rotate;

        if (buttonArrowController.rotateAmount < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (buttonArrowController.rotateAmount != 0)
        {
            animator.SetBool("Rotate", true);
        }
        else animator.SetBool("Rotate", false);

        rigid2D.velocity = this.transform.up * speedMoving;
    }

    public void MovingInputMoveFinger()
    {
        rigid2D.velocity = this.transform.up * speedMoving;

        var mouPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float targetAngle = this.transform.eulerAngles.z;
        if (Input.GetMouseButton(0))
        {
            directionNormalized = mouPos - this.transform.position;
        }

        targetAngle = Mathf.Atan2(directionNormalized.y, directionNormalized.x) * Mathf.Rad2Deg - 90;
        Debug.DrawLine(this.transform.position, mouPos, Color.red);
        
        Quaternion rotate = this.transform.rotation;
        float currentAngle = Mathf.LerpAngle(rotate.eulerAngles.z, targetAngle, speedRotate * Time.deltaTime);
        //Debug.Log($"currentAngle: {currentAngle}, targetAngle: {targetAngle}");
        
        rotate = Quaternion.Euler(0, 0, currentAngle);

        float rotateAmount = Vector3.Cross(directionNormalized, transform.up).z;

        if (rotateAmount > 0)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }

        if ((int)previousAngle != (int)currentAngle)
        {
            animator.SetBool("Rotate", true);
        }
        else animator.SetBool("Rotate", false);
        previousAngle = currentAngle;

        this.transform.rotation = rotate;
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
                GameObject explosionTemp = Instantiate(explosionMissilePrefab, this.transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                shieldReceive.SetActive(false);
                haveShield = false;
            }
            else
            {
                //this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                //speedMoving = 0;
                //speedRotate = 0;
                Debug.Log("Explosion!");
                GameObject explosionTemp = Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
            }
        }

        if (collision.gameObject.CompareTag("speedup") && !haveSpeedUp)
        {
            Debug.Log("speedup");
            Destroy(collision.gameObject);
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
}
