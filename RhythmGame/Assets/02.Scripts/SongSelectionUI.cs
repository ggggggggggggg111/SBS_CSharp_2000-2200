using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class SongSelectionUI : MonoBehaviour
{
    public string selected;

    [SerializeField] private TMP_Text _title;
    [SerializeField] private Button _StartPlay;

    private void Awake()
    {
        Select(string.Empty);
        
    }

    private void Start()
    {
        _StartPlay.onClick.AddListener(() => 
        GameManager.instance.state = GameManager.State.LoadSongData);
    }
    public void Select(string selected)
    {
        this.selected = selected;
        if (string.IsNullOrEmpty(selected))
        {
            _title.text = string.Empty;
            _StartPlay.interactable = false;
        }
        else
        {
            _title.text = selected;
            _StartPlay.interactable = true;
        }
    }


}
