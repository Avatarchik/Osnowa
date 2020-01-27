﻿namespace Osnowa.Osnowa.Unity.Tiles
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	using Assets.Plugins.TilemapEnhancements.Tiles.Rule_Tile.Scripts;
	using Osnowa.Tiles;
	using UnityEditor;
	using UnityEngine;

	public class IdGenerator : MonoBehaviour
	{
		public Tileset Tileset;

		public byte GenerateId()
		{
			IList<OsnowaTile> declaredTiles = GetUniqueDeclaredTilesFromTileset();

			bool[] takenIds = new bool[byte.MaxValue+1];

			foreach (OsnowaTile declaredTile in declaredTiles)
			{
				takenIds[declaredTile.Id] = true;
			}

			for (byte id = 1;; id++)
			{
				if (takenIds[id] == false)
					return id;
				if(id == byte.MaxValue)
					throw new InvalidOperationException("All IDs for tiles already taken.");
			}
		}

		public void AssignIdsToTileset()
		{
			IList<OsnowaTile> declaredTiles = GetUniqueDeclaredTilesFromTileset();

			bool[] takenIds = new bool[byte.MaxValue + 1];

			foreach (OsnowaTile declaredTile in declaredTiles)
			{
				takenIds[declaredTile.Id] = true;
			}

			byte lastTriedId = 1;
			foreach (OsnowaTile declaredTile in declaredTiles)
			{
				if (declaredTile.Id > 0)
					continue;
				for (byte id = lastTriedId; ; id++)
				{
					if (takenIds[id] == false)
					{
						declaredTile.Id = id;
						takenIds[id] = true;
#if UNITY_EDITOR
						EditorUtility.SetDirty(declaredTile);
#endif
						lastTriedId = id;
						Debug.Log("Assigned " + id + " ID to " + declaredTile.name + " tile.");
						break;
					}
					if (id == byte.MaxValue)
						throw new InvalidOperationException("All IDs for tiles already taken.");
				}
			}


		}

		public void ResetDuplicateIds()
		{
			IList<OsnowaTile> declaredTiles = GetUniqueDeclaredTilesFromTileset();

			int[] idCounts = new int[byte.MaxValue+1];

			foreach (OsnowaTile declaredTile in declaredTiles)
			{
				++idCounts[declaredTile.Id];
			}

			var wrongIds = new List<int>();
			for (int i = 0; i < byte.MaxValue; i++)
			{
				if(idCounts[i] > 1)
					wrongIds.Add(i);
			}
			foreach (int wrongId in wrongIds)
			{
				var wrongTiles = declaredTiles.Where(t => t.Id == wrongId);
				foreach (OsnowaTile wrongTile in wrongTiles)
				{
					Debug.Log("Resetting ID of " + wrongTile.name + " to 0.");
					wrongTile.Id = 0;
#if UNITY_EDITOR
					EditorUtility.SetDirty(wrongTile);
#endif
				}
			}
		}

		private List<OsnowaTile> GetUniqueDeclaredTilesFromTileset()
		{
			var tilesDeclaredByName =
				typeof(Tileset).GetFields(BindingFlags.Public | BindingFlags.Instance)
					.Where(f => f.FieldType == typeof(OsnowaTile))
					.Select(f => f.GetValue(Tileset)).Cast<OsnowaTile>();

			List<OsnowaTile> allDeclaredTiles = tilesDeclaredByName.Union(Tileset.OtherTiles).ToList();

			return allDeclaredTiles.Distinct().ToList();
		}
	}
}
