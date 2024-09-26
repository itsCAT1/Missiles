using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testplane : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public Animator animator;
    public float speed;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        transform.position += transform.up * speed;
    }

    public void Vao()
    {
        StartCoroutine(StartGame());
        virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_XDamping = 0;
    }

    public void Thoat()
    {
        virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_XDamping = 1;
    }

    IEnumerator StartGame()
    {
        rb.angularVelocity = 185;
        yield return new WaitForSeconds(1);
        rb.angularVelocity = 0;
    }
}
