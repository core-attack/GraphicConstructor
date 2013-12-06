namespace GraphicConstructor
{
    partial class RightClickOnTextBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RightClickOnTextBox));
            this.listBoxFunc = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxFunc
            // 
            this.listBoxFunc.FormattingEnabled = true;
            this.listBoxFunc.Location = new System.Drawing.Point(1, 2);
            this.listBoxFunc.Name = "listBoxFunc";
            this.listBoxFunc.Size = new System.Drawing.Size(133, 160);
            this.listBoxFunc.TabIndex = 0;
            this.listBoxFunc.SelectedIndexChanged += new System.EventHandler(this.listBoxFunc_SelectedIndexChanged);
            // 
            // RightClickOnTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(134, 161);
            this.Controls.Add(this.listBoxFunc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "RightClickOnTextBox";
            this.ShowIcon = false;
            this.Text = "RightClickOnTextBox";
            this.Click += new System.EventHandler(this.RightClickOnTextBox_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxFunc;

    }
}