using System;

namespace FactoryMethod
{
    /// <summary>
    /// ������������ ������.
    /// </summary>
    public class Dollar : MoneyBase
    {
        /// <summary>
        /// ���������� ���.
        /// </summary>
        public Guid Number { get; private set; }

        /// <summary>
        /// ������� ������.
        /// </summary>
        public int Volume { get; private set; }

        /// <summary>
        /// ������� ����� ��������� ������������� �������.
        /// </summary>
        /// <param name="volume"> �������. </param>
        public Dollar(int volume)
            : base("American dollar", "$")
        {
            // ��������� ������� ������ �� ������������.
            if (volume <= 0)
            {
                throw new ArgumentException("The currency denomination must be greater than zero.", nameof(volume));
            }

            Number = Guid.NewGuid();
            Volume = volume;
        }

        /// <summary>
        /// ���������� ������� � ������.
        /// </summary>
        /// <returns> ���������� � ������. </returns>
        public override string ToString()
        {
            return $"{Name} {Number} denomination {Volume}{Symbol}";
        }
    }
}