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
    
    public Rigidbody2D rigid2D;
    Animator animator;

    public GameObject shieldReceive;
    public bool haveSpeedUp;
    public bool haveShield;
    public GameObject explosionPrefab;
    public GameObject explosionMissilePrefab;

    public JoystickController joystickController;
    public ButtonArrowController buttonArrowController;

    float previousAngle = 0f;
    Vector3 directionNormalized;

    AudioSource audioPlaneExplosion;
    AudioSource audioMissileExplosionClose;
    AudioSource audioReceiveShield;
    AudioSource audioReceiveStar;

    void Awake()
    {
        rigid2D = this.GetComponent<Rigidbody2D>();
        animator = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
        previousAngle = this.transform.eulerAngles.z;
        audioPlaneExplosion = GameObject.Find("PlaneExplosion").GetComponent<AudioSource>();
        audioMissileExplosionClose = GameObject.Find("MissileExplosionClose").GetComponent<AudioSource>();
        audioReceiveShield = GameObject.Find("ReceiveShield").GetComponent<AudioSource>();
        audioReceiveStar = GameObject.Find("ReceiveStar").GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        rigid2D.velocity = this.transform.up * speedMoving;
    }

    public void MovingInputJoystick()
    {
        Vector2 directionNormalized = joystickController.direction.normalized;

        float currentAngle = this.transform.eulerAngles.z;
        
        currentAngle = Mathf.Atan2(directionNormalized.y, directionNormalized.x) * Mathf.Rad2Deg - 90;
        
        Quaternion rotate = this.transform.rotation;
        
        float tartgetAngle = Mathf.LerpAngle(rotate.eulerAngles.z, currentAngle, speedRotate * Time.deltaTime);
        
        rotate = Quaternion.Euler(0, 0, tartgetAngle);
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

        if (previousAngle != (int)tartgetAngle)
        {
            animator.SetBool("Rotate", true);
        }
        else animator.SetBool("Rotate", false);
        previousAngle = (int)tartgetAngle;
        
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
    }

    public void MovingInputMoveFinger()
    {
        var mouPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float currentAngle = this.transform.eulerAngles.z;
        if (Input.GetMouseButton(0))
        {
            directionNormalized = mouPos - this.transform.position;
        }

        currentAngle = Mathf.Atan2(directionNormalized.y, directionNormalized.x) * Mathf.Rad2Deg - 90;
        Debug.DrawLine(this.transform.position, mouPos, Color.red);
        
        Quaternion rotate = this.transform.rotation;
        float targetAngle = Mathf.LerpAngle(rotate.eulerAngles.z, currentAngle, speedRotate * Time.deltaTime);
        
        rotate = Quaternion.Euler(0, 0, targetAngle);

        float rotateAmount = Vector3.Cross(directionNormalized, transform.up).z;

        if (rotateAmount > 0)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }

        if ((int)previousAngle != (int)targetAngle)
        {
            animator.SetBool("Rotate", true);
        }
        else animator.SetBool("Rotate", false);
        previousAngle = targetAngle;

        this.transform.rotation = rotate;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("shield") && !haveShield)
        {
            haveShield = true;
            audioReceiveShield.Play();
            Destroy(collision.gameObject);
            shieldReceive.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("missile"))
        {
            if (haveShield)
            {
                haveShield = false;
                GameManager.shieldPoint += 1;
                audioMissileExplosionClose.Play();
                GameObject explosionTemp = Instantiate(explosionMissilePrefab, this.transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                shieldReceive.SetActive(false);
            }
            else
            {
                this.gameObject.SetActive(false);
                speedMoving = 0;
                speedRotate = 0;

                audioPlaneExplosion.Play();
                GameObject explosionTemp = Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
            }
        }

        if (collision.gameObject.CompareTag("star"))
        {
            audioReceiveStar.Play();
            GameManager.starPoint += 1;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("speedup") && !haveSpeedUp)
        {
            Destroy(collision.gameObject);
            GameManager.speedUpPoint += 1;
            StartCoroutine(StateSpeedUp());
        }
    }

    IEnumerator StateSpeedUp()
    {
        haveSpeedUp = true;
        
        audioReceiveShield.Play();
        float oldSpeed = speedMoving;
        speedMoving = oldSpeed * 1.5f;
        yield return new WaitForSecondsRealtime(5);
        speedMoving = oldSpeed;
        haveSpeedUp = false;
    }
}
