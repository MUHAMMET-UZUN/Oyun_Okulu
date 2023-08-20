using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
using TMPro;

public class SpeechToText : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    private object speech;
    public TextMeshProUGUI sonuc;

    void Start()
    {
        actions.Add("e", E);
        actions.Add("l", L);
        actions.Add("a", A);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    public void StartRecognize()
    {
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        actions[speech.text.ToUpper()].Invoke();
    }

    private void E()
    {
        Debug.Log("E");
        sonuc.text = "e dedin";
    }
    private void L()
    {
        Debug.Log("L");
        sonuc.text = "l dedin";
    }
    private void A()
    {
        Debug.Log("A");
        sonuc.text = "a dedin";
    }
}
