using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//SELFLESS

public class Lara : MonoBehaviour
{
    Animator AnimZombie;
   
    public float Timepassed;
    public float Timecheck;
    //public float prevOxeHallo;
    //public float prevOxeMarko;
    public int id = 1;
    float speed = 5.0f;
    public float Food;
    public float Health;
    public int action;
    int seconds = 0;
    int i = 0;
    int count = 0;
    public GameObject Food1;
    public GameObject Food2;
    public GameObject Food3;
    Random random = new Random();
    public SpriteRenderer FoodFiller;
    public SpriteRenderer HealthFiller;
    public float Reward;

    //public float OxetocinForHallo;
    float PrevFood = 10;
    float Pfood;
    bool once = false;
    bool healthinc;
    public float dist;
    public MarkoScript Marko;
    public AgentMove Hallo;
    public GameObject LaraModel;
    public float Dopamin;
    //public float OxetocinForMarko;
    //public float OxetocinInHalloForLara;
    //public float OxetocinInMarkoForLara;
  


    bool AttackedByHallo = false;
    bool AttackedByMarko = false;

    //For Coin Collection
    public GameObject Coin1;
    public GameObject Coin2;
    public GameObject Coin3;
    public GameObject Coin4;
    public int numberofCoins = 0;
    Coin coin;
    public float Cointime = 0;
    public int Coinseconds;

    //For health kit collection
    public GameObject AIDkit1;
    public GameObject AIDkit2;
    public int healthKit = 0;
    FirstAidKit Aidkit;
    //public PythonCommunicator py;
    //Bullet fire
    public GameObject Player;
    public GameObject AttackParticle;
    public GameObject ParticlesContainer;
    BulletFire bulletfire;

    float FoodZerotimeSec = 0;
    int FoodZerotime = 0;
    Vector3 AgentStartingPos;

    //Rivalary Levels
    //public float RLForMarko;
    //public float RLForHallo;

    private void Awake()
    {
        this.AttackParticle.SetActive(false);
        Physics.IgnoreLayerCollision(11, 11);
    }


    // Use this for initialization
    void Start()
    {
        Reward = 0;
        Timepassed = 0;
        Timecheck = 0;
        Food = 10;
        Health = 10;
        healthinc = false;
        AnimZombie = GetComponent<Animator>();
        Food3.SetActive(false);
        //Dopamin = 0;
        //OxetocinInHalloForLara = 0;
        //OxetocinInMarkoForLara = 0;
        coin = new Coin();
        Aidkit = new FirstAidKit();
        bulletfire = new BulletFire();
        AgentStartingPos = this.transform.position;
      //  py = new PythonCommunicator();
    }
    public void AddReward(float Reward)
    {
        this.Reward += Reward;
    }

    public void SetReward(float Reward)
    {
        this.Reward = Reward;
    }

    // Update is called once per frame
    void Update()
    {
        //this.action = 0;
        // py.Communication(id, LaraModel, MarkoModel, HalloModel, Marko, Hallo, this, this.Dopamin, this.OxetocinForHallo, this.OxetocinForMarko);
        if (Food == 0)
        {
            FoodZerotimeSec += Time.deltaTime;
            FoodZerotime = (int)FoodZerotimeSec;
            if (FoodZerotime == 3)
            {
                Health = 0;
            }
        }
        if (DieAgent.LaraLive == true)
        {
            AgentReset();
        }

        // DeadTime
        if (this.Health <= 0)
        {
            DieAgent.LaraDied = true;
            Player.active = false;
        }
        Vector3 targetPos = AnimZombie.transform.position;
        Timepassed += Time.deltaTime;
        Timecheck += Time.deltaTime;
        seconds = (int)Timepassed;
        //action = py.AgentAction;
        if (seconds == count)
        {
            count += 1;
            action = Random.Range(1, 7);
            healthinc = false;
            once = false;
        }
        if (seconds == i)
        {
            if(Food> 0)
            {
                Food = Food - 0.5f;
                if (FoodFiller.size.x > 0)
                {
                    this.FoodFiller.size = new Vector2(this.FoodFiller.size.x - 0.02f, this.FoodFiller.size.y);
                }
            }
            i += 2;
        }
        if (PrevFood - Food == 1)
        {
            Health -= 0.5f;
            if(HealthFiller.size.x > 0)
            {
                this.HealthFiller.size = new Vector2(this.HealthFiller.size.x - 0.02f, this.HealthFiller.size.y);

            }
            //this.HealthFiller.size = new Vector2(this.HealthFiller.size.x - 0.02f, this.HealthFiller.size.y);
            PrevFood = Food;
        }


        float dist1 = Vector3.Distance(Hallo.transform.position, Food1.transform.position);
        float dist2 = Vector3.Distance(Hallo.transform.position, Food2.transform.position);
        float dist3 = Vector3.Distance(Hallo.transform.position, Food3.transform.position);

        if (action == 5 && once == false && (dist1 < 1.42 || dist2 < 1.42 || dist3 < 1.42))
        {
            Food++;
            if (FoodFiller.size.x <= 1)
            {
                this.FoodFiller.size = new Vector2(this.FoodFiller.size.x + 0.02f, this.FoodFiller.size.y);
            }
            once = true;
            if (dist1 < 1.42)
            {
                Food1.SetActive(false);
                Timecheck = 0;

            }
            else if (dist2 < 1.42f)
            {
                Food2.SetActive(false);
                Timecheck = 0;

            }
            else if (dist3 < 1.42f)
            {
                Food3.SetActive(false);
                Timecheck = 0;

            }


        }
        if ((int)Timecheck == 5)
        {
            Food1.SetActive(true);
            Food2.SetActive(true);
            Food3.SetActive(true);

        }

        if (Food - PrevFood == 1 && healthinc == false)
        {
            Health += 0.5f;
            this.HealthFiller.size = new Vector2(this.HealthFiller.size.x + 0.02f, this.HealthFiller.size.y);
            healthinc = true;
        }
        //Run Agent Animation 

        if (action == 1 || action == 2 || action == 3 || action == 4)
        {
            AnimZombie.SetTrigger("run");

        }

        //Stop Agent Animation
        // if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.A))
        if (action == 0)
        {
            AnimZombie.SetTrigger("idle");
        }

        //Attack Agent Animation

        //if (Hallo.RLForLara > Hallo.RLForMarko)
        //{
        //    AttackedByHallo = true;
        //}
        //action 7 is attack
        if (Hallo.action == 7 && Vector3.Distance(this.transform.position, Hallo.transform.position) < 3 /*&& AttackedByHallo && Hallo.OxetocinForLara < 3*/)
        {
            //if(OxetocinForHallo > 0)
            //{
            //    OxetocinForHallo -= 0.5f;
            //}
            //transform.LookAt(Hallo.transform.position);
            AnimZombie.SetTrigger("attack");
            bulletfire.ShootBullet(AttackParticle, Player, ParticlesContainer);
            if (Food > 0)
            {
                Food--;
                this.FoodFiller.size = new Vector2(this.FoodFiller.size.x - 0.02f, this.FoodFiller.size.y);
            }
            //RLForHallo += 0.5f;
        }
        //if(Marko.RLForLara > Marko.RLForHallo)
        //{
        //    AttackedByMarko = true;
        //}
        if (Marko.action == 7 && Vector3.Distance(this.transform.position, Marko.transform.position) < 3 /*&& AttackedByMarko && Marko.OxetocinForLara < 3*/)
        {
            //if (OxetocinForMarko > 0)
            //{
            //    OxetocinForMarko -= 0.5f;
            //}
            //transform.LookAt(Marko.transform.position);
            AnimZombie.SetTrigger("attack");
            bulletfire.ShootBullet(AttackParticle, Player, ParticlesContainer);
            if (Food > 0)
            {
                Food--;
                this.FoodFiller.size = new Vector2(this.FoodFiller.size.x - 0.02f, this.FoodFiller.size.y);
            }
            //RLForMarko += 0.5f;
        }
        float DistanceWithMarko = Vector3.Distance(this.transform.position, Marko.transform.position);

        //Sharing with Marko
        if (action == 6 && DistanceWithMarko <= 1.42f /*&& OxetocinForMarko >= 2*/)
        {
            if (Food > 0)
            {
                this.Food -= 0.5f;
                Marko.Food += 0.5f;
              //  OxetocinInMarkoForLara += 0.5f;
                AddReward(1f);
            }
            //if (Marko.RLForLara > 0)
            //{
            //    Marko.RLForLara -= 0.5f;
            //}
            if (this.FoodFiller.size.x > 0)
            {
                this.FoodFiller.size = new Vector2(this.FoodFiller.size.x - 0.02f, this.FoodFiller.size.y);
            }
            if (Marko.FoodFiller.size.x <= 1)
            {
                Marko.FoodFiller.size = new Vector2(this.FoodFiller.size.x + 0.02f, this.FoodFiller.size.y);
            }
        }
        float DistanceWithHallo = Vector3.Distance(this.transform.position, Hallo.transform.position);
        //Sharing with hallo
        if (action == 6 && DistanceWithHallo <= 1.42f /*&& OxetocinForHallo >= 2*/)
        {
            Hallo.interactionWithLara++;
            if (Food > 0)
            {
                this.Food -= 0.5f;
                Hallo.Food += 0.5f;
               // OxetocinInHalloForLara += 0.5f;
                AddReward(1f);
            }
            //if (Hallo.RLForLara > 0)
            //{
            //    Hallo.RLForLara -= 0.5f;
            //}
            if (this.FoodFiller.size.x > 0)
            {
                this.FoodFiller.size = new Vector2(this.FoodFiller.size.x - 0.02f, this.FoodFiller.size.y);
            }
            //doesnt get out of the filler
            if (Hallo.FoodFiller.size.x <= 1)
            {
                Hallo.FoodFiller.size = new Vector2(this.FoodFiller.size.x + 0.02f, this.FoodFiller.size.y);
            }
        }
        //if (OxetocinInMarkoForLara - prevOxeMarko > 5)
        //{
        //    prevOxeMarko = OxetocinInMarkoForLara;
        //    Dopamin++;
        //}
        //if (OxetocinInHalloForLara - prevOxeHallo > 5)
        //{
        //    prevOxeHallo = OxetocinInHalloForLara;
        //    Dopamin++;
        //}
        //if (Dopamin > 5)
        //{
        //    AddReward(1f);
        //}
        if (Health <= 0)
        {
            SetReward(-1f);
        }

        //Coin collection
        Cointime = Cointime + Time.deltaTime;
        Coinseconds = (int)Cointime;
        numberofCoins = numberofCoins + coin.coin_production(Coinseconds, LaraModel, Coin1, Coin2, Coin3, Coin4);

        //Health Kit Collection
        healthKit = Aidkit.AIDKIT(Coinseconds, LaraModel, AIDkit1, AIDkit2);
        if (healthKit > 0)
        {
            Health += 0.5f;
            this.HealthFiller.size = new Vector2(this.HealthFiller.size.x + 0.02f, this.HealthFiller.size.y);
            healthKit = 0;
        }
        if (Coinseconds == 5)
        {
            Cointime = 0;
            Coinseconds = 0;
        }
       // py.nextState(id, LaraModel, MarkoModel, HalloModel, Marko, Hallo, this, this.Dopamin, this.OxetocinForHallo, this.OxetocinForMarko, this.Reward);
    }
    private void FixedUpdate()
    {

        //Move PLayer


        //Move Player forward
        if (action == 1)
        {
            transform.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(Vector3.left);
            transform.position += Vector3.left * Time.deltaTime * speed;
        }

        //if (Input.GetKey(KeyCode.UpArrow))
        if (action == 2)

        {
            transform.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(Vector3.forward);
            transform.position += Vector3.forward * Time.deltaTime * speed;
        }

        //Move Player Backward
        //  if (Input.GetKey(KeyCode.DownArrow))
        if (action == 3)
        {
            transform.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(Vector3.back);
            transform.position -= Vector3.forward * Time.deltaTime * speed;
        }

        //Move Player left
        //if (Input.GetKey(KeyCode.LeftArrow))

        //Move Player Right
        if (action == 4)
        {
            transform.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(Vector3.right);
            transform.position -= Vector3.left * Time.deltaTime * speed;
        }
    }
    void AgentReset()
    {
        Timepassed = 0;
        Timecheck = 0;
        Food = 10;
        Health = 10;
        healthinc = false;
        Food3.SetActive(false);
        numberofCoins = 0;
        //Dopamin = 0;
        //OxetocinInHalloForLara = 0;
        //OxetocinInMarkoForLara = 0;
        healthKit = 0;
        seconds = 0;
        i = 0;
        count = 0;
        Cointime = 0;
        //PrevFood = 10;
        once = false;
        DieAgent.LaraLive = false;
        this.transform.position = AgentStartingPos;
        FoodZerotimeSec = 0;
        FoodZerotime = 0;
    }
}
