using System;

namespace FuncEcs
{
    internal class CreateCastleSystem : IEcsTransformSystem
    {
        private SceneConfiguration sceneConfiguration;

        public CreateCastleSystem(SceneConfiguration sceneConfiguration)
        {
            this.sceneConfiguration = sceneConfiguration;
        }

        public EcsEntity TransformEntity(EcsEntity entity)
        {
            // transform entity with only cell component
            return entity.cell
                .Match(cell =>
                    {
                        var playerCastleObject = sceneConfiguration.playerCastleObject;
                        var enemyCastleObject = sceneConfiguration.enemyCastleObject;

                        if (cell.position != playerCastleObject.castlePosition
                         && cell.position != enemyCastleObject.castlePosition)
                        {
                            return entity;
                        }

                        return GetSpawnedCastle(cell, playerCastleObject, enemyCastleObject, entity);
                    },
                    () => entity);
        }

        private EcsEntity GetSpawnedCastle(Cell cell,
            CastleObject playerCastleObject,
            CastleObject enemyCastleObject,
            EcsEntity cellEntity)
        {
            if (cell.position == sceneConfiguration.playerCastleObject.castlePosition)
            {
                return GetSpawnedCastle(cellEntity, playerCastleObject, Side.Player);
            }

            return GetSpawnedCastle(cellEntity, enemyCastleObject, Side.Enemy);
        }

        private EcsEntity GetSpawnedCastle(EcsEntity entity,
            CastleObject playerCastleObject, Side side)
        {
            Hp hp = new Hp();
            hp.hp = playerCastleObject.hp;

            return EcsEntity.CreateInstance(hp, entity.cell, side);
        }
    }
}