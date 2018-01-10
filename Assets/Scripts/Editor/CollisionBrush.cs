using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace UnityEditor
{
    [CustomGridBrush(true, false, false, "Collision Brush")]
	public class CollisionBrush : GridBrush {
		public static bool PaletteOnlyMode = false;
		public static int TileRadiusFromCursorToRender = 3;

        public override void Paint(GridLayout grid, GameObject brushTarget, Vector3Int position)
        {
			// Only allow editing palettes
			if (brushTarget.layer != 31 && PaletteOnlyMode)
				return;
			
			Tilemap tilemap = brushTarget.GetComponent<Tilemap>();
			if (tilemap != null)
			{
				SetCollision(tilemap, position, Tile.ColliderType.Grid);
			}
        }
        
        public override void Erase(GridLayout grid, GameObject brushTarget, Vector3Int position)
        {
			// Only allow editing palettes
			if (brushTarget.layer != 31 && PaletteOnlyMode)
				return;

			Tilemap tilemap = brushTarget.GetComponent<Tilemap>();
			if (tilemap != null)
			{
				SetCollision(tilemap, position, Tile.ColliderType.None);
			}
        }

		public override void BoxErase (GridLayout gridLayout, GameObject brushTarget, BoundsInt position)
		{
			
		}

		public override void BoxFill (GridLayout gridLayout, GameObject brushTarget, BoundsInt position)
		{
			
		}

		public override void FloodFill (GridLayout gridLayout, GameObject brushTarget, Vector3Int position) {}
		public override void Move (GridLayout gridLayout, GameObject brushTarget, BoundsInt from, BoundsInt to) {}
        
		private static void SetCollision(Tilemap tilemap, Vector3Int position, Tile.ColliderType colliderType)
		{
			TileBase tile = tilemap.GetTile(position);
			if (tile != null)
			{
				var t = tilemap.GetTile<Tile> (position);
				t.colliderType = colliderType;
				tilemap.RefreshTile (position);

				EditorUtility.SetDirty(t);

				if (!PaletteOnlyMode) tilemap.RefreshAllTiles ();
			}
		}
    }

	[CustomEditor(typeof(CollisionBrush))]
	public class CollisionBrushEditor : GridBrushEditor
    {
		private CollisionBrush collisionBrush { get { return target as CollisionBrush; } }
		private bool justEnabled;

		protected override void OnEnable ()
		{
			justEnabled = true;
		}

		public override void OnMouseEnter ()
		{
			base.OnMouseEnter ();

			justEnabled = true;
		}

		public override void OnPaintInspectorGUI ()
		{
			base.OnPaintInspectorGUI ();
		}

		public override void PaintPreview(GridLayout grid, GameObject brushTarget, Vector3Int position)
		{
			if (brushTarget.layer != 31 && CollisionBrush.PaletteOnlyMode)
				return;

			DrawCollisions (brushTarget, position);
		}

		public override void OnPaintSceneGUI (GridLayout gridLayout, GameObject brushTarget, BoundsInt position, GridBrushBase.Tool tool, bool executing)
		{
			if (brushTarget.layer != 31 && CollisionBrush.PaletteOnlyMode)
				return;

			base.OnPaintSceneGUI (gridLayout, brushTarget, position, tool, executing);

			DrawCollisions (brushTarget, position.position);
		}

		private void DrawCollisions(GameObject brushTarget, Vector3Int position)
		{
			Tilemap[] tilemaps = null;

			if (justEnabled) {
				justEnabled = false;
				if (brushTarget.transform.parent == null) return;
				tilemaps = brushTarget.transform.parent.GetComponentsInChildren<Tilemap> ();
				if(tilemaps != null)
					foreach (var tilemap in tilemaps) {
						tilemap.RefreshAllTiles ();
					}
			}

			if ((brushTarget.layer != 31  && CollisionBrush.PaletteOnlyMode) || Event.current.type != EventType.Repaint)
				return;
			if (brushTarget.transform.parent == null) return;

			if(tilemaps == null) tilemaps = brushTarget.transform.parent.GetComponentsInChildren<Tilemap>();

			foreach (var tilemap in tilemaps) {
				var tilesBounds = tilemap.cellBounds;

				//for (int x = tilesBounds.min.x; x < tilesBounds.max.x; x++) {
				//	for (int y = tilesBounds.min.y; y < tilesBounds.max.y; y++) {
				var maxEachDir = 35;
				for (int x = position.x - maxEachDir; x <= position.x + maxEachDir; x++) {
					for (int y = position.y - maxEachDir; y <= position.y + maxEachDir; y++) {
						var pos = new Vector3Int (x, y, 0);
						if (!tilesBounds.Contains (pos)) continue;

						var colType = tilemap.GetColliderType (pos);
						switch (colType) {
						case Tile.ColliderType.None:
							continue;
						case Tile.ColliderType.Grid:
							{
								Handles.color = Color.red;
								Handles.CubeHandleCap (0, pos + new Vector3 (.5f, .5f), Quaternion.identity, .9f, EventType.Repaint);
								Handles.color = Color.white;
								Handles.CubeHandleCap (0, pos + new Vector3 (.5f, .5f), Quaternion.identity, .8f, EventType.Repaint);
							} break;
						case Tile.ColliderType.Sprite:
							{
								Handles.color = Color.red;
								Handles.SphereHandleCap (0, pos + new Vector3 (.5f, .5f), Quaternion.identity, .9f, EventType.Repaint);
								Handles.color = Color.white;
								Handles.SphereHandleCap (0, pos + new Vector3 (.5f, .5f), Quaternion.identity, .8f, EventType.Repaint);
							} break;
						}
					}
				}
			}
		}
    }
}




































