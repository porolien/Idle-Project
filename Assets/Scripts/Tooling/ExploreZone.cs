using System.Collections.Generic;
using UnityEngine;

public class ExploreZone : MonoBehaviour
{
    // Liste de points pour définir la zone
    public List<Vector3> points = new List<Vector3>();

    // Définir la couleur du gizmo
    public Color gizmoColor = Color.green;

    // Cette méthode est appelée par Unity pour dessiner des gizmos dans l'éditeur
    private void OnDrawGizmos()
    {
        // Sauvegarder la couleur actuelle des gizmos
        Color previousColor = Gizmos.color;
        // Définir la couleur des gizmos
        Gizmos.color = gizmoColor;

        // Dessiner les points et les lignes entre les points
        for (int i = 0; i < points.Count; i++)
        {
            // Dessiner une petite sphère pour représenter chaque point
            Gizmos.DrawSphere(transform.position + points[i], 0.1f);

            // Dessiner une ligne entre le point actuel et le point suivant
            if (i < points.Count - 1)
            {
                Gizmos.DrawLine(transform.position + points[i], transform.position + points[i + 1]);
            }
            // Dessiner une ligne entre le dernier point et le premier pour fermer la zone
            else if (points.Count > 2)
            {
                Gizmos.DrawLine(transform.position + points[i], transform.position + points[0]);
            }
        }

        // Restaurer la couleur précédente des gizmos
        Gizmos.color = previousColor;
    }
    public Vector3 GetRandomPointInPolygon()
    {
        // Calculer un point aléatoire dans le polygone
        // Utiliser la méthode de triangulation pour déterminer si le point est à l'intérieur
        Vector3 randomPoint;
        do
        {
            float minX = Mathf.Min(points.ConvertAll(p => p.x).ToArray());
            float maxX = Mathf.Max(points.ConvertAll(p => p.x).ToArray());
            float minY = Mathf.Min(points.ConvertAll(p => p.z).ToArray());
            float maxY = Mathf.Max(points.ConvertAll(p => p.z).ToArray());

            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            randomPoint = new Vector3(randomX, 0, randomY);
        } 
        
        while (!IsPointInPolygon(randomPoint));

        return transform.position + randomPoint;
    }

    // Méthode pour vérifier si un point est à l'intérieur du polygone
    private bool IsPointInPolygon(Vector3 point)
    {
        bool isInside = false;
        for (int i = 0, j = points.Count - 1; i < points.Count; j = i++)
        {
            if (((points[i].z > point.z) != (points[j].z > point.z)) &&
                (point.x < (points[j].x - points[i].x) * (point.z - points[i].z) / (points[j].z - points[i].z) + points[i].x))
            {
                isInside = !isInside;
            }
        }
        return isInside;
    }

}
