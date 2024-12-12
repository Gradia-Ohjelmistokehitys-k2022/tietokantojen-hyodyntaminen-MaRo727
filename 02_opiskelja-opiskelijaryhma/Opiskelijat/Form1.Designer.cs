
namespace Opiskelijat
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
            dataGridView1 = new DataGridView();
            cmbRyhmat = new ComboBox();
            addToDb = new Button();
            firstNameInput = new TextBox();
            lastNameInput = new TextBox();
            deleteButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(94, 73);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(240, 150);
            dataGridView1.TabIndex = 0;
            // 
            // cmbRyhmat
            // 
            cmbRyhmat.FormattingEnabled = true;
            cmbRyhmat.Location = new Point(340, 73);
            cmbRyhmat.Name = "cmbRyhmat";
            cmbRyhmat.Size = new Size(121, 23);
            cmbRyhmat.TabIndex = 1;
            // 
            // addToDb
            // 
            addToDb.Location = new Point(471, 131);
            addToDb.Name = "addToDb";
            addToDb.Size = new Size(75, 23);
            addToDb.TabIndex = 2;
            addToDb.Text = "Add";
            addToDb.UseVisualStyleBackColor = true;
            addToDb.Click += addToDb_Click_1;
            // 
            // firstNameInput
            // 
            firstNameInput.Location = new Point(340, 102);
            firstNameInput.Name = "firstNameInput";
            firstNameInput.Size = new Size(100, 23);
            firstNameInput.TabIndex = 3;
            // 
            // lastNameInput
            // 
            lastNameInput.Location = new Point(446, 102);
            lastNameInput.Name = "lastNameInput";
            lastNameInput.Size = new Size(100, 23);
            lastNameInput.TabIndex = 4;
            lastNameInput.Text = " ";
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(423, 200);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(75, 23);
            deleteButton.TabIndex = 5;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(deleteButton);
            Controls.Add(lastNameInput);
            Controls.Add(firstNameInput);
            Controls.Add(addToDb);
            Controls.Add(cmbRyhmat);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox cmbRyhmat;
        private Button addToDb;
        private TextBox firstNameInput;
        private TextBox lastNameInput;
        private Button deleteButton;
    }
}
