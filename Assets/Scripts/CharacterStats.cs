using UnityEngine;
using UnityEngine.UI;


public class CharacterStats : MonoBehaviour
{
    public Image[] hearts;

    public Animator animator;

    public int health = 3;
    int maxHealth = 3;
    int newhealth=3;

    public void Damage(int amount)
    {   
        health -= amount;
    }

    public void Regen(int amount)
    {
        health += amount;

        for(int i=0; i< health; i++)
        {
            hearts[i].enabled = true;
        }
    }

    private void Update()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        if (health < newhealth)
        {
            animator.SetTrigger("PlayerHurt");
            for (int i = 3; i > health; i--)
            {
                hearts[i - 1].enabled = false;
            }
            newhealth = health;
        }

    }


}
