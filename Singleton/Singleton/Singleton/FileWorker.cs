using System;


namespace SingletonCodeBlog
{
    /// <summary>
    /// ����� ��� ������ � �������. ���������� ��������� � ���� 
    /// ����������� ������ �� ������� Save.
    /// �� ����� ��������� �������� � ������������ ������.
    /// </summary>
    public class FileWorker
    {
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
        /// </summary>
        public FileWorker()
        {
            FilePath = "test.txt";
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