using LanguageExt;

namespace FuncEcs
{
    internal class InitFieldSystem : IEcsSpawnSystem
    {
        private SceneConfiguration sceneConfiguration;

        public InitFieldSystem(SceneConfiguration sceneConfiguration)
        {
            this.sceneConfiguration = sceneConfiguration;
        }

        public Lst<EcsEntity> CreateEntities()
        {
            var lst = Lst<EcsEntity>.Empty;
            for (int i = 0; i < sceneConfiguration.cellsCount; i++)
            {
                Cell cell = new Cell();
                cell.position = i;

                EcsEntity entity = EcsEntity.CreateInstance(default, cell);
                lst = lst.Add(entity);
            }

            return lst;
        }
    }
}