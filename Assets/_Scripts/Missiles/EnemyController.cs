using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rigidBody;
    public float angleChangingSpeed;
    public float movementSpeed;

    private void Start()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 direction = (Vector2)PlaneController.playerPos.position - (Vector2)transform.position;
        float rotateAmount = Vector3.Cross(direction.normalized, transform.up).z;
        rigidBody.angularVelocity = -angleChangingSpeed * rotateAmount;
        rigidBody.velocity = transform.up * movementSpeed;
    }
}
