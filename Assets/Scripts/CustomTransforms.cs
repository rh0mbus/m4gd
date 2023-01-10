using UnityEngine;

public class CustomTransforms : MonoBehaviour
{
    [SerializeField] Vector2 localCoord;
    [SerializeField] Vector2 worldCoord;
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector2 worldPos = LocalToWorld(localCoord);
        Gizmos.DrawSphere(worldPos, 0.1f);

        localCoord = WorldToLocal(worldCoord);
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(localCoord, 0.1f);
    }

    Vector2 LocalToWorld(Vector2 local)
    {
        Vector2 position = transform.position;
        position += local.x * (Vector2)transform.right;
        position += local.y * (Vector2)transform.up;
        return position;
    }

    Vector2 WorldToLocal(Vector2 world)
    {
        Vector2 rel = world - (Vector2)transform.position;
        float x = Vector2.Dot(rel, transform.right);
        float y = Vector2.Dot(rel, transform.up);
        return new (x, y);
    }
}
