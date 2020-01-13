﻿namespace PCG.Recipees.ComponentRecipees
{
	using Osnowa.Osnowa.RNG;
	using UnityEngine;

	[CreateAssetMenu(fileName = "Integrity", menuName = "Kafelki/Entities/Recipees/Integrity", order = 0)]
	public class IntegrityComponentRecipee : ComponentRecipee
	{
		public float Integrity;
		public float MaxIntegrity;

		public override void ApplyToEntity(GameEntity entity, IRandomNumberGenerator rng)
		{
			entity.ReplaceIntegrity(Integrity, MaxIntegrity);
		}
	}
}