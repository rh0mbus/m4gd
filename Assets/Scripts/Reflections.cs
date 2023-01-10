using UnityEngine;

public class Reflections : MonoBehaviour
{
    // Reflected vector
    // r = d-2(d dot normal) * normal 

    [SerializeField] int numBounces = 2;
    void OnDrawGizmos()
    {
        var transform1 = transform;
        Vector2 origin = transform1.position;
        Vector2 dir = transform1.right;
        
        Ray ray = new Ray(origin, dir);
        
        Gizmos.DrawLine(origin, origin + dir);

        for (int i = 0; i < numBounces; i++)
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Gizmos.DrawSphere(hit.point, 0.1f);
                var placeholder = hit.normal;

                Vector2 reflected = Reflect(ray.direction, hit.normal);
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(hit.point, (Vector2)hit.point + reflected);


                ray.direction = reflected;
                ray.origin = hit.point;
                // Built in
                // Vector2.Reflect();
            }
        }
    }

    Vector2 Reflect(Vector2 inDir, Vector2 normal)
    {
        float proj = Vector2.Dot(inDir, normal);
        return inDir - 2 * proj * normal;
    }
}
