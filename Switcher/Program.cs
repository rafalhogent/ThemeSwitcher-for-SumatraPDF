

namespace Switcher;

class Program
{

    private static string localPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

    private static string settPath = localPath + @"\SumatraPDF\SumatraPDF-settings.txt";
    private static string lightPath = localPath + @"\SumatraPDF\SumatraPDF-settings_LIGHT.txt";
    private static string darkPath = localPath + @"\SumatraPDF\SumatraPDF-settings_DARK.txt";
    private static string switchPath = localPath + @"\SumatraPDF\switch.txt";

    static void Main(string[] args)
    {




        //Console.WriteLine(localPath + "   " + settPath);
        //Console.WriteLine(settPath);



        if (File.Exists(settPath))
        {

            if (!File.Exists(switchPath)) File.WriteAllText(switchPath, "");
            string currentTheme = File.ReadAllText(switchPath);

            if (args.Length == 0)
            {
                
                if (currentTheme.ToUpper() != "DARK")
                {
                    SwitchTheme("DARK");
                }
                else
                {
                    SwitchTheme("LIGHT");
                }
            
            }
            else
            {
                if (args[0].ToUpper() == "D") { SwitchTheme("DARK"); return; }
                if (args[0].ToUpper() == "L") { SwitchTheme("LIGHT"); return; }
            }





        }
    }

    private static void SwitchTheme(string theme = "")
    {

        File.WriteAllText(switchPath, theme);

        if (theme.ToUpper() == "DARK")
        {
            if (File.Exists(darkPath))
            {
                File.Copy(darkPath, settPath, true);
            }
            return;
        }
                
        if (theme.ToUpper() == "LIGHT")
        {
            if (File.Exists(lightPath))
            {
                File.Copy(lightPath, settPath, true);
            }
            return;
        }
    }



    private static void SwitchToDark()
    {
        File.WriteAllText(switchPath, "DARK");
        if (File.Exists(darkPath))
        {
            File.Copy(darkPath, settPath, true);
        }
    }

    private static void SwitchToLight()
    {
        File.WriteAllText(switchPath, "LIGHT");
        if (File.Exists(darkPath))
        {
            //File.Delete(settPath);
            File.Copy(lightPath, settPath, true);
        }
    }



}












//Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));

