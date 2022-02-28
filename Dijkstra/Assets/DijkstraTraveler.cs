using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DijkstraTraveler : MonoBehaviour
{
    public Node currentNode;
    public Node goal;
    private List<Node> path = new List<Node>();
    // Start is called before the first frame update
    void Start()
    {
        DijkstraAlgo dijkstraAlgo = new DijkstraAlgo(currentNode, goal);
        path = dijkstraAlgo.CalcPath();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path.Count>0)
        {
            //Debug.Log("inpath");
            //Vector3.MoveTowards(transform.position, path[0].transform.position, 1.0f);
            //float speed = 2.5f;
            //float smooth = 1.0f - Mathf.Pow(0.5f, Time.deltaTime * speed);
            transform.position = Vector3.MoveTowards(transform.position, path[0].transform.position, 10.0f * Time.fixedDeltaTime);
            //transform.position = Vector3.Lerp(transform.position, path[0].transform.position, 0.01f);
            if (Vector3.Distance(transform.position, path[0].transform.position) < 0.2)
                path.RemoveAt(0);
            //transform.position = Vector3.Lerp(transform.position, path[0].transform.position, 10.0f/Time.fixedDeltaTime);
        }
    }
}
