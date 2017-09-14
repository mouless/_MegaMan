using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerEnemyMove : MonoBehaviour
{
    private Animator anim;

    private PlayerControllerScripts_Update thePlayer;

    public float moveSpeed;

    public float playerRange;

    public LayerMask playerLayer;

    public bool playerInRange;

    public bool iamImmune = false;

    // Use this for initialization
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerControllerScripts_Update>();
        playerRange = Random.Range(4.0f, 9.0f);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer);

        if (playerInRange)
        {
            anim.SetBool("HuntPlayer", true);
            transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, moveSpeed * Time.deltaTime);
        }
        else if (!playerInRange)
        {
            anim.SetBool("HuntPlayer", false);
        }

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Bat_Idle"))
        {
            iamImmune = false;
        }
        else
        {
            iamImmune = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        //Gizmos.DrawSphere(transform.position, Random.Range(6.0f, 9.0f));
        Gizmos.DrawSphere(transform.position, playerRange);
    }
}
