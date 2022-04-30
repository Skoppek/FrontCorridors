using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Char_Selection : MonoBehaviour
{
    public Character[] characters;
    [HideInInspector]
    public int selected = 0;

    public TMP_Text name;
    public TMP_Text about;
    

    private Coroutine _typeTextName;
    private Coroutine _typeTextAbout;


    public void Start()
    {
        replaceData();
    }
    public void nextCharacter()
    {
        selected = (selected + 1) % characters.Length;
        replaceData();
    }


    public void prevCharacter()
    {

        selected--;
        if (selected<0)
        {
            selected += characters.Length;
           
        }
        replaceData();
    }

    public void replaceData()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = characters[selected].character_sprite;
        name.text = characters[selected].name;
        about.text = characters[selected].about;
        StartCoroutine(startAnimate());
        if (_typeTextName != null)
        {
            StopCoroutine(_typeTextName);
            _typeTextName = null;
        }
        if (_typeTextName == null) _typeTextName = StartCoroutine(typeText(name.text, name,0.1f));

        if (_typeTextAbout != null)
        {
            StopCoroutine(_typeTextAbout);
            _typeTextAbout = null;
        }
        if (_typeTextAbout == null) _typeTextAbout = StartCoroutine(typeText(about.text, about, 0.02f));


    }

    public void startGame()
    {
        PlayerPrefs.SetInt("selectedCharacter", selected);
        SceneManager.LoadScene("Main_Corridor", LoadSceneMode.Single);
    }

    IEnumerator startAnimate()
    {

        GameObject.Find("Dimmer").GetComponent<DimmerControl>().targetAlpha = 1;
        yield return new WaitForSecondsRealtime(0.1f);
        GameObject.Find("Dimmer").GetComponent<DimmerControl>().targetAlpha = 0;

    }

    IEnumerator typeText (string some_message, TMP_Text some_text, float speed)
    {
        some_text.text = "";
        foreach (char letter in some_message.ToCharArray())
        {
            some_text.text += letter;
            yield return new WaitForSecondsRealtime(speed);
        }
    }
}
