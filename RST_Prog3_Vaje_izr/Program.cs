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

                case Tutorial.Tutorial_02:
                    {
                        switch (InterfaceFunctions.ChooseOption<Tutorials_02.Exercises>())
                        {
                            case Tutorials_02.Exercises.Exercise_574:
                                {
                                    Tutorials_02.Exercise_574();
                                }
                                break;
                            
                            case Tutorials_02.Exercises.Exercise_575:
                                {
                                    Tutorials_02.Exercise_575();
                                }
                                break;
                        }                        
                    }
                    break;

                case Tutorial.Tutorial_04:
                    {
                        switch (InterfaceFunctions.ChooseOption<Tutorials_04.Exercises>())
                        {
                            case Tutorials_04.Exercises.Exercise_1022:
                                {
                                    Tutorials_04.Exercise_1022();
                                }
                                break;
                            case Tutorials_04.Exercises.Exercise_1121:
                                {
                                    Tutorials_04.Exercise_1121();
                                }
                                break;
                        }
                    }
                    break;

                case Tutorial.Tutorial_06:
                    {
                        switch (InterfaceFunctions.ChooseOption<Tutorials_06.Exercises>())
                        {
                            case Tutorials_06.Exercises.Exercise_1421:
                                {
                                    Tutorials_06.Exercise_1421();
                                }
                                break;
                            case Tutorials_06.Exercises.Exercise_823:
                                {
                                    Tutorials_06.Exercise_823();
                                }
                                break;
                            case Tutorials_06.Exercises.Exercise_1521:
                                {
                                    Tutorials_06.Exercise_1521();
                                }
                                break;
                            case Tutorials_06.Exercises.Exercise_1522:
                                {
                                    Tutorials_06.Exercise_1522();
                                }
                                break;
                        }
                    }
                    break;
            }
            
            Console.ReadLine();
        }
    }
}
