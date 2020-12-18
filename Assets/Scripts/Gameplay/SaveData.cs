using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    //For reference, position 0 is current HP and position 1 is current MP, position 2 is current maxHP, position 3 is current maxMP
    int[] AliceData = new int[4];
    int[] BobData = new int[4];
    int[] CharlieData = new int[4];
    int[] DaveData = new int[4];
    public Vector2 saveLocation = new Vector2(0,10);
    string saveScene = "PresentationScene1";
    int characterAtSave = 1;

    //Variables for loading
    CharacterSwapping characterSwapper;
    PlayerController AliceController;
    PlayerController BobController;
    PlayerController CharlieController;
    PlayerController DaveController;
    //list of items to save
    List<Item> saveItems = new List<Item>();
    List<int> saveitemNumbers = new List<int>();
    GameObject[] saveSlots;
    GameObject gameManagerGO;
    GameManager gameManager;
    GameObject coinCounterM;
    int savedCoinCounter;
    //list of equipment items to save
    List<EquipmentItem> savedEquipmentItems = new List<EquipmentItem>();
    GameObject[] savedEquipmentSlots;
    List<EquipmentItem> savedEquipmentHelmets = new List<EquipmentItem>();
    List<EquipmentItem> savedEquipmentChest = new List<EquipmentItem>();
    List<EquipmentItem> savedEquipmentPants = new List<EquipmentItem>();
    List<EquipmentItem> savedEquipmentBoots = new List<EquipmentItem>();
    List<EquipmentItem> savedEquipmentWeapon = new List<EquipmentItem>();

    private void Start() {
        characterSwapper = GetComponent<CharacterSwapping>();
        AliceController = characterSwapper.character1.GetComponent<PlayerController>();
        BobController = characterSwapper.character2.GetComponent<PlayerController>();
        CharlieController = characterSwapper.character3.GetComponent<PlayerController>();
        DaveController = characterSwapper.character4.GetComponent<PlayerController>();
    
        AliceData[0] = 50;
        BobData[0] = 100;
        CharlieData[0] = 150;
        DaveData[0] = 200;
        AliceData[1] = 10;
        BobData[1] = 100;
        CharlieData[1] = 20;
        DaveData[1] = 50;
        gameManagerGO = GameObject.Find("GameManager");
        gameManager = gameManagerGO.GetComponent<GameManager>();
        coinCounterM = GameObject.Find("CoinsManager");
        savedCoinCounter = 0;
    }

    public void LoadData(){
        AliceController.incrementHealth(AliceData[0]);
        BobController.incrementHealth(BobData[0]);
        CharlieController.incrementHealth(CharlieData[0]);
        DaveController.incrementHealth(DaveData[0]);
        AliceController.decrementMana(999);
        BobController.decrementMana(999);
        CharlieController.decrementMana(999);
        DaveController.decrementMana(999);

        AliceController.incrementMana(AliceData[1]);
        BobController.incrementMana(BobData[1]);
        CharlieController.incrementMana(CharlieData[1]);
        DaveController.incrementMana(DaveData[1]);

        AliceController.setMaxHealth(AliceData[2]);       
        BobController.setMaxHealth(BobData[2]);
        CharlieController.setMaxHealth(CharlieData[2]);
        DaveController.setMaxHealth(DaveData[2]);

        AliceController.setMaxMana(AliceData[3]);
        BobController.setMaxMana(BobData[3]);
        CharlieController.setMaxMana(CharlieData[3]);
        DaveController.setMaxMana(DaveData[3]);

        StartCoroutine(LoadSaveScene());

        switch (characterAtSave)
        {
            case 1:
                characterSwapper.switchToCharacter1();
                break;
            case 2:
                characterSwapper.switchToCharacter2();
                break;
            case 3:
                characterSwapper.switchToCharacter3();
                break;
            case 4:
                characterSwapper.switchToCharacter4();
                break;
            default:
                break;
        }

        //LOADING ITEMS
        if (saveItems.Count != 0 ) {
            gameManagerGO.GetComponent<GameManager>().items.Clear();
            for (int i = 0; i < saveItems.Count; i++)
            {
                gameManagerGO.GetComponent<GameManager>().items.Add(saveItems[i]);
               // Debug.Log("LOAD: " + saveItems[i].itemName);
            }
            for (int i = 0; i < gameManagerGO.GetComponent<GameManager>().items.Count; i++)
            {
              //  Debug.Log("LOAD: " + gameManagerGO.GetComponent<GameManager>().items[i].itemName);
            }
            gameManagerGO.GetComponent<GameManager>().itemNumbers.Clear();
            for (int i = 0; i < saveitemNumbers.Count; i++)
            {
                gameManagerGO.GetComponent<GameManager>().itemNumbers.Add(saveitemNumbers[i]);
              //  Debug.Log("LOAD: " + saveitemNumbers[i]);
            }

            gameManagerGO.GetComponent<GameManager>().slots = saveSlots;
            gameManagerGO.GetComponent<GameManager>().DisplayItems();
        }
        //LOADING ITEMS WORKING

        //LOADING COIN COUNTER
        coinCounterM.GetComponent<ScoreManager>().setValueAndText(savedCoinCounter);
        Debug.Log("Coins Loaded: " + coinCounterM.GetComponent<ScoreManager>().score);
        //COIN COUNTER LOADED


        //LOADING EQUIPMENT ITEMS
        //gameManagerGO.GetComponent<GameManager>().equipmentItems.Clear();



        //LOADING EQUIPMENT HELMET
        // gameManagerGO.GetComponent<GameManager>().equipmentHelmets.Clear();
        /*for (int i = 0; i < gameManager.GetComponent<GameManager>().equipmentHelmets.Count; i++)
        {
            gameManager.GetComponent<GameManager>().RemoveEquipmentItem(gameManager.GetComponent<GameManager>().equipmentHelmets[i]);
        }*/
        //            Debug.Log("HELMETS BEFORE: " + gameManager.GetComponent<GameManager>().equipmentHelmets.Count);
        /*    for (int i = 0; i < savedEquipmentHelmets.Count; i++)
            {
                gameManagerGO.GetComponent<GameManager>().equipmentHelmets.Add(savedEquipmentHelmets[i]);
            }*/
        //LOADING EQUIPMENT BODY
        //gameManagerGO.GetComponent<GameManager>().equipmentChest.Clear();
        /*for (int i = 0; i < gameManager.GetComponent<GameManager>().equipmentChest.Count; i++)
        {
            gameManager.GetComponent<GameManager>().RemoveEquipmentItem(gameManager.GetComponent<GameManager>().equipmentChest[i]);
        }
       // Debug.Log("BODY BEFORE: " + gameManager.GetComponent<GameManager>().equipmentChest.Count);
        *//* for (int i = 0; i < savedEquipmentChest.Count; i++)
        {
            gameManagerGO.GetComponent<GameManager>().equipmentChest.Add(savedEquipmentChest[i]);
        }*//*
        //LOADING EQUIPMENT PANTS
        // gameManagerGO.GetComponent<GameManager>().equipmentPants.Clear();
        for (int i = 0; i < gameManager.GetComponent<GameManager>().equipmentPants.Count; i++)
        {
            gameManager.GetComponent<GameManager>().RemoveEquipmentItem(gameManager.GetComponent<GameManager>().equipmentPants[i]);
        }
       // Debug.Log("PANTS BEFORE: " + gameManager.GetComponent<GameManager>().equipmentPants.Count);
        *//*  for (int i = 0; i < savedEquipmentPants.Count; i++)
        {
            gameManagerGO.GetComponent<GameManager>().equipmentPants.Add(savedEquipmentPants[i]);
        }*//*
        //LOADING EQUIPMENT BOOTS
        // gameManagerGO.GetComponent<GameManager>().equipmentBoots.Clear();
        for (int i = 0; i < gameManager.GetComponent<GameManager>().equipmentBoots.Count; i++)
        {
            gameManager.GetComponent<GameManager>().RemoveEquipmentItem(gameManager.GetComponent<GameManager>().equipmentBoots[i]);
        }
        //Debug.Log("BOOTS BEFORE: " + gameManager.GetComponent<GameManager>().equipmentBoots.Count);
        *//*    for (int i = 0; i < savedEquipmentBoots.Count; i++)
            {
                gameManagerGO.GetComponent<GameManager>().equipmentBoots.Add(savedEquipmentBoots[i]);
            }*//*
        //LOADING EQUIPMENT WEAPON
        //gameManagerGO.GetComponent<GameManager>().equipmentWeapon.Clear();
        for (int i = 0; i < gameManager.GetComponent<GameManager>().equipmentWeapon.Count; i++)
        {
            gameManager.GetComponent<GameManager>().RemoveEquipmentItem(gameManager.GetComponent<GameManager>().equipmentWeapon[i]);
        }*/
        //  Debug.Log("WEAPONS BEFORE: " + gameManager.GetComponent<GameManager>().equipmentWeapon.Count);
        /* for (int i = 0; i < savedEquipmentWeapon.Count; i++)
        {
            gameManagerGO.GetComponent<GameManager>().equipmentWeapon.Add(savedEquipmentWeapon[i]);
        }*/
        //Debug.Log("EITEMS BEFORE loop: " + gameManagerGO.GetComponent<GameManager>().equipmentItems.Count);
        for (int i = 0; i < gameManagerGO.GetComponent<GameManager>().equipmentItems.Count; i++)
        {
            gameManagerGO.GetComponent<GameManager>().RemoveEquipmentItem(gameManager.GetComponent<GameManager>().equipmentItems[i]);
        }
        for (int i = 0; i < gameManagerGO.GetComponent<GameManager>().equipmentItems.Count; i++)
        {
            Debug.Log("EITEM NOT DELETED: " + gameManagerGO.GetComponent<GameManager>().equipmentItems[i]);
        }
        Debug.Log("EITEMS BEFORE after loop: " + gameManagerGO.GetComponent<GameManager>().equipmentItems.Count);
        for (int i = 0; i < savedEquipmentItems.Count; i++)
        {
            gameManagerGO.GetComponent<GameManager>().AddEquipmentItem(savedEquipmentItems[i]);
        }
        Debug.Log("EITEMS AFTER : " + gameManager.GetComponent<GameManager>().equipmentItems.Count);


        gameManagerGO.GetComponent<GameManager>().equipmentSlots = savedEquipmentSlots;
        characterSwapper.currentCharacter.transform.position = saveLocation;
    }

    public void save(Vector3 newSaveLocation, string newSaveScene, int newCharacterAtSave){
        AliceData[0] = AliceController.GetComponent<Health>().currentHP;       
        BobData[0] = BobController.GetComponent<Health>().currentHP;
        CharlieData[0] = CharlieController.GetComponent<Health>().currentHP;
        DaveData[0] = DaveController.GetComponent<Health>().currentHP;

        AliceData[1] = AliceController.GetComponent<Mana>().currentMP;
        BobData[1] = BobController.GetComponent<Mana>().currentMP;
        CharlieData[1] = CharlieController.GetComponent<Mana>().currentMP;
        DaveData[1] = DaveController.GetComponent<Mana>().currentMP;

        AliceData[2] = AliceController.GetComponent<Health>().maxHP;
        BobData[2] = BobController.GetComponent<Health>().maxHP;
        CharlieData[2] = CharlieController.GetComponent<Health>().maxHP;
        DaveData[2] = DaveController.GetComponent<Health>().maxHP;
        
        AliceData[3] = AliceController.GetComponent<Mana>().maxMP;
        BobData[3] = BobController.GetComponent<Mana>().maxMP;
        CharlieData[3] = CharlieController.GetComponent<Mana>().maxMP;
        DaveData[3] = DaveController.GetComponent<Mana>().maxMP;
        saveLocation = newSaveLocation;
        saveScene = newSaveScene;
        characterAtSave = newCharacterAtSave;

        //saving ITEMS
        for (int i = 0;i< gameManager.items.Count;i++)
        {
            saveItems.Add(gameManager.items[i]);
           // Debug.Log("SAVED: " + saveItems[i].itemName);
        }

        for (int j = 0; j < gameManager.itemNumbers.Count;j++)
        {
            saveitemNumbers.Add(gameManager.itemNumbers[j]);
          //  Debug.Log("SAVED: " + saveitemNumbers[j]);
        }
        saveSlots = gameManager.slots;

        //SAVING ALL EQUIPMENT
        savedEquipmentItems.AddRange(gameManager.equipmentItems);
        /*for (int i = 0; i <gameManager.equipmentItems.Count;i++)
        {
            savedEquipmentItems[i] = gameManager.equipmentItems[i];
        }*/
       
        // for (int i = 0; i < savedEquipmentItems.Count; i++)
        // {
        //     Debug.Log("SAVED: " + savedEquipmentItems[i].itemName);
        // }
        // for (int i = 0; i < savedEquipmentHelmets.Count; i++)
        // {
        //     Debug.Log("SAVED: " + savedEquipmentHelmets[i].itemName);
        // }
        // Debug.Log("EITEMS COUNT: " + savedEquipmentItems.Count);
        // Debug.Log("HELMETS COUNT: " + savedEquipmentHelmets.Count);
        savedEquipmentSlots = gameManager.equipmentSlots;


        //Saving Coin Count
        savedCoinCounter = coinCounterM.GetComponent<ScoreManager>().score;
        // Debug.Log("Coins Saved: " +savedCoinCounter);
        // coin Count saved

        //Debug.Log("EquipmentITEMS Count: " + savedEquipmentItems.Count);
        // Debug.Log("EquipmentSlots Count: " + savedEquipmentSlots.Length);
        /*//SAVING EQUIPMENT HELMET
        for (int i = 0; i < gameManager.equipmentHelmets.Count; i++)
        {
            savedEquipmentHelmets.Add(gameManager.equipmentHelmets[i]);
        }


        //SAVING EQUIPMENT BODY
        for (int i = 0; i < gameManager.equipmentChest.Count; i++)
        {
            savedEquipmentChest.Add(gameManager.equipmentChest[i]);
        }
        //SAVING EQUIPMENT PANTS
        for (int i = 0; i < gameManager.equipmentPants.Count; i++)
        {
            savedEquipmentPants.Add(gameManager.equipmentPants[i]);
        }
        //SAVING EQUIPMENT BOOTS
        for (int i = 0; i < gameManager.equipmentBoots.Count; i++)
        {
            savedEquipmentBoots.Add(gameManager.equipmentBoots[i]);
        }
        //SAVING EQUIPMENT WEAPONS
        for (int i = 0; i < gameManager.equipmentWeapon.Count; i++)
        {
            savedEquipmentWeapon.Add(gameManager.equipmentWeapon[i]);
        }*/


    }
    IEnumerator LoadSaveScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(saveScene);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }


}
