using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using Mirror.Discovery;
using Assets.Scripts.Classes.ITEM.ARMOR;
using Assets.Scripts.Classes.ITEM.WEAPON;

public class SetupLocalPlayer : NetworkBehaviour
{
    public GameObject WeaponSpawnFBerserker;

    public bool IsPlayerSetup = false;

    public VirtualJoystick moveJoystick_Prefab;
    public VirtualJoystick moveJoystick;

    Button Attack_1;
    Button Attack_2;
    public Button Attack_1Prefab;
    public Button Attack_2Prefab;

    public GameObject HealthBar;
    public GameObject HealthBar_Prefab;

    public Text TextPrefab;
    public Text text;
    public Transform textPos;


    public string ChoosenClass;

    public static Transform player;
    public static GameObject PlayerArmor;
    public static GameObject PlayerWeapon;
    public static GameObject PlayerShield;
    string Nick = "Batuhan";


    public GameObject WeaponHand;
    GameObject ShieldHand;

    Quaternion HammerRotation;
    Quaternion SwordRotation;
    Quaternion ShieldRotation;

    private string Name;
    GameObject CloneArmor;
    GameObject CloneWeapon;
    GameObject CloneShield;

    public Animator PlayerAnimator;
    NetworkAnimator PlayerNAnim;

    public override void OnStartClient()
    {
        GameManager.singleton.ClientCount++;
        if (!GameManager.Players.Contains((GameObject.FindGameObjectWithTag("Player" + GameManager.singleton.ClientCount.ToString()))))
        {
            this.gameObject.tag = "Player" + GameManager.singleton.ClientCount.ToString();
            Debug.Log("TAG DONE!");
            GameManager.Players.Add(GameObject.FindGameObjectWithTag("Player" + GameManager.singleton.ClientCount.ToString()));
        }
        Debug.Log("GAMEMANAGER PLAYERS: " + GameManager.Players[0]);
        Debug.Log("PLAYER LİST COUNT: " + GameManager.Players.Count);

        NetworkDiscoveryHUD _NetworkDiscoveryHUD = GameObject.Find("NetworkManager").GetComponent<NetworkDiscoveryHUD>();
        ChoosenClass = _NetworkDiscoveryHUD.CharacaterClass;
        _NetworkDiscoveryHUD.textSword.enabled = false;
        _NetworkDiscoveryHUD.textHammer.enabled = false;
        _NetworkDiscoveryHUD.textCrossBow.enabled = false;
        _NetworkDiscoveryHUD.audiosource.enabled = false;
        foreach (var Sample in _NetworkDiscoveryHUD.CharacterSelectionSamples)
            Sample.SetActive(false);

        switch (ChoosenClass)
        {
            case "HammerBerserker":
                SetupDefaultHammerBerserker();
                PlayerAnimator = transform.GetChild(1).gameObject.GetComponent<Animator>();
                IsPlayerSetup = true;
                break;
            case "SwordBerserker":
                SetupDefaultSwordBerserker();
                PlayerAnimator = transform.GetChild(1).gameObject.GetComponent<Animator>();
                IsPlayerSetup = true;
                break;
            case "CrossBow":
                SetupDefaultCrossBow();
                PlayerAnimator = transform.GetChild(1).gameObject.GetComponent<Animator>();
                IsPlayerSetup = true;
                break;
            case "Rogue":
                SetupDefaultRogue();
                break;
        }

        base.OnStartClient();
    }
    void Start()
    {
        if (isLocalPlayer)
        {
            this.GetComponent<PlayerController>().enabled = true;
            player = this.transform;
        }
        else
        {
            this.GetComponent<PlayerController>().enabled = false;
        }

        GameObject canvas = GameObject.FindWithTag("MainCanvas");
        text = Instantiate(TextPrefab, Vector3.zero, Quaternion.identity) as Text;
        text.transform.SetParent(canvas.transform);
        text.transform.localScale = new Vector3(1, 1, 1);
        text.text = this.gameObject.tag;
    }
    void Update()
    {
        Vector3 _TextPos = Camera.main.WorldToScreenPoint(textPos.position);
        text.transform.position = _TextPos;
    }

    void SetupDefaultHammerBerserker()
    {
        Berserker berserker;
        string Key = "Hammer";
        berserker = new Berserker(Nick, Key);
        PlayerArmor = berserker.GetArmor();
        Name = PlayerArmor.gameObject.name + "(Clone)";
        PlayerArmor.transform.localScale = new Vector3(1, 1, 1);
        Instantiate(PlayerArmor, this.transform.position, Quaternion.identity, this.transform);

        PlayerWeapon = berserker.GetWeapon();
        PlayerWeapon.GetComponent<Collider>().enabled = false;


        WeaponHand = transform.Find(Name).Find("biped:mr:skeleton").Find("biped:mr:root_jnt").Find("biped:mr:spine_01_jnt").
                Find("biped:mr:spine_02_jnt").Find("biped:mr:R_Arm_Clavicle_jnt").Find("biped:mr:R_Arm_Shoulder_jnt").Find("biped:mr:R_elbow_jnt").
                Find("biped:mr:R_wrist_jnt").Find("biped:mr:R_WeaponAttachMent_jnt").gameObject;
        CloneWeapon = Instantiate(PlayerWeapon, new Vector3(WeaponHand.transform.position.x, WeaponHand.transform.position.y, WeaponHand.transform.position.z), WeaponHand.transform.rotation, WeaponHand.transform);
        CloneWeapon.name = PlayerWeapon.name;
        CloneWeapon.transform.position = new Vector3(1f, 1.5f, 1.2f);
        CloneWeapon.transform.Rotate(-3, 100, 58);

        PlayerShield = berserker.GetShield();

        ShieldHand = transform.Find(Name).Find("biped:mr:skeleton").Find("biped:mr:root_jnt").Find("biped:mr:spine_01_jnt").
                Find("biped:mr:spine_02_jnt").Find("biped:mr:L_Arm_Clavicle_jnt").Find("biped:mr:L_Arm_Shoulder_jnt").Find("biped:mr:L_elbow_jnt").
                Find("biped:mr:L_wrist_jnt").Find("biped:mr:L_Shield_AttachMent_jnt").gameObject;
        CloneShield = Instantiate(PlayerShield, new Vector3(ShieldHand.transform.position.x, ShieldHand.transform.position.y, ShieldHand.transform.position.z), ShieldHand.transform.rotation, ShieldHand.transform);
        CloneShield.name = PlayerShield.name;

        this.GetComponent<PlayerController>().Defense = berserker.GetDefense();
        this.GetComponent<PlayerController>().Damage = berserker.GetAttackDamage();
        this.GetComponent<PlayerController>().Health = berserker.GetHealth();
        this.GetComponent<PlayerController>().MovementSpeed = berserker.GetMovementSpeed();
        this.GetComponent<PlayerController>().AttackSpeed = berserker.GetAttackSpeed();

    }
    void SetupDefaultSwordBerserker()
    {
        Berserker berserker;
        string Key = "Sword";
        berserker = new Berserker("Batuhan", Key);
        PlayerArmor = berserker.GetArmor();

        PlayerArmor.transform.localScale = new Vector3(1, 1, 1);
        GameObject CloneArmor = Instantiate(PlayerArmor, this.transform.position, Quaternion.identity, this.transform);
        CloneArmor.name = PlayerArmor.name;
        PlayerWeapon = berserker.GetWeapon();
        PlayerWeapon.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        WeaponHand = transform.Find(CloneArmor.name).Find("biped:mr:skeleton").Find("biped:mr:root_jnt").Find("biped:mr:spine_01_jnt").
                Find("biped:mr:spine_02_jnt").Find("biped:mr:R_Arm_Clavicle_jnt").Find("biped:mr:R_Arm_Shoulder_jnt").Find("biped:mr:R_elbow_jnt").
                Find("biped:mr:R_wrist_jnt").Find("biped:mr:R_WeaponAttachMent_jnt").gameObject;
        CloneWeapon = Instantiate(PlayerWeapon, new Vector3(WeaponHand.transform.position.x, WeaponHand.transform.position.y, WeaponHand.transform.position.z), WeaponHand.transform.rotation, WeaponHand.transform);
        CloneWeapon.name = PlayerWeapon.name;

        PlayerShield = berserker.GetShield();

        ShieldHand = transform.Find(CloneArmor.name).Find("biped:mr:skeleton").Find("biped:mr:root_jnt").Find("biped:mr:spine_01_jnt").
                Find("biped:mr:spine_02_jnt").Find("biped:mr:L_Arm_Clavicle_jnt").Find("biped:mr:L_Arm_Shoulder_jnt").Find("biped:mr:L_elbow_jnt").
                Find("biped:mr:L_wrist_jnt").Find("biped:mr:L_Shield_AttachMent_jnt").gameObject;
        CloneShield = Instantiate(PlayerShield, new Vector3(ShieldHand.transform.position.x, ShieldHand.transform.position.y, ShieldHand.transform.position.z), ShieldHand.transform.rotation, ShieldHand.transform);
        CloneShield.name = PlayerShield.name;

        this.GetComponent<PlayerController>().Defense = berserker.GetDefense();
        this.GetComponent<PlayerController>().Damage = berserker.GetAttackDamage();
        this.GetComponent<PlayerController>().Health = berserker.GetHealth();
        this.GetComponent<PlayerController>().MovementSpeed = berserker.GetMovementSpeed();
        this.GetComponent<PlayerController>().AttackSpeed = berserker.GetAttackSpeed();

    }
    void SetupDefaultCrossBow()
    {

    }
    void SetupDefaultRogue()
    {

    }

    [SyncVar(hook = "OnChangeShield")]
    private string CurrentShield = "weapon_shield_1";
    void OnChangeShield(string none, string none_)
    {
        Shield shield = new Shield(Resources.Load<GameObject>("GameAssetInScene/ITEM/ARMOR/SHIELD/ONPLAYER/" + CurrentShield));
        shield.GetDefense();
    }

    [SyncVar(hook = "OnChangeSword")]
    private string CurrentSword = "weapon_sword_1 Variant";
    void OnChangeSword(string none, string none_)
    {
        Sword sword = new Sword(Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/" + CurrentSword));
        this.GetComponent<PlayerController>().CriticalDamage = sword.GetCriticalDamage();
        this.GetComponent<PlayerController>().CriticalPercentage = sword.GetCriticalPercentage(); ;
        this.GetComponent<PlayerController>().Damage = sword.GetDamage();
        this.GetComponent<PlayerController>().FireDamage = sword.GetFireAmount();
        this.GetComponent<PlayerController>().FirePercentage = sword.GetFirePercentage();
    }

    [SyncVar(hook = "OnBerserkerArmorChange")]
    private string CurrentArmor = "";
    void OnBerserkerArmorChange(string none, string none_)
    {
        ArBerserker arberserker = new ArBerserker(Resources.Load<GameObject>("GameAssetInScene/ITEM/ARMOR/BERSERKER/ONPLAYER/" + CurrentArmor));
        this.GetComponent<PlayerController>().Defense = arberserker.GetDefense();
    }

    /// <summary>
    /// WEAPONCHANGE
    /// </summary>
    /// <param name="none"></param>
    /// <param name="weaponState"></param>
    [Command]
    public void CmdChangeWeaponState(string none, string weaponState, string CalledState)
    {
        UpdateCurrentWeapon(weaponState, CalledState);
        RpcChangeWeaponState("none", weaponState, CalledState);
    }
    [ClientRpc]
    public void RpcChangeWeaponState(string none, string weaponState, string CalledState)
    {
        if (!isServer)
            UpdateCurrentWeapon(weaponState, CalledState);
    }
    void UpdateCurrentWeapon(string weaponState, string CalledState)
    {
        CurrentSword = weaponState;
        GameObject Weapon;
        GameObject CloneWeapon;
        Transform hand;
        hand = this.transform.GetChild(1).Find("biped:mr:skeleton").Find("biped:mr:root_jnt").Find("biped:mr:spine_01_jnt").
               Find("biped:mr:spine_02_jnt").Find("biped:mr:R_Arm_Clavicle_jnt").Find("biped:mr:R_Arm_Shoulder_jnt").Find("biped:mr:R_elbow_jnt").
               Find("biped:mr:R_wrist_jnt").Find("biped:mr:R_WeaponAttachMent_jnt").transform;

        switch (CalledState)
        {
            case "InUpdateArmor":
                CloneWeapon = Instantiate(Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/" + weaponState), hand.position, hand.rotation, hand);
                CloneWeapon.name = Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/" + weaponState).name;
                break;
            case "OutUpdateArmor":
                Weapon = hand.GetChild(0).gameObject;
                CloneWeapon = Instantiate(Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/" + weaponState), hand.position, hand.rotation, hand);
                CloneWeapon.name = Resources.Load<GameObject>("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/" + weaponState).name;
                Destroy(Weapon);
                break;
        }


    }


    /// <summary>
    /// SHIELDCHANGE
    /// </summary>
    /// <param name="none"></param>
    /// <param name="armorState"></param>
    [Command]
    public void CmdChangeShieldState(string none, string armorState, string CalledState)
    {
        UpdateCurrentShield(armorState, CalledState);
        RpcChangeShieldState("none", armorState, CalledState);
    }
    [ClientRpc]
    public void RpcChangeShieldState(string none, string armorState, string CalledState)
    {
        if (!isServer)
            UpdateCurrentShield(armorState, CalledState);
    }
    void UpdateCurrentShield(string armorState, string CalledState)
    {
        CurrentShield = armorState;

        GameObject CloneArmor;
        Transform hand = this.transform.GetChild(1).Find("biped:mr:skeleton").Find("biped:mr:root_jnt").Find("biped:mr:spine_01_jnt").
       Find("biped:mr:spine_02_jnt").Find("biped:mr:L_Arm_Clavicle_jnt").Find("biped:mr:L_Arm_Shoulder_jnt").Find("biped:mr:L_elbow_jnt").
       Find("biped:mr:L_wrist_jnt").Find("biped:mr:L_Shield_AttachMent_jnt").transform;

        switch (CalledState)
        {
            case "InUpdateArmor":
                CloneArmor = Instantiate(Resources.Load<GameObject>("GameAssetInScene/ITEM/ARMOR/SHIELD/ONPLAYER/" + armorState), hand.position,
                          hand.rotation, hand);
                CloneArmor.name = Resources.Load<GameObject>("GameAssetInScene/ITEM/ARMOR/SHIELD/ONPLAYER/" + armorState).name;
                break;
            case "OutUpdateArmor":
                GameObject Shield = hand.GetChild(0).transform.gameObject;
                CloneArmor = Instantiate(Resources.Load<GameObject>("GameAssetInScene/ITEM/ARMOR/SHIELD/ONPLAYER/" + armorState), hand.position,
                          hand.rotation, hand);
                CloneArmor.name = Resources.Load<GameObject>("GameAssetInScene/ITEM/ARMOR/SHIELD/ONPLAYER/" + armorState).name;
                Destroy(Shield);
                break;

        }

    }


    /// <summary>
    /// ARMORCHANGE 
    /// </summary>
    /// <param name="none"></param>
    /// <param name="armorState"></param>
    [Command]
    public void CmdChangeArmorState(string none, string armorState)
    {
        UpdateCurrentArmor(armorState);
        RpcChangeArmorState("none", armorState);

        UpdateCurrentShield(CurrentShield, "InUpdateArmor");
        RpcChangeShieldState("none", CurrentShield, "InUpdateArmor");

        UpdateCurrentWeapon(CurrentSword, "InUpdateArmor");
        RpcChangeWeaponState("none", CurrentSword, "InUpdateArmor");
    }
    [ClientRpc]
    public void RpcChangeArmorState(string none, string armorState)
    {
        if (!isServer)
            UpdateCurrentArmor(armorState);

    }
    void UpdateCurrentArmor(string armorState)
    {
        CurrentArmor = armorState;
        GameObject Armor;
        GameObject CloneArmor;
        Armor = this.transform.GetChild(1).gameObject;

        CloneArmor = Instantiate(Resources.Load<GameObject>("GameAssetInScene/ITEM/ARMOR/BERSERKER/ONPLAYER/" + armorState), Armor.transform.position, Armor.transform.rotation, this.transform) as GameObject;
        CloneArmor.name = Resources.Load<GameObject>("GameAssetInScene/ITEM/ARMOR/BERSERKER/ONPLAYER/" + armorState).name;
        GetComponent<SetupLocalPlayer>().PlayerAnimator = CloneArmor.GetComponent<Animator>();
        DestroyImmediate(Armor);
    }


    /// <summary>
    /// ANİMATİONCHANGE
    /// </summary>
    [SyncVar(hook = "OnChangeAnimation")]
    public string animState = "idle";

    void OnChangeAnimation(string none, string aS)
    {
        if (isLocalPlayer) return;
        UpdateAnimationState(aS);
    }
    [Command]
    public void CmdChangeAnimState(string none, string aS)
    {
        UpdateAnimationState(aS);
        RpcChangeAnimState("none", aS);
    }
    [ClientRpc]
    public void RpcChangeAnimState(string none, string aS)
    {
        if (!isServer)
            UpdateAnimationState(aS);
    }

    void UpdateAnimationState(string aS)
    {
        if (animState == aS) return;
        animState = aS;
        if (animState == "idle")
            PlayerAnimator.SetFloat("Speed", 0);
        if (animState == "run")
            PlayerAnimator.SetFloat("Speed", 1);
        if (animState == "attack_1")
            PlayerAnimator.SetTrigger("Attack_1");
        if (animState == "attack_2")
            PlayerAnimator.SetTrigger("Attack_2");
    }

    //ATTACK-EFFECT-BERSERKER
    [ClientRpc]
    void RpcCriticalPercentage()
    {
        if (!isServer)
            Instantiate(this.GetComponentInChildren<SwordController>().Critical, this.GetComponentInChildren<SwordController>().HitPos.position + new Vector3(0, 1, 0),
                this.GetComponentInChildren<SwordController>().HitPos.rotation);
    }

    [Command]
    public void CmdCriticalPercentage()
    {
        float _criticalpercentage = this.GetComponentInChildren<SwordController>().ReferenceWeapon.GetCriticalPercentage();
        if (Random.Range(0, 100) <= _criticalpercentage)
        {
            Instantiate(this.GetComponentInChildren<SwordController>().Critical, this.GetComponentInChildren<SwordController>().HitPos.position + new Vector3(0, 1, 0),
                this.GetComponentInChildren<SwordController>().HitPos.rotation);
            Handheld.Vibrate();
            RpcCriticalPercentage();
        }

    }

    [ClientRpc]
    void RpcFirePercentage()
    {
        if (!isServer)
            Instantiate(this.GetComponentInChildren<SwordController>().Fire, this.GetComponentInChildren<SwordController>().HitPos.position + new Vector3(0, 1, 0),
                this.GetComponentInChildren<SwordController>().HitPos.rotation);
    }

    [Command]
    public void CmdFirePercentage()
    {
        float _firepercentage = this.GetComponentInChildren<SwordController>().ReferenceWeapon.GetFirePercentage();
        if (Random.Range(0, 100) <= _firepercentage)
        {
            Instantiate(this.GetComponentInChildren<SwordController>().Fire, this.GetComponentInChildren<SwordController>().HitPos.position + new Vector3(0, 1, 0),
                this.GetComponentInChildren<SwordController>().HitPos.rotation);
            Handheld.Vibrate();
            RpcFirePercentage();
        }

    }


}
