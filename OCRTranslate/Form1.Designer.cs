namespace OCRTranslate
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox_Control = new System.Windows.Forms.GroupBox();
            this.label_Arrow = new System.Windows.Forms.Label();
            this.comboBox_LanguageTrans = new System.Windows.Forms.ComboBox();
            this.button_AreaSet = new System.Windows.Forms.Button();
            this.checkBox_Language = new System.Windows.Forms.CheckBox();
            this.comboBox_Language = new System.Windows.Forms.ComboBox();
            this.groupBox_Extract = new System.Windows.Forms.GroupBox();
            this.label_ErrorExtract = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.pictureBox_Extract = new System.Windows.Forms.PictureBox();
            this.textBox_Extract = new System.Windows.Forms.TextBox();
            this.groupBox_Translate = new System.Windows.Forms.GroupBox();
            this.label_ErrorTranslate = new System.Windows.Forms.Label();
            this.textBox_Translate = new System.Windows.Forms.TextBox();
            this.timer_Image = new System.Windows.Forms.Timer(this.components);
            this.button_TimerImage = new System.Windows.Forms.Button();
            this.groupBox_Control.SuspendLayout();
            this.groupBox_Extract.SuspendLayout();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Extract)).BeginInit();
            this.groupBox_Translate.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_Control
            // 
            this.groupBox_Control.Controls.Add(this.button_TimerImage);
            this.groupBox_Control.Controls.Add(this.label_Arrow);
            this.groupBox_Control.Controls.Add(this.comboBox_LanguageTrans);
            this.groupBox_Control.Controls.Add(this.button_AreaSet);
            this.groupBox_Control.Controls.Add(this.checkBox_Language);
            this.groupBox_Control.Controls.Add(this.comboBox_Language);
            this.groupBox_Control.Location = new System.Drawing.Point(12, 12);
            this.groupBox_Control.Name = "groupBox_Control";
            this.groupBox_Control.Size = new System.Drawing.Size(445, 69);
            this.groupBox_Control.TabIndex = 0;
            this.groupBox_Control.TabStop = false;
            this.groupBox_Control.Text = "Control";
            // 
            // label_Arrow
            // 
            this.label_Arrow.AutoSize = true;
            this.label_Arrow.Location = new System.Drawing.Point(133, 45);
            this.label_Arrow.Name = "label_Arrow";
            this.label_Arrow.Size = new System.Drawing.Size(17, 12);
            this.label_Arrow.TabIndex = 0;
            this.label_Arrow.Text = "▶";
            // 
            // comboBox_LanguageTrans
            // 
            this.comboBox_LanguageTrans.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_LanguageTrans.FormattingEnabled = true;
            this.comboBox_LanguageTrans.Items.AddRange(new object[] {
            "영어 (미국)",
            "한국어",
            "일본어"});
            this.comboBox_LanguageTrans.Location = new System.Drawing.Point(156, 42);
            this.comboBox_LanguageTrans.Name = "comboBox_LanguageTrans";
            this.comboBox_LanguageTrans.Size = new System.Drawing.Size(121, 20);
            this.comboBox_LanguageTrans.TabIndex = 3;
            this.comboBox_LanguageTrans.SelectedIndexChanged += new System.EventHandler(this.comboBox_LanguageTrans_SelectedIndexChanged);
            // 
            // button_AreaSet
            // 
            this.button_AreaSet.Location = new System.Drawing.Point(283, 40);
            this.button_AreaSet.Name = "button_AreaSet";
            this.button_AreaSet.Size = new System.Drawing.Size(75, 23);
            this.button_AreaSet.TabIndex = 4;
            this.button_AreaSet.Text = "Area Set";
            this.button_AreaSet.UseVisualStyleBackColor = true;
            this.button_AreaSet.Click += new System.EventHandler(this.button_AreaSet_Click);
            // 
            // checkBox_Language
            // 
            this.checkBox_Language.AutoSize = true;
            this.checkBox_Language.Location = new System.Drawing.Point(6, 20);
            this.checkBox_Language.Name = "checkBox_Language";
            this.checkBox_Language.Size = new System.Drawing.Size(110, 16);
            this.checkBox_Language.TabIndex = 1;
            this.checkBox_Language.Text = "User Language";
            this.checkBox_Language.UseVisualStyleBackColor = true;
            this.checkBox_Language.CheckedChanged += new System.EventHandler(this.checkBox_Language_CheckedChanged);
            // 
            // comboBox_Language
            // 
            this.comboBox_Language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Language.FormattingEnabled = true;
            this.comboBox_Language.Location = new System.Drawing.Point(6, 42);
            this.comboBox_Language.Name = "comboBox_Language";
            this.comboBox_Language.Size = new System.Drawing.Size(121, 20);
            this.comboBox_Language.TabIndex = 2;
            this.comboBox_Language.SelectedIndexChanged += new System.EventHandler(this.comboBox_Language_SelectedIndexChanged);
            // 
            // groupBox_Extract
            // 
            this.groupBox_Extract.Controls.Add(this.label_ErrorExtract);
            this.groupBox_Extract.Controls.Add(this.panel);
            this.groupBox_Extract.Controls.Add(this.textBox_Extract);
            this.groupBox_Extract.Location = new System.Drawing.Point(12, 189);
            this.groupBox_Extract.Name = "groupBox_Extract";
            this.groupBox_Extract.Size = new System.Drawing.Size(760, 360);
            this.groupBox_Extract.TabIndex = 0;
            this.groupBox_Extract.TabStop = false;
            this.groupBox_Extract.Text = "Extract";
            // 
            // label_ErrorExtract
            // 
            this.label_ErrorExtract.AutoSize = true;
            this.label_ErrorExtract.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_ErrorExtract.ForeColor = System.Drawing.Color.Red;
            this.label_ErrorExtract.Location = new System.Drawing.Point(50, 0);
            this.label_ErrorExtract.Name = "label_ErrorExtract";
            this.label_ErrorExtract.Size = new System.Drawing.Size(42, 12);
            this.label_ErrorExtract.TabIndex = 0;
            this.label_ErrorExtract.Text = "Error!";
            this.label_ErrorExtract.Visible = false;
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.Controls.Add(this.pictureBox_Extract);
            this.panel.Location = new System.Drawing.Point(6, 96);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(748, 258);
            this.panel.TabIndex = 0;
            // 
            // pictureBox_Extract
            // 
            this.pictureBox_Extract.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Extract.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_Extract.Name = "pictureBox_Extract";
            this.pictureBox_Extract.Size = new System.Drawing.Size(748, 258);
            this.pictureBox_Extract.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_Extract.TabIndex = 6;
            this.pictureBox_Extract.TabStop = false;
            // 
            // textBox_Extract
            // 
            this.textBox_Extract.Location = new System.Drawing.Point(6, 20);
            this.textBox_Extract.Multiline = true;
            this.textBox_Extract.Name = "textBox_Extract";
            this.textBox_Extract.ReadOnly = true;
            this.textBox_Extract.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Extract.Size = new System.Drawing.Size(748, 70);
            this.textBox_Extract.TabIndex = 6;
            this.textBox_Extract.TabStop = false;
            // 
            // groupBox_Translate
            // 
            this.groupBox_Translate.Controls.Add(this.label_ErrorTranslate);
            this.groupBox_Translate.Controls.Add(this.textBox_Translate);
            this.groupBox_Translate.Location = new System.Drawing.Point(12, 87);
            this.groupBox_Translate.Name = "groupBox_Translate";
            this.groupBox_Translate.Size = new System.Drawing.Size(760, 96);
            this.groupBox_Translate.TabIndex = 0;
            this.groupBox_Translate.TabStop = false;
            this.groupBox_Translate.Text = "Translate";
            // 
            // label_ErrorTranslate
            // 
            this.label_ErrorTranslate.AutoSize = true;
            this.label_ErrorTranslate.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_ErrorTranslate.ForeColor = System.Drawing.Color.Red;
            this.label_ErrorTranslate.Location = new System.Drawing.Point(63, 0);
            this.label_ErrorTranslate.Name = "label_ErrorTranslate";
            this.label_ErrorTranslate.Size = new System.Drawing.Size(42, 12);
            this.label_ErrorTranslate.TabIndex = 0;
            this.label_ErrorTranslate.Text = "Error!";
            this.label_ErrorTranslate.Visible = false;
            // 
            // textBox_Translate
            // 
            this.textBox_Translate.Location = new System.Drawing.Point(6, 20);
            this.textBox_Translate.Multiline = true;
            this.textBox_Translate.Name = "textBox_Translate";
            this.textBox_Translate.ReadOnly = true;
            this.textBox_Translate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Translate.Size = new System.Drawing.Size(748, 70);
            this.textBox_Translate.TabIndex = 5;
            this.textBox_Translate.TabStop = false;
            // 
            // timer_Image
            // 
            this.timer_Image.Interval = 500;
            this.timer_Image.Tick += new System.EventHandler(this.timer_Image_Tick);
            // 
            // button_TimerImage
            // 
            this.button_TimerImage.Location = new System.Drawing.Point(364, 40);
            this.button_TimerImage.Name = "button_TimerImage";
            this.button_TimerImage.Size = new System.Drawing.Size(75, 23);
            this.button_TimerImage.TabIndex = 1;
            this.button_TimerImage.Text = "Timer On";
            this.button_TimerImage.UseVisualStyleBackColor = true;
            this.button_TimerImage.Click += new System.EventHandler(this.button_TimerImage_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox_Translate);
            this.Controls.Add(this.groupBox_Extract);
            this.Controls.Add(this.groupBox_Control);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "OCR Translate";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_Control.ResumeLayout(false);
            this.groupBox_Control.PerformLayout();
            this.groupBox_Extract.ResumeLayout(false);
            this.groupBox_Extract.PerformLayout();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Extract)).EndInit();
            this.groupBox_Translate.ResumeLayout(false);
            this.groupBox_Translate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Control;
        private System.Windows.Forms.Button button_AreaSet;
        private System.Windows.Forms.GroupBox groupBox_Extract;
        private System.Windows.Forms.ComboBox comboBox_LanguageTrans;
        private System.Windows.Forms.CheckBox checkBox_Language;
        private System.Windows.Forms.ComboBox comboBox_Language;
        private System.Windows.Forms.TextBox textBox_Extract;
        private System.Windows.Forms.Label label_Arrow;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.PictureBox pictureBox_Extract;
        private System.Windows.Forms.GroupBox groupBox_Translate;
        private System.Windows.Forms.TextBox textBox_Translate;
        private System.Windows.Forms.Label label_ErrorExtract;
        private System.Windows.Forms.Label label_ErrorTranslate;
        private System.Windows.Forms.Timer timer_Image;
        private System.Windows.Forms.Button button_TimerImage;
    }
}

