using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float speed = 20;
    [SerializeField] string axis;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float v = speed * Input.GetAxisRaw(axis);
        rb2d.velocity = new Vector2(0, v);
    }
}
