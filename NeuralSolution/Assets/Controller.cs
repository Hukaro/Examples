using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public DNA dna;
    [HideInInspector]
    public bool isActive = false, hasToBeDestroyed = false, foundSolution = false;

    Vector3 target;

    float destroyIn = .5f;

    public int action = 0;

   public void StartCreature(DNA newDNA, Vector3 _target)
    {
        dna = newDNA;

        target = _target;

        transform.position = dna.positions[dna.positions.Count - 1];
        isActive = false;

        if (Vector3.Distance(dna.positions[dna.positions.Count - 1], _target) < .4f)
            foundSolution = true;
        else
            foundSolution = false;
    }

    public void Sollution(DNA sollution)
    {
        gameObject.AddComponent<LineRenderer>();
        GetComponent<LineRenderer>().positionCount = sollution.positions.Count;
        GetComponent<LineRenderer>().startWidth = .3f;
        GetComponent<LineRenderer>().endWidth = .3f;
        for (int i = 0; i < sollution.positions.Count;i++) {
            GetComponent<LineRenderer>().SetPosition(i, sollution.positions[i]);
            transform.position = sollution.positions[i];
        }
        Debug.Log("Done");
    }
    
    
    public float fitness
    {
        get
        {
            float _distance = Vector3.Distance(transform.position, target);
            return 100 / _distance;
        }
    }

    void FixedUpdate()
    {
        if (hasToBeDestroyed && !isActive)
        {
            destroyIn -= Time.fixedDeltaTime;
            if (destroyIn <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}