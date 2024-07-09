using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static Augment;

public class TestEntity : MonoBehaviour
{
    public GameObject Shop;
    public GameObject RessourcePoint;

    public StatGive stat;

    [SerializeField]
    private float timeToWaitOnObjectif;
    private Vector3 nextDestination;
    private GameObject ActualObjectif;
    private NavMeshAgent agent;
    private bool isOnObjectif;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!IsObjectifReached())
        {
            agent.SetDestination(nextDestination);
        }
        else if (!isOnObjectif)
        {
            StartCoroutine(WaitOnObjectif());
        }
    }

    private bool IsObjectifReached()
    {
        return Vector3.Distance(transform.position, nextDestination) < 4.5f;
    }

    private void SetObjectif()
    {
        if (ActualObjectif == RessourcePoint)
        {
            ActualObjectif = Shop;
        }
        else
        {
            ActualObjectif = RessourcePoint;
            Shop.SendMessage("SoldItem");
        }

        nextDestination = ActualObjectif.transform.position;
    }

    private IEnumerator WaitOnObjectif()
    {
        isOnObjectif = true;
        yield return new WaitForSeconds(timeToWaitOnObjectif);
        isOnObjectif = false;
        SetObjectif();
    }
}
