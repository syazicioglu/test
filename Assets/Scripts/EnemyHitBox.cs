using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag == "Player")
        {
            collision.GetComponent<CharacterStats>().health -= damage;
        }

    }
}
