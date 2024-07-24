using UnityEngine;

public class EntityAttack : MonoBehaviour
{
    public GameObject Target;
    private GameObject animAttack;
    private EntityMain main;
    private float attackCooldown;

    private void Init(EntityMain _main)
    {
        main = _main;
        _main.Attack = this;
    }

    public void InitBattle()
    {
        if (Target == null)
        {
            Target = main.OwnTeam.ActualBattle.SearchTheClosestEnnemy(gameObject, main.OwnTeam.ActualBattle.GetOtherTeam(main.OwnTeam));
        }
    }

    /// <summary>
    /// Fais attention � la range de l'entit� ainsi qu'a sa vitesse d'attaque,
    /// lancera AttackMove si toutes les conditions bonnes
    /// </summary>
    /// 
    private void FixedUpdate()
    {
        if (attackCooldown > 0)
        {
            attackCooldown -= Time.fixedDeltaTime;
            if (attackCooldown < 0 )
            {
                attackCooldown = 0;
            }
        }

        if (main != null && Target != null)
        {
            if (main.Stat.AttackRange <= Vector3.Distance(transform.position, Target.transform.position))
            {
                if (attackCooldown <= 0f)
                {
                    AttackMove();

                    // R�initialiser le cooldown bas� sur la vitesse d'attaque
                    attackCooldown = 1f / main.Stat.AttackSpeed;
                }
            }
        }
    }

    /// <summary>
    /// S'active lorsque l'entit� attaque
    /// </summary>
    private void AttackMove()
    {
        //Active l'animation d'attaque

        //Cette fonctionnalit� sera � changer en fonction de ce qui aura �t� fais pour la version final
        GameObject newAttack = Instantiate(animAttack, transform.position, Quaternion.identity);
    }

}
