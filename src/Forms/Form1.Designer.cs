namespace MemeMaker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tenorGifButton = new Button();
            uploadImageButton = new Button();
            captionTextBox = new TextBox();
            fontSizeSlider = new TrackBar();
            label2 = new Label();
            label3 = new Label();
            boldTextButton = new Button();
            justifyTextButton = new Button();
            label4 = new Label();
            fontComboBox = new ComboBox();
            panel1 = new Panel();
            captionText = new Label();
            selectedGifPictureBox = new PictureBox();
            exportGifButton = new Button();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)fontSizeSlider).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)selectedGifPictureBox).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // tenorGifButton
            // 
            tenorGifButton.BackColor = Color.Gray;
            tenorGifButton.FlatAppearance.BorderSize = 0;
            tenorGifButton.FlatStyle = FlatStyle.Flat;
            tenorGifButton.Font = new Font("Segoe UI", 20.25F);
            tenorGifButton.ForeColor = Color.White;
            tenorGifButton.Location = new Point(6, 7);
            tenorGifButton.Name = "tenorGifButton";
            tenorGifButton.Size = new Size(140, 60);
            tenorGifButton.TabIndex = 1;
            tenorGifButton.Text = "Tenor Gif";
            tenorGifButton.UseCompatibleTextRendering = true;
            tenorGifButton.UseVisualStyleBackColor = false;
            tenorGifButton.Click += tenorGifButton_Click;
            // 
            // uploadImageButton
            // 
            uploadImageButton.BackColor = Color.Gray;
            uploadImageButton.FlatAppearance.BorderSize = 0;
            uploadImageButton.FlatStyle = FlatStyle.Flat;
            uploadImageButton.Font = new Font("Segoe UI", 20.25F);
            uploadImageButton.ForeColor = Color.White;
            uploadImageButton.Location = new Point(152, 7);
            uploadImageButton.Name = "uploadImageButton";
            uploadImageButton.Size = new Size(127, 60);
            uploadImageButton.TabIndex = 2;
            uploadImageButton.Text = "Upload";
            uploadImageButton.UseCompatibleTextRendering = true;
            uploadImageButton.UseVisualStyleBackColor = false;
            uploadImageButton.Click += uploadImageButton_Click;
            // 
            // captionTextBox
            // 
            captionTextBox.BackColor = Color.Silver;
            captionTextBox.Enabled = false;
            captionTextBox.ForeColor = Color.Black;
            captionTextBox.Location = new Point(6, 73);
            captionTextBox.Multiline = true;
            captionTextBox.Name = "captionTextBox";
            captionTextBox.PlaceholderText = "Enter caption here";
            captionTextBox.Size = new Size(273, 171);
            captionTextBox.TabIndex = 3;
            captionTextBox.TextChanged += captionTextBox_TextChanged;
            // 
            // fontSizeSlider
            // 
            fontSizeSlider.Enabled = false;
            fontSizeSlider.Location = new Point(57, 314);
            fontSizeSlider.Maximum = 100;
            fontSizeSlider.Minimum = 12;
            fontSizeSlider.Name = "fontSizeSlider";
            fontSizeSlider.Size = new Size(222, 45);
            fontSizeSlider.TabIndex = 4;
            fontSizeSlider.Value = 12;
            fontSizeSlider.Scroll += fontSizeSlider_Scroll;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(10, 314);
            label2.Name = "label2";
            label2.Size = new Size(38, 21);
            label2.TabIndex = 6;
            label2.Text = "Size";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(10, 370);
            label3.Name = "label3";
            label3.Size = new Size(43, 21);
            label3.TabIndex = 7;
            label3.Text = "Style";
            // 
            // boldTextButton
            // 
            boldTextButton.BackColor = Color.Silver;
            boldTextButton.FlatAppearance.BorderSize = 0;
            boldTextButton.FlatStyle = FlatStyle.Flat;
            boldTextButton.Font = new Font("Segoe UI", 9.75F);
            boldTextButton.ForeColor = Color.LightGray;
            boldTextButton.Location = new Point(57, 362);
            boldTextButton.Name = "boldTextButton";
            boldTextButton.Size = new Size(110, 40);
            boldTextButton.TabIndex = 8;
            boldTextButton.Text = "Bold";
            boldTextButton.UseCompatibleTextRendering = true;
            boldTextButton.UseVisualStyleBackColor = false;
            boldTextButton.Click += boldTextButton_Click;
            // 
            // justifyTextButton
            // 
            justifyTextButton.BackColor = Color.Silver;
            justifyTextButton.FlatAppearance.BorderSize = 0;
            justifyTextButton.FlatStyle = FlatStyle.Flat;
            justifyTextButton.Font = new Font("Segoe UI", 9.75F);
            justifyTextButton.ForeColor = Color.LightGray;
            justifyTextButton.Location = new Point(169, 362);
            justifyTextButton.Name = "justifyTextButton";
            justifyTextButton.Size = new Size(110, 40);
            justifyTextButton.TabIndex = 9;
            justifyTextButton.Text = "Justify: Left";
            justifyTextButton.UseCompatibleTextRendering = true;
            justifyTextButton.UseVisualStyleBackColor = false;
            justifyTextButton.Click += justifyTextButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(10, 270);
            label4.Name = "label4";
            label4.Size = new Size(41, 21);
            label4.TabIndex = 10;
            label4.Text = "Font";
            // 
            // fontComboBox
            // 
            fontComboBox.BackColor = Color.Gray;
            fontComboBox.Enabled = false;
            fontComboBox.FlatStyle = FlatStyle.Flat;
            fontComboBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fontComboBox.ForeColor = Color.White;
            fontComboBox.FormattingEnabled = true;
            fontComboBox.Items.AddRange(new object[] { "Helvetica", "Impact" });
            fontComboBox.Location = new Point(57, 270);
            fontComboBox.Name = "fontComboBox";
            fontComboBox.Size = new Size(222, 23);
            fontComboBox.TabIndex = 11;
            fontComboBox.SelectedIndexChanged += fontComboBox_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.LightGray;
            panel1.BackgroundImage = Properties.Resources.preview_watermark;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(captionText);
            panel1.Controls.Add(selectedGifPictureBox);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(752, 602);
            panel1.TabIndex = 12;
            // 
            // captionText
            // 
            captionText.BackColor = Color.White;
            captionText.Location = new Point(3, 7);
            captionText.Name = "captionText";
            captionText.Size = new Size(72, 25);
            captionText.TabIndex = 1;
            captionText.Text = "Caption";
            captionText.TextAlign = ContentAlignment.MiddleLeft;
            captionText.Visible = false;
            // 
            // selectedGifPictureBox
            // 
            selectedGifPictureBox.Location = new Point(3, 35);
            selectedGifPictureBox.Name = "selectedGifPictureBox";
            selectedGifPictureBox.Size = new Size(72, 50);
            selectedGifPictureBox.TabIndex = 0;
            selectedGifPictureBox.TabStop = false;
            selectedGifPictureBox.Visible = false;
            // 
            // exportGifButton
            // 
            exportGifButton.BackColor = Color.Silver;
            exportGifButton.FlatAppearance.BorderSize = 0;
            exportGifButton.FlatStyle = FlatStyle.Flat;
            exportGifButton.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            exportGifButton.ForeColor = Color.LightGray;
            exportGifButton.Location = new Point(10, 523);
            exportGifButton.Name = "exportGifButton";
            exportGifButton.Size = new Size(269, 76);
            exportGifButton.TabIndex = 13;
            exportGifButton.Text = "Export GIF";
            exportGifButton.UseCompatibleTextRendering = true;
            exportGifButton.UseVisualStyleBackColor = false;
            exportGifButton.Click += exportGifButton_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel2.Controls.Add(captionTextBox);
            panel2.Controls.Add(exportGifButton);
            panel2.Controls.Add(tenorGifButton);
            panel2.Controls.Add(uploadImageButton);
            panel2.Controls.Add(fontComboBox);
            panel2.Controls.Add(fontSizeSlider);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(justifyTextButton);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(boldTextButton);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(770, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(286, 602);
            panel2.TabIndex = 14;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1068, 626);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MemeMaker";
            SizeChanged += Form1_SizeChanged;
            ((System.ComponentModel.ISupportInitialize)fontSizeSlider).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)selectedGifPictureBox).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button tenorGifButton;
        private Button uploadImageButton;
        private TextBox captionTextBox;
        private TrackBar fontSizeSlider;
        private Label label2;
        private Label label3;
        private Button boldTextButton;
        private Button justifyTextButton;
        private Label label4;
        private ComboBox fontComboBox;
        private Panel panel1;
        private Label captionText;
        private PictureBox selectedGifPictureBox;
        private Button exportGifButton;
        private Panel panel2;
    }
}
