﻿namespace Osnowa.NaPozniej
{
	using UnityEngine;

	[CreateAssetMenu(fileName = "ActorStatuses", menuName = "Kafelki/Configuration/ActorStatuses", order = 0)]
	public class ActorStatuses : ScriptableObject
	{
		public ActorStatusDefinition Unconcerned;

		public ActorStatusDefinition LittleConcerned;
		public ActorStatusDefinition Concerned;
		public ActorStatusDefinition VeryConcerned;

		/// <summary>
		/// = noticing enemies automatically.
		/// </summary>
		public ActorStatusDefinition Aware;

		/// <summary>
		/// Doing nothing
		/// </summary>
		public ActorStatusDefinition Watchful;

		public ActorStatusDefinition Sneaking;

		public ActorStatusDefinition Sleeping;
	}
}