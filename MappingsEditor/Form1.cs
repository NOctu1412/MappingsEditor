using System.Diagnostics;
using System.Windows.Forms;

namespace MappingsEditor {
    public partial class Form1 : Form {
        private static bool skipNextClassNameChangeEvent = false;
        private static bool skipNextObfuscatedClassNameChangeEvent = false;

        // Add state variables to track file-related status
        private string? currentFilePath = null;
        private bool isModified = false;

        public Form1() {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            UpdateTitle();
        }

        private void UpdateTitle() {
            string baseTitle = "Class Editor";
            string fileName = currentFilePath != null ? Path.GetFileName(currentFilePath) : "Untitled";
            Text = isModified ? $"{baseTitle} - {fileName}*" : $"{baseTitle} - {fileName}";
        }

        private void MarkAsModified() {
            isModified = true;
            UpdateTitle();
        }

        private void MarkAsSaved(string filePath) {
            isModified = false;
            currentFilePath = filePath;
            UpdateTitle();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            // Placeholder for event handling logic
        }

        private void addClassButton_Click(object sender, EventArgs e) {
            string tempName = "Class" + (classesList.Items.Count + 1);
            ClassData classData = new ClassData();
            classData.Name = tempName;
            classesList.Items.Add(classData);
            MarkAsModified();
        }

        private void removeClassButton_Click(object sender, EventArgs e) {
            if (classesList.SelectedItem == null) return;
            ClassData classData = (ClassData)classesList.SelectedItem;
            classesList.Items.Remove(classData);
            UnloadClassDataFromForm();
            MarkAsModified();
        }

        private void classesList_SelectedIndexChanged(object sender, EventArgs e) {
            if (classesList.SelectedItem == null) return;
            ClassData classData = (ClassData)classesList.SelectedItem;
            LoadClassDataInForm(classData);
        }

        public void LoadClassDataInForm(ClassData classData) {
            UnloadClassDataFromForm();
            classNameTextBox.Text = classData.Name;
            obfuscatedClassName.Text = classData.ObfuscatedName;

            foreach (var field in classData.Fields) {
                fieldsGrid.Rows.Add(field.Name, field.ObfuscatedName, field.Descriptor, field.Static);
            }

            foreach (var method in classData.Methods) {
                methodsGrid.Rows.Add(method.Name, method.ObfuscatedName, method.Descriptor, method.Static);
            }
        }

        public void UnloadClassDataFromForm() {
            skipNextClassNameChangeEvent = true;
            classNameTextBox.Text = "";
            skipNextObfuscatedClassNameChangeEvent = true;
            obfuscatedClassName.Text = "";
            fieldsGrid.Rows.Clear();
            methodsGrid.Rows.Clear();
        }

        public void RefreshClassesList() {
            classesList.DrawMode = DrawMode.OwnerDrawFixed;
            classesList.DrawMode = DrawMode.Normal;
        }

        private void classNameTextBox_TextChanged(object sender, EventArgs e) {
            if (skipNextClassNameChangeEvent) {
                skipNextClassNameChangeEvent = false;
                return;
            }
            if (classesList.SelectedItem == null) return;
            ClassData classData = (ClassData)classesList.SelectedItem;
            classData.Name = classNameTextBox.Text;
            RefreshClassesList();
            MarkAsModified();
        }

        private void obfuscatedClassName_TextChanged(object sender, EventArgs e) {
            if (skipNextObfuscatedClassNameChangeEvent) {
                skipNextObfuscatedClassNameChangeEvent = false;
                return;
            }
            if (classesList.SelectedItem == null) return;
            ClassData classData = (ClassData)classesList.SelectedItem;
            classData.ObfuscatedName = obfuscatedClassName.Text;
            MarkAsModified();
        }

        private void fieldsGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            if (classesList.SelectedItem == null) return;
            ClassData classData = (ClassData)classesList.SelectedItem;
            classData.Fields.Clear();

            foreach (DataGridViewRow fieldRow in fieldsGrid.Rows) {
                DataGridViewCellCollection cells = fieldRow.Cells;
                object? cell3Value = cells[3].Value;
                bool isStatic = cell3Value == null ? false : (cell3Value is bool ? (bool)cell3Value : (cell3Value is string ? (string)cell3Value == "Static" : throw new Exception("Unable to find type of cell[3]")));
                classData.Fields.Add(new MemberData(
                    (string?)cells[0].Value,
                    (string?)cells[1].Value,
                    (string?)cells[2].Value,
                    isStatic
                ));
            }
            MarkAsModified();
        }

        private void methodsGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            if (classesList.SelectedItem == null) return;
            ClassData classData = (ClassData)classesList.SelectedItem;
            classData.Methods.Clear();

            foreach (DataGridViewRow methodRow in methodsGrid.Rows) {
                DataGridViewCellCollection cells = methodRow.Cells;
                object? cell3Value = cells[3].Value;
                bool isStatic = cell3Value == null ? false : (cell3Value is bool ? (bool)cell3Value : (cell3Value is string ? (string)cell3Value == "Static" : throw new Exception("Unable to find type of cell[3]")));
                classData.Methods.Add(new MemberData(
                    (string?)cells[0].Value,
                    (string?)cells[1].Value,
                    (string?)cells[2].Value,
                    isStatic
                ));
            }
            MarkAsModified();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            string fileContent = ClassData.SerializeClassDataList(classesList.Items.Cast<ClassData>().ToList());

            if (currentFilePath != null) {
                // Save to the current file path without showing a dialog
                File.WriteAllText(currentFilePath, fileContent);
                MarkAsSaved(currentFilePath);
            } else {
                // Show SaveFileDialog for new files
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "json files (*.json)|*.json";
                DialogResult saveResult = saveFileDialog.ShowDialog();
                if (saveResult == DialogResult.OK) {
                    string fileName = saveFileDialog.FileName;
                    File.WriteAllText(fileName, fileContent);
                    MarkAsSaved(fileName);
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            // Check if there are unsaved changes
            if (isModified) {
                var result = MessageBox.Show("You have unsaved changes. Do you want to save them before opening a new file?", "Unsaved Changes", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes) {
                    // Save the current changes
                    saveToolStripMenuItem_Click(sender, e);
                } else if (result == DialogResult.Cancel) {
                    return; // Cancel the open operation
                }
            }

            // Show OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "json files (*.json)|*.json";
            openFileDialog.Multiselect = false;
            DialogResult openResult = openFileDialog.ShowDialog();
            if (openResult == DialogResult.OK) {
                UnloadClassDataFromForm();
                string fileName = openFileDialog.FileName;
                string fileContent = File.ReadAllText(fileName);
                classesList.Items.Clear();
                classesList.Items.AddRange(ClassData.DeserializeClassDataList(fileContent).ToArray());
                MarkAsSaved(fileName);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            if (e.Control && e.KeyCode == Keys.S) {
                saveToolStripMenuItem_Click(sender, e);
                e.SuppressKeyPress = true;
            }

            if (e.Control && e.KeyCode == Keys.O) {
                openToolStripMenuItem_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }
    }
}
