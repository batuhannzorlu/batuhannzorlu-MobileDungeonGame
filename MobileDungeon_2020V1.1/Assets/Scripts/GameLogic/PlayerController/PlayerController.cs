using Assets.Scripts.Classes.ITEM.ARMOR;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Mirror;
using UnityEngine.EventSystems;
using System;
using UIHealthAlchemy;

public class PlayerController : NetworkBehaviour
{


    public float speed = 6.0f;
    private int Level;
    private string Sprite;
    private float CriticalDamage;
    private float CriticalPercentange;
    private string Name;
    private string WeaponName = null;

    Vector3 DefaultPosition;

    private float Damage;
    BoxCollider Weapon;

    bool Attack_1 = false;
    bool Attack_2 = false;
    float Attack_1Speed = 0.4f;
    float Attack_2Speed = 0.4f;

    public string Type;
    public float AttackDamage;
    public float Defense;
    public Vector3 Location;
    public string Nick = "Batuhan";
    public float Health;
    public Inventory Inventory;
    public float MovementSpeed;
    public float AttackSpeed;
    Vector3 dir;

    private void Awake()
    {
        this.GetComponent<SetupLocalPlayer>().IsPlayerSetup = false;
    }
    private void Start()
    {
        dir = Vector3.zero;
    }
    private void FixedUpdate()
    {

        if (this.GetComponent<SetupLocalPlayer>().IsPlayerSetup)
        {

            if (dir.magnitude > 1)
                dir.Normalize();

            dir = this.GetComponent<SetupLocalPlayer>().moveJoystick.InputDirection;
            Vector3 rotateDir = Camera.main.transform.TransformDirection(dir);
            this.transform.GetChild(1).GetComponent<Animator>().SetFloat("Speed", Mathf.Abs(dir.x) + Mathf.Abs(dir.z));
            rotateDir = new Vector3(rotateDir.x, 0, rotateDir.z);
            rotateDir = rotateDir.normalized * dir.magnitude;
            this.GetComponent<Rigidbody>().velocity = rotateDir * 10;
            transform.rotation = Quaternion.LookRotation(rotateDir);
        }

    }
    public void OnSwordHammerAttack_1BtnDown()
    {
        if (!Attack_1)
        {
            this.GetComponent<SetupLocalPlayer>().PlayerAnimator.SetTrigger("Attack_1");
            Attack_1 = true;
            StartCoroutine(Attack_1Density());
        }
    }
    public void OnSwordHammerAttack_2BtnDown()
    {
        if (!Attack_2)
        {
            this.GetComponent<SetupLocalPlayer>().PlayerAnimator.SetTrigger("Attack_2");
            Attack_2 = true;
            StartCoroutine(Attack_2Density());
        }

    }
    IEnumerator Attack_1Density()
    {
        yield return new WaitForSeconds(Attack_1Speed);
        Attack_1 = false;
    }
    IEnumerator Attack_2Density()
    {
        yield return new WaitForSeconds(Attack_1Speed);
        Attack_2 = false;
    }


    public void OnSwordHammerAttackBtnUp()
    {

    }

    public void SetCurrentHealth(float _Damage)
    {
        if (this.Health - _Damage >= 0)
            this.Health -= _Damage;
        else
            this.Health = 0;
    }


    private void OnTriggerEnter(Collider collider)
    {
        GameObject CloneObject;

        if (collider.tag.StartsWith("Armor"))
        {
            GameObject CloneArmor = null;
            switch (collider.tag)
            {
                case "ArmorBerserker":
                    CloneArmor = collider.gameObject;
                    Destroy(collider.gameObject);
                    // Destroy(transform.Find(Name).gameObject);
                    Level = CloneArmor.GetComponent<ArBerserkerController>().ReferenceArmor.GetLevel();
                    Type = CloneArmor.GetComponent<ArBerserkerController>().ReferenceArmor.GetType();
                    Defense = CloneArmor.GetComponent<ArBerserkerController>().ReferenceArmor.GetDefense();
                    Sprite = CloneArmor.GetComponent<ArBerserkerController>().ReferenceArmor.GetSprite().name;
                    Name = CloneArmor.GetComponent<ArBerserkerController>().ReferenceArmor.GetObjectName() + "(Clone)";

                    CloneArmor.GetComponent<Animator>().enabled = false;
                    CloneArmor.GetComponent<Collider>().enabled = false;
                    this.gameObject.GetComponent<Animator>().enabled = true;

                    break;
                case "ArmorCrossBow":
                    CloneArmor = collider.gameObject;
                    Destroy(collider.gameObject);
                    Level = CloneArmor.GetComponent<ArCrossBowController>().ReferenceArmor.GetLevel();
                    Type = CloneArmor.GetComponent<ArCrossBowController>().ReferenceArmor.GetType();
                    Defense = CloneArmor.GetComponent<ArCrossBowController>().ReferenceArmor.GetDefense();
                    Sprite = CloneArmor.GetComponent<ArCrossBowController>().ReferenceArmor.GetSprite().name;

                    Debug.Log("Type: " + Type);
                    Debug.Log("Level: " + Level);
                    Debug.Log("Defense: " + Defense);
                    Debug.Log("Sprite: " + Sprite);

                    CloneArmor.GetComponent<Animator>().enabled = false;
                    CloneArmor.GetComponent<Collider>().enabled = false;
                    break;
                case "ArmorPriest":
                    break;
                case "ArmorShield":
                    CloneArmor = collider.gameObject;
                    Destroy(collider.gameObject);
                    Level = CloneArmor.GetComponent<ShieldController>().ReferenceShield.GetLevel();
                    Type = CloneArmor.GetComponent<ShieldController>().ReferenceShield.GetType();
                    Defense = CloneArmor.GetComponent<ShieldController>().ReferenceShield.GetDefense();
                    Sprite = CloneArmor.GetComponent<ShieldController>().ReferenceShield.GetSprite().name;

                    Debug.Log("Type: " + Type);
                    Debug.Log("Level: " + Level);
                    Debug.Log("Defense: " + Defense);
                    Debug.Log("Sprite: " + Sprite);

                    CloneArmor.GetComponent<Animator>().enabled = false;
                    CloneArmor.GetComponent<Collider>().enabled = false;
                    break;
                default:
                    break;
            }
            Instantiate(CloneArmor, new Vector3(this.transform.position.x, this.transform.position.y - 1.8f, this.transform.position.z), Quaternion.identity, transform);

        }
        if (collider.tag.StartsWith("Weapon"))
        {


            collider.gameObject.GetComponent<Animator>().enabled = false;
            collider.gameObject.GetComponent<Collider>().enabled = false;
            CloneObject = collider.gameObject;
            Destroy(collider.gameObject);
            Resources.UnloadUnusedAssets();

            switch (collider.tag)
            {
                case "WeaponHammer":
                    if (WeaponName != null)
                    {

                    }
                    Level = CloneObject.GetComponent<HammerController>().ReferenceWeapon.GetLevel();
                    Type = CloneObject.GetComponent<HammerController>().ReferenceWeapon.GetType();
                    CriticalDamage = CloneObject.GetComponent<HammerController>().ReferenceWeapon.GetCriticalDamage();
                    CriticalPercentange = CloneObject.GetComponent<HammerController>().ReferenceWeapon.GetCriticalPercentage();
                    Sprite = CloneObject.GetComponent<HammerController>().ReferenceWeapon.GetSprite().name;


                    Debug.Log("Type: " + Type);
                    Debug.Log("Level: " + Level);
                    Debug.Log("CriticalDamage: " + CriticalDamage);
                    Debug.Log("CriticalPercentage: " + CriticalPercentange);
                    Debug.Log("Sprite: " + Sprite);
                    break;
                case "WeaponBow":
                    Level = CloneObject.GetComponent<BowController>().ReferenceWeapon.GetLevel();
                    Type = CloneObject.GetComponent<BowController>().ReferenceWeapon.GetType();
                    CriticalDamage = CloneObject.GetComponent<BowController>().ReferenceWeapon.GetCriticalDamage();
                    CriticalPercentange = CloneObject.GetComponent<BowController>().ReferenceWeapon.GetCriticalPercentage();
                    Sprite = CloneObject.GetComponent<BowController>().ReferenceWeapon.GetSprite().name;
                    Debug.Log("BowType: " + Type);
                    Debug.Log("BowLevel: " + Level);
                    Debug.Log("BowCriticalDamage: " + CriticalDamage);
                    Debug.Log("BowCriticalPercentage: " + CriticalPercentange);
                    Debug.Log("BowSprite: " + Sprite);
                    break;
                case "WeaponSword":
                    Level = CloneObject.GetComponent<SwordController>().ReferenceWeapon.GetLevel();
                    Type = CloneObject.GetComponent<SwordController>().ReferenceWeapon.GetType();
                    CriticalDamage = CloneObject.GetComponent<SwordController>().ReferenceWeapon.GetCriticalDamage();
                    CriticalPercentange = CloneObject.GetComponent<SwordController>().ReferenceWeapon.GetCriticalPercentage();
                    Sprite = CloneObject.GetComponent<SwordController>().ReferenceWeapon.GetSprite().name;
                    Debug.Log("SwordType: " + Type);
                    Debug.Log("SwordLevel: " + Level);
                    Debug.Log("SwordCriticalDamage: " + CriticalDamage);
                    Debug.Log("SwordCriticalPercentage: " + CriticalPercentange);
                    Debug.Log("SwordSprite: " + Sprite);
                    break;
                default:
                    break;
            }
            //Instantiate(CloneObject, new Vector3(Hand.transform.position.x - 0.04f, Hand.transform.position.y + 0.05f, Hand.transform.position.z + 0.65f), HandRotation, Hand.transform);

        }
        if (collider.tag.StartsWith("PowerUp"))
        {
            collider.gameObject.GetComponent<Animator>().enabled = false;
            collider.gameObject.GetComponent<Collider>().enabled = false;
            switch (collider.tag)
            {
                case "PowerUpAttack":
                    Level = collider.gameObject.GetComponent<PUAttackController>().ReferencePowerup.GetLevel();
                    Type = collider.gameObject.GetComponent<PUAttackController>().ReferencePowerup.GetType();
                    Damage = collider.gameObject.GetComponent<PUAttackController>().ReferencePowerup.GetBonusAttack();
                    Sprite = collider.gameObject.GetComponent<PUAttackController>().ReferencePowerup.GetSprite().name;

                    Debug.Log("BonusAttack:" + Damage);
                    Debug.Log("Type: " + Type);
                    Debug.Log("Level: " + Level);
                    Debug.Log("Sprite: " + Sprite);
                    break;
                case "PowerUpCross":
                    Level = collider.gameObject.GetComponent<PUCrossController>().ReferencePowerup.GetLevel();
                    Type = collider.gameObject.GetComponent<PUCrossController>().ReferencePowerup.GetType();
                    Damage = collider.gameObject.GetComponent<PUCrossController>().ReferencePowerup.GetBonusCross();
                    Sprite = collider.gameObject.GetComponent<PUCrossController>().ReferencePowerup.GetSprite().name;

                    Debug.Log("BonusCross:" + Damage);
                    Debug.Log("Type: " + Type);
                    Debug.Log("Level: " + Level);
                    Debug.Log("Sprite: " + Sprite);
                    break;
                case "PowerUpHeart":
                    Level = collider.gameObject.GetComponent<PUHpController>().ReferencePowerup.GetLevel();
                    Type = collider.gameObject.GetComponent<PUHpController>().ReferencePowerup.GetType();
                    Damage = collider.gameObject.GetComponent<PUHpController>().ReferencePowerup.GetBonusHeart();
                    Sprite = collider.gameObject.GetComponent<PUHpController>().ReferencePowerup.GetSprite().name;

                    Debug.Log("BonusHp:" + Damage);
                    Debug.Log("Type: " + Type);
                    Debug.Log("Level: " + Level);
                    Debug.Log("Sprite: " + Sprite);
                    break;
                case "PowerUpLuckClover":
                    Level = collider.gameObject.GetComponent<PULockcloverController>().ReferencePowerup.GetLevel();
                    Type = collider.gameObject.GetComponent<PULockcloverController>().ReferencePowerup.GetType();
                    Damage = collider.gameObject.GetComponent<PULockcloverController>().ReferencePowerup.GetBonusLuckclover();
                    Sprite = collider.gameObject.GetComponent<PULockcloverController>().ReferencePowerup.GetSprite().name;

                    Debug.Log("BonusLuckClover:" + Damage);
                    Debug.Log("Type: " + Type);
                    Debug.Log("Level: " + Level);
                    Debug.Log("Sprite: " + Sprite);
                    break;
                default:
                    break;
            }
            Destroy(collider.gameObject);
        }
        if (collider.tag.StartsWith("Potion"))
        {

        }
        if (collider.tag.StartsWith("Enemy"))
        {
            if (collider.tag == "EnemyWeapon")
            {
                SetCurrentHealth(collider.gameObject.GetComponent<GoblinWeaponFeatures>().Damage - this.Defense);
                this.GetComponent<SetupLocalPlayer>().HealthBar.GetComponent<MaterialHealhBar>().Value = Health / 2000;
                Debug.Log(collider.gameObject.GetComponent<GoblinWeaponFeatures>().Damage - this.Defense);
            }

        }

    }


}
