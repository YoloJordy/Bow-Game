using UnityEngine;

public class Boss_Idle : StateMachineBehaviour
{
    BossController boss;
    [SerializeField] float attackCooldown = 5f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<BossController>();
        boss.Invoke(nameof(boss.Attack), attackCooldown);
        boss.Invoke(nameof(boss.Attack), attackCooldown * 2);
        boss.Invoke(nameof(boss.Attack), attackCooldown * 3);
        boss.Invoke(nameof(boss.Attack), attackCooldown * 4);
        boss.Invoke(nameof(boss.Attack), attackCooldown * 5);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
