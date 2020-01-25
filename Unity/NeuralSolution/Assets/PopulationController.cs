using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulationController : MonoBehaviour
{
    [SerializeField]
    [Range(45, 90)]
    int availableAngle = 45;
    [SerializeField]
    LayerMask whatToHit;

    [SerializeField]
    [Range(5, 250)]
    int populationSize = 10;

    [SerializeField]
    [Range(1, 20)]
    int genomeLength = 2;

    [SerializeField]
    [Range(.01f, .5f)]
    float mutationChance = .01f;

    [SerializeField]
    Text gen, creatures, best;

    int generation = 0;

    [SerializeField]
    [Range(1, 5)]
    float cutoff = 1;

    GameObject generationHolder;

    Vector3 start, end;

    [SerializeField]
    List<DNA> allDNA = new List<DNA>();
    [SerializeField]
    List<DNA> bestDNA = new List<DNA>();
    float fit = 0, maxFit = float.MinValue;
    int index = 0, counter = 0, z;
    bool doStaff = false;

    public void StartGeneration()
    {
        float x = FindObjectOfType<Map>().mapSize;
        start = new Vector3(x / 2 - 2, 0, x / -2 + 2);
        end = new Vector3(x / -2 + 2, 0, x / 2 - 2);

        #region Создание старта и финиша
        GameObject startPoint = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        startPoint.name = "Start";
        GameObject endPoint = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        endPoint.name = "End";
        startPoint.transform.position = start;
        endPoint.transform.position = end;

        startPoint.layer = LayerMask.NameToLayer("Ignore");
        endPoint.layer = LayerMask.NameToLayer("Ignore");

        startPoint.GetComponent<MeshRenderer>().material.color = Color.blue;
        endPoint.GetComponent<MeshRenderer>().material.color = Color.red;
        #endregion

        generationHolder = new GameObject();
        generationHolder.transform.position = new Vector3();
        generationHolder.name = "Generation";

        First();
    }

    void First()
    {
        for (int i = 0; i < populationSize; i++)
            allDNA.Add(new DNA(genomeLength, start, whatToHit, availableAngle));

        gen.text = (generation++).ToString();
        doStaff = true;
    }

    void Update()
    {
        if (doStaff)
        {
            Second();
        }
    }


    void Second()
    {
        doStaff = false;
        gen.text = (generation++).ToString();
        float tmp = mutationChance;

        z = Mathf.RoundToInt(populationSize * (cutoff / 10));
        if (z % 2 != 0)
            z++;

        //if (generation % 50 == 0)
        //{
        //    if (counter >= Mathf.Pow(z, 3) / 4)
        //    {
        //        genomeLength++;
        //        mutationChance = .3f;
        //        counter = 0;
        //    }
        //}

        for (int l = 0; l < z; l++)
        {
            for (int i = 0; i < allDNA.Count; i++)
            {
                float distance = Vector3.Distance(allDNA[i].positions[allDNA[i].positions.Count - 1], end);
                fit = 100 / distance;

                if (distance <= .3f)
                {
                    Debug.Log("Done");
                    //GameObject creature = new GameObject();
                    //creature.transform.position = start;
                    //creature.transform.SetParent(generationHolder.transform);
                    //creature.name = "Sollution";
                    //creature.AddComponent<Controller>().Sollution(allDNA[i]);
                }

                if (maxFit < fit)
                {
                    maxFit = fit;
                    index = i;
                    best.text = "Max fitness: " + maxFit.ToString();
                    //counter = 0;
                }
                else
                {
                    //counter++;
                }
            }

            bestDNA.Add(allDNA[index]);
            allDNA.Remove(allDNA[index]);
        }

        allDNA = new List<DNA>();

        while (allDNA.Count < populationSize)
        {
            for (int i = 0; i < bestDNA.Count; i++)
            {
                int n = Random.Range(0, bestDNA.Count);

                while (true)
                    if (i == n) n = Random.Range(0, bestDNA.Count);
                    else break;

                allDNA.Add(new DNA(bestDNA[n], bestDNA[i], start, whatToHit, genomeLength, mutationChance, availableAngle));

                if (allDNA.Count >= populationSize)
                    break;
            }
        }

        mutationChance = tmp;

        bestDNA = new List<DNA>();

        doStaff = true;
    }
}