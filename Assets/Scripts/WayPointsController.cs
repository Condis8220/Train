using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointsController : Singleton<WayPointsController>
{
    public List<Transform> waypoinList;

    private int numPoint;

    private void Start()
    {
        numPoint = -1;

        foreach (Transform i in transform)
        {
            if (i.Find("Points").GetComponent<Rail>().isTurnOver)
            {
                for (int j = i.Find("Points").childCount - 1; j > 0; j--)
                {
                    waypoinList.Add(i.Find("Points").GetChild(j));
                }
            }
            else
            {
                for (int j = 0; j < i.Find("Points").childCount; j++)
                {
                    waypoinList.Add(i.Find("Points").GetChild(j));
                }
            }
        }
    }

    public Vector3 GetNextPoint()
    {
        numPoint++;

        if (numPoint == waypoinList.Count - 1)
            numPoint = 0;

        return waypoinList[numPoint].position;
    }
}
