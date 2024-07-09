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
                // A la place d'une coroutine on va vérifier si l'entité à fini son objectif
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

    //Méthode permettant d'ajouter une destination
    public void NewDestination(Vector3 _newDestination)
    {
        nextDestination = _newDestination;
    }

    // Méthode pour vérifier la distance entre l'entité et l'objectifs
    public bool IsObjectifReached()
    {
        return Vector3.Distance(transform.position, nextDestination) < 4.5f;
    }

    /// <summary>
    /// Méthode permettant de changer l'objectif de l'entité,
    /// à évoluer pour changer l'objectif et l'état
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

    // Méthode permettant de créer du délais pendant la réalisation des objectifs
    private IEnumerator WaitOnObjectif()
    {
        isOnObjectif = true;
        yield return new WaitForSeconds(timeToWaitOnObjectif);
        isOnObjectif = false;
        SetObjectif();
    }
}
