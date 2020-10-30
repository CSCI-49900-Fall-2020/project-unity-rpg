using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBinds : MonoBehaviour
{

    public Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public Text up, left, down, right, jump, interract, menu, inventory;
    public Text skill1, skill2, skill3, skill4;

    private GameObject currentKey;

    private Color32 normal = new Color32(39, 171, 249, 255);
    private Color32 selected = new Color32(239, 116, 36, 255);


    // Start is called before the first frame update
    void Start()
    {
        keys.Add("Up", (KeyCode)System.Enum.Parse(typeof(KeyCode),PlayerPrefs.GetString("Up","W")));
        keys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A")));
        keys.Add("Down", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Down", "S")));
        keys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D")));
        keys.Add("Jump", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space")));

        keys.Add("Skill1", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Skill1", "I")));
        keys.Add("Skill2", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Skill2", "J")));
        keys.Add("Skill3", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Skill3", "K")));
        keys.Add("Skill4", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Skill4", "L")));
        keys.Add("Items", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Items", "B")));

        keys.Add("Interract", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Interract", "Return")));
        keys.Add("UICanvas", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("UICanvas", "Escape")));

        up.text = keys["Up"].ToString();
        left.text = keys["Left"].ToString();
        down.text = keys["Down"].ToString();
        right.text = keys["Right"].ToString();
        jump.text = keys["Jump"].ToString();

        skill1.text = keys["Skill1"].ToString();
        skill2.text = keys["Skill2"].ToString();
        skill3.text = keys["Skill3"].ToString();
        skill4.text = keys["Skill4"].ToString();
        inventory.text = keys["Items"].ToString();

        interract.text = keys["Interract"].ToString();
        menu.text = keys["UICanvas"].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //When key is pressed, output a message
        /*
        if (Input.GetKeyDown(keys["Up"]))
        {
            Debug.Log("Up");
        }
        */
    }
    
    public bool GetButtonDown(string buttonName)
    {
        if(keys.ContainsKey(buttonName) == false)
        {
            Debug.LogError("KeyBinds::GetButtonDown - No button called " + buttonName);
            return false;
        }

        return Input.GetKeyDown(keys[buttonName]);
    }

    public bool GetButton(string buttonName)
    {
        if (keys.ContainsKey(buttonName) == false)
        {
            Debug.LogError("KeyBinds::GetButtonDown - No button called " + buttonName);
            return false;
        }

        return Input.GetKey(keys[buttonName]);
    }

    public bool GetButtonUp(string buttonName)
    {
        if (keys.ContainsKey(buttonName) == false)
        {
            Debug.LogError("KeyBinds::GetButtonDown - No button called " + buttonName);
            return false;
        }

        return Input.GetKeyUp(keys[buttonName]);
    }

    void OnGUI()
    {
        if(currentKey != null)
        {
            Event e = Event.current;
            
            if(e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }
            
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        if (currentKey != null)
            currentKey.GetComponent<Image>().color = normal;

        currentKey = clicked;
        currentKey.GetComponent<Image>().color = selected;

    }
    
    public void SaveKeys()
    {
        foreach (var key in keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }

        PlayerPrefs.Save();
    }

    void AddKeyBind(KeyBinds keyBinds, string function, string defaultKey)
    {
        keyBinds = GameObject.FindObjectOfType<KeyBinds>();
        keyBinds.GetButtonDown(function);
        keys.Add(function, (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(function, defaultKey)));
    }

    public void ReturnToDefault()
    {
        keys["Up"] = KeyCode.W;
        keys["Left"] = KeyCode.A;
        keys["Down"] = KeyCode.S;
        keys["Right"] = KeyCode.D;
        keys["Jump"] = KeyCode.Space;

        keys["Skill1"] = KeyCode.I;
        keys["Skill2"] = KeyCode.J;
        keys["Skill3"] = KeyCode.K;
        keys["Skill4"] = KeyCode.L;
        keys["Items"] = KeyCode.B;

        keys["Interract"] = KeyCode.Return;
        keys["UICanvas"] = KeyCode.Escape;

        up.text = keys["Up"].ToString();
        left.text = keys["Left"].ToString();
        down.text = keys["Down"].ToString();
        right.text = keys["Right"].ToString();
        jump.text = keys["Jump"].ToString();

        skill1.text = keys["Skill1"].ToString();
        skill2.text = keys["Skill2"].ToString();
        skill3.text = keys["Skill3"].ToString();
        skill4.text = keys["Skill4"].ToString();
        inventory.text = keys["Items"].ToString();

        interract.text = keys["Interract"].ToString();
        menu.text = keys["UICanvas"].ToString();

        foreach (var key in keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }

        PlayerPrefs.Save();
    }
}
