using LanguageExt;

namespace FuncEcs
{
    internal interface IEcsSpawnSystem
    {
        public Lst<EcsEntity> CreateEntities();
    }
}