using System;
using System.Collections;
using System.Collections.Generic;
using Common.Model;
using Newtonsoft.Json.Linq;
using Puzzle.Util;
using UnityEngine;

public class GameStorage : MonoBehaviour
{
    static GameStorage m_Instance = null;
    private Dictionary<string, Storage> storages;
    
    public static Stage Stage => GameStorage.Instance.GetStorage<Stage>();
    public static Hashtable Stages;
    
    public static GameStorage Instance
    {
        get
        {
            if (m_Instance == null)
            {
                var obj = new GameObject(nameof(GameStorage));
                m_Instance = obj.AddComponent<GameStorage>();
                m_Instance.storages = new Dictionary<string, Storage>();
            }
            return m_Instance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void OpenPuzzleStorages()
    {
        GameStorage.Stages = new Hashtable();
        var stageFiles = Resources.LoadAll<TextAsset>(FilePathControl.PATH_ASSET_STAGE_FOLDER.ToString());
        foreach (var stageTextAsset in stageFiles)
        {
            string fileText = stageTextAsset.text;
            JObject jObject = JObject.Parse(fileText);
            Stage stage = new Stage(jObject);
            
            GameStorage.Stages.Add(stage.StageNo, stage);
        }
    }
    
    private void OpenSubStorage<T>(T storage) where T : Storage
    {
        string key = typeof(T).Name;
        if (storages.ContainsKey(key)) storages[key] = storage;
        else storages.Add(key, storage);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public T GetStorage<T>() where T : Storage
    {
        if (!storages.ContainsKey(typeof(T).Name)) return default(T);
        return storages[typeof(T).Name] as T;
    }
}