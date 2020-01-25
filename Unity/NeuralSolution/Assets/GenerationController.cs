using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerationController : MonoBehaviour
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
    Text gen, creatures, best,test;

    List<Controller> population = new List<Controller>();

    int generation = 0;

    [SerializeField]
    [Range(1, 5)]
    float cutoff = 1;

    GameObject generationHolder;

    bool generate = false;

    Vector3 start, end;

    List<Controller> survivors = new List<Controller>();

    int z;
    int n = 0;
    float bestFitness = 0;
    int counter = 0;

    public void StartGeneration()
    {
        float x;
        x = FindObjectOfType<Map>().mapSize;
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

        for (int i = 0; i < populationSize; i++)
        {
            GameObject creature = new GameObject();

            creature.transform.position = start;
            creature.transform.SetParent(generationHolder.transform);
            creature.name = (generation + 1 + "/" + i).ToString();
            creature.AddComponent<Controller>().StartCreature(new DNA(genomeLength, start, whatToHit, availableAngle), end);
            population.Add(creature.GetComponent<Controller>());
        }
        generation++;
        gen.text = "Generation: " + generation.ToString();
        n += populationSize;
        creatures.text = "Creatures: " + n.ToString();
        generate = true;
        best.text = "Max fitness: " + bestFitness.ToString();
    }


    void Update()
    {
        if (generate)
        {
            if (HasActive())
            {
                float tmp = mutationChance;
                generate = false;
                z = Mathf.RoundToInt(populationSize * (cutoff / 10));
                if (z % 2 != 0)
                    z++;
                for (int i = 0; i < z; i++)
                {
                    survivors.Add(GetFittest());
                    if (survivors[i].foundSolution)
                    {
                        generate = false;
                        best.text = "Max fitness: " + bestFitness.ToString();
                        DrawSollution(survivors[i]);
                        return;
                    }
                }

                population = new List<Controller>();

                if (generation % 10 == 0)
                {
                    best.text = "Max fitness: " + bestFitness.ToString();
                    test.text = (counter + "/" + Mathf.Pow(z, 3) / 8).ToString();
                    if (counter >= Mathf.Pow(z, 3) / 8)
                    {
                        genomeLength++;
                        mutationChance *= 3;
                        counter = 0;
                    }
                }

                while (population.Count < populationSize)
                {
                    for (int i = 0; i < survivors.Count; i++)
                    {
                        GameObject creature = new GameObject();

                        creature.transform.position = start;
                        creature.transform.SetParent(generationHolder.transform);

                        int n = Random.Range(0, survivors.Count);

                        while (true)
                            if (i == n)
                                n = Random.Range(0, survivors.Count);
                            else
                                break;

                        creature.AddComponent<Controller>().StartCreature(new DNA(survivors[i].dna, survivors[n].dna, start, whatToHit, genomeLength, mutationChance, availableAngle), end);
                        population.Add(creature.GetComponent<Controller>());

                        if (population.Count >= populationSize)
                            break;
                    }
                }

                mutationChance = tmp;

                survivors = new List<Controller>();

                generation++;
                gen.text = "Generation: " + generation.ToString();

                n += populationSize;
                creatures.text = "Creatures: " + n.ToString();

                generate = true;
            }
        }
    }

    void DrawSollution(Controller sollution)
    {
        GameObject creature = new GameObject();
        creature.transform.position = start;
        creature.transform.SetParent(generationHolder.transform);
        creature.name = "Sollution";
        creature.AddComponent<Controller>().Sollution(sollution.dna);


        survivors = new List<Controller>();

        population = new List<Controller>();
    }

    bool HasActive()
    {
        for (int i = 0; i < population.Count; i++)
            if (population[i].isActive)
            {
                return false;
            }

        for (int i = 0; i < population.Count; i++)
            population[i].hasToBeDestroyed = true;

        return true;
    }

    Controller GetFittest()
    {
        float maxFitness = float.MinValue;
        int index = 0;

        for (int i = 0; i < population.Count; i++)
        {
            if (population[i].fitness > maxFitness)
            {
                maxFitness = population[i].fitness;

                index = i;
            }
        }

        if (bestFitness < maxFitness)
        {
            bestFitness = maxFitness;
            best.text = "Max fitness: " + bestFitness.ToString();
            counter = 0;
        }
        else
        {
            counter++;
            test.text = (counter + "/" + Mathf.Pow(z, 3) / 8).ToString();
        }

        Controller fittest = population[index];

        population.Remove(fittest);
        return fittest;
    }
}