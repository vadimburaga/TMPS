using System;
using System.Collections.Generic;
using System.Linq;

namespace FactoryMethod
{
    /// <summary>
    /// Устройство для печати российских рублей.
    /// </summary>
    public class EuroCashMachine : CashMachineBase
    {
        /// <summary>
        /// Количество купюр на одном листе бумаги.
        /// </summary>
        private readonly int _countOnPage = 100 ;

        /// <summary>
        /// Номинал купюры.
        /// </summary>
        private int _denomination;

        /// <summary>
        /// Возможные номиналы валюты.
        /// </summary>
        private int[] _correntDenomination = { 5, 10, 20, 50, 100, 500, 1000 };

        /// <summary>
        /// Создать новый экземпляр устройства для печати российских рублей.
        /// </summary>
        /// <param name="denomination"> Номинал. </param>
        public EuroCashMachine(int denomination = 100)
            : base("Euro printer")
        {
            // Проверяем входные данные на корректность.
            if (denomination <= 0)
            {
                throw new ArgumentException("The currency denomination must be greater than zero.", nameof(denomination));
            }

            if (!_correntDenomination.Contains(denomination))
            {
                throw new ArgumentException($"Incorrect currency denomination.", nameof(denomination));
            }

            // Устанавливаем значение.
            _denomination = denomination;
        }

        /// <inheritdoc />
        public override MoneyBase[] Create(int pageCount)
        {
            // Подсчитываем количество денег, которое должно быть напечатано.
            var count = _countOnPage * pageCount;

            // Создаем коллекцию для сохранения денег.
            var money = new List<MoneyBase>();

            // Создаем деньги и добавляем в коллекцию.
            for (var i = 0; i < count; i++)
            {
                var euro = new Euro(_denomination);
                money.Add(euro);
            }

            // Возвращаем готовые деньги.
            return money.ToArray();
        }
    }
}