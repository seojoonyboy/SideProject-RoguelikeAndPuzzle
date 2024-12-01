using System;
using System.Collections;
using System.Collections.Generic;
using Puzzle.View;
using UnityEngine;
using UnityEngine.UI;

public class LobbyPuzzleListView : BaseView
{
    [SerializeField] private GridLayoutGroup gridLayoutGroup;
    [SerializeField] private GameObject stagePref;

    [SerializeField] private Transform content;
    
    private Dictionary<UInt64, Stage> stages;

    public new class Params : BaseView.Params
    {
        public Dictionary<UInt64, Stage> stages;
    }

    public override void Open(BaseView.Params p)
    {
        base.Open(p);
        Params pB = (Params)p;
        this.stages = pB.stages;
        
        this.InitGridLayout();
        this.MakeListItemView();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitGridLayout()
    {
        float screenWidth = Screen.width;

        float targetItemSizeX = screenWidth / gridLayoutGroup.constraintCount;
        float targetItemSizeY = stagePref.GetComponent<RectTransform>().sizeDelta.y;

        this.gridLayoutGroup.cellSize = new Vector2(targetItemSizeX, targetItemSizeY);
    }

    private void MakeListItemView()
    {
        foreach (KeyValuePair<UInt64, Stage> keyValuePair in this.stages)
        {
            Stage stage = keyValuePair.Value;
            
        }
    }
}
