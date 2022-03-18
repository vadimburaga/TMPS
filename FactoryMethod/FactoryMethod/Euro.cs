using System;

namespace FactoryMethod
{
    /// <summary>
    /// Российский рубль.
    /// </summary>
    public class Euro : MoneyBase
    {
        /// <summary>
        /// Номер.
        /// </summary>
        public int Number { get; private set; }

        /// <summary>
        /// Номинал валюты.
        /// </summary>
        public int Denomination { get; private set; }

        /// <summary>
        /// Создать новый экземпляр рубля.
        /// </summary>
        /// <param name="denomination"> Номинал валюты. </param>
        public Euro(int denomination)
            : base("Euro", "€")
        {
            // Проверяем входные данные на корректность.
            if (denomination <= 0)
            {
                throw new ArgumentException("The currency denomination must be greater than zero.", nameof(denomination));
            }

            // Создаем генератор случайных чисел.
            var rnd = new Random();

            // Устанавливаем значения.
            Number = rnd.Next(1000000, 9999999);
            Denomination = denomination;
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns> Информация о купюре. </returns>
        public override string ToString()
        {
            return $"{Name} {Number} denomination {Denomination}{Symbol}";
        }
    }
}