using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mirror;
using UnityEngine.AI;


public class GameManager : NetworkBehaviour
{
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
    private int MaxPowerUp = 5;
    private float powerupspawntime = 5f;
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
    private int MaxGoblin = 5;
    private float goblinspawntime = 5f;
    private float currentgoblinspawntime = 0;

    private int BlueGoblinCurrent = 0;
    private int BlueGoblinMax = 10;
    private float BlueGoblinSpawntime = 5f;
    private float BlueGoblinspawntimeCurrent = 0;

    private int GreenGoblinCurrent = 0;
    private int GreenGoblinMax = 10;
    private float GreenGoblinSpawntime = 5f;
    private float GreenGoblinspawntimeCurrent = 0;

    public static GameManager singleton;
    public static List<GameObject> Players = null;
    public int ReferencePlayer = 0;
    public int ClientCount = 0;


    public static bool IsGoblinSpawned = false;

    private void Awake()
    {
        singleton = this;
        Players = new List<GameObject>();
    }




    private void Update()
    {

        //if (isServer)
        //{
        PowerUpSpawnManager();
 /*       RedGoblinSpawnManager()*/;
        BlueGoblinSpawnManager();
        GreenGoblinSpawnManager();

        currentpowerupspawntime += Time.deltaTime;

        currentgoblinspawntime += Time.deltaTime;
        BlueGoblinspawntimeCurrent += Time.deltaTime;
        GreenGoblinspawntimeCurrent += Time.deltaTime;
        //}

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
                //RpcPowerUpSpawnManager(randomPowerUp, randomNumber);
            }
        }

    }


    [ClientRpc]
    void RpcGoblinSpawnManager(int _Goblin, int _RandomNumber)
    {
        if (!isServer)
        {
            GameObject RpcTempGoblin = null;
            RpcTempGoblin = Instantiate(RedGoblinBerserkerPrefab[_Goblin], GoblinSpawnLocations[_RandomNumber].transform.position, GoblinSpawnLocations[_RandomNumber].transform.rotation, null);
            RpcTempGoblin.name = RedGoblinBerserkerPrefab[_Goblin].name;

        }
    }
    //[Server]
    public void RedGoblinSpawnManager()
    {
        if (currentgoblinspawntime > goblinspawntime)
        {
            currentgoblinspawntime = 0;
            if (CurrentGoblin <= MaxGoblin)
            {
                CurrentGoblin++;
                int randomNumber = Random.Range(0, GoblinSpawnLocations.Length - 1);
                GameObject spawnlocation = GoblinSpawnLocations[randomNumber];
                int randomGoblin = Random.Range(0, 6);
                //TempGoblinRedBerserker = Instantiate(RedGoblinBerserkerPrefab[randomGoblin], GoblinSpawnLocations[randomNumber].transform.position, GoblinSpawnLocations[randomNumber].transform.rotation, null);
                //TempGoblinRedBerserker.name = RedGoblinBerserkerPrefab[randomGoblin].name;

                //TempGoblinRedWarrior = Instantiate(RedGoblinWarriorPrefab[randomGoblin], GoblinSpawnLocations[randomNumber].transform.position, GoblinSpawnLocations[randomNumber].transform.rotation, null);
                //TempGoblinRedWarrior.name = RedGoblinWarriorPrefab[randomGoblin].name;

                TempGoblinRedWitchdoctor = Instantiate(RedGoblinWitchdoctorPrefab[randomGoblin], GoblinSpawnLocations[randomNumber].transform.position, GoblinSpawnLocations[randomNumber].transform.rotation, null);
                TempGoblinRedWitchdoctor.name = RedGoblinWitchdoctorPrefab[randomGoblin].name;

                //RpcGoblinSpawnManager(randomGoblin, randomNumber);
                IsGoblinSpawned = true;
            }
        }
    }
    //[Server]
    public void BlueGoblinSpawnManager()
    {
        if (BlueGoblinspawntimeCurrent > BlueGoblinSpawntime)
        {
            BlueGoblinspawntimeCurrent = 0;
            if (BlueGoblinCurrent <= BlueGoblinMax)
            {
                //CurrentGoblin++;
                int randomNumber = Random.Range(0, GoblinSpawnLocations.Length - 1);
                GameObject spawnlocation = GoblinSpawnLocations[randomNumber];
                int randomGoblin = Random.Range(0, 6);
                //TempGoblinBlueBerserker = Instantiate(BlueGoblinBerserkerPrefab[randomGoblin], GoblinSpawnLocations[randomNumber].transform.position, GoblinSpawnLocations[randomNumber].transform.rotation, null);
                //TempGoblinBlueBerserker.name = BlueGoblinBerserkerPrefab[randomGoblin].name;

                //TempGoblinBlueWarrior = Instantiate(BlueGoblinWarriorrPrefab[randomGoblin], GoblinSpawnLocations[randomNumber].transform.position, GoblinSpawnLocations[randomNumber].transform.rotation, null);
                //TempGoblinBlueWarrior.name = BlueGoblinWarriorrPrefab[randomGoblin].name;

                TempGoblinBlueWitchdoctor = Instantiate(BlueGoblinWitchdoctorPrefab[randomGoblin], GoblinSpawnLocations[randomNumber].transform.position, GoblinSpawnLocations[randomNumber].transform.rotation, null);
                TempGoblinBlueWitchdoctor.name = BlueGoblinWitchdoctorPrefab[randomGoblin].name;
                //RpcGoblinSpawnManager(randomGoblin, randomNumber);
                IsGoblinSpawned = true;
            }
        }
    }
    //[Server]
    public void GreenGoblinSpawnManager()
    {
        if (GreenGoblinspawntimeCurrent > GreenGoblinSpawntime)
        {
            GreenGoblinspawntimeCurrent = 0;
            if (BlueGoblinCurrent <= GreenGoblinMax)
            {
                BlueGoblinCurrent++;
                int randomNumber = Random.Range(0, GoblinSpawnLocations.Length - 1);
                GameObject spawnlocation = GoblinSpawnLocations[randomNumber];
                int randomGoblin = Random.Range(0, 6);
                //TempGoblinGreenBerserker = Instantiate(GreenGoblinBerserkerPrefab[randomGoblin], GoblinSpawnLocations[randomNumber].transform.position, GoblinSpawnLocations[randomNumber].transform.rotation, null);
                //TempGoblinGreenBerserker.name = GreenGoblinBerserkerPrefab[randomGoblin].name;

                //TempGoblinGreenWarrior = Instantiate(GreenGoblinWarriorPrefab[randomGoblin], GoblinSpawnLocations[randomNumber].transform.position, GoblinSpawnLocations[randomNumber].transform.rotation, null);
                //TempGoblinGreenWarrior.name = GreenGoblinWarriorPrefab[randomGoblin].name;

                TempGoblinGreenWitchdoctor = Instantiate(GreenGoblinWitchdoctorPrefab[randomGoblin], GoblinSpawnLocations[randomNumber].transform.position, GoblinSpawnLocations[randomNumber].transform.rotation, null);
                TempGoblinGreenWitchdoctor.name = GreenGoblinWitchdoctorPrefab[randomGoblin].name;
                //RpcGoblinSpawnManager(randomGoblin, randomNumber);
                IsGoblinSpawned = true;
            }
        }
    }


}

