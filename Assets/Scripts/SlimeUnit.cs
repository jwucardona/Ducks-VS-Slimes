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
        //es = EnemySpawner.getInstance();
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
            attackVariable = true;
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.layer == 6 || other.tag == "Duck"){
            isStopped = true;
            duckTarget = other.gameObject.GetComponent<DuckUnit>();
        }
        if (other.gameObject.layer == 3) {
            EndScript.Lose();
            other.gameObject.GetComponent<GameControllerScript>().GameOver();
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
        speed = 0.0025f;
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
        if (attackVariable && timer > 2f)
        {
            Idle();
        }

    }
    public override void die()
    {
        gc.deadSlime();
        print(this);
        //print("test1");
        Destroy(this.gameObject);
    }
}
