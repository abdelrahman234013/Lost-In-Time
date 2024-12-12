using UnityEngine;

public class Obliv_Idle : StateMachineBehaviour
{
    private Scene3Enemy boss;
    private AudioSource audioSource;
    public AudioClip enemyDetectedAudio;
    private bool hasPlayedAudio = false; 

   
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<Scene3Enemy>();
        audioSource = boss.GetComponent<AudioSource>(); 
        hasPlayedAudio = false;
    }

   
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if (boss.IsPlayerInRange() && !hasPlayedAudio)
        {
            hasPlayedAudio = true;
            audioSource.PlayOneShot(enemyDetectedAudio);
            animator.SetBool("isIdle", false);
            boss.StartCoroutine(WaitAndRun(animator));
        }
    }

    private System.Collections.IEnumerator WaitAndRun(Animator animator)
    {
        yield return new WaitForSeconds(5f);
    }
}
