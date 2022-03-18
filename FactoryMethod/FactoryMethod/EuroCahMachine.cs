using System;
using System.Collections.Generic;
using System.Linq;

namespace FactoryMethod
{
    /// <summary>
    /// ���������� ��� ������ ���������� ������.
    /// </summary>
    public class EuroCashMachine : CashMachineBase
    {
        /// <summary>
        /// ���������� ����� �� ����� ����� ������.
        /// </summary>
        private readonly int _countOnPage = 100 ;

        /// <summary>
        /// ������� ������.
        /// </summary>
        private int _denomination;

        /// <summary>
        /// ��������� �������� ������.
        /// </summary>
        private int[] _correntDenomination = { 5, 10, 20, 50, 100, 500, 1000 };

        /// <summary>
        /// ������� ����� ��������� ���������� ��� ������ ���������� ������.
        /// </summary>
        /// <param name="denomination"> �������. </param>
        public EuroCashMachine(int denomination = 100)
            : base("Euro printer")
        {
            // ��������� ������� ������ �� ������������.
            if (denomination <= 0)
            {
                throw new ArgumentException("The currency denomination must be greater than zero.", nameof(denomination));
            }

            if (!_correntDenomination.Contains(denomination))
            {
                throw new ArgumentException($"Incorrect currency denomination.", nameof(denomination));
            }

            // ������������� ��������.
            _denomination = denomination;
        }

        /// <inheritdoc />
        public override MoneyBase[] Create(int pageCount)
        {
            // ������������ ���������� �����, ������� ������ ���� ����������.
            var count = _countOnPage * pageCount;

            // ������� ��������� ��� ���������� �����.
            var money = new List<MoneyBase>();

            // ������� ������ � ��������� � ���������.
            for (var i = 0; i < count; i++)
            {
                var euro = new Euro(_denomination);
                money.Add(euro);
            }

            // ���������� ������� ������.
            return money.ToArray();
        }
    }
}