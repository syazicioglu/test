using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Rigidbody2D rgb;
    float myPosition;
    public Animator animator;


    float speedAmount = 1f;
    public int health;
    float nextAttackTime = 0f;
    int newhealth=3;
    
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        myPosition = GameObject.Find("Player").transform.position.x;
        if(health<newhealth)
        {
            animator.SetTrigger("Ehurt");
            newhealth = health;

        }

        if (myPosition-1f > transform.position.x)
        {
            transform.position = transform.position + (Vector3.right * speedAmount * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            animator.SetBool("Erun", true);

        }
        else if(myPosition+1f < transform.position.x)
        {
            transform.position = transform.position + (Vector3.left * speedAmount * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            animator.SetBool("Erun", true);
        }
        else
        {
            animator.SetBool("Erun", false);
            if (Time.time >= nextAttackTime)
            {
                animator.SetTrigger("Ehit");
                nextAttackTime = Time.time + 0.7f;
            }
        }


        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void GetDamage(int amount)
    {
        health -= amount;
    }





}
