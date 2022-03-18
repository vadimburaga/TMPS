using System;

namespace FactoryMethod
{
    /// <summary>
    /// ������� ����� ��� ����� ������.
    /// </summary>
    public abstract class MoneyBase
    {
        /// <summary>
        /// �������� ������.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// ������ ������.
        /// </summary>
        public string Symbol { get; protected set; }

        /// <summary>
        /// ������� ����� ��������� ������.
        /// </summary>
        /// <param name="name"> �������� ������. </param>
        /// <param name="symbol"> ������ ������. </param>
        public MoneyBase(string name, string symbol)
        {
            // ��������� ������� ������ �� ������������.
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (string.IsNullOrEmpty(symbol))
            {
                throw new ArgumentNullException(nameof(symbol));
            }

            // ������������� ��������.
            Name = name;
            Symbol = symbol;
        }

        /// <summary>
        /// ���������� ������� � ������. 
        /// </summary>
        /// <returns> �������� ������. </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}