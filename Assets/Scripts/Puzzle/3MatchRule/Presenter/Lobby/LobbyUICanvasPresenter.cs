using System;
using System.Collections;
using System.Collections.Generic;
using Puzzle.Presenter;
using UnityEngine;

public class LobbyUICanvasPresenter : BasePresenter
{
    [SerializeField] private GameObject puzzlePanel;
    [SerializeField] private LobbyPuzzleListView lobbyPuzzleListView;

    private Dictionary<UInt64, Stage> stages;
    
    public void InitStageList()
    {
        
    }
    
    public void InitStageList(Dictionary<UInt64, Stage> stages)
    {
        LobbyPuzzleListView.Params p = new LobbyPuzzleListView.Params();
        this.stages = p.stages = stages;
        this.lobbyPuzzleListView.Open(p);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
