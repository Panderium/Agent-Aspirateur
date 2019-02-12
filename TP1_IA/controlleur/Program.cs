using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using TP1_IA.model;


namespace TP1_IA
{
    static class Program
    {
        private static Environnement env = null;
        private static Agent agent;
        private static Thread t = null;
        private static Thread t2 = null;
        private static Form1 form = null;

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {                
            form = new Form1();

            env = Environnement.Instance;
            agent = Agent.Instance;
            t = new Thread(env.generateStuff);
            t2 = new Thread(agent.run);
            t.Start();
            t2.Start();
            
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(form); */
                     
          
            
        }

        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        public static void updateUI()
        {
            
                form.updateUI();
           
        }
    }
    
}
