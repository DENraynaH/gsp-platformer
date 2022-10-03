using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{

    private Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(PlatformFall());
        StartCoroutine(DestoryPlatform());
    }

    IEnumerator PlatformFall()
    {
        yield return new WaitForSeconds(0.5f);
        rigidBody.velocity = new Vector2(0, -5);
        rigidBody.bodyType = RigidbodyType2D.Dynamic;
    }

    IEnumerator DestoryPlatform()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }



}
