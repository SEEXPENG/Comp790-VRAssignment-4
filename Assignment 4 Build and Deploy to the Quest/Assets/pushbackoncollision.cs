using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushbackoncollision : MonoBehaviour
{
    public float pushBackDistance = 1f; // The distance to move the object back

    private void OnCollisionEnter(Collision collision)
    {
        // Calculate the direction to move the object back
        Vector3 pushDirection = (collision.transform.position - transform.position).normalized;
        pushDirection.y = 0; // Optional: Keep the movement horizontal

        // Move the collided object back by a certain distance
        collision.transform.position += pushDirection * pushBackDistance;
    }
}
