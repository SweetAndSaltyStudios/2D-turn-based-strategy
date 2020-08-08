using System;
using System.Collections;
using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public enum TileType
    {
        Grass,
        Sand,
        Water
    }

    [Serializable]
    public class TileData
    {
        public TileType TileType;
        public Sprite TileSprite;

        private readonly SpriteRenderer spriteRenderer;
        private Vector2 position;

        public TileData(GameObject gameObject, int x, int y)
        {
            gameObject.name = $"Tile( {x} , {y} )";
            spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
            spriteRenderer.sprite = TileSprite;
            position.x = x;
            position.y = y;
        }
    }

    public class GameManager : Singelton<GameManager>
    {
        #region VARIABLES

        public Tile BaseTilePrefab;
        public TileData[] TileDatas;

        public Unit UnitPrefab;

        private int[,] tileMap;
        private readonly int mapWidth = 4;
        private readonly int mapHeight = 4;

        public float X_Offset;
        public float Y_Offset;

        private readonly WaitForSeconds tileSpawnRate = new WaitForSeconds(0.25f);

        #endregion VARIABLES

        #region PROPERTIES

        public Unit Unit
        {
            get;
            private set;
        }

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        private IEnumerator Start()
        {
            yield return StartCoroutine(GenerateTileMap());

            Unit = Instantiate(UnitPrefab);
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        private IEnumerator GenerateTileMap()
        {
            var parent = new GameObject("Tiles").transform;
            parent.SetParent(transform);

            tileMap = new int[mapWidth, mapHeight];

            for(int x = 0; x < mapWidth; x++)
                for(int y = 0; y < mapHeight; y++)                  
                {
                    var xPosition = x * X_Offset;
                    var yPosition = y * Y_Offset;

                    if(y % 2 == 1)
                    {
                        xPosition += X_Offset * 0.5f;
                    }

                    var newTile = Instantiate(
                        BaseTilePrefab,
                        new Vector2(xPosition, yPosition),
                        Quaternion.identity,
                        parent
                        );

                    newTile.name = $"( {x} , {y} )";

                    yield return tileSpawnRate;
                }
        }

        private void Dijkstra(Tile[] nodes, Tile startingNode)
        {

        }

        #endregion CUSTOM_FUNCTIONS
    }
}

