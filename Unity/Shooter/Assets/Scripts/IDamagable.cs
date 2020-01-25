using UnityEngine;
public interface IDamagable
{
    void TakeHit(float damage, Vector3 hitPOint, Vector3 hitDirection);

    void TakeDamage(float damage);
}
