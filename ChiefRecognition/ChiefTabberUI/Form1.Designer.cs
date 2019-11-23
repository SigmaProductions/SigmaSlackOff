namespace ChiefTabberUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.CheckboxHackerTyper = new System.Windows.Forms.CheckBox();
            this.CheckboxPlayKeyboardSound = new System.Windows.Forms.CheckBox();
            this.CheckboxCommit = new System.Windows.Forms.CheckBox();
            this.ButtonCommit = new System.Windows.Forms.Button();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(-28, -57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(524, 371);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(245, 51);
            this.button2.TabIndex = 1;
            this.button2.Text = "Connect tabber do detector";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CheckboxHackerTyper
            // 
            this.CheckboxHackerTyper.AutoSize = true;
            this.CheckboxHackerTyper.Location = new System.Drawing.Point(74, 79);
            this.CheckboxHackerTyper.Name = "CheckboxHackerTyper";
            this.CheckboxHackerTyper.Size = new System.Drawing.Size(166, 24);
            this.CheckboxHackerTyper.TabIndex = 2;
            this.CheckboxHackerTyper.Text = "Display HackerTyper";
            this.CheckboxHackerTyper.UseVisualStyleBackColor = true;
            // 
            // CheckboxPlayKeyboardSound
            // 
            this.CheckboxPlayKeyboardSound.AutoSize = true;
            this.CheckboxPlayKeyboardSound.Location = new System.Drawing.Point(74, 124);
            this.CheckboxPlayKeyboardSound.Name = "CheckboxPlayKeyboardSound";
            this.CheckboxPlayKeyboardSound.Size = new System.Drawing.Size(168, 24);
            this.CheckboxPlayKeyboardSound.TabIndex = 3;
            this.CheckboxPlayKeyboardSound.Text = "Play keyboard sound";
            this.CheckboxPlayKeyboardSound.UseVisualStyleBackColor = true;
            // 
            // CheckboxCommit
            // 
            this.CheckboxCommit.AutoSize = true;
            this.CheckboxCommit.Location = new System.Drawing.Point(74, 164);
            this.CheckboxCommit.Name = "CheckboxCommit";
            this.CheckboxCommit.Size = new System.Drawing.Size(128, 24);
            this.CheckboxCommit.TabIndex = 4;
            this.CheckboxCommit.Text = "Make commits";
            this.CheckboxCommit.UseVisualStyleBackColor = true;
            // 
            // ButtonCommit
            // 
            this.ButtonCommit.Location = new System.Drawing.Point(74, 371);
            this.ButtonCommit.Name = "ButtonCommit";
            this.ButtonCommit.Size = new System.Drawing.Size(241, 51);
            this.ButtonCommit.TabIndex = 5;
            this.ButtonCommit.Text = "Make random commit";
            this.ButtonCommit.UseVisualStyleBackColor = true;
            this.ButtonCommit.Click += new System.EventHandler(this.ButtonCommit_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ButtonCommit);
            this.Controls.Add(this.CheckboxCommit);
            this.Controls.Add(this.CheckboxPlayKeyboardSound);
            this.Controls.Add(this.CheckboxHackerTyper);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxTimeMinimized;
        private System.Windows.Forms.CheckBox CheckboxHackerTyper;
        private System.Windows.Forms.CheckBox CheckboxPlayKeyboardSound;
        private System.Windows.Forms.CheckBox CheckboxCommit;
        private System.Windows.Forms.Button ButtonCommit;
    }
}

