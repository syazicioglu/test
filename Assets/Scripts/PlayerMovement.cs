using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rgb;
    Vector3 velocity;
    public Animator animator;

    float speedAmount= 5f;
    float jumpAmount = 5f;

    float nextAttackTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speedAmount * Time.deltaTime;
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if(Input.GetKeyDown(KeyCode.UpArrow) && Mathf.Approximately(rgb.velocity.y, 0))
        {
            rgb.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse);

        }

        if(Input.GetAxisRaw("Horizontal")== -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if(Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if(Time.time >= nextAttackTime)
        {
              if (Input.GetKeyDown(KeyCode.Space))
              {
                  animator.SetTrigger("PlayerHit");
                  nextAttackTime = Time.time + 0.6f;
              }
             
        }
             
       
    }
}
