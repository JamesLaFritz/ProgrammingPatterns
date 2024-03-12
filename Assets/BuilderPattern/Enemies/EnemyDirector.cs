#region Header

// EnemyDirector.cs
// 
// From [Warped Imagination](https://www.youtube.com/@WarpedImagination)

#endregion

using UnityEngine;

namespace BuilderPattern
{
    public class EnemyDirector
    {
        /// <summary>
        /// Builds an enemy with a weapon and health component, using the provided strategies for each of them 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Enemy Construct(EnemyBuilder builder, EnemyData data)
        {
            builder.AddWeaponComponent();
            builder.AddWeaponStrategy(data.WeaponStrategy);
            builder.AddHealthComponent();
            
            return builder.Build();

        }

        #region Private Static Methods

        internal static EnemyBuilder GetNewDefaultBuilder() => new EnemyBuilder(); 

        #endregion

    }

    public class EnemyBuilder
    {
        private Enemy m_enemy = new GameObject("Enemy").AddComponent<Enemy>();
        
        public void AddWeaponComponent()
        {
            m_enemy.gameObject.AddComponent<EnemyWeapon>();
        }

        public void AddWeaponStrategy(WeaponStrategy strategy)
        {
            if (m_enemy.gameObject.TryGetComponent<EnemyWeapon>(out var weapon))
            {
                weapon.SetWeaponStrategy(strategy);
            }
        }

        public void AddHealthComponent()
        {
            m_enemy.gameObject.AddComponent<Health>();
        }

        public Enemy Build()
        {
            Enemy builtEnemy = m_enemy;
            m_enemy = new GameObject("Enemy").AddComponent<Enemy>();

            return builtEnemy;
        }

    }
}