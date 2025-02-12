using UnityEngine;
using System.Threading.Tasks;

public class Building : MonoBehaviour
{
    public Transform EnterTransform;
    //à exprimer en milliseconde
    public int DurationJob;
    // Si on doit construire les bâtiments
    private int cost;
    private GameObject buildingPrefab;

    public virtual async Task BuildingTask(EntityMain _entity)
    {

    }

    public virtual IBaseEntityState ReturnTheNextState(EntityStateMachine _entity)
    {
        return _entity.DestinationState;
    }

    protected virtual void Start()
    {
        
    }
}
