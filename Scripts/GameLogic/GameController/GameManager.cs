using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mirror;
using UnityEngine.AI;
using UnityEngine.UI;

public class GameManager : NetworkBehaviour
{
    public GameObject Plague_prefab;
    public GameObject PowerUpAttackPrefab;
    public GameObject PowerUpAttackEnhanchedPrefab;
    public GameObject PowerUpCrossPrefab;
    public GameObject PowerUpCrossEnchanchedPrefab;
    public GameObject PowerUpHPPrefab;
    public GameObject PowerUpHPEnhancedPrefab;
    public GameObject PowerUpLuckCloverPrefab;

    public GameObject[] RedGoblinBerserkerPrefab;
    public GameObject[] BlueGoblinBerserkerPrefab;
    public GameObject[] GreenGoblinBerserkerPrefab;

    public GameObject[] RedGoblinWarriorPrefab;
    public GameObject[] BlueGoblinWarriorrPrefab;
    public GameObject[] GreenGoblinWarriorPrefab;

    public GameObject[] RedGoblinWitchdoctorPrefab;
    public GameObject[] BlueGoblinWitchdoctorPrefab;
    public GameObject[] GreenGoblinWitchdoctorPrefab;

    public GameObject[] PowerUpSpawnLocations;
    public GameObject[] GoblinSpawnLocations;

    private GameObject TempPowerUp;
    private int CurrentPowerUp = 0;
    private int MaxPowerUp = 10;
    private float powerupspawntime = 10f;
    private float currentpowerupspawntime = 0;

    private GameObject TempGoblinRedWitchdoctor;
    private GameObject TempGoblinRedWarrior;
    private GameObject TempGoblinRedBerserker;
    private GameObject TempGoblinGreenWitchdoctor;
    private GameObject TempGoblinGreenWarrior;
    private GameObject TempGoblinGreenBerserker;
    private GameObject TempGoblinBlueWitchdoctor;
    private GameObject TempGoblinBlueWarrior;
    private GameObject TempGoblinBlueBerserker;

    private int CurrentGoblin = 0;
    private int MaxGoblin = 30;
    private float goblinspawntime = 5f;
    private float currentgoblinspawntime = 0;

    private int BlueGoblinCurrent = 0;
    private int BlueGoblinMax = 30;
    private float BlueGoblinSpawntime = 5f;
    private float BlueGoblinspawntimeCurrent = 0;

    private int GreenGoblinCurrent = 0;
    private int GreenGoblinMax = 30;
    private float GreenGoblinSpawntime = 5f;
    private float GreenGoblinspawntimeCurrent = 0;

    public static GameManager singleton;
    public static List<GameObject> Players = null;
    public int ReferencePlayer = 0;
    public int ClientCount = 0;
    int AcceptableClientCount = 0;
    float starttimer = 0;
    float serverstarter = 0;

    AudioSource audiosource;
    public AudioClip[] GameAmbianceClips;

    public Text PlayerWaitingText_Prefab;
    Text PlayerWaitingText;

    private void Awake()
    {
        singleton = this;
        Players = new List<GameObject>();
    }
    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = GameAmbianceClips[0];
        audiosource.Play();
        AcceptableClientCount = GameObject.Find("NetworkManager").GetComponent<NetworkManager>().maxConnections;

        if (isServer)
        {
            GameObject canvas = GameObject.FindWithTag("MainCanvas");
            PlayerWaitingText = Instantiate(PlayerWaitingText_Prefab, Vector3.zero, Quaternion.identity) as Text;
            PlayerWaitingText.transform.SetParent(canvas.transform);
            PlayerWaitingText.transform.localScale = new Vector3(1, 1, 1);
            PlayerWaitingText.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -50);
        }

    }

    private void Update()
    {
        if (ClientCount == AcceptableClientCount && isServer)
        {
            RedGoblinSpawnManager();
            currentpowerupspawntime += Time.deltaTime;
            currentgoblinspawntime += Time.deltaTime;
            starttimer += Time.deltaTime;
            serverstarter += Time.deltaTime;
            PlayerWaitingText.enabled = false;

        }


    }

    [ClientRpc]
    void RpcPowerUpSpawnManager(int _RandomPowerUp, int _RandomNumber)
    {
        if (!isServer)
        {
            GameObject RpcTempPowerUp;
            switch (_RandomPowerUp)
            {
                case 0:
                    RpcTempPowerUp = Instantiate(PowerUpAttackPrefab, PowerUpSpawnLocations[_RandomNumber].transform.position, PowerUpSpawnLocations[_RandomNumber].transform.rotation, null);
                    RpcTempPowerUp.name = PowerUpAttackPrefab.name;
                    break;
                case 1:
                    RpcTempPowerUp = Instantiate(PowerUpAttackEnhanchedPrefab, PowerUpSpawnLocations[_RandomNumber].transform.position, PowerUpSpawnLocations[_RandomNumber].transform.rotation, null);
                    RpcTempPowerUp.name = PowerUpAttackEnhanchedPrefab.name;
                    break;
                case 2:
                    RpcTempPowerUp = Instantiate(PowerUpCrossPrefab, PowerUpSpawnLocations[_RandomNumber].transform.position, PowerUpSpawnLocations[_RandomNumber].transform.rotation, null);
                    RpcTempPowerUp.name = PowerUpCrossPrefab.name;
                    break;
                case 3:
                    RpcTempPowerUp = Instantiate(PowerUpCrossEnchanchedPrefab, PowerUpSpawnLocations[_RandomNumber].transform.position, PowerUpSpawnLocations[_RandomNumber].transform.rotation, null);
                    RpcTempPowerUp.name = PowerUpCrossEnchanchedPrefab.name;
                    break;
                case 4:
                    RpcTempPowerUp = Instantiate(PowerUpHPPrefab, PowerUpSpawnLocations[_RandomNumber].transform.position, PowerUpSpawnLocations[_RandomNumber].transform.rotation, null);
                    RpcTempPowerUp.name = PowerUpHPPrefab.name;
                    break;
                case 5:
                    RpcTempPowerUp = Instantiate(PowerUpHPEnhancedPrefab, PowerUpSpawnLocations[_RandomNumber].transform.position, PowerUpSpawnLocations[_RandomNumber].transform.rotation, null);
                    RpcTempPowerUp.name = PowerUpHPEnhancedPrefab.name;
                    break;
                case 6:
                    RpcTempPowerUp = Instantiate(PowerUpLuckCloverPrefab, PowerUpSpawnLocations[_RandomNumber].transform.position, PowerUpSpawnLocations[_RandomNumber].transform.rotation, null);
                    RpcTempPowerUp.name = PowerUpLuckCloverPrefab.name;
                    break;

            }
        }
    }
    [Server]
    public void PowerUpSpawnManager()
    {
        if (currentpowerupspawntime > powerupspawntime)
        {
            currentpowerupspawntime = 0;
            if (CurrentPowerUp < MaxPowerUp)
            {
                CurrentPowerUp++;
                int randomNumber = Random.Range(0, PowerUpSpawnLocations.Length - 1);
                GameObject spawnlocation = PowerUpSpawnLocations[randomNumber];
                int randomPowerUp = Random.Range(0, 6);
                switch (randomPowerUp)
                {
                    case 0:
                        TempPowerUp = Instantiate(PowerUpAttackPrefab, PowerUpSpawnLocations[randomNumber].transform.position, PowerUpSpawnLocations[randomNumber].transform.rotation, null);
                        TempPowerUp.name = PowerUpAttackPrefab.name;
                        break;
                    case 1:
                        TempPowerUp = Instantiate(PowerUpAttackEnhanchedPrefab, PowerUpSpawnLocations[randomNumber].transform.position, PowerUpSpawnLocations[randomNumber].transform.rotation, null);
                        TempPowerUp.name = PowerUpAttackEnhanchedPrefab.name;
                        break;
                    case 2:
                        TempPowerUp = Instantiate(PowerUpCrossPrefab, PowerUpSpawnLocations[randomNumber].transform.position, PowerUpSpawnLocations[randomNumber].transform.rotation, null);
                        TempPowerUp.name = PowerUpCrossPrefab.name;
                        break;
                    case 3:
                        TempPowerUp = Instantiate(PowerUpCrossEnchanchedPrefab, PowerUpSpawnLocations[randomNumber].transform.position, PowerUpSpawnLocations[randomNumber].transform.rotation, null);
                        TempPowerUp.name = PowerUpCrossEnchanchedPrefab.name;
                        break;
                    case 4:
                        TempPowerUp = Instantiate(PowerUpHPPrefab, PowerUpSpawnLocations[randomNumber].transform.position, PowerUpSpawnLocations[randomNumber].transform.rotation, null);
                        TempPowerUp.name = PowerUpHPPrefab.name;
                        break;
                    case 5:
                        TempPowerUp = Instantiate(PowerUpHPEnhancedPrefab, PowerUpSpawnLocations[randomNumber].transform.position, PowerUpSpawnLocations[randomNumber].transform.rotation, null);
                        TempPowerUp.name = PowerUpHPEnhancedPrefab.name;
                        break;
                    case 6:
                        TempPowerUp = Instantiate(PowerUpLuckCloverPrefab, PowerUpSpawnLocations[randomNumber].transform.position, PowerUpSpawnLocations[randomNumber].transform.rotation, null);
                        TempPowerUp.name = PowerUpLuckCloverPrefab.name;
                        break;
                }
                RpcPowerUpSpawnManager(randomPowerUp, randomNumber);
            }
        }

    }


    [ClientRpc]
    void RpcGoblinSpawnManager(bool IsCountDone)
    {
        if (!isServer)
        {
            GameObject RpcTempGoblinBerserker = null;
            GameObject RpcTempGoblinWarrior = null;
            GameObject RpcTempGoblinWitchdoctor = null;
            for (int i = 0; i < 3; i++)
            {
                RpcTempGoblinBerserker = Instantiate(RedGoblinBerserkerPrefab[1], GoblinSpawnLocations[1].transform.position, GoblinSpawnLocations[1].transform.rotation, null);
                RpcTempGoblinBerserker.name = RedGoblinBerserkerPrefab[1].name;
            }
            for (int i = 0; i < 3; i++)
            {
                RpcTempGoblinWarrior = Instantiate(RedGoblinWarriorPrefab[2], GoblinSpawnLocations[2].transform.position, GoblinSpawnLocations[2].transform.rotation, null);
                RpcTempGoblinWarrior.name = RedGoblinWarriorPrefab[2].name;
            }
            for (int i = 0; i < 3; i++)
            {
                RpcTempGoblinWitchdoctor = Instantiate(RedGoblinWitchdoctorPrefab[3], GoblinSpawnLocations[3].transform.position, GoblinSpawnLocations[3].transform.rotation, null);
                RpcTempGoblinWitchdoctor.name = RedGoblinWitchdoctorPrefab[3].name;
            }
           
            if (IsCountDone)
                PlagueSpawner();
        }
    }
    [Server]
    public void RedGoblinSpawnManager()
    {
        if (currentgoblinspawntime > goblinspawntime)
        {
            currentgoblinspawntime = 0;
            if (CurrentGoblin <= MaxGoblin && starttimer >= 15)
            {
                CurrentGoblin++;
                for (int i = 0; i < 3; i++)
                {
                    TempGoblinRedBerserker = Instantiate(RedGoblinBerserkerPrefab[1], GoblinSpawnLocations[1].transform.position, GoblinSpawnLocations[1].transform.rotation, null);
                    TempGoblinRedBerserker.name = RedGoblinBerserkerPrefab[1].name;
                }


                for (int i = 0; i < 3; i++)
                {
                    TempGoblinRedWarrior = Instantiate(RedGoblinWarriorPrefab[2], GoblinSpawnLocations[2].transform.position, GoblinSpawnLocations[2].transform.rotation, null);
                    TempGoblinRedWarrior.name = RedGoblinWarriorPrefab[2].name;
                }


                for (int i = 0; i < 3; i++)
                {
                    TempGoblinRedWitchdoctor = Instantiate(RedGoblinWitchdoctorPrefab[3], GoblinSpawnLocations[3].transform.position, GoblinSpawnLocations[3].transform.rotation, null);
                    TempGoblinRedWitchdoctor.name = RedGoblinWitchdoctorPrefab[3].name;
                }

                if (CurrentGoblin == MaxGoblin)
                {
                    RpcGoblinSpawnManager(true);
                    PlagueSpawner();
                }
                else
                    RpcGoblinSpawnManager(false);

            }
        }
    }
    [Server]
    public void BlueGoblinSpawnManager()
    {
        if (BlueGoblinspawntimeCurrent > BlueGoblinSpawntime)
        {
            BlueGoblinspawntimeCurrent = 0;
            if (BlueGoblinCurrent <= BlueGoblinMax)
            {
                BlueGoblinCurrent++;
                int randomNumber = Random.Range(0, GoblinSpawnLocations.Length - 1);
                GameObject spawnlocation = GoblinSpawnLocations[randomNumber];
                int randomGoblin = Random.Range(0, 6);
                TempGoblinBlueBerserker = Instantiate(BlueGoblinBerserkerPrefab[randomGoblin], GoblinSpawnLocations[randomNumber].transform.position, GoblinSpawnLocations[randomNumber].transform.rotation, null);
                TempGoblinBlueBerserker.name = BlueGoblinBerserkerPrefab[randomGoblin].name;

                TempGoblinBlueWarrior = Instantiate(BlueGoblinWarriorrPrefab[randomGoblin], GoblinSpawnLocations[randomNumber].transform.position, GoblinSpawnLocations[randomNumber].transform.rotation, null);
                TempGoblinBlueWarrior.name = BlueGoblinWarriorrPrefab[randomGoblin].name;

                TempGoblinBlueWitchdoctor = Instantiate(BlueGoblinWitchdoctorPrefab[randomGoblin], GoblinSpawnLocations[randomNumber].transform.position, GoblinSpawnLocations[randomNumber].transform.rotation, null);
                TempGoblinBlueWitchdoctor.name = BlueGoblinWitchdoctorPrefab[randomGoblin].name;
                //RpcGoblinSpawnManager(randomGoblin, randomNumber);
            }
        }
    }
    [Server]
    public void GreenGoblinSpawnManager()
    {
        if (GreenGoblinspawntimeCurrent > GreenGoblinSpawntime)
        {
            GreenGoblinspawntimeCurrent = 0;
            if (BlueGoblinCurrent <= GreenGoblinMax)
            {
                GreenGoblinCurrent++;
                int randomNumber = Random.Range(0, GoblinSpawnLocations.Length - 1);
                GameObject spawnlocation = GoblinSpawnLocations[randomNumber];
                int randomGoblin = Random.Range(0, 6);
                TempGoblinGreenBerserker = Instantiate(GreenGoblinBerserkerPrefab[randomGoblin], GoblinSpawnLocations[randomNumber].transform.position, GoblinSpawnLocations[randomNumber].transform.rotation, null);
                TempGoblinGreenBerserker.name = GreenGoblinBerserkerPrefab[randomGoblin].name;

                TempGoblinGreenWarrior = Instantiate(GreenGoblinWarriorPrefab[randomGoblin], GoblinSpawnLocations[randomNumber].transform.position, GoblinSpawnLocations[randomNumber].transform.rotation, null);
                TempGoblinGreenWarrior.name = GreenGoblinWarriorPrefab[randomGoblin].name;

                //TempGoblinGreenWitchdoctor = Instantiate(GreenGoblinWitchdoctorPrefab[randomGoblin], GoblinSpawnLocations[randomNumber].transform.position, GoblinSpawnLocations[randomNumber].transform.rotation, null);
                //TempGoblinGreenWitchdoctor.name = GreenGoblinWitchdoctorPrefab[randomGoblin].name;
                //RpcGoblinSpawnManager(randomGoblin, randomNumber);

            }
        }

    }


    public void PlagueSpawner()
    {
        Instantiate(Plague_prefab, GameObject.FindWithTag("Player" + ClientCount).transform.position + new Vector3(3, 0, 5), Quaternion.identity);
        audiosource.clip = GameAmbianceClips[1];
        audiosource.Play();
        audiosource.volume = 1f;
    }


}

