using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{

    public LayerMask collisionMask;
    float speed = 10;
    float damage = 1;
    public float lifeTime = 0.05f;
    float skinWidth = .1f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
        Collider[] initialCollisions = Physics.OverlapSphere(transform.position, .1f, collisionMask);
        if (initialCollisions.Length > 0)
        {
            OnHitObject(initialCollisions[0],transform.position);
        }
    }
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    void Update()
    {
        float moveDisttance = speed * Time.deltaTime;
        CheckCollisions(moveDisttance);
        transform.Translate(Vector3.forward * moveDisttance);
    }
    void CheckCollisions(float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, moveDistance + skinWidth, collisionMask))
        {
            OnHitObject(hit.collider,hit.point);
        }
    }
   
    void OnHitObject(Collider c,Vector3 hitPoint)
    {
        IDamagable damagebleObject = c.GetComponent<IDamagable>();
        if (damagebleObject != null)
        {
            damagebleObject.TakeHit(damage,hitPoint,transform.forward);
        }
        GameObject.Destroy(gameObject);
    }
}