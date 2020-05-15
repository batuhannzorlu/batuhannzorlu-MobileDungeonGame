using Assets.Scripts.Classes.ITEM.ARMOR;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Mirror;
using UnityEngine.EventSystems;
using System;
using UIHealthAlchemy;
using UnityEngine.UI;

public class PlayerController : NetworkBehaviour
{
    public GameObject _Inventory;
    public GameObject _Inventory_Prefab;
    public GameObject[] CloneSlots;

    public GameObject HealthBar;
    public GameObject HealthBar_Prefab;

    public GameObject OtherClientsHealthBar;
    public GameObject OtherClientsHealthBar_Prefab;

    public VirtualJoystick moveJoystick_Prefab;
    public VirtualJoystick moveJoystick;

    Button Attack_1;
    Button Attack_2;
    public Button Attack_1Prefab;
    public Button Attack_2Prefab;


    public string Type;
    public float Defense;
    public Vector3 Location;
    public string Nick = "Batuhan";
    public float Health;
    public float MovementSpeed;
    public float AttackSpeed;
    public float Damage;
    public float speed = 6.0f;
    public int Level;
    public string Sprite;
    public float CriticalDamage;
    public float CriticalPercentage;
    public float FireDamage;
    public float FirePercentage;
    public string Name;
    public string WeaponName = null;

    bool Attack_1b = false;
    bool Attack_2b = false;
    float Attack_1Speed = 0.1f;
    float Attack_2Speed = 0.1f;
    Vector3 dir;
    Vector3 idleRotation;

    public bool IsWeaponChanged = false;
    private void Awake()
    {
        this.GetComponent<SetupLocalPlayer>().IsPlayerSetup = false;
    }
    private void Start()
    {

        dir = Vector3.zero;
        if (isLocalPlayer)
            SetupSwordBerserkerUI();
    }
    private void FixedUpdate()
    {
        if (this.GetComponent<SetupLocalPlayer>().IsPlayerSetup && this.transform.GetChild(1) != null)
        {
            if (dir.magnitude > 1)
                dir.Normalize();

            dir = this.moveJoystick.InputDirection;
            Vector3 rotateDir = Camera.main.transform.TransformDirection(dir);

            if (Mathf.Abs(dir.x) + Mathf.Abs(dir.z) >= 0.1)
            {
                this.GetComponent<SetupLocalPlayer>().CmdChangeAnimState("none", "run");
                rotateDir = new Vector3(rotateDir.x, 0, rotateDir.z);
                rotateDir = rotateDir.normalized * dir.magnitude;
                transform.rotation = Quaternion.LookRotation(rotateDir);
            }
            else
                this.GetComponent<SetupLocalPlayer>().CmdChangeAnimState("none", "idle");
            this.GetComponent<Rigidbody>().velocity = rotateDir * 10;
        }
        if (this.GetComponentInChildren<SwordController>() != null && this.GetComponentInChildren<SwordController>().IsHitEnemy == true && hasAuthority)
        {
            this.GetComponentInChildren<SwordController>().IsHitEnemy = false;
            this.GetComponent<SetupLocalPlayer>().CmdCriticalPercentage();
            this.GetComponent<SetupLocalPlayer>().CmdFirePercentage();
        }
    }
    public void OnSwordHammerAttack_1BtnDown()
    {
        if (!Attack_1b && isClient)
        {
            this.GetComponent<SetupLocalPlayer>().CmdChangeAnimState("none", "attack_1");
            Attack_1b = true;
            StartCoroutine(Attack_1Density());
        }
    }
    public void OnSwordHammerAttack_2BtnDown()
    {
        if (!Attack_2b && isClient)
        {
            this.GetComponent<SetupLocalPlayer>().CmdChangeAnimState("none", "attack_2");
            Attack_2b = true;
            StartCoroutine(Attack_2Density());
        }

    }
    IEnumerator Attack_1Density()
    {
        yield return new WaitForSeconds(Attack_1Speed);
        Attack_1b = false;
    }
    IEnumerator Attack_2Density()
    {
        yield return new WaitForSeconds(Attack_2Speed);
        Attack_2b = false;
    }

    void SetupHammerBerserkerUI()
    {
        GameObject canvas = GameObject.FindWithTag("MainCanvas");
        Attack_1 = Instantiate(Attack_1Prefab, Vector3.zero, Quaternion.identity) as Button;
        Attack_1.transform.SetParent(canvas.transform);
        Attack_1.transform.localScale = new Vector3(1, 1, 1);
        Attack_1.onClick.RemoveAllListeners();
        Attack_1.onClick.AddListener(delegate { this.gameObject.GetComponent<PlayerController>().OnSwordHammerAttack_1BtnDown(); });
        Attack_1.GetComponent<RectTransform>().anchoredPosition = new Vector2(600, 0);
        //Attack_1.image = (Image)(Resources.Load("GameAssetInScene/UI/UIAttackSprites/IIMW 7"));

        Attack_2 = Instantiate(Attack_2Prefab, Vector3.zero, Quaternion.identity) as Button;
        Attack_2.transform.SetParent(canvas.transform);
        Attack_2.transform.localScale = new Vector3(1, 1, 1);
        Attack_2.onClick.RemoveAllListeners();
        Attack_2.onClick.AddListener(delegate { this.gameObject.GetComponent<PlayerController>().OnSwordHammerAttack_2BtnDown(); });
        Attack_2.GetComponent<RectTransform>().anchoredPosition = new Vector2(200, 0);
        //Attack_2.GetComponent<Image>().sprite = (Sprite)(Resources.Load("GameAssetInScene/UI/UIAttackSprites/IIMW 12.png"));

        SetupPlayerJoyStick();
    }
    void SetupCrossBowUI()
    {
        GameObject canvas = GameObject.FindWithTag("MainCanvas");
        Attack_1 = Instantiate(Attack_1Prefab, Vector3.zero, Quaternion.identity) as Button;
        Attack_1.transform.SetParent(canvas.transform);
        Attack_1.transform.localScale = new Vector3(1, 1, 1);
        Attack_1.onClick.RemoveAllListeners();
        //  Attack_1.onClick.AddListener(delegate { this.gameObject.GetComponent<PlayerController>().OnSwordHammerAttackBtnDown(); });
        Attack_1.GetComponent<RectTransform>().anchoredPosition = new Vector2(600, 0);
        //Attack_1.image = (Image)(Resources.Load("GameAssetInScene/UI/UIAttackSprites/IIMW 15"));
    }
    void SetupSwordBerserkerUI()
    {
        GameObject canvas = GameObject.FindWithTag("MainCanvas");

        Attack_2 = Instantiate(Attack_2Prefab, Vector3.zero, Quaternion.identity) as Button;
        Attack_2.transform.SetParent(canvas.transform);
        Attack_2.transform.localScale = new Vector3(1, 1, 1);
        Attack_2.onClick.RemoveAllListeners();
        Attack_2.onClick.AddListener(delegate { this.gameObject.GetComponent<PlayerController>().OnSwordHammerAttack_2BtnDown(); });
        Attack_2.GetComponent<RectTransform>().anchoredPosition = new Vector2(700, -250);
        //Attack_2.GetComponent<SpriteRenderer>().sprite = Resources.Load("GameAssetInScene/UI/UIAttackSprites/IIMW 1", typeof(Sprite)) as Sprite;

        Attack_1 = Instantiate(Attack_1Prefab, Vector3.zero, Quaternion.identity) as Button;
        Attack_1.transform.SetParent(canvas.transform);
        Attack_1.transform.localScale = new Vector3(1, 1, 1);
        Attack_1.onClick.RemoveAllListeners();
        Attack_1.onClick.AddListener(delegate { this.gameObject.GetComponent<PlayerController>().OnSwordHammerAttack_1BtnDown(); });
        Attack_1.GetComponent<RectTransform>().anchoredPosition = new Vector2(500, -250);
        //Attack_1.GetComponent<Image>() = (Resources.Load("GameAssetInScene/ItemSprite/Bows/001 YAY"))as Image;

        HealthBar = Instantiate(HealthBar_Prefab, Vector3.zero, Quaternion.identity) as GameObject;
        HealthBar.transform.SetParent(canvas.transform);
        HealthBar.transform.localScale = new Vector3(0.25F, 0.25F, 0.25F);
        HealthBar.GetComponent<RectTransform>().anchoredPosition = new Vector2(100, 0);
        //CmdSetupLocalHealth();
        SetupPlayerJoyStick();
        SetupInventory();
    }
    void SetupPlayerJoyStick()
    {

        GameObject canvas = GameObject.FindWithTag("MainCanvas");
        moveJoystick = Instantiate(moveJoystick_Prefab, Vector3.zero, Quaternion.identity) as VirtualJoystick;
        moveJoystick.transform.SetParent(canvas.transform);
        moveJoystick.transform.localScale = new Vector3(1, 1, 1);
        moveJoystick.GetComponent<RectTransform>().anchoredPosition = new Vector2(100, 100);

    }
    void SetupInventory()
    {
        GameObject Panel = GameObject.FindWithTag("Inventory");
        for (int i = 0; i < 6; i++)
        {
            CloneSlots[i] = Instantiate(this.gameObject.GetComponent<Inventory>().Slots[0], Vector3.zero, Quaternion.identity, Panel.transform);
            CloneSlots[i].GetComponent<SlotInventoryButton>().i = i;
            this.gameObject.GetComponent<Inventory>().Slots[i] = CloneSlots[i];
            CloneSlots[i].GetComponent<SlotInventoryButton>().PlayerTag = this.tag;
        }
    }


    [Command]
    void CmdSetupLocalHealth()
    {
        GameObject canvas = GameObject.FindWithTag("MainCanvas");
        HealthBar = Instantiate(HealthBar_Prefab, Vector3.zero, Quaternion.identity) as GameObject;
        HealthBar.transform.SetParent(canvas.transform);
        HealthBar.transform.localScale = new Vector3(0.25F, 0.25F, 0.25F);
        HealthBar.GetComponent<RectTransform>().anchoredPosition = new Vector2(100, -90);

        RpcSetupOtherConnectedClientsLocalHealth();
    }
    [ClientRpc]
    void RpcSetupOtherConnectedClientsLocalHealth()
    {
        if (!isServer)
        {
            GameObject canvas = GameObject.FindWithTag("MainCanvas");
            OtherClientsHealthBar = Instantiate(OtherClientsHealthBar_Prefab, Vector3.zero, Quaternion.identity) as GameObject;
            HealthBar.transform.SetParent(canvas.transform);
            HealthBar.transform.localScale = new Vector3(0.15F, 0.15F, 0.15F);
            HealthBar.GetComponent<RectTransform>().anchoredPosition = new Vector2(100, 100);
        }

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
        if (collider.gameObject.tag.StartsWith("Player"))
        {
            Physics.IgnoreCollision(collider, this.GetComponent<CapsuleCollider>());
        }
        if (collider.tag.StartsWith("PowerUp"))
        {
            collider.gameObject.GetComponent<Animator>().enabled = false;
            collider.gameObject.GetComponent<Collider>().enabled = false;
            switch (collider.tag)
            {
                case "PowerUpAttack":
                    Damage = collider.gameObject.GetComponent<PUAttackController>().ReferencePowerup.GetBonusAttack();
                    Sprite = collider.gameObject.GetComponent<PUAttackController>().ReferencePowerup.GetSprite().name;

                    break;
                case "PowerUpCross":
                    Damage = collider.gameObject.GetComponent<PUCrossController>().ReferencePowerup.GetBonusCross();
                    Sprite = collider.gameObject.GetComponent<PUCrossController>().ReferencePowerup.GetSprite().name;

                    break;
                case "PowerUpHeart":
                    Damage = collider.gameObject.GetComponent<PUHpController>().ReferencePowerup.GetBonusHeart();
                    Sprite = collider.gameObject.GetComponent<PUHpController>().ReferencePowerup.GetSprite().name;

                    break;
                case "PowerUpLuckClover":
                    Damage = collider.gameObject.GetComponent<PULockcloverController>().ReferencePowerup.GetBonusLuckclover();
                    Sprite = collider.gameObject.GetComponent<PULockcloverController>().ReferencePowerup.GetSprite().name;

                    break;
                default:
                    break;
            }
            Destroy(collider.gameObject);
        }

        if (collider.tag.StartsWith("Enemy"))
        {
            if (collider.tag == "EnemyWeapon")
            {
                SetCurrentHealth(collider.gameObject.GetComponent<GoblinWeaponFeatures>().Damage - this.Defense);
                this.HealthBar.GetComponent<MaterialHealhBar>().Value = Health / 2000;
            }

        }

    }

    [Command]
    public void CmdChangeWeaponState(string none, string weaponState)
    {
        UpdateCurrentWeapon(weaponState);
        if (isLocalPlayer) return;
        RpcChangeWeaponState("none", weaponState);
    }
    [ClientRpc]
    public void RpcChangeWeaponState(string none, string weaponState)
    {
        if (!isServer)
            UpdateCurrentWeapon(weaponState);
    }
    void UpdateCurrentWeapon(string weaponState)
    {
        GameObject Weapon;
        GameObject CloneWeapon;
        Weapon = this.GetComponent<SetupLocalPlayer>().WeaponHand.transform.GetChild(0).gameObject;
        switch (weaponState)
        {
            case "weapon_sword_1 Variant":
                Destroy(Weapon);
                CloneWeapon = Instantiate(Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/weapon_sword_1 Variant"), this.GetComponent<SetupLocalPlayer>().WeaponHand.transform.position,
                    this.GetComponent<SetupLocalPlayer>().WeaponHand.transform.rotation, this.GetComponent<SetupLocalPlayer>().WeaponHand.transform);
                CloneWeapon.name = Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/weapon_sword_1 Variant").name;
                break;
            case "weapon_sword_2 Variant":
                CloneWeapon = Instantiate(Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/weapon_sword_2 Variant"), this.GetComponent<SetupLocalPlayer>().WeaponHand.transform.position,
                    this.GetComponent<SetupLocalPlayer>().WeaponHand.transform.rotation, this.GetComponent<SetupLocalPlayer>().WeaponHand.transform);
                CloneWeapon.name = Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/weapon_sword_2 Variant").name;
                Destroy(Weapon);
                break;
            case "weapon_sword_3 Variant":
                CloneWeapon = Instantiate(Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/weapon_sword_3 Variant"), this.GetComponent<SetupLocalPlayer>().WeaponHand.transform.position,
                    this.GetComponent<SetupLocalPlayer>().WeaponHand.transform.rotation, this.GetComponent<SetupLocalPlayer>().WeaponHand.transform);
                CloneWeapon.name = Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/weapon_sword_3 Variant").name;
                Destroy(Weapon);
                break;
            case "weapon_sword_4 Variant":
                CloneWeapon = Instantiate(Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/weapon_sword_4 Variant"), this.GetComponent<SetupLocalPlayer>().WeaponHand.transform.position,
                    this.GetComponent<SetupLocalPlayer>().WeaponHand.transform.rotation, this.GetComponent<SetupLocalPlayer>().WeaponHand.transform);
                CloneWeapon.name = Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/weapon_sword_4 Variant").name;
                Destroy(Weapon);
                break;
            case "weapon_sword_5 Variant":
                CloneWeapon = Instantiate(Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/weapon_sword_5 Variant"), this.GetComponent<SetupLocalPlayer>().WeaponHand.transform.position,
                    this.GetComponent<SetupLocalPlayer>().WeaponHand.transform.rotation, this.GetComponent<SetupLocalPlayer>().WeaponHand.transform);
                CloneWeapon.name = Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/weapon_sword_5 Variant").name;
                Destroy(Weapon);
                break;
            case "weapon_sword_6 Variant":
                CloneWeapon = Instantiate(Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/weapon_sword_6 Variant"), this.GetComponent<SetupLocalPlayer>().WeaponHand.transform.position,
                    this.GetComponent<SetupLocalPlayer>().WeaponHand.transform.rotation, this.GetComponent<SetupLocalPlayer>().WeaponHand.transform);
                CloneWeapon.name = Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/weapon_sword_6 Variant").name;
                Destroy(Weapon);
                break;
            case "weapon_sword_7 Variant":
                CloneWeapon = Instantiate(Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/weapon_sword_7 Variant"), this.GetComponent<SetupLocalPlayer>().WeaponHand.transform.position,
                    this.GetComponent<SetupLocalPlayer>().WeaponHand.transform.rotation, this.GetComponent<SetupLocalPlayer>().WeaponHand.transform);
                CloneWeapon.name = Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/weapon_sword_7 Variant").name;
                Destroy(Weapon);
                break;
            case "weapon_sword_8 Variant":
                CloneWeapon = Instantiate(Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/weapon_sword_8 Variant"), this.GetComponent<SetupLocalPlayer>().WeaponHand.transform.position,
                    this.GetComponent<SetupLocalPlayer>().WeaponHand.transform.rotation, this.GetComponent<SetupLocalPlayer>().WeaponHand.transform);
                CloneWeapon.name = Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/weapon_sword_8 Variant").name;
                Destroy(Weapon);
                break;
            case "weapon_sword_9 Variant":
                CloneWeapon = Instantiate(Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/weapon_sword_9 Variant"), this.GetComponent<SetupLocalPlayer>().WeaponHand.transform.position,
                    this.GetComponent<SetupLocalPlayer>().WeaponHand.transform.rotation, this.GetComponent<SetupLocalPlayer>().WeaponHand.transform);
                CloneWeapon.name = Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/weapon_sword_9 Variant").name;
                Destroy(Weapon);
                break;
            case "weapon_sword_10 Variant":
                CloneWeapon = Instantiate(Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/weapon_sword_10 Variant"), this.GetComponent<SetupLocalPlayer>().WeaponHand.transform.position,
                    this.GetComponent<SetupLocalPlayer>().WeaponHand.transform.rotation, this.GetComponent<SetupLocalPlayer>().WeaponHand.transform);
                CloneWeapon.name = Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/weapon_sword_10 Variant").name;
                Destroy(Weapon);
                break;
            case "weapon_sword_gold_1 Variant":
                CloneWeapon = Instantiate(Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/weapon_sword_gold_1 Variant"), this.GetComponent<SetupLocalPlayer>().WeaponHand.transform.position,
                    this.GetComponent<SetupLocalPlayer>().WeaponHand.transform.rotation, this.GetComponent<SetupLocalPlayer>().WeaponHand.transform);
                CloneWeapon.name = Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/weapon_sword_gold_1 Variant").name;
                Destroy(Weapon);
                break;
            case "weapon_sword_gold_2 Variant":
                CloneWeapon = Instantiate(Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/weapon_sword_gold_2 Variant"), this.GetComponent<SetupLocalPlayer>().WeaponHand.transform.position,
                    this.GetComponent<SetupLocalPlayer>().WeaponHand.transform.rotation, this.GetComponent<SetupLocalPlayer>().WeaponHand.transform);
                CloneWeapon.name = Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/weapon_sword_gold_2 Variant").name;
                Destroy(Weapon);
                break;
            case "weapon_sword_gold_3 Variant":
                CloneWeapon = Instantiate(Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/weapon_sword_gold_3 Variant"), this.GetComponent<SetupLocalPlayer>().WeaponHand.transform.position,
                    this.GetComponent<SetupLocalPlayer>().WeaponHand.transform.rotation, this.GetComponent<SetupLocalPlayer>().WeaponHand.transform);
                CloneWeapon.name = Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/weapon_sword_gold_3 Variant").name;
                Destroy(Weapon);
                break;
            case "weapon_sword_gold_4 Variant":
                CloneWeapon = Instantiate(Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/weapon_sword_gold_4 Variant"), this.GetComponent<SetupLocalPlayer>().WeaponHand.transform.position,
                    this.GetComponent<SetupLocalPlayer>().WeaponHand.transform.rotation, this.GetComponent<SetupLocalPlayer>().WeaponHand.transform);
                CloneWeapon.name = Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/weapon_sword_gold_4 Variant").name;
                Destroy(Weapon);
                break;
            case "weapon_sword_gold_5 Variant":
                CloneWeapon = Instantiate(Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/weapon_sword_gold_5 Variant"), this.GetComponent<SetupLocalPlayer>().WeaponHand.transform.position,
                    this.GetComponent<SetupLocalPlayer>().WeaponHand.transform.rotation, this.GetComponent<SetupLocalPlayer>().WeaponHand.transform);
                CloneWeapon.name = Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/weapon_sword_gold_5 Variant").name;
                Destroy(Weapon);
                break;
            default:
                break;
        }
    }





  


}
