using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour
{
    public Transform raySource;

    public int numReflections = 2;

    private void OnDrawGizmos()
    {
        Vector2 rayOrigin = raySource.position;

        float random = Random.Range(0f, 260f); //https://discussions.unity.com/t/getting-a-random-unit-vector2/109474

        Vector2 rayDirection = new Vector2(Mathf.Cos(random), Mathf.Sin(random));

        Ray ray = new Ray(rayOrigin, rayDirection);

        reflectRay(ray, rayOrigin, numReflections);
    }

    //draw a sphere at our point of collision and reflect again 
    private void reflectRay(Ray ray, Vector2 rayOrigin, int numReflects) {
        
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Gizmos.DrawSphere(hit.point, 0.1f);
            Gizmos.DrawLine(rayOrigin, hit.point);

            Vector2 hitNormal = hit.normal;
            Vector2 rayNormal = ray.direction.normalized;
            float dotProduct = ((rayNormal.x * hitNormal.x) + (rayNormal.y * hitNormal.y));
            //float dotProduct = Mathf.Acos(rayNormal.magnitude * hitNormal.magnitude * Mathf.Cos(Vector2.SignedAngle(rayNormal, hitNormal)));

            //float missingLength = Mathf.Sqrt(1 - (dotProduct * dotProduct));
            Vector2 reflectedVector = rayNormal - 2 * (dotProduct) * hitNormal; 

            //float reflectAngle = Mathf.Acos(dotProduct);
            //Vector2 reflectDirection = new Vector2(dotProduct, missingLength);

            ray = new Ray(hit.point, reflectedVector);

            numReflects--;

            if (numReflects > 0)
            {
                reflectRay(ray, hit.point, numReflects);
            }
        } else
        {
            Gizmos.DrawLine(rayOrigin, ray.direction * 1000);
        }
    }


}
