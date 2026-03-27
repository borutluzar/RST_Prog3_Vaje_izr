namespace RST_Prog3_Vaje_izr
{
    internal class Program
    {
        enum Tutorial
        {
            Tutorial_01 = 1,  // 26. 3. 2026
            Tutorial_02 = 2,  //  8. 4. 2026
            Tutorial_03 = 3,  // 16. 4. 2026
            Tutorial_04 = 4,  // 22. 4. 2026
            Tutorial_05 = 5,  // 23. 4. 2026
            Tutorial_06 = 6,  //  5. 5. 2026
            Tutorial_07 = 7,  // 11. 5. 2026
        }

        static void Main(string[] args)
        {
            switch (InterfaceFunctions.ChooseOption<Tutorial>())
            {
                case Tutorial.Tutorial_01:
                    {
                        Tutorials_01.Exercise_324();
                    }
                    break;
            }
        }
    }
}
