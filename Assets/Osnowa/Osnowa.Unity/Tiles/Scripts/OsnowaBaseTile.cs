﻿namespace Osnowa.Osnowa.Unity.Tiles.Scripts
{
	using Context;
	using UnityEngine;
	using UnityEngine.Serialization;
	using UnityEngine.Tilemaps;

	public class OsnowaBaseTile : TileBase
	{
		public byte Id;

		public TilemapLayer Layer;

		public OsnowaBaseTile ShorterVariant;

		public WalkabilityModifier Walkability = WalkabilityModifier.Indifferent;
		public PassingLightModifier IsPassingLight = PassingLightModifier.Indifferent;
	}

	public enum WalkabilityModifier
	{
		/// <summary>
		/// Doesn't change walkability of a position resolved on lower layers.
		/// </summary>
		Indifferent = 0,

		/// <summary>
		/// Forces the position to be walkable, no matter what was on lower layers. Still can be changed by walkability of upper layers.
		/// </summary>
		ForceWalkable = 1,

		/// <summary>
		/// Forces the position to be unwalkable, no matter what was on lower layers. Still can be changed by walkability of upper layers.
		/// </summary>
		ForceUnwalkable = 2
	}

	public enum PassingLightModifier
	{
		/// <summary>
		/// Doesn't change passing light of a position resolved on lower layers.
		/// </summary>
		Indifferent = 0,

		/// <summary>
		/// Forces the position to pass light, no matter what was on lower layers. Still can be changed by passing light of upper layers.
		/// </summary>
		ForcePassing = 1,

		/// <summary>
		/// Forces the position to block light, no matter what was on lower layers. Still can be changed by passing light of upper layers 
		/// (e.g. by a window in a wall).
		/// </summary>
		ForceBlocking = 3
	}
}