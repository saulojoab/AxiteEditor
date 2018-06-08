namespace AxiteEditor
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btSave = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iFoundABugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iHaveASuggestionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howDoIUseThisThingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whoMadeThisBeautifulSoftwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mainEditor = new ScintillaNET.Scintilla();
            this.opacityBar = new System.Windows.Forms.TrackBar();
            this.lineLabel = new System.Windows.Forms.Label();
            this.selectedLanguage = new System.Windows.Forms.ComboBox();
            this.whatAreYouPlanningToDoWithThisSoftwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacityBar)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(654, 26);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.btSave,
            this.saveAsToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(41, 22);
            this.toolStripMenuItem1.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // btSave
            // 
            this.btSave.Enabled = false;
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(123, 22);
            this.btSave.Text = "Save";
            this.btSave.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iFoundABugToolStripMenuItem,
            this.iHaveASuggestionToolStripMenuItem,
            this.howDoIUseThisThingToolStripMenuItem,
            this.whoMadeThisBeautifulSoftwareToolStripMenuItem,
            this.whatAreYouPlanningToDoWithThisSoftwareToolStripMenuItem});
            this.helpToolStripMenuItem.Font = new System.Drawing.Font("Corbel", 11.25F);
            this.helpToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(48, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // iFoundABugToolStripMenuItem
            // 
            this.iFoundABugToolStripMenuItem.Name = "iFoundABugToolStripMenuItem";
            this.iFoundABugToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.iFoundABugToolStripMenuItem.Text = "I found a bug!";
            // 
            // iHaveASuggestionToolStripMenuItem
            // 
            this.iHaveASuggestionToolStripMenuItem.Name = "iHaveASuggestionToolStripMenuItem";
            this.iHaveASuggestionToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.iHaveASuggestionToolStripMenuItem.Text = "I have a suggestion!";
            // 
            // howDoIUseThisThingToolStripMenuItem
            // 
            this.howDoIUseThisThingToolStripMenuItem.Name = "howDoIUseThisThingToolStripMenuItem";
            this.howDoIUseThisThingToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.howDoIUseThisThingToolStripMenuItem.Text = "How do I use this thing?";
            // 
            // whoMadeThisBeautifulSoftwareToolStripMenuItem
            // 
            this.whoMadeThisBeautifulSoftwareToolStripMenuItem.Name = "whoMadeThisBeautifulSoftwareToolStripMenuItem";
            this.whoMadeThisBeautifulSoftwareToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.whoMadeThisBeautifulSoftwareToolStripMenuItem.Text = "Who made this beautiful software?";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.mainEditor, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.opacityBar, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 26);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.53503F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.46497F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(654, 312);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // mainEditor
            // 
            this.mainEditor.AdditionalCaretForeColor = System.Drawing.Color.Black;
            this.mainEditor.CaretForeColor = System.Drawing.Color.White;
            this.mainEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainEditor.EdgeColor = System.Drawing.Color.Black;
            this.mainEditor.IndentationGuides = ScintillaNET.IndentView.Real;
            this.mainEditor.IndentWidth = 4;
            this.mainEditor.Location = new System.Drawing.Point(3, 3);
            this.mainEditor.Name = "mainEditor";
            this.mainEditor.ScrollWidth = 900;
            this.mainEditor.Size = new System.Drawing.Size(654, 270);
            this.mainEditor.TabIndex = 2;
            this.mainEditor.WrapMode = ScintillaNET.WrapMode.Word;
            this.mainEditor.TextChanged += new System.EventHandler(this.mainEditor_TextChanged_1);
            // 
            // opacityBar
            // 
            this.opacityBar.AccessibleName = "opacityBar";
            this.opacityBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.opacityBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.opacityBar.Location = new System.Drawing.Point(3, 279);
            this.opacityBar.Maximum = 100;
            this.opacityBar.Minimum = 10;
            this.opacityBar.Name = "opacityBar";
            this.opacityBar.Size = new System.Drawing.Size(654, 30);
            this.opacityBar.SmallChange = 10;
            this.opacityBar.TabIndex = 1;
            this.opacityBar.TickFrequency = 10;
            this.opacityBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.opacityBar.Value = 100;
            this.opacityBar.Scroll += new System.EventHandler(this.opacityBar_Scroll);
            // 
            // lineLabel
            // 
            this.lineLabel.AutoSize = true;
            this.lineLabel.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineLabel.Location = new System.Drawing.Point(576, 8);
            this.lineLabel.Name = "lineLabel";
            this.lineLabel.Size = new System.Drawing.Size(44, 18);
            this.lineLabel.TabIndex = 3;
            this.lineLabel.Text = "Lines:";
            // 
            // selectedLanguage
            // 
            this.selectedLanguage.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedLanguage.FormattingEnabled = true;
            this.selectedLanguage.Items.AddRange(new object[] {
            "Normal Text",
            "Python 2",
            "Python 3",
            "CSS",
            "C#",
            "C",
            "C++",
            "Javascript",
            "HTML"});
            this.selectedLanguage.Location = new System.Drawing.Point(242, 1);
            this.selectedLanguage.Name = "selectedLanguage";
            this.selectedLanguage.Size = new System.Drawing.Size(121, 26);
            this.selectedLanguage.TabIndex = 4;
            this.selectedLanguage.Text = "Normal Text";
            this.selectedLanguage.SelectedIndexChanged += new System.EventHandler(this.selectedLanguage_SelectedIndexChanged);
            // 
            // whatAreYouPlanningToDoWithThisSoftwareToolStripMenuItem
            // 
            this.whatAreYouPlanningToDoWithThisSoftwareToolStripMenuItem.Name = "whatAreYouPlanningToDoWithThisSoftwareToolStripMenuItem";
            this.whatAreYouPlanningToDoWithThisSoftwareToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.whatAreYouPlanningToDoWithThisSoftwareToolStripMenuItem.Text = "What are you planning to do with this software?";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(654, 338);
            this.Controls.Add(this.selectedLanguage);
            this.Controls.Add(this.lineLabel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AxiteEditor 0.1 ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacityBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TrackBar opacityBar;
        private System.Windows.Forms.Label lineLabel;
        private System.Windows.Forms.ToolStripMenuItem btSave;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private ScintillaNET.Scintilla mainEditor;
        private System.Windows.Forms.ComboBox selectedLanguage;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iFoundABugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iHaveASuggestionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem howDoIUseThisThingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whoMadeThisBeautifulSoftwareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whatAreYouPlanningToDoWithThisSoftwareToolStripMenuItem;
    }
}

