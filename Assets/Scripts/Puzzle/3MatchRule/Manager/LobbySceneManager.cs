using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbySceneManager : MonoBehaviour
{
    [SerializeField] private LobbyUICanvasPresenter lobbyUICanvasPresenter;
    
    // Start is called before the first frame update
    void Start()
    {
        this.InitStorages();
        this.InitPresenters();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void InitStorages()
    {
        GameStorage.Instance.OpenPuzzleStorages();
    }
    
    private void InitPresenters()
    {
        var stages = GameStorage.Instance.GetAllStages();
        this.lobbyUICanvasPresenter.InitStageList(stages);
    }
}
