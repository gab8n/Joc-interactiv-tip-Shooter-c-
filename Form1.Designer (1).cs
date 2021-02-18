﻿namespace Shooter
{
    partial class FireShooter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FireShooter));
            this.timerGameLoop = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerGameLoop
            // 
            this.timerGameLoop.Tick += new System.EventHandler(this.timerGameLoop_Tick);
            // 
            // FireShooter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Shooter.Properties.Resources.Background;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1006, 527);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FireShooter";
            this.Text = "Shooter";
            this.Load += new System.EventHandler(this.FireShooter_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FireShooter_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FireShooter_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerGameLoop;
    }
}

