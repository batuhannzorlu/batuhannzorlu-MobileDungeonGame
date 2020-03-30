using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class SetupLocalPlayer : NetworkBehaviour
{
    Button Attack_1;
    Button Attack_2;
    public Button Attack_1Prefab;
    public Button Attack_2Prefab;

    public Text TextPrefab;
    public Text text;
    public Transform textPos;

    public string Nick = "Batuhan";
    public string ChoosenClass;

    public static Transform player;
    public static GameObject PlayerArmor;
    public static GameObject PlayerWeapon;
    public static GameObject PlayerShield;

    GameObject WeaponHand;
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
        ChoosenClass = "SwordBerserker";
        switch (ChoosenClass)
        {
            case "HammerBerserker":
                SetupDefaultHammerBerserker();
                PlayerAnimator = transform.GetChild(1).gameObject.GetComponent<Animator>();
                SetupHammerBerserkerUI();
                break;
            case "SwordBerserker":
                SetupDefaultSwordBerserker();
                PlayerAnimator = transform.GetChild(1).gameObject.GetComponent<Animator>();
                SetupSwordBerserkerUI();
                break;
            case "CrossBow":
                SetupDefaultCrossBow();
                PlayerAnimator = transform.GetChild(1).gameObject.GetComponent<Animator>();
                SetupCrossBowUI();
                break;
            case "Rogue":
                SetupDefaultRogue();
                break;
        }
        //PlayerAnimator = transform.GetChild(1).gameObject.GetComponent<Animator>();

        //PlayerNAnim = transform.gameObject.GetComponent<NetworkAnimator>();
        //PlayerNAnim.animator = transform.GetChild(1).gameObject.GetComponent<Animator>();
        base.OnStartClient();

    }
    void Start()
    {
        if (isLocalPlayer)
        {
            this.GetComponent<PlayerController>().enabled = true;
            //this.GetComponent<PetController>().enabled = true;        
            player = this.transform;
        }
        else
        {
            this.GetComponent<PlayerController>().enabled = false;
            //this.GetComponent<PetController>().enabled = false;
        }

        GameObject canvas = GameObject.FindWithTag("MainCanvas");
        text = Instantiate(TextPrefab, Vector3.zero, Quaternion.identity) as Text;
        text.transform.SetParent(canvas.transform);
        text.transform.localScale = new Vector3(1, 1, 1);
    }
    private void Update()
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
        PlayerWeapon.transform.localScale = new Vector3(1, 1, 1);
        PlayerWeapon.GetComponent<Collider>().enabled = false;

        HammerRotation = new Quaternion();
        HammerRotation.Set(1.696f, 89.57201f, 75.843f, 1);
        WeaponHand = transform.Find(Name).Find("biped:mr:skeleton").Find("biped:mr:root_jnt").Find("biped:mr:spine_01_jnt").
                Find("biped:mr:spine_02_jnt").Find("biped:mr:R_Arm_Clavicle_jnt").Find("biped:mr:R_Arm_Shoulder_jnt").Find("biped:mr:R_elbow_jnt").
                Find("biped:mr:R_wrist_jnt").Find("biped:mr:R_WeaponAttachMent_jnt").gameObject;
        CloneWeapon = Instantiate(PlayerWeapon, new Vector3(WeaponHand.transform.position.x, WeaponHand.transform.position.y, WeaponHand.transform.position.z), HammerRotation, WeaponHand.transform);
        CloneWeapon.name = PlayerWeapon.name;

        PlayerShield = berserker.GetShield();
        PlayerShield.transform.localScale = new Vector3(2, 2, 2);

        ShieldRotation = new Quaternion();
        ShieldRotation.Set(0, 0, 0, 1);
        ShieldHand = transform.Find(Name).Find("biped:mr:skeleton").Find("biped:mr:root_jnt").Find("biped:mr:spine_01_jnt").
                Find("biped:mr:spine_02_jnt").Find("biped:mr:L_Arm_Clavicle_jnt").Find("biped:mr:L_Arm_Shoulder_jnt").Find("biped:mr:L_elbow_jnt").
                Find("biped:mr:L_wrist_jnt").Find("biped:mr:L_WeaponAttachMent_jnt").gameObject;
        CloneShield = Instantiate(PlayerShield, new Vector3(ShieldHand.transform.position.x, ShieldHand.transform.position.y + 0.05f, ShieldHand.transform.position.z + 0.65f), ShieldHand.transform.rotation, ShieldHand.transform);
        CloneShield.name = PlayerShield.name;

        float x = berserker.GetAttackDamage();
        float y = berserker.GetDefense();
        float z = berserker.GetMovementSpeed();
        float t = berserker.GetAttackSpeed();
        string l = berserker.GetNick();

        Debug.Log(" Nick: " + l);
        Debug.Log(Nick + " Damage: " + x);
        Debug.Log(Nick + " Defense: " + y);
        Debug.Log(Nick + " MovementSpeed: " + z);
        Debug.Log(Nick + " AttackSpeed: " + t);
    }
    void SetupDefaultSwordBerserker()
    {
        Berserker berserker;
        string Key = "Sword";
        berserker = new Berserker(Nick, Key);
        PlayerArmor = berserker.GetArmor();
        Name = PlayerArmor.gameObject.name + "(Clone)";
        PlayerArmor.transform.localScale = new Vector3(1, 1, 1);
        Instantiate(PlayerArmor, this.transform.position, Quaternion.identity, this.transform);

        PlayerWeapon = berserker.GetWeapon();
        PlayerWeapon.transform.localScale = new Vector3(1, 1, 1);

        SwordRotation = new Quaternion();
        SwordRotation.Set(60f, 0f, 0f, 1);
        WeaponHand = transform.Find(Name).Find("biped:mr:skeleton").Find("biped:mr:root_jnt").Find("biped:mr:spine_01_jnt").
                Find("biped:mr:spine_02_jnt").Find("biped:mr:R_Arm_Clavicle_jnt").Find("biped:mr:R_Arm_Shoulder_jnt").Find("biped:mr:R_elbow_jnt").
                Find("biped:mr:R_wrist_jnt").Find("biped:mr:R_WeaponAttachMent_jnt").gameObject;
        CloneWeapon = Instantiate(PlayerWeapon, new Vector3(WeaponHand.transform.position.x, WeaponHand.transform.position.y, WeaponHand.transform.position.z), WeaponHand.transform.rotation, WeaponHand.transform);
        CloneWeapon.name = PlayerWeapon.name;

        PlayerShield = berserker.GetShield();
        PlayerShield.transform.localScale = new Vector3(2, 2, 2);

        ShieldRotation = new Quaternion();
        ShieldRotation.Set(-60, 0, 0, 1);
        ShieldHand = transform.Find(Name).Find("biped:mr:skeleton").Find("biped:mr:root_jnt").Find("biped:mr:spine_01_jnt").
                Find("biped:mr:spine_02_jnt").Find("biped:mr:L_Arm_Clavicle_jnt").Find("biped:mr:L_Arm_Shoulder_jnt").Find("biped:mr:L_elbow_jnt").
                Find("biped:mr:L_wrist_jnt").Find("biped:mr:L_Shield_AttachMent_jnt").gameObject;
        CloneShield = Instantiate(PlayerShield, new Vector3(ShieldHand.transform.position.x, ShieldHand.transform.position.y, ShieldHand.transform.position.z), ShieldHand.transform.rotation, ShieldHand.transform);
        CloneShield.name = PlayerShield.name;

        float x = berserker.GetAttackDamage();
        float y = berserker.GetDefense();
        float z = berserker.GetMovementSpeed();
        float t = berserker.GetAttackSpeed();
        string l = berserker.GetNick();

        Debug.Log(" Nick: " + l);
        Debug.Log(Nick + " Damage: " + x);
        Debug.Log(Nick + " Defense: " + y);
        Debug.Log(Nick + " MovementSpeed: " + z);
        Debug.Log(Nick + " AttackSpeed: " + t);
    }

   
    void SetupDefaultCrossBow()
    {

    }
    void SetupDefaultRogue()
    {

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
    }
    void SetupSwordBerserkerUI()
    {
        GameObject canvas = GameObject.FindWithTag("MainCanvas");
        Attack_2 = Instantiate(Attack_2Prefab, Vector3.zero, Quaternion.identity) as Button;
        Attack_2.transform.SetParent(canvas.transform);
        Attack_2.transform.localScale = new Vector3(1, 1, 1);
        Attack_2.onClick.RemoveAllListeners();
        Attack_2.onClick.AddListener(delegate { this.gameObject.GetComponent<PlayerController>().OnSwordHammerAttack_2BtnDown(); });
        Attack_2.GetComponent<RectTransform>().anchoredPosition = new Vector2(800, -300);
        //Attack_2.GetComponent<Image>().sprite = (Sprite)(Resources.Load("GameAssetInScene/UI/UIAttackSprites/IIMW 12.png"));

        Attack_1 = Instantiate(Attack_1Prefab, Vector3.zero, Quaternion.identity) as Button;
        Attack_1.transform.SetParent(canvas.transform);
        Attack_1.transform.localScale = new Vector3(1, 1, 1);
        Attack_1.onClick.RemoveAllListeners();
        Attack_1.onClick.AddListener(delegate { this.gameObject.GetComponent<PlayerController>().OnSwordHammerAttack_1BtnDown(); });
        Attack_1.GetComponent<RectTransform>().anchoredPosition = new Vector2(600, -300);
        //Attack_1.GetComponent<Image>().sprite = (Sprite)(Resources.Load("GameAssetInScene/UI/UIAttackSprites/IIMW 1.png"));


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



}
