namespace MemeMaker
{
    partial class TenorGifSearchForm
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
            gifSearchBox = new TextBox();
            gifFlowLayoutPanel = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // gifSearchBox
            // 
            gifSearchBox.Location = new Point(12, 12);
            gifSearchBox.Name = "gifSearchBox";
            gifSearchBox.PlaceholderText = "Search tenor gifs";
            gifSearchBox.Size = new Size(700, 23);
            gifSearchBox.TabIndex = 0;
            // 
            // gifFlowLayoutPanel
            // 
            gifFlowLayoutPanel.AutoScroll = true;
            gifFlowLayoutPanel.Location = new Point(12, 41);
            gifFlowLayoutPanel.Name = "gifFlowLayoutPanel";
            gifFlowLayoutPanel.Size = new Size(700, 397);
            gifFlowLayoutPanel.TabIndex = 1;
            // 
            // TenorGifSearchForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 450);
            Controls.Add(gifFlowLayoutPanel);
            Controls.Add(gifSearchBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TenorGifSearchForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TenorGifSearchForm";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox gifSearchBox;
        private FlowLayoutPanel gifFlowLayoutPanel;
    }
}