using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle.Util
{
    public class Cell
    {
        // 블록이 위치한 행값
        public int row;
        // 블록이 위치한 열값
        public int col;
        
        // 셀 타입, 블럭타입과는 다르다.
        public CellType type;
        // 셀 속성
        public CellAttr attr;
        
        // 블럭생성 능력이 있는가?
        // this.Type의 속성이 CellAttr.Genesis일 경우, Ref멤버임(Stage.Genesises의 참조)
        public Genesis genesis = null;

        public Cell()
        {
            this.row = 0;
            this.col = 0;
            this.type = CellType.None;
            this.attr = CellAttr.None;
        }

        public Cell(int row, int col, CellType type, CellAttr attr)
        {
            this.row = row;
            this.col = col;
            this.type = type;
            this.attr = attr;
        }
        
        public enum CellType
        {
            None = 0,               // 정의되지 않음
            Alive = 1,              // 블럭이 들어가서 역할을 수행하여 살아있다고 표현, default
            Dead = 2,               // 고정형 블럭이 들어가서 역할을 수행하지 않아 죽어있다고 표현
        };
        
        public enum CellAttr
        {
            None = 0,               // 정의되지 않음, default
            Genesis = 1,            // 제네시스 셀인가?
            FlowerpotTerminal = 2,  // 화분종착지점 셀인가?
            WarpIn = 3,             // 블럭 공간이동 입구인가?
            WarpOut = 4,            // 블럭 공간이동 출구인가?
            NoRefresh = 5,          // 맞출 수 있는 블럭이 없는 경우 블럭을 재생성 안하는 셀
        };
    }
}
