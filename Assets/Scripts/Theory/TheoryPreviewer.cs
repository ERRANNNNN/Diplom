using UnityEngine;
using SimpleJSON;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class TheoryPreviewer : MonoBehaviour
{
    [SerializeField] private Transform ContentBox;
    [SerializeField] private Transform TheoryText;
    [SerializeField] private Transform TheoryImage;

    private JSONArray theoryData;
    [SerializeField] private SkipTheory _SkipTheory;
    private List<Transform> gms = new List<Transform>();

    private void Start()
    {
        //Init(0);
    }

    public void Init(int chapterId, Chapter chapter)
    {
        _SkipTheory._chapter = chapter;
        
        foreach(Transform obj in gms)
        {
            Destroy(obj.gameObject);
        }

        gms = new List<Transform>();

        if(chapterId < Storage.ChaptersTheoryArray.Count)
        {
            theoryData = Storage.ChaptersTheoryArray[chapterId].AsArray;

            foreach (JSONNode node in theoryData)
            {
                if (node["type"] == "text")
                {
                    foreach (JSONNode abzats in node["data"].AsArray)
                    {
                        Transform obj = Instantiate(TheoryText, ContentBox);
                        gms.Add(obj);
                        TextMeshProUGUI tmka = obj.gameObject.GetComponent<TextMeshProUGUI>();
                        tmka.text = abzats;
                    }
                }
                else if (node["type"] == "image")
                {
                    Transform obj = Instantiate(TheoryImage, ContentBox);
                    gms.Add(obj);
                    Image imaga = obj.gameObject.GetComponent<Image>();

                    Sprite img = Resources.Load<Sprite>("Theory/ch_" + (chapterId + 1) + "_" + node["data"]);
                    imaga.sprite = img;
                }
            }
        }
    }
}
