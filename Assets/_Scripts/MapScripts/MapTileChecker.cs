using System.Collections.Generic;
using System.Linq;
using _Scripts.EncounterScripts.Encounters;
using _Scripts.Tiles;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

namespace _Scripts.MapScripts
{
    public class MapTileChecker : MonoBehaviour
    {
        public Tilemap[] tiles; // Assign the Ground Tilemap component
        public TileInfo[] tileInfos;

        [CanBeNull] public static TileInfo currentTile; //todo this will change cant be null

        private Dictionary<TileBase, TileInfo> _dataFromTiles;

        private void Awake()
        {
            _dataFromTiles = new Dictionary<TileBase, TileInfo>();

            foreach (var tileInfo in tileInfos)
            {
                foreach (var tile in tileInfo.tiles)
                {
                    _dataFromTiles.Add(tile, tileInfo);
                }
            }
        }

        private void Update()
        {
          //  SetCurrentGrid();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                LookAround();
            }
        }

        private void LookAround()
        {
            EncounterInfo.currentTileInfo = currentTile;
            SceneManager.LoadScene(0);
        }

        private void SetCurrentGrid()
        {
            // Get the cell position of the player
            //todo here there are more than 1 tiles make sure to get the right ones
            //when designing the real map make sure to have only 1 tile per cell if possible
            //its okay to have town on top of grass but not 2 grass tiles on top of each other
            foreach (var tile in tiles.Reverse())
            {
                Vector3Int cellPosition = tile.WorldToCell(transform.position);

                var currecntTile = tile.GetTile(cellPosition);
                if (currecntTile == null)
                {
                    currentTile = null;
                    break;
                }

                currentTile = _dataFromTiles[currecntTile];
                if (currecntTile != null) break;

                // Debug.Log("Speed: " + _dataFromTiles[currecntTile].walkingSpeed);
                // Debug.Log("Type: " + _dataFromTiles[currecntTile].tileType);
            }
        }
    }
}