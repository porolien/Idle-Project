using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ProceduralSphere : MonoBehaviour
{
    public int longitudeSegments = 24;
    public int latitudeSegments = 16;
    public float radius = 1f;

    private void Start()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        Vector3[] vertices = new Vector3[(longitudeSegments + 1) * latitudeSegments + 2];
        int[] triangles = new int[longitudeSegments * latitudeSegments * 6];
        Vector2[] uv = new Vector2[vertices.Length];

        float pi = Mathf.PI;
        float twoPi = pi * 2f;

        vertices[0] = Vector3.up * radius;
        for (int lat = 0; lat < latitudeSegments; lat++)
        {
            float a1 = pi * (lat + 1) / (latitudeSegments + 1);
            float sin1 = Mathf.Sin(a1);
            float cos1 = Mathf.Cos(a1);

            for (int lon = 0; lon <= longitudeSegments; lon++)
            {
                float a2 = twoPi * (lon == longitudeSegments ? 0 : lon) / longitudeSegments;
                float sin2 = Mathf.Sin(a2);
                float cos2 = Mathf.Cos(a2);

                vertices[lon + lat * (longitudeSegments + 1) + 1] = new Vector3(sin1 * cos2, cos1, sin1 * sin2) * radius;
                uv[lon + lat * (longitudeSegments + 1) + 1] = new Vector2((float)lon / longitudeSegments, (float)(lat + 1) / (latitudeSegments + 1));
            }
        }
        vertices[vertices.Length - 1] = Vector3.down * radius;

        int vert = 1;
        int tri = 0;
        for (int lon = 0; lon < longitudeSegments; lon++)
        {
            triangles[tri++] = 0;
            triangles[tri++] = vert;
            triangles[tri++] = vert + 1;
            vert++;
        }

        vert = 1;
        for (int lat = 0; lat < latitudeSegments - 1; lat++)
        {
            for (int lon = 0; lon < longitudeSegments; lon++)
            {
                int current = lon + lat * (longitudeSegments + 1) + 1;
                int next = current + longitudeSegments + 1;

                triangles[tri++] = current;
                triangles[tri++] = next;
                triangles[tri++] = current + 1;

                triangles[tri++] = current + 1;
                triangles[tri++] = next;
                triangles[tri++] = next + 1;
            }
        }

        vert = vertices.Length - (longitudeSegments + 1) - 1;
        for (int lon = 0; lon < longitudeSegments; lon++)
        {
            triangles[tri++] = vertices.Length - 1;
            triangles[tri++] = vert + 1;
            triangles[tri++] = vert;
            vert++;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;
        mesh.RecalculateNormals();
    }
}
