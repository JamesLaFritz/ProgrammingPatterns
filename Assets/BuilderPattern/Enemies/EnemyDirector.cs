#region Header

// EnemyDirector.cs
// 
// From [Warped Imagination](https://www.youtube.com/@WarpedImagination)

#endregion

using UnityEngine;

namespace BuilderPattern
{

    public interface IEnemyBuilder
    {
        IWeaponEnemyBuilder AddWeaponComponent();
    }

    public interface IWeaponEnemyBuilder
    {
        IHealthEnemyBuilder AddWeaponStrategy(WeaponStrategy strategy);
    }

    public interface IHealthEnemyBuilder
    {
        IFinalEnemyBuilder AddHealthComponent();
    }

    public interface IFinalEnemyBuilder
    {
        Enemy Build();
    }

    public class EnemyDirector
    {
        public IEnemyBuilder m_builder;
        public EnemyDirector(EnemyBuilder builder)
        {
            m_builder = builder;
        }

        /// <summary>
        /// Builds an enemy with a weapon and health component, using the provided strategies for each of them 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Enemy Construct(EnemyData data)
        {
            return m_builder
                .AddWeaponComponent()
                .AddWeaponStrategy(data.WeaponStrategy)
                .AddHealthComponent()
                .Build();
        }
        
    }
    
    public class EnemyBuilder : IEnemyBuilder, IWeaponEnemyBuilder, IHealthEnemyBuilder, IFinalEnemyBuilder
    {
        private Enemy m_enemy = new GameObject("Enemy").AddComponent<Enemy>();
        
        public IWeaponEnemyBuilder AddWeaponComponent()
        {
            m_enemy.gameObject.AddComponent<EnemyWeapon>();
            return this;
        }

        public IHealthEnemyBuilder AddWeaponStrategy(WeaponStrategy strategy)
        {
            if (m_enemy.gameObject.TryGetComponent<EnemyWeapon>(out var weapon))
                weapon.SetWeaponStrategy(strategy);

            return this;
        }

        public IFinalEnemyBuilder AddHealthComponent()
        {
            m_enemy.gameObject.AddComponent<Health>();
            return this;
        }

        public Enemy Build()
        {
            Enemy builtEnemy = m_enemy;
            m_enemy = new GameObject("Enemy").AddComponent<Enemy>();

            return builtEnemy;
        }

    }
}