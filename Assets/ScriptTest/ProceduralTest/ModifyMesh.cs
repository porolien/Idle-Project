using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class ModifyMesh : MonoBehaviour
{
    public float noiseScale = 1.0f;
    public float noiseIntensity = 1.0f;

    private void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            float noise = Mathf.PerlinNoise(vertices[i].x * noiseScale, vertices[i].z * noiseScale);
            vertices[i].y += noise * noiseIntensity;
        }

        mesh.vertices = vertices;
        mesh.RecalculateNormals();
        AddVertice();
    }

    private void AddVertice()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] originalVertices = mesh.vertices;
        int[] originalTriangles = mesh.triangles;

        // Exemple simple : ajouter un sommet au centre du maillage
        Vector3[] newVertices = new Vector3[originalVertices.Length + 1];
        originalVertices.CopyTo(newVertices, 0);
        newVertices[newVertices.Length - 1] = Vector3.zero; // Ajouter un nouveau sommet au centre

        int[] newTriangles = new int[originalTriangles.Length + 3];
        originalTriangles.CopyTo(newTriangles, 0);
        newTriangles[newTriangles.Length - 3] = 0; // Indices des triangles pour utiliser le nouveau sommet
        newTriangles[newTriangles.Length - 2] = 1;
        newTriangles[newTriangles.Length - 1] = newVertices.Length - 1;

        mesh.vertices = newVertices;
        mesh.triangles = newTriangles;
        mesh.RecalculateNormals();
    }
}
