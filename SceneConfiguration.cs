namespace FuncEcs
{
    public struct SceneConfiguration
    {
        public int cellsCount;
        public CastleObject playerCastleObject;
        public CastleObject enemyCastleObject;

        public SceneConfiguration(int cellsCount, CastleObject playerCastleObject, CastleObject enemyCastleObject)
        {
            this.cellsCount = cellsCount;
            this.playerCastleObject = playerCastleObject;
            this.enemyCastleObject = enemyCastleObject;
        }
    }
    
    public struct CastleObject 
    {
        public int hp;
        public int castlePosition;

        public CastleObject(int hp, int castlePosition)
        {
            this.hp = hp;
            this.castlePosition = castlePosition;
        }
    }
}