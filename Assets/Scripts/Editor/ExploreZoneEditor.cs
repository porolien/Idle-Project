using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ExploreZone))]

public class ExploreZoneEditor : Editor
{
    private void OnSceneGUI()
    {
        ExploreZone gizmo = (ExploreZone)target;

        for (int i = 0; i < gizmo.points.Count; i++)
        {
            // Utiliser Handles pour créer un handle de position ajustable pour chaque point
            Vector3 newPosition = Handles.PositionHandle(gizmo.transform.position + gizmo.points[i], Quaternion.identity);
            if (gizmo.points[i] != newPosition - gizmo.transform.position)
            {
                // Enregistrer la modification dans l'historique pour permettre les annulations
                Undo.RecordObject(gizmo, "Move Point");
                gizmo.points[i] = newPosition - gizmo.transform.position;
            }
        }
    }

}
