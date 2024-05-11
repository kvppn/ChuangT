using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//[ExecuteInEditMode]
public class GridMap : MonoBehaviour
{
   /* public MapData_SO mapData;

    public GridType gridType;

    private Tilemap currentTilemap;

    private void OnEnable()

    {

        if (!Application.IsPlaying(this))

        {

            currentTilemap = GetComponent<Tilemap>();

            if (mapData != null)

                mapData.tileProperties.Clear();

        }

    }

    private void OnDisable()

    {

        if (!Application.IsPlaying(this))

        {

            currentTilemap = GetComponent<Tilemap>();

            UpdateTileProperties();

#if UNITY_EDITOR

            if (mapData != null)

                EditorUtility.SetDirty(mapData);//设为脏数据后，才能进行保存和读取

#endif

        }

    }

    private void UpdateTileProperties()

    {

        currentTilemap.CompressBounds();

        if (!Application.IsPlaying(this))

        {

            if (mapData != null)

            {

                //已绘制范围的左下角坐标

                Vector3Int startPos = currentTilemap.cellBounds.min;

                //已绘制范围的右上角坐标

                Vector3Int endPos = currentTilemap.cellBounds.max;

                //循环遍历地图从左下角到右上角

                for (int x = startPos.x; x < endPos.x; x++)

                {

                    for (int y = startPos.y; y < endPos.y; y++)

                    {

                        //根据x和y坐标读取场景中的图块的坐标

                        TileBase tile = currentTilemap.GetTile(new Vector3Int(x, y, 0));

                        //生成图块信息

                        if (tile != null)

                        {

                            TileProperty newTile = new TileProperty

                            {

                                tileCoordinate = new Vector2Int(x, y),

                                gridType = this.gridType,

                                boolTypeValue = true

                            };

                            mapData.tileProperties.Add(newTile);

                        }

                    }

                }

            }

        }

    }*/
}
