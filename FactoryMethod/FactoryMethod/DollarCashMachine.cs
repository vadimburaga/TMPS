using System;
using System.Collections.Generic;
using System.Linq;

namespace FactoryMethod
{
    public class DollarCashMachine : CashMachineBase
    {
        /// <summary>
        /// ������� ������.
        /// </summary>
        private int _denomination;

        /// <summary>
        /// ������� ����� ��������� ���������� ��� ������ ������������ ��������.
        /// </summary>
        /// <param name="denomination"> �������. </param>
        public DollarCashMachine(int denomination = 5)
            : base("Dollar printer")
        {
            // ��������� ������� ������ �� ������������.
            if (denomination <= 0)
            {
                throw new ArgumentException("The currency denomination must be greater than zero", nameof(denomination));
            }

            // ��������� �������� ������.
            var correntDenomination = new int[] { 5, 10, 50, 100, 500, 1000 };

            // ��������� ������������ ��������.
            if (!correntDenomination.Contains(denomination))
            {
                throw new ArgumentException($"Incorrect currency denomination.", nameof(denomination));
            }

            // ������������� ��������.
            _denomination = denomination;
        }

        /// <inheritdoc />
        public override MoneyBase[] Create(int pageCount)
        {
            // ���������� ����� �� ����� ����� ������.
            var countOnPage = 50;

            // ������������ ���������� �����, ������� ������ ���� ����������.
            var count = countOnPage * pageCount;

            // ������� ��������� ��� ���������� �����.
            var money = new List<MoneyBase>();

            // ������� ������ � ��������� � ���������.
            for (var i = 0; i < count; i++)
            {
                var dollar = new Dollar(_denomination);
                money.Add(dollar);
            }

            // ���������� ������� ������.
            return money.ToArray();
        }
    }
}