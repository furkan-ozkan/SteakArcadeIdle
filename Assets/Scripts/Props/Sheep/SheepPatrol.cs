using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class SheepPatrol : MonoBehaviour
{
    public float minX, maxX, minZ, maxZ;
    public int numberOfPatrolPoints = 10;
    public float speed = .5f;
    public float thresholdDistance = 0.1f;

    private Vector3[] patrolPoints;
    private int currentPatrolPointIndex;

    public bool stopMove;

    void Start()
    {
        patrolPoints = GenerateRandomPatrolPoints(numberOfPatrolPoints);
        currentPatrolPointIndex = 0;
        StartCoroutine(MoveToNextPatrolPoint());
    }

    Vector3[] GenerateRandomPatrolPoints(int numberOfPoints)
    {
        Vector3[] points = new Vector3[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            float x = Random.Range(minX, maxX);
            float z = Random.Range(minZ, maxZ);
            points[i] = new Vector3(x, .5f, z);
        }
        return points;
    }

    IEnumerator MoveToNextPatrolPoint()
    {
        while (true)
        {
            Vector3 targetPosition = patrolPoints[currentPatrolPointIndex];
            while (Vector3.Distance(transform.position, targetPosition) > thresholdDistance)
            {
                if (!stopMove)
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                    transform.DOLookAt(new Vector3(targetPosition.x,transform.position.y,targetPosition.z),.25f);
                }
                yield return null;
            }
            currentPatrolPointIndex = (currentPatrolPointIndex + 1) % patrolPoints.Length;
        }
    }
}