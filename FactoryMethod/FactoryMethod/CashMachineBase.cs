using System;

namespace FactoryMethod
{
    /// <summary>
    /// ������� ����� ��� ��������� ������ �����.
    /// </summary>
    public abstract class CashMachineBase
    {
        /// <summary>
        /// �������� ����������.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// ������� ����� ��������� ���������� ������ �����.
        /// </summary>
        /// <param name="name"> ��������. </param>
        public CashMachineBase(string name)
        {
            // ��������� ������� ������ �� ������������.
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            // ������������� ��������.
            Name = name;
        }

        /// <summary>
        /// ���������� ����� ������ �����.
        /// </summary>
        /// <param name="pageCount"> ���������� ������ ������ ��� �����. </param>
        /// <returns> ������������ ������. </returns>
        public abstract MoneyBase[] Create(int pageCount);

        /// <summary>
        /// ���������� ������� � ������.
        /// </summary>
        /// <returns> ��������. </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}