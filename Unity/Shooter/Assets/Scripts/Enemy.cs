using UnityEngine;
using System.Collections;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class Enemy : LivingEntety
{
    public enum State { Idle, Chasing, Attacking };
    State currentSrate;

    UnityEngine.AI.NavMeshAgent pathfinder;
    Transform target;

    LivingEntety targetEntety;

    float attackDistaanceThreshhold = .5f;
    float timeBetweenAttack = 1;

    float nextAttackTime;

    float myCollisionRadius;
    float targetCollisionRadius;
    float damage = 1;
    bool hasTarget;

    public ParticleSystem deathEffect;

    protected override void Start()
    {
        base.Start();
        pathfinder = GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (GameObject.FindGameObjectWithTag("GM").GetComponent<Spawner>().currentWaveNumber - 1 != 0)
            pathfinder.speed += pathfinder.speed * ((GameObject.FindGameObjectWithTag("GM").GetComponent<Spawner>().currentWaveNumber - 1) / 2);
        //Debug.Log(GameObject.FindGameObjectWithTag("GM").GetComponent<Spawner>().currentWaveNumber);
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            currentSrate = State.Chasing;
            hasTarget = true;

            target = GameObject.FindGameObjectWithTag("Player").transform;
            targetEntety = target.GetComponent<LivingEntety>();
            targetEntety.OnDeath += OnTargetDeath;

            myCollisionRadius = GetComponent<CapsuleCollider>().radius;
            targetCollisionRadius = target.GetComponent<CapsuleCollider>().radius;

            StartCoroutine(UpdatePath());
        }
    }
    void OnTargetDeath()
    {
        hasTarget = false;
        currentSrate = State.Idle;
    }
    void Update()
    {
        if (hasTarget)
        {
            if (Time.time > nextAttackTime)
            {
                float sqrDistToTarget = (target.position - transform.position).sqrMagnitude;
                if (sqrDistToTarget < Mathf.Pow(attackDistaanceThreshhold + myCollisionRadius + targetCollisionRadius, 2))
                {
                    nextAttackTime = Time.time + timeBetweenAttack;
                    StartCoroutine(Attack());
                }
            }
        }
    }
    IEnumerator Attack()
    {
        currentSrate = State.Attacking;
        pathfinder.enabled = false;

        Vector3 originalPosition = transform.position;

        Vector3 dirToRarget = (target.position - transform.position).normalized;
        Vector3 attackPosition = target.position - dirToRarget * (myCollisionRadius);

        float percent = 0;
        float attackSpeed = 3;

        bool hasAppliedDamage = false;
        while (percent <= 1)
        {
            if (percent >= .5f && !hasAppliedDamage) {
                hasAppliedDamage = true;
                targetEntety.TakeDamage(damage);
            }
            percent += Time.deltaTime * attackSpeed;
            float intarpolation = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector3.Lerp(originalPosition, attackPosition, intarpolation);

            yield return null;
        }
        currentSrate = State.Chasing;
        pathfinder.enabled = true;
    }

    public override void TakeHit(float damage, Vector3 hitPoit, Vector3 hitDirection)
    {
        if (damage >= health)
        {
           // Destroy(Instantiate(deathEffect, hitPoit, Quaternion.FromToRotation(Vector3.forward, hitDirection)) as GameObject, deathEffect.startLifetime);
        }
            base.TakeHit(damage, hitPoit, hitDirection);
    }

    IEnumerator UpdatePath()
    {
        float refreshRate = .2f;
        while (hasTarget)
        {
            if (currentSrate == State.Chasing)
            {
                Vector3 dirToRarget = (target.position - transform.position).normalized;
                Vector3 targetPosition = target.position - dirToRarget * (myCollisionRadius + targetCollisionRadius + attackDistaanceThreshhold / 2);
                if (!dead)
                {
                    pathfinder.SetDestination(target.position);
                }
            }
            yield return new WaitForSeconds(refreshRate);
        }
    }
}