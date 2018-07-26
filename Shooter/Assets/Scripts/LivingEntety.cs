using UnityEngine;
using System.Collections;

public class LivingEntety : MonoBehaviour, IDamagable
{
    public float startingHealth;
    protected float health;
    protected bool dead;

    public event System.Action OnDeath;

    protected virtual void Start()
    {
        startingHealth = startingHealth * GameObject.FindGameObjectWithTag("GM").GetComponent<Spawner>().currentWaveNumber;
        health = startingHealth;
    }

     public virtual void TakeHit(float damage, Vector3 hitPoit, Vector3 hitDirection)
    {
        TakeDamage(damage);
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0 && !dead)
        {
            Die();
        }
    }

    protected void Die()
    {
        dead = true;
        if (OnDeath != null)
        {
            OnDeath();
        }
        GameObject.Destroy(gameObject);
    }
}
