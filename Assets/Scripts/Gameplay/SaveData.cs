using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    //For reference, position 0 is current HP and position 1 is current MP
    int[] AliceData = new int[2];
    int[] BobData = new int[2];
    int[] CharlieData = new int[2];
    int[] DaveData = new int[2];
    Vector2 saveLocation = new Vector2(0,10);
    string saveScene = "PresentationScene1";
    int characterAtSave = 1;

    //Variables for loading
    CharacterSwapping characterSwapper;
    PlayerController AliceController;
    PlayerController BobController;
    PlayerController CharlieController;
    PlayerController DaveController;

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
    }

    public void LoadData(){
        AliceController.incrementHealth(AliceData[0]);
        BobController.incrementHealth(BobData[0]);
        CharlieController.incrementHealth(CharlieData[0]);
        DaveController.incrementHealth(DaveData[0]);

        SceneManager.LoadScene(saveScene);
        
        switch(characterAtSave)
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
        
        characterSwapper.currentCharacter.transform.position = saveLocation;
    }

    public void save(Vector3 newSaveLocation, string newSaveScene, int newCharacterAtSave){
        AliceData[0] = AliceController.GetComponent<Health>().currentHP;
        BobData[0] = BobController.GetComponent<Health>().currentHP;
        CharlieData[0] = CharlieController.GetComponent<Health>().currentHP;
        DaveData[0] = DaveController.GetComponent<Health>().currentHP;
        saveLocation = newSaveLocation;
        saveScene = newSaveScene;
        characterAtSave = newCharacterAtSave;
    }
}
