namespace MappingsEditor {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            classesList = new ListBox();
            label1 = new Label();
            addClassButton = new Button();
            removeClassButton = new Button();
            label2 = new Label();
            classNameTextBox = new TextBox();
            label3 = new Label();
            obfuscatedClassName = new TextBox();
            classTabs = new TabControl();
            fieldsTab = new TabPage();
            fieldsGrid = new DataGridView();
            fieldName = new DataGridViewTextBoxColumn();
            obfuscatedFieldName = new DataGridViewTextBoxColumn();
            fieldDescriptor = new DataGridViewTextBoxColumn();
            fieldAccessor = new DataGridViewCheckBoxColumn();
            methodsTab = new TabPage();
            methodsGrid = new DataGridView();
            methodName = new DataGridViewTextBoxColumn();
            methodObfuscatedName = new DataGridViewTextBoxColumn();
            methodDescriptor = new DataGridViewTextBoxColumn();
            methodAccessor = new DataGridViewCheckBoxColumn();
            menuStrip1.SuspendLayout();
            classTabs.SuspendLayout();
            fieldsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fieldsGrid).BeginInit();
            methodsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)methodsGrid).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, openToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(180, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(180, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // classesList
            // 
            classesList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            classesList.FormattingEnabled = true;
            classesList.ItemHeight = 15;
            classesList.Location = new Point(12, 42);
            classesList.Name = "classesList";
            classesList.Size = new Size(193, 379);
            classesList.TabIndex = 1;
            classesList.SelectedIndexChanged += classesList_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(12, 24);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 2;
            label1.Text = "Classes";
            // 
            // addClassButton
            // 
            addClassButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            addClassButton.Location = new Point(26, 427);
            addClassButton.Name = "addClassButton";
            addClassButton.Size = new Size(75, 23);
            addClassButton.TabIndex = 3;
            addClassButton.Text = "Add";
            addClassButton.UseVisualStyleBackColor = true;
            addClassButton.Click += addClassButton_Click;
            // 
            // removeClassButton
            // 
            removeClassButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            removeClassButton.Location = new Point(107, 427);
            removeClassButton.Name = "removeClassButton";
            removeClassButton.Size = new Size(75, 23);
            removeClassButton.TabIndex = 4;
            removeClassButton.Text = "Remove";
            removeClassButton.UseVisualStyleBackColor = true;
            removeClassButton.Click += removeClassButton_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(275, 42);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 5;
            label2.Text = "Class Name";
            // 
            // classNameTextBox
            // 
            classNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            classNameTextBox.Location = new Point(350, 39);
            classNameTextBox.Name = "classNameTextBox";
            classNameTextBox.Size = new Size(403, 23);
            classNameTextBox.TabIndex = 6;
            classNameTextBox.TextChanged += classNameTextBox_TextChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(211, 76);
            label3.Name = "label3";
            label3.Size = new Size(133, 15);
            label3.TabIndex = 7;
            label3.Text = "Obfuscated Class Name";
            // 
            // obfuscatedClassName
            // 
            obfuscatedClassName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            obfuscatedClassName.Location = new Point(350, 73);
            obfuscatedClassName.Name = "obfuscatedClassName";
            obfuscatedClassName.Size = new Size(403, 23);
            obfuscatedClassName.TabIndex = 8;
            obfuscatedClassName.TextChanged += obfuscatedClassName_TextChanged;
            // 
            // classTabs
            // 
            classTabs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            classTabs.Controls.Add(fieldsTab);
            classTabs.Controls.Add(methodsTab);
            classTabs.Location = new Point(211, 111);
            classTabs.Name = "classTabs";
            classTabs.SelectedIndex = 0;
            classTabs.Size = new Size(577, 310);
            classTabs.TabIndex = 9;
            // 
            // fieldsTab
            // 
            fieldsTab.Controls.Add(fieldsGrid);
            fieldsTab.Location = new Point(4, 24);
            fieldsTab.Name = "fieldsTab";
            fieldsTab.Padding = new Padding(3);
            fieldsTab.Size = new Size(569, 282);
            fieldsTab.TabIndex = 0;
            fieldsTab.Text = "Fields";
            fieldsTab.UseVisualStyleBackColor = true;
            // 
            // fieldsGrid
            // 
            fieldsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            fieldsGrid.Columns.AddRange(new DataGridViewColumn[] { fieldName, obfuscatedFieldName, fieldDescriptor, fieldAccessor });
            fieldsGrid.Dock = DockStyle.Fill;
            fieldsGrid.Location = new Point(3, 3);
            fieldsGrid.Name = "fieldsGrid";
            fieldsGrid.Size = new Size(563, 276);
            fieldsGrid.TabIndex = 0;
            fieldsGrid.CellContentClick += dataGridView1_CellContentClick;
            fieldsGrid.CellEndEdit += fieldsGrid_CellEndEdit;
            // 
            // fieldName
            // 
            fieldName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            fieldName.HeaderText = "Name";
            fieldName.Name = "fieldName";
            // 
            // obfuscatedFieldName
            // 
            obfuscatedFieldName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            obfuscatedFieldName.FillWeight = 65F;
            obfuscatedFieldName.HeaderText = "Obfuscated Name";
            obfuscatedFieldName.Name = "obfuscatedFieldName";
            // 
            // fieldDescriptor
            // 
            fieldDescriptor.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            fieldDescriptor.FillWeight = 200F;
            fieldDescriptor.HeaderText = "Descriptor";
            fieldDescriptor.Name = "fieldDescriptor";
            // 
            // fieldAccessor
            // 
            fieldAccessor.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            fieldAccessor.FalseValue = "Not Static";
            fieldAccessor.FillWeight = 50F;
            fieldAccessor.HeaderText = "Static";
            fieldAccessor.Name = "fieldAccessor";
            fieldAccessor.Resizable = DataGridViewTriState.True;
            fieldAccessor.SortMode = DataGridViewColumnSortMode.Automatic;
            fieldAccessor.TrueValue = "Static";
            // 
            // methodsTab
            // 
            methodsTab.Controls.Add(methodsGrid);
            methodsTab.Location = new Point(4, 24);
            methodsTab.Name = "methodsTab";
            methodsTab.Padding = new Padding(3);
            methodsTab.Size = new Size(569, 282);
            methodsTab.TabIndex = 1;
            methodsTab.Text = "Methods";
            methodsTab.UseVisualStyleBackColor = true;
            // 
            // methodsGrid
            // 
            methodsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            methodsGrid.Columns.AddRange(new DataGridViewColumn[] { methodName, methodObfuscatedName, methodDescriptor, methodAccessor });
            methodsGrid.Dock = DockStyle.Fill;
            methodsGrid.Location = new Point(3, 3);
            methodsGrid.Name = "methodsGrid";
            methodsGrid.Size = new Size(563, 276);
            methodsGrid.TabIndex = 1;
            methodsGrid.CellEndEdit += methodsGrid_CellEndEdit;
            // 
            // methodName
            // 
            methodName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            methodName.HeaderText = "Name";
            methodName.Name = "methodName";
            // 
            // methodObfuscatedName
            // 
            methodObfuscatedName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            methodObfuscatedName.FillWeight = 65F;
            methodObfuscatedName.HeaderText = "Obfuscated Name";
            methodObfuscatedName.Name = "methodObfuscatedName";
            // 
            // methodDescriptor
            // 
            methodDescriptor.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            methodDescriptor.FillWeight = 200F;
            methodDescriptor.HeaderText = "Descriptor";
            methodDescriptor.Name = "methodDescriptor";
            // 
            // methodAccessor
            // 
            methodAccessor.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            methodAccessor.FalseValue = "Not Static";
            methodAccessor.FillWeight = 50F;
            methodAccessor.HeaderText = "Static";
            methodAccessor.Name = "methodAccessor";
            methodAccessor.Resizable = DataGridViewTriState.True;
            methodAccessor.SortMode = DataGridViewColumnSortMode.Automatic;
            methodAccessor.TrueValue = "Static";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 456);
            Controls.Add(classTabs);
            Controls.Add(obfuscatedClassName);
            Controls.Add(label3);
            Controls.Add(classNameTextBox);
            Controls.Add(label2);
            Controls.Add(removeClassButton);
            Controls.Add(addClassButton);
            Controls.Add(label1);
            Controls.Add(classesList);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Mappings Editor";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            classTabs.ResumeLayout(false);
            fieldsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)fieldsGrid).EndInit();
            methodsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)methodsGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ListBox classesList;
        private Label label1;
        private Button addClassButton;
        private Button removeClassButton;
        private Label label2;
        private TextBox classNameTextBox;
        private Label label3;
        private TextBox obfuscatedClassName;
        private TabControl classTabs;
        private TabPage fieldsTab;
        private TabPage methodsTab;
        private DataGridView fieldsGrid;
        private DataGridView methodsGrid;
        private DataGridViewTextBoxColumn methodName;
        private DataGridViewTextBoxColumn methodObfuscatedName;
        private DataGridViewTextBoxColumn methodDescriptor;
        private DataGridViewCheckBoxColumn methodAccessor;
        private DataGridViewTextBoxColumn fieldName;
        private DataGridViewTextBoxColumn obfuscatedFieldName;
        private DataGridViewTextBoxColumn fieldDescriptor;
        private DataGridViewCheckBoxColumn fieldAccessor;
    }
}
