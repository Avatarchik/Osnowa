﻿using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using UnityEngine;

namespace Piec.Tests.RNG
{
	[TestFixture]
	public class RandomNumberGeneratorTests
	{
		[Test]
		public void NextPosition_ReturnsPositionsWithinBoundsAndAllPossiblePositionsAreGeneratedEventually()
		{
			var rng = new RandomNumberGenerator(9438);
			var results = new List<Position>();
			var bounds = new BoundsInt(-1, -1, 0, 4, 4, 1);
			var possibleResults = new[]
			{
				new Position(-1, -1), new Position(+0, -1), new Position(+1, -1), new Position(+2, -1),
				new Position(-1, +0), new Position(+0, +0), new Position(+1, +0), new Position(+2, +0),
				new Position(-1, +1), new Position(+0, +1), new Position(+1, +1), new Position(+2, +1),
				new Position(-1, +2), new Position(+0, +2), new Position(+1, +2), new Position(+2, +2)
			};

			for (int i = 0; i < 100; i++)
			{
				var result = rng.NextPosition(bounds);
				results.Add(result);
			}

			foreach (Position result in results)
			{
				possibleResults.Should().Contain(result);
			}
			foreach (Position possibleResult in possibleResults)
			{
				results.Should().Contain(possibleResult);
			}
		}

		[TestCase(0,0)]
		[TestCase(3,0)]
		[TestCase(0,5)]
		[TestCase(-12,21)]
		public void BiasedPosition_WhenRadiusIs0_ReturnsInputPosition(int x, int y)
		{
			var rng = new RandomNumberGenerator(2131235);
			var testedVector = new Position(x, y);
			var results = new List<Position>();

			for (int i = 0; i < 100; i++)
			{
				var newResult = rng.BiasedPosition(testedVector, 0);
				results.Add(newResult);
			}

			foreach (Position result in results)
			{
				result.Should().Be(testedVector);
			}
		}

		[TestCase(0, 0)]
		[TestCase(3, 0)]
		[TestCase(0, 5)]
		[TestCase(-12, 21)]
		public void BiasedPosition_WhenRadiusIs1_ReturnsInputPositionOrItsNeighboursAndAllNeighboursAreEventuallyReturned(int x, int y)
		{
			var rng = new RandomNumberGenerator(2131235);
			var testedVector = new Position(x, y);
			List<Position> possibleResults = new[] {testedVector}.Union(PositionUtilities.Neighbours4List(testedVector)).ToList();
			var results = new List<Position>();

			for (int i = 0; i < 100; i++)
			{
				var newResult = rng.BiasedPosition(testedVector, 1);
				results.Add(newResult);
			}

			foreach (Position possibleResult in possibleResults)
			{
				results.Should().Contain(possibleResult);
			}
			foreach (Position result in results)
			{
				possibleResults.Should().Contain(result);
			}
		}

		[TestCase(0, 0)]
		[TestCase(3, 0)]
		[TestCase(0, 5)]
		[TestCase(-12, 21)]
		public void BiasedPosition_WhenRadiusIs5_ReturnsPositionsWithin5RangeFromInputPosition(int x, int y)
		{
			var rng = new RandomNumberGenerator(2131235);
			var testedVector = new Position(x, y);
			var results = new List<Position>();

			for (int i = 0; i < 100; i++)
			{
				var newResult = rng.BiasedPosition(testedVector, 1);
				results.Add(newResult);
			}

			foreach (Position result in results)
			{
				Position.Distance(testedVector, result).Should().BeLessOrEqualTo(5);
			}
		}
	}
}