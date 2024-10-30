using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilesMovingSineWave : MonoBehaviour
{
    public float frequency;
    public float amplitude;

    Rigidbody2D rigid2D;
    void Start()
    {
        rigid2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float sineWave = Mathf.Sin(Time.time * frequency) * amplitude;
        this.rigid2D.velocity += (Vector2)this.transform.right * sineWave;
    }
}
