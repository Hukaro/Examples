using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA
{
    public List<Vector3> positions = new List<Vector3>();

    List<float> angles = new List<float>();
    List<float> distances = new List<float>();

    float angle, distance;

    int aa = 45;
    float bb = .001f;
    RaycastHit ray;
    Vector3 direction, position;

    int layer;

    public DNA(int genomeLength = 2, Vector3 startPoint = new Vector3(), LayerMask whatToHit = new LayerMask(), int _aa = 45)
    {
        layer = whatToHit.value;
        position = startPoint;
        positions.Add(position);
        aa = _aa;
        for (int i = 0; i < genomeLength; i++)
        {
            if (i == 0)
                angle = Random.Range(1f, 360f);
            else
                angle = Random.Range(angles[i - 1] - aa, angles[i - 1] + aa);

            angles.Add(angle);
            direction = new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(Mathf.Deg2Rad * angle));
            if (Physics.Raycast(position, direction, out ray, Mathf.Infinity, layer))
            {
                distance = Random.Range(ray.distance * bb, ray.distance - (ray.distance * bb));
                distances.Add(distance);

                if (distance > .01f)
                {
                    position = position + (ray.point - position) * (distance / Vector3.Distance(ray.point, position));
                }
            }
            positions.Add(position);
        }
    }

    public DNA(DNA parent1, DNA parent2, Vector3 firsPoint, LayerMask whatToHit = new LayerMask(), int genomeLength = 2, float mutationRate = .012f, int _aa = 45)
    {
        layer = whatToHit.value;
        position = firsPoint;
        positions.Add(position);
        aa = _aa;

        for (int i = 0; i < genomeLength; i++)
        {
            if (i < parent1.angles.Count)
            {
                float mutationChance = Random.Range(0.0f, 1.0f);
                if (mutationChance <= mutationRate)
                {
                    if (i == 0)
                        angle = Random.Range(1f, 360f);
                    else
                        angle = Random.Range(angles[i - 1] - aa, angles[i - 1] + aa);

                    angles.Add(angle);
                    direction = new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(Mathf.Deg2Rad * angle));
                    if (Physics.Raycast(position, direction, out ray, Mathf.Infinity, layer))
                    {
                        distance = Random.Range(ray.distance * bb, ray.distance - (ray.distance * bb));
                        distances.Add(distance);
                        if (distance > .01f)
                        {
                            position = position + (ray.point - position) * (distance / Vector3.Distance(ray.point, position));
                        }
                    }
                }
                else
                {
                    int chance = Random.Range(0, 2);
                    if (chance == 0)
                    {
                        angle = parent1.angles[i];

                        angles.Add(angle);
                        direction = new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(Mathf.Deg2Rad * angle));
                        if (Physics.Raycast(position, direction, out ray, Mathf.Infinity, layer))
                        {
                            if (position == parent1.positions[i])
                                distance = parent1.distances[i];
                            else
                                distance = Random.Range(ray.distance * bb, ray.distance - (ray.distance * bb));

                            distances.Add(distance);
                            if (distance > .01f)
                            {
                                position = position + (ray.point - position) * (distance / Vector3.Distance(ray.point, position));
                            }
                        }
                    }
                    else
                    {
                        angle = parent2.angles[i];

                        angles.Add(angle);
                        direction = new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(Mathf.Deg2Rad * angle));
                        if (Physics.Raycast(position, direction, out ray, Mathf.Infinity, layer))
                        {
                            if (position == parent2.positions[i])
                                distance = parent2.distances[i];
                            else
                                distance = Random.Range(ray.distance * bb, ray.distance - (ray.distance * bb));

                            distances.Add(distance);
                            if (distance > .01f)
                            {
                                position = position + (ray.point - position) * (distance / Vector3.Distance(ray.point, position));
                            }
                        }
                    }
                }
            }
            else
            {
                angle = Random.Range(angles[i - 1] - aa, angles[i - 1] + aa);
                angles.Add(angle);
                direction = new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(Mathf.Deg2Rad * angle));
                if (Physics.Raycast(position, direction, out ray, Mathf.Infinity, layer))
                {
                    distance = Random.Range(ray.distance * bb, ray.distance - (ray.distance * bb));
                    distances.Add(distance);

                    if (distance > .01f)
                    {
                        position = position + (ray.point - position) * (distance / Vector3.Distance(ray.point, position));
                    }
                }/**/
            }
            positions.Add(position);
        }
    }
}