using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public List<Transform> platformPoints = new List<Transform> ();
    private int nextPlatform;
    public float platformSpeed = 2;

    void Update()
    {
        IsNextPlatform();
        MovePlatform(platformPoints[nextPlatform]);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.parent = this.transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.parent = null;
    }

    private void IsNextPlatform()
    {
        if (transform.position == platformPoints[nextPlatform].position) { nextPlatform++; }
        if (nextPlatform >= platformPoints.Count) { nextPlatform = 0; }
    }

    private void MovePlatform(Transform destination)
    {
        transform.position = Vector2.MoveTowards(transform.position, destination.position, platformSpeed * Time.deltaTime);
    }

}
