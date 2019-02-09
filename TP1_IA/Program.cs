using System;
using System.Threading;
using System.Windows.Forms;
using TP1_IA.model;
using TP1_IA.strategy;

namespace TP1_IA
{
    static class Program
    {
        
        static Environnement env = Environnement.Instance;
        static Thread t = new Thread(env.generateStuff);
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
        Arbre a = new Arbre();
        a.build(new Coordonnees(5, 5),new Connaissances());
        Console.WriteLine(a);



        
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
       

        }
    }
}
