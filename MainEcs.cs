using System;
using System.Diagnostics;

namespace FuncEcs
{
    class MainEcs
    {
        static void Main(string[] args)
        {
            SceneConfiguration sceneConfiguration = getTestSceneConfiguration();

            InitFieldSystem initFieldSystem = new InitFieldSystem(sceneConfiguration);
            CreateCastleSystem createCastleSystem = new CreateCastleSystem(sceneConfiguration);

            var entities = initFieldSystem.CreateEntities();
            foreach (EcsEntity entity in entities)
            {
                EcsEntity en = createCastleSystem.TransformEntity(entity);
                Console.Write(en.cell.IfNone(new Cell()).position);
                Console.Write(" " + getHpString(en));
                Console.WriteLine();
            }
        }

        private static SceneConfiguration getTestSceneConfiguration()
        {
            return new SceneConfiguration(31,
                new CastleObject(22, 0),
                new CastleObject(22, 30));
        }

        private static string getHpString(EcsEntity en)
        {
            return en.hp.Match(hp => hp.hp.ToString(), "");
        }
    }
}