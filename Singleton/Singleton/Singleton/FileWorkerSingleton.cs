using System;


namespace SingletonCodeBlog
{
    /// <summary>
    /// ����� ��� ������ � �������. ���������� ��������� � ���� 
    /// ����������� ������ �� ������� Save.
    /// �� ����� ��������� �������� � ������������ ������.
    /// ���������� �������� ��������.
    /// </summary>
    public sealed class FileWorkerSingleton
    {
        /// <summary>
        /// �������� ����������� ���� ������, � ������� �������� ������������ ���������
        /// ������ ��������. ������������� ���������� ����������� ������ - �� ����
        /// ����� ����������� ������ ��� ������ ���������.
        /// ����� ������ ����������� �����������, ��� ��� ��������� �� ���������� ������� �����
        /// ������ ������ ���� ��������� ������.
        /// </summary>
        private static readonly Lazy<FileWorkerSingleton> instance =
            new Lazy<FileWorkerSingleton>(() => new FileWorkerSingleton());

        /// <summary>
        /// �������� �������� ��� ������� � ���������� ������ ��������.
        /// </summary>
        public static FileWorkerSingleton Instance { get { return instance.Value; } }

        /// <summary>
        /// ���� � ����� ������.
        /// </summary>
        public string FilePath { get; }

        /// <summary>
        /// ���������� ����� � ������������ ������.
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// ������� ����� ��������� ��� ������ � �������.
        /// ��� ����, ����� � ������������ ������ �� ���� ����������� ��������� 
        /// ����� ���������� ������ ����������� ���������� ������� ��������.
        /// </summary>
        private FileWorkerSingleton()
        {
            FilePath = "test2.txt";
            ReadTextFromFile();
        }

        /// <summary>
        /// �������� ����� � ���� (��� ���������� � ���������� ������).
        /// </summary>
        /// <param name="text"> ����������� �����. </param>
        public void WriteText(string text)
        {
            Text += text;
        }

        /// <summary>
        /// ��������� ����� � ����.
        /// </summary>
        public void Save()
        {
            using (var writer = new StreamWriter(FilePath, false))
            {
                writer.WriteLine(Text);
            }
        }

        /// <summary>
        /// ��������� ������ �� �����.
        /// </summary>
        private void ReadTextFromFile()
        {
            if (!File.Exists(FilePath))
            {
                Text = "";
            }
            else
            {
                using (var reader = new StreamReader(FilePath))
                {
                    Text = reader.ReadToEnd();
                }
            }
        }
    }
}