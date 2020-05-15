using Assets.Scripts.Classes;
using Assets.Scripts.Classes.ITEM.WEAPON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlagueController : MonoBehaviour
{
    private int ReferencePlayer;

    private bool IsPlayerInAttackRange = false;
    protected float AttackRange = 6;
    public GameObject PoisonPrefab;
    BoxCollider Weapon;
    private bool IsDieSoundPlayed = false;

    float timer = 0;
    public Slider SliderPrefab;
    public Slider slider;
    public Transform SliderPos;
    private float Health { get; set; }
    private float Defense { get; set; }

    public float GetHealth() { return this.Health; }
    public float GetDefense() { return this.Defense; }

    public void SetHealth(float _Health) { this.Health = _Health; }
    public void SetDefense(float _Defense) { this.Defense = _Defense; }
    public void SetCurrentHealth(float _Damage)
    {
        if (this.Health - _Damage >= 0)
            this.Health -= _Damage;
        else
            this.Health = 0;
    }

    private NavMeshAgent nav;
    private Animator anim;
    private AudioSource audiosource;
    public AudioClip[] clip;

    private void Start()
    {
        GameObject canvas = GameObject.FindWithTag("MainCanvas");
        slider = Instantiate(SliderPrefab, Vector3.zero, Quaternion.identity) as Slider;
        slider.transform.SetParent(canvas.transform);
        slider.transform.localScale = new Vector3(1, 1, 1);
        this.SetHealth(100);
        nav = this.transform.GetComponent<NavMeshAgent>();
        anim = this.transform.GetChild(0).GetComponent<Animator>();

        audiosource = this.transform.GetComponent<AudioSource>();
        audiosource.Play();
        audiosource.PlayOneShot(clip[1]);

    }

    private void Update()
    {
        Chase();
        Attack(10, 10, 10, 10, 3);
        StartCoroutine("Die");
        Vector3 _SliderPos = Camera.main.WorldToScreenPoint(SliderPos.position);
        slider.transform.position = _SliderPos;

    }

    public void Chase()
    {
        FindReferencePlayer();
        if (GameManager.Players[ReferencePlayer] == null) return;
        if (!IsPlayerInAttackRange)
        {
            if (nav.isOnNavMesh)
            {
                nav.SetDestination(GameManager.Players[ReferencePlayer].transform.position);
                anim.SetTrigger("Run_1");

                //audiosource.clip = clip[0];
                //audiosource.Play();
            }
        }
        //if (!nav.hasPath && nav.pathStatus == NavMeshPathStatus.PathComplete)
        //{
        //    Debug.Log("Character stuck");
        //    nav.enabled = false;
        //    nav.enabled = true;
        //    Debug.Log("navmesh re enabled");
        //    // navmesh agent will start moving again
        //}
       
    }
    public void Attack(float _AttackSpeed, float _Damage, float _CriticalDamage, float _CriticalPercentage, float _AttackRange)
    {
        Vector3 relativePos;
        FindReferencePlayer();
        if (GameManager.Players[ReferencePlayer] == null) return;
        if (Vector3.Distance(GameManager.Players[ReferencePlayer].transform.position, this.transform.position) < _AttackRange)
        {
            IsPlayerInAttackRange = true;
            relativePos = GameManager.Players[ReferencePlayer].transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            transform.rotation = rotation;
            anim.SetTrigger("Attack_1");
        }
        else
            IsPlayerInAttackRange = false;

    }

    public IEnumerator Die()
    {
        if (this.GetHealth() <= 0)
        {
            anim.Play("Armature|Death");
            this.GetComponent<CapsuleCollider>().enabled = false;
            this.GetComponent<NavMeshAgent>().enabled = false;
            if (!IsDieSoundPlayed)
            {
                audiosource.PlayOneShot(clip[0]);
                IsDieSoundPlayed = true;
            }

            yield return new WaitForSeconds(3);
            transform.Translate(-Vector3.up * Time.deltaTime / 3);
            yield return new WaitForSeconds(4);
            Destroy(this.gameObject);
        }
    }

    protected void FindReferencePlayer()
    {
        Vector3 mindistance = new Vector3();
        if (GameManager.Players[0] == null) return;
        mindistance = GameManager.Players[0].transform.position - this.transform.position;
        for (int i = 0; i < GameManager.Players.Count; i++)
        {
            if (GameManager.Players[i] == null) return;
            Vector3 tempdistance = GameManager.Players[i].transform.position - this.transform.position;
            if (tempdistance.magnitude <= mindistance.magnitude)
            {
                mindistance = tempdistance;
                ReferencePlayer = i;
            }
        }
    }


    private void OnTriggerEnter(Collider _PlayerWeapon)
    {
        switch (_PlayerWeapon.tag)
        {
            case "WeaponHammer":
                Hammer _CloneReferenceHammer;
                _CloneReferenceHammer = _PlayerWeapon.gameObject.GetComponent<HammerController>().ReferenceWeapon;
                SetCurrentHealth(Mathf.Abs(_CloneReferenceHammer.GetDamage() - this.GetDefense()));
                slider.value = this.GetHealth();
                break;
            case "WeaponSword":
                Sword _CloneReferenceSword;
                _CloneReferenceSword = _PlayerWeapon.gameObject.GetComponent<SwordController>().ReferenceWeapon;
                SetCurrentHealth(Mathf.Abs(_CloneReferenceSword.GetDamage() - this.GetDefense()));
                slider.value = this.GetHealth();
                break;
            case "WeaponBow":
                Bow _CloneReferenceBow;
                _CloneReferenceBow = _PlayerWeapon.gameObject.GetComponent<BowController>().ReferenceWeapon;
                SetCurrentHealth(Mathf.Abs(_CloneReferenceBow.GetDamage() - this.GetDefense()));
                slider.value = this.GetHealth();
                break;
        }

    }


}






