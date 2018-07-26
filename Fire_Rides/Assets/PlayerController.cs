using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    int wallsLayer, gatesLayer;
    float angle = 45f;
    RaycastHit hit;
    Rigidbody orb;
    GameObject tile;
    LineRenderer lr;
    Text timer;

    [HideInInspector]
    Vector3 direction, point;
    float n1 = 0, n2 = 0;
    Transform p;
    int counter = 0;
    bool upd = false, started = false;

    public void StartGame(LayerMask walls, LayerMask gates,Text _timer)
    {
        lr = GetComponent<LineRenderer>();

        wallsLayer = walls.value;
        gatesLayer = gates.value;
        timer = _timer;

        orb = GetComponent<Rigidbody>();

        if (Physics.Raycast(transform.position, Vector3.up, out hit, Mathf.Infinity, wallsLayer))
        {
            tile = hit.collider.gameObject;
            tile.GetComponent<MeshRenderer>().material.color = Color.red;

            tile.AddComponent<ConfigurableJoint>().xMotion = ConfigurableJointMotion.Limited;
            tile.GetComponent<ConfigurableJoint>().yMotion = ConfigurableJointMotion.Limited;
            tile.GetComponent<ConfigurableJoint>().zMotion = ConfigurableJointMotion.Locked;

            tile.GetComponent<ConfigurableJoint>().connectedBody = orb;

            tile.GetComponent<ConfigurableJoint>().anchor = Vector3.zero;

            tile.GetComponent<ConfigurableJoint>().axis = Vector3.up;

            point = tile.transform.position;
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, point);
        }
        n1 = point.x % 30f;
        p = tile.transform.parent;
        direction = new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle), 0);

        GetComponent<Rigidbody>().AddForce(direction * 5f, ForceMode.Impulse);
    }

    public void Connect()
    {
        upd = false;
        if (!started)
            started = true;
        Destroy(tile.GetComponent<ConfigurableJoint>());
        if (Physics.Raycast(transform.position, direction, out hit, Mathf.Infinity, wallsLayer))
        {
            if (!hit.collider.GetComponent<Rigidbody>())
                tile = hit.collider.transform.parent.gameObject;
            else
                tile = hit.collider.gameObject;

            tile.GetComponent<MeshRenderer>().material.color = Color.red;

            tile.AddComponent<ConfigurableJoint>().xMotion = ConfigurableJointMotion.Limited;
            tile.GetComponent<ConfigurableJoint>().yMotion = ConfigurableJointMotion.Limited;
            tile.GetComponent<ConfigurableJoint>().zMotion = ConfigurableJointMotion.Locked;

            tile.GetComponent<ConfigurableJoint>().connectedBody = orb;

            tile.GetComponent<ConfigurableJoint>().axis = Vector3.up;

            point = tile.transform.position;
        }

        n1 = point.x % 30f;
        if (n1 > n2 || n1 == n2)
            n2 = n1;
        else
        {
            for (int i = 0; i < 2; i++)
            {
                FindObjectOfType<MapController>().AddMapTiles();
            }
        }

        if (tile.transform.parent != p)
        {

            if (counter > 2)
            {
                counter = 0;
                FindObjectOfType<MapController>().Remover();
            }
            else
                counter++;
        }
        else
        {
            counter = 0;
        }
    }

    void Update()
    {
        lr.SetPosition(0, transform.position);
        if (!upd)
            lr.SetPosition(1, point);
        else
            lr.SetPosition(1, transform.position);
    }

    public void UnClipp()
    {
        upd = true;
        if (tile == null)
            return;
        Destroy(tile.GetComponent<ConfigurableJoint>());
        point = transform.position;
    }

    [HideInInspector]
    public float time = 0;
    void FixedUpdate()
    {
        if (started)
        {
            time += Time.fixedDeltaTime;
            timer.text = time.ToString("F2");
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.collider.gameObject.layer == gatesLayer)
        {
            time++;
        }
        else if (c.collider.gameObject.layer == 8 || c.collider.gameObject.layer == 10)
        {
            started = false;
        }
    }
}