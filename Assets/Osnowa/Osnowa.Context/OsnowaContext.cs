namespace Osnowa.Osnowa.Context
{
	using System.Collections.Generic;
	using Core;
	using Entities;
	using Pathfinding;

	public class OsnowaContext : IOsnowaContext
	{
		/// <inheritdoc />
		public PathfindingDataHolder PathfindingData { get; }
		public PositionFlags PositionFlags { get; }
        public MatrixByte[] TileMatricesByteByLayer { get; }
        public MatrixFloat Walkability { get; }

        public Position StartingPosition { get; set; }
        public HashSet<IPositionedEntity> VisibleEntities { get; set; }
        public int TurnsPassed { get; set; }

        public OsnowaContext(int xSize, int ySize)
		{
			PositionFlags = new PositionFlags(xSize, ySize);
			PathfindingData = new PathfindingDataHolder(xSize, ySize);
			TileMatricesByteByLayer = new MatrixByte[TilemapLayers.TotalLayersCount];
		    Walkability = new MatrixFloat(xSize, ySize);
			for (int i = 0; i < TileMatricesByteByLayer.Length; i++)
			{
				TileMatricesByteByLayer[i] = new MatrixByte(xSize, ySize);
			}
		    VisibleEntities = new HashSet<IPositionedEntity>();
		}
	}
}