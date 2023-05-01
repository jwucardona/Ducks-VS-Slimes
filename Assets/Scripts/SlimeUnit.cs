using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// public enum AnimationState { Idle,Walk,Attack,Damage}

public class SlimeUnit : AbstractUnit
{
    // Declare the variables
    public float speed;
    private Vector3 spawn;
    private bool isStopped;
    private bool attackVariable, attackInProgress;

    public Face faces;
    public GameObject SmileBody;
    // public AnimationState currentState; 
    public Animator animator;
    //public NavMeshAgent agent;
    public int damType;

    private bool move;
    private Material faceMaterial;
    private Vector3 destination;
    private AbstractUnit currTarget;

    private DuckUnit duckTarget;

    private float timer = 0;

    // Constructor
    public SlimeUnit(int hp, int dmg, float speed) : base(hp, dmg)
    {
        // Set the default values
        this.speed = speed;
    }

    // public void setState(AnimationState state)
    // {
    //     currentState = state;
    // }

    // mutator for spawn
    public void setSpawn(Vector3 spawn)
    {
        this.spawn = spawn;
    }

    void SetFace(Texture tex)
    {
        faceMaterial.SetTexture("_MainTex", tex);
    }

    public void setDestination(Vector3 destination)
    {
        this.destination = destination;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //originPos = transform.position;
        faceMaterial = SmileBody.GetComponent<Renderer>().materials[1];
        attackVariable = false;
        attackInProgress = false;
    }

    public void Idle()
    {
        // if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) return;
        animator.SetBool("Attack", false);
        //StopAgent();
        //SetFace(faces.Idleface);
    }


    public void Attack()
    {
        // if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) return;
        //StopAgent();
        //SetFace(faces.attackFace);
        attackVariable = false;
        if (duckTarget != null)
        {
            animator.SetBool("Attack", true);
            duckTarget.TakeDamageForDucks(damage, this);
            //yield return new WaitForSeconds(5f);
            //animator.SetBool("Attack", false);
            attackVariable = true;
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.layer == 6 || other.tag == "Duck"){
            isStopped = true;
            print("Slime hit duck");
            duckTarget = other.gameObject.GetComponent<DuckUnit>();
        }
    }

    public void defeatedDuck()
    {
        //print(this + " DEFEATEDDUCK");
        isStopped = false;
        attackVariable = false;
        duckTarget = null;
        //StopCoroutine(Attack());
        print("Slime defeated duck");
    }

    public void slowDown()
    {
        speed = 0.005f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStopped){
            transform.Translate(new Vector3(0, 0, speed * 1));
            attackInProgress = false;
            Idle();
        }
        else if (!attackInProgress) {
            //print("starting new attack");
            attackVariable = true;
            attackInProgress = true;
        }

        timer += Time.deltaTime;
        if (attackVariable && timer > 5f)
        {
            Attack();
            //print(timer);
            timer = 0;
        }


        // switch (currentState)
        // {
        //     case AnimationState.Idle:

        //         if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) return;
        //         StopAgent();
        //         SetFace(faces.Idleface);
        //         break;

        //     case AnimationState.Walk:

        //         if (animator.GetCurrentAnimatorStateInfo(0).IsName("Walk")) return;

        //         agent.isStopped = false;
        //         agent.updateRotation = true;

        //         agent.SetDestination(originPos);
        //         // Debug.Log("WalkToOrg");
        //         SetFace(faces.WalkFace);
        //         // agent reaches the destination
        //         if (agent.remainingDistance < agent.stoppingDistance)
        //         {
        //             // walkType = WalkType.Patroll;
        //             //facing to camera
        //             //transform.rotation = Quaternion.identity;
        //             currentState = AnimationState.Idle;
        //         }


        //         // set Speed parameter synchronized with agent root motion moverment
        //         animator.SetFloat("Speed", agent.velocity.magnitude);


        //         break;

        //     // case SlimeAnimationState.Jump:

        //     //     if (animator.GetCurrentAnimatorStateInfo(0).IsName("Jump")) return;

        //     //     StopAgent();
        //     //     SetFace(faces.jumpFace);
        //     //     animator.SetTrigger("Jump");

        //     //     //Debug.Log("Jumping");
        //     //     break;

        //     case AnimationState.Attack:

        //         if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) return;
        //         StopAgent();
        //         SetFace(faces.attackFace);
        //         animator.SetTrigger("Attack");

        //        // Debug.Log("Attacking");

        //         break;
        //     case AnimationState.Damage:

        //        // Do nothing when animtion is playing
        //        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Damage0")
        //             || animator.GetCurrentAnimatorStateInfo(0).IsName("Damage1")
        //             || animator.GetCurrentAnimatorStateInfo(0).IsName("Damage2") ) return;

        //         StopAgent();
        //         animator.SetTrigger("Damage");
        //         animator.SetInteger("DamageType", damType);
        //         SetFace(faces.damageFace);

        //         //Debug.Log("Take Damage");
        //         break;

        // }

    }
    public override void die()
    {
        Destroy(gameObject);
    }
}
