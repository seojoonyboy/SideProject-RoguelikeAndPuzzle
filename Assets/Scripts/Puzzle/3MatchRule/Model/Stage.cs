using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

using Common.Model;
using Newtonsoft.Json.Linq;
using Puzzle.Util;

public class Stage : Storage
{
    private string name;
    private string description;
    private UInt64 stageNo;

    public UInt64 StageNo
    {
        get
        {
            return stageNo;
        }   
    }
    
    private UInt64 collectionNo;
    private UInt32 rowCount;
    private UInt32 colCount;
    
    private UInt32 totalTurn;
    private UInt32 turn;
    
    private UInt32 skillFever;
    private UInt32 skillFeverMax;

    public List<Clear> clears = new List<Clear>();
    public List<Genesis> genesises = new List<Genesis>();
    public Cell[,] cells = null;
    
    public Stage(JObject obj)
    {
        this.LoadStageInfoFromFiles(obj);
    }

    private void LoadStageInfoFromFiles(JObject jObject)
    {
        // headers
        this.SetHeaders(jObject);
        
        // cells
        this.SetStages();
        
        // clears
        this.SetClears(jObject);
                
        // genesises
        this.SetGenesis(jObject);
    }

    private void SetStages()
    {
        this.cells = new Cell[this.rowCount, this.colCount];
    }

    private void SetHeaders(JObject jObject)
    {
        JObject header = jObject["header"] as JObject;
        this.name = (string)header["name"];
        this.description = (string)header["description"];
        this.stageNo = (UInt64)header["stageNo"];
        this.collectionNo = (UInt64)header["collectionNo"];
        this.rowCount = (UInt32)header["rowCount"];
        this.colCount = (UInt32)header["colCount"];
        this.totalTurn = (UInt32)header["totalTurn"];
                
        this.turn = null != header["turn"] ? (UInt32)header["turn"] : 0;
        this.skillFever = null != header["skillFever"] ? (UInt32)header["skillFever"] : 0;
        this.skillFeverMax = null != header["skillFeverMax"] ? (UInt32)header["skillFeverMax"] : 32;
    }

    private void SetGenesis(JObject jObject)
    {
        JArray genesises = jObject["genesises"] as JArray;
        if (null != genesises)
        {
            foreach (JObject o in genesises) {
                Genesis g = new Genesis(o);
                this.genesises.Add(g);
                        
                // 해당셀의 속성으로 제네시스를 넣어준다.
                this.cells[g.row, g.col] = new Cell
                {
                    attr = Cell.CellAttr.Genesis,
                    genesis = g
                };
            }
        }
    }

    private void SetClears(JObject jObject)
    {
        JArray clears = jObject["clears"] as JArray;
        if (null != clears)
        {
            foreach (JObject o in clears) {
                Clear clear = new Clear(o);
                this.clears.Add(clear);
            }
        }
    }

    public class Clear
    {
        public UInt32 total;
        public UInt32 current;
        
        public ClearType type;
        
        public Clear() { }
        
        public Clear(JObject obj)
        {
            if ((string)obj["type"] == "0") return;
            if (null != obj["type"]) {
                if (JTokenType.String == obj["type"].Type)
                    this.type = (ClearType)Enum.Parse(typeof(ClearType), (string)obj["type"]);
                else
                    this.type = (ClearType)(int)obj["type"];                    
            } else
                this.type = ClearType.None;
            this.total = (UInt32)obj["total"];
            this.current = (UInt32)(obj["current"] ?? 0);
        }
    }
    
    public enum ClearType
    {
        None = 0,

        // 일반블록 제거 횟수
        Normal = 100,
        // CAUTION: 일부러 아래 1~7은 블럭타입과 동일하게 맞추었다.
        Red = 101,
        Blue = 102,
        Green = 103,
        Yellow = 104,
        Purple = 105,
        Pink = 106,
        Brown = 107,

        // 특수블록 폭파 횟수
        Special = 200,
        // CAUTION: 일부러 아래 특수블록5개는 블럭타입과 동일하게 맞추었다.
        PaperPlane = 301,
        Rocket = 302,
        Bomb = 303,
        Mirrorball = 304,
        ShootingStar = 305,

        // 트로피(화분) 화면하단 이동 횟수
        Throphy = 201,
        // 폭죽상자 제거 횟수
        // Fireworkbox = 202,
        // 럭키볼(푸딩)제거 횟수
        Luckyball = 203,
        // 잔디(뽁뽁이)
        Grass = 204,
        // 티켓박스(도시락) 주변에 블록 폭파할 때 티켓 한 개를 수집
        TicketBox = 205,
        // 바리케이드(철창(감옥)) 제거 횟수
        Barricade = 206,
        // 보석(캔)
        Gemstone = 207,
        // 팝콘상자 주변에 블록 폭파 할 때 팝콘 수집, 연쇄 작용 있음
        // Popcornbox = 208,
        // 레드카펫(물감)
        RedCarpet = 209,
        // 나무상자(종이상자)
        Woodbox = 210,
        // 물웅덩이(잔디) 제거 횟수
        Puddle = 211,
        // 관중석(2x2블록크기의 세탁기)
        Stand = 212,

        // 2022.08.19 : 블록타입 추가

        IceCube = 401,
        TopiarySpring = 402,
        TopiaryWinter = 403,
        FloorLamp = 404,
        
        TeaCup = 405,
        Vase = 406,
        Pumpkin = 407,
        Lantern = 408,

        Coconut = 409,
        CannedSoda = 410,
        CannedFood = 411,
        JewelStash = 412,

        Snow = 413,

        Pizza = 414,
        Fridge = 415,
        Fishbowl = 416,

        // 신규기능, 2x2 풍선타입
        BalloonBox = 417,
        RedBalloonBox = 418,
        YellowBalloonBox = 419,
        GreenBalloonBox = 420,
        PurpleBalloonBox = 421,

        // 신규기능, 색깔나무상자
        ColoredWoodbox = 428,
        RedWoodbox = 422,
        YellowWoodbox = 423,
        GreenWoodbox = 424,
        PurpleWoodbox = 425,

        // 신규기능, 2x2 금고
        Vault = 426,

        // 신규기능, 금속상자
        IronBox = 427,

        // 타임어텍 (Mode == 1)
        TimeAttack = 9999,
    };
}
