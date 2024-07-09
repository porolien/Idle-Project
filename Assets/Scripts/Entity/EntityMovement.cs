using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EntityMovement : MonoBehaviour
{
    public GameObject Shop;
    public GameObject RessourcePoint;
    public GameObject ActualObjectif;

    [SerializeField]
    private float timeToWaitOnObjectif;
    private Vector3 nextDestination;
    
    public NavMeshAgent Agent;
    private bool isOnObjectif;

    private EntityMain main;

    private void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {/*
        if (!main.Attack.Target)
        {
            if (!IsObjectifReached())
            {
                agent.SetDestination(nextDestination);
            }
            else if (!isOnObjectif)
            {
                // A la place d'une coroutine on va v�rifier si l'entit� � fini son objectif
                StartCoroutine(WaitOnObjectif());
            }
        }*/
    }

    private void Init(EntityMain _main)
    {
        _main.Movement = this;
        main = _main;
    }
    
    public void GoToTheDestination()
    {
        Agent.SetDestination(nextDestination);
    }

    //M�thode permettant d'ajouter une destination
    public void NewDestination(Vector3 _newDestination)
    {
        nextDestination = _newDestination;
    }

    // M�thode pour v�rifier la distance entre l'entit� et l'objectifs
    public bool IsObjectifReached()
    {
        return Vector3.Distance(transform.position, nextDestination) < 4.5f;
    }

    /// <summary>
    /// M�thode permettant de changer l'objectif de l'entit�,
    /// � �voluer pour changer l'objectif et l'�tat
    /// </summary>
    public void SetObjectif()
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

    // M�thode permettant de cr�er du d�lais pendant la r�alisation des objectifs
    private IEnumerator WaitOnObjectif()
    {
        isOnObjectif = true;
        yield return new WaitForSeconds(timeToWaitOnObjectif);
        isOnObjectif = false;
        SetObjectif();
    }
}
