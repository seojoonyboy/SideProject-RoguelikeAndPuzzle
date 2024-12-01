using System.Collections;
using System.Collections.Generic;
using Puzzle.Presenter;
using UnityEngine;

namespace Puzzle.Manager
{
    public class PuzzleSceneManager : MonoBehaviour
    {
        [SerializeField] private StagePresenter stagePresenter;
        [SerializeField] private BlockPresenter blockPresenter;
        
        // Start is called before the first frame update
        void Start()
        {
            this.InitStorages();
            this.InitPresenters();
        }
        
        private void InitStorages()
        {
            // GameStorage.Instance.OpenPuzzleStorages();
        }

        private void OnStageFileUpdated()
        {
            
        }

        private void InitPresenters()
        {
            this.stagePresenter.Init();
        }
    }
}