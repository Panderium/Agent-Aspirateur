using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TP1_IA
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        
        
        
        

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.uninformedSearch = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.informedSearch = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(619, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Score : ";
            // 
            // uninformedSearch
            // 
            this.uninformedSearch.AutoSize = true;
            this.uninformedSearch.ForeColor = System.Drawing.Color.White;
            this.uninformedSearch.Location = new System.Drawing.Point(622, 99);
            this.uninformedSearch.Name = "uninformedSearch";
            this.uninformedSearch.Size = new System.Drawing.Size(82, 17);
            this.uninformedSearch.TabIndex = 1;
            this.uninformedSearch.TabStop = true;
            this.uninformedSearch.Text = "Non-informé";
            this.uninformedSearch.UseVisualStyleBackColor = true;
            this.uninformedSearch.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(619, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Non-informé";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(619, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Informé";
            // 
            // informedSearch
            // 
            this.informedSearch.AutoSize = true;
            this.informedSearch.ForeColor = System.Drawing.Color.White;
            this.informedSearch.Location = new System.Drawing.Point(622, 183);
            this.informedSearch.Name = "informedSearch";
            this.informedSearch.Size = new System.Drawing.Size(60, 17);
            this.informedSearch.TabIndex = 3;
            this.informedSearch.TabStop = true;
            this.informedSearch.Text = "Informé";
            this.informedSearch.UseVisualStyleBackColor = true;
            this.informedSearch.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.informedSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uninformedSearch);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private RadioButton uninformedSearch;
        private Label label2;
        private Label label3;
        private RadioButton informedSearch;

        
    }
}

