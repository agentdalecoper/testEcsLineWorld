using LanguageExt;

namespace FuncEcs
{
    struct EcsEntity
    {
        private EcsEntity(Option<Hp> hp = default, Option<Cell> cell = default, Option<Side> side = default)
        {
            this.hp = hp;
            this.cell = cell;
            this.side = side;
        }

        public static EcsEntity CreateInstance(Option<Hp> hp = default, Option<Cell> cell = default,
            Option<Side> side = default)
        {
            return new EcsEntity(hp, cell, side);
        }

        public Option<Hp> hp { get; }
        public Option<Cell> cell { get; }
        public Option<Side> side { get; }
    }
    
    internal struct Hp
    {
        public int hp;
    }
    
    internal struct Cell
    {
        public int position;
    }
    
    public enum Side
    {
        Player,
        Enemy
    }
}