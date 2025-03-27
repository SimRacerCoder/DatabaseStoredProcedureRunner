namespace DatabaseStoredProcedureRunner;

partial class MainForm
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
        LabelServerName = new Label();
        TextBoxServerName = new TextBox();
        LabelDatabaseName = new Label();
        TextBoxDatabaseName = new TextBox();
        LabelUsername = new Label();
        TextBoxUsername = new TextBox();
        LabelPassword = new Label();
        TextBoxPassword = new TextBox();
        ButtonConnect = new Button();
        LabelStoredProcedures = new Label();
        ComboBoxStoredProcedures = new ComboBox();
        ButtonExecuteStoredProcedure = new Button();
        StoredProcedureParameterInputs = new StoredProcedureParameterInput();
        DataGridViewResults = new DataGridView();
        CheckBoxUseWindowsAuth = new CheckBox();
        ((System.ComponentModel.ISupportInitialize)DataGridViewResults).BeginInit();
        SuspendLayout();
        // 
        // LabelServerName
        // 
        LabelServerName.Location = new Point(15, 11);
        LabelServerName.Margin = new Padding(4, 0, 4, 0);
        LabelServerName.Name = "LabelServerName";
        LabelServerName.Size = new Size(108, 23);
        LabelServerName.TabIndex = 0;
        LabelServerName.Text = "Server Name:";
        LabelServerName.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // TextBoxServerName
        // 
        TextBoxServerName.Location = new Point(131, 11);
        TextBoxServerName.Margin = new Padding(4, 3, 4, 3);
        TextBoxServerName.Name = "TextBoxServerName";
        TextBoxServerName.Size = new Size(215, 23);
        TextBoxServerName.TabIndex = 1;
        // 
        // LabelDatabaseName
        // 
        LabelDatabaseName.Location = new Point(15, 40);
        LabelDatabaseName.Margin = new Padding(4, 0, 4, 0);
        LabelDatabaseName.Name = "LabelDatabaseName";
        LabelDatabaseName.Size = new Size(108, 23);
        LabelDatabaseName.TabIndex = 2;
        LabelDatabaseName.Text = "Database Name:";
        LabelDatabaseName.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // TextBoxDatabaseName
        // 
        TextBoxDatabaseName.Location = new Point(131, 40);
        TextBoxDatabaseName.Margin = new Padding(4, 3, 4, 3);
        TextBoxDatabaseName.Name = "TextBoxDatabaseName";
        TextBoxDatabaseName.Size = new Size(215, 23);
        TextBoxDatabaseName.TabIndex = 3;
        // 
        // LabelUsername
        // 
        LabelUsername.Location = new Point(354, 11);
        LabelUsername.Margin = new Padding(4, 0, 4, 0);
        LabelUsername.Name = "LabelUsername";
        LabelUsername.Size = new Size(108, 23);
        LabelUsername.TabIndex = 4;
        LabelUsername.Text = "Username:";
        LabelUsername.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // TextBoxUsername
        // 
        TextBoxUsername.Location = new Point(470, 11);
        TextBoxUsername.Margin = new Padding(4, 3, 4, 3);
        TextBoxUsername.Name = "TextBoxUsername";
        TextBoxUsername.Size = new Size(215, 23);
        TextBoxUsername.TabIndex = 5;
        // 
        // LabelPassword
        // 
        LabelPassword.Location = new Point(354, 40);
        LabelPassword.Margin = new Padding(4, 0, 4, 0);
        LabelPassword.Name = "LabelPassword";
        LabelPassword.Size = new Size(108, 23);
        LabelPassword.TabIndex = 6;
        LabelPassword.Text = "Password:";
        LabelPassword.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // TextBoxPassword
        // 
        TextBoxPassword.Location = new Point(470, 40);
        TextBoxPassword.Margin = new Padding(4, 3, 4, 3);
        TextBoxPassword.Name = "TextBoxPassword";
        TextBoxPassword.PasswordChar = '*';
        TextBoxPassword.Size = new Size(215, 23);
        TextBoxPassword.TabIndex = 7;
        // 
        // ButtonConnect
        // 
        ButtonConnect.Location = new Point(692, 40);
        ButtonConnect.Margin = new Padding(4, 3, 4, 3);
        ButtonConnect.Name = "ButtonConnect";
        ButtonConnect.Size = new Size(149, 23);
        ButtonConnect.TabIndex = 9;
        ButtonConnect.Text = "Connect && Load Procs";
        ButtonConnect.UseVisualStyleBackColor = true;
        ButtonConnect.Click += ButtonConnect_Click;
        // 
        // LabelStoredProcedures
        // 
        LabelStoredProcedures.Location = new Point(15, 82);
        LabelStoredProcedures.Margin = new Padding(4, 0, 4, 0);
        LabelStoredProcedures.Name = "LabelStoredProcedures";
        LabelStoredProcedures.Size = new Size(108, 23);
        LabelStoredProcedures.TabIndex = 10;
        LabelStoredProcedures.Text = "Stored Procedures:";
        LabelStoredProcedures.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // ComboBoxStoredProcedures
        // 
        ComboBoxStoredProcedures.DropDownStyle = ComboBoxStyle.DropDownList;
        ComboBoxStoredProcedures.FormattingEnabled = true;
        ComboBoxStoredProcedures.Location = new Point(131, 82);
        ComboBoxStoredProcedures.Margin = new Padding(4, 3, 4, 3);
        ComboBoxStoredProcedures.Name = "ComboBoxStoredProcedures";
        ComboBoxStoredProcedures.Size = new Size(215, 23);
        ComboBoxStoredProcedures.TabIndex = 11;
        ComboBoxStoredProcedures.SelectedIndexChanged += ComboBoxStoredProcedures_SelectedIndexChanged;
        // 
        // ButtonExecuteStoredProcedure
        // 
        ButtonExecuteStoredProcedure.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        ButtonExecuteStoredProcedure.Location = new Point(12, 436);
        ButtonExecuteStoredProcedure.Margin = new Padding(4, 3, 4, 3);
        ButtonExecuteStoredProcedure.Name = "ButtonExecuteStoredProcedure";
        ButtonExecuteStoredProcedure.Size = new Size(334, 23);
        ButtonExecuteStoredProcedure.TabIndex = 13;
        ButtonExecuteStoredProcedure.Text = "Execute Stored Procedure";
        ButtonExecuteStoredProcedure.UseVisualStyleBackColor = true;
        ButtonExecuteStoredProcedure.Click += ButtonExecuteStoredProcedure_Click;
        // 
        // StoredProcedureParameterInputs
        // 
        StoredProcedureParameterInputs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        StoredProcedureParameterInputs.AutoSize = true;
        StoredProcedureParameterInputs.Location = new Point(12, 111);
        StoredProcedureParameterInputs.Margin = new Padding(4, 3, 4, 3);
        StoredProcedureParameterInputs.Name = "StoredProcedureParameterInputs";
        StoredProcedureParameterInputs.Size = new Size(334, 319);
        StoredProcedureParameterInputs.TabIndex = 12;
        // 
        // DataGridViewResults
        // 
        DataGridViewResults.AllowUserToAddRows = false;
        DataGridViewResults.AllowUserToDeleteRows = false;
        DataGridViewResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        DataGridViewResults.Location = new Point(354, 111);
        DataGridViewResults.Margin = new Padding(4, 3, 4, 3);
        DataGridViewResults.Name = "DataGridViewResults";
        DataGridViewResults.ReadOnly = true;
        DataGridViewResults.Size = new Size(526, 348);
        DataGridViewResults.TabIndex = 14;
        // 
        // CheckBoxUseWindowsAuth
        // 
        CheckBoxUseWindowsAuth.Location = new Point(692, 11);
        CheckBoxUseWindowsAuth.Name = "CheckBoxUseWindowsAuth";
        CheckBoxUseWindowsAuth.Size = new Size(126, 23);
        CheckBoxUseWindowsAuth.TabIndex = 8;
        CheckBoxUseWindowsAuth.Text = "Use Windows Auth";
        CheckBoxUseWindowsAuth.UseVisualStyleBackColor = true;
        CheckBoxUseWindowsAuth.CheckedChanged += CheckBoxUseWindowsAuth_CheckedChanged;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(893, 471);
        Controls.Add(CheckBoxUseWindowsAuth);
        Controls.Add(ButtonExecuteStoredProcedure);
        Controls.Add(ComboBoxStoredProcedures);
        Controls.Add(LabelStoredProcedures);
        Controls.Add(ButtonConnect);
        Controls.Add(TextBoxPassword);
        Controls.Add(LabelPassword);
        Controls.Add(TextBoxUsername);
        Controls.Add(LabelUsername);
        Controls.Add(TextBoxDatabaseName);
        Controls.Add(LabelDatabaseName);
        Controls.Add(TextBoxServerName);
        Controls.Add(LabelServerName);
        Controls.Add(StoredProcedureParameterInputs);
        Controls.Add(DataGridViewResults);
        Margin = new Padding(4, 3, 4, 3);
        Name = "MainForm";
        Text = "SQL Stored Procedure Explorer";
        ((System.ComponentModel.ISupportInitialize)DataGridViewResults).EndInit();
        ResumeLayout(false);
        PerformLayout();

    }

    #endregion

    private StoredProcedureParameterInput StoredProcedureParameterInputs;
    private DataGridView DataGridViewResults;
    private System.Windows.Forms.Label LabelServerName;
    private System.Windows.Forms.TextBox TextBoxServerName;
    private System.Windows.Forms.Label LabelDatabaseName;
    private System.Windows.Forms.TextBox TextBoxDatabaseName;
    private System.Windows.Forms.Label LabelUsername;
    private System.Windows.Forms.TextBox TextBoxUsername;
    private System.Windows.Forms.Label LabelPassword;
    private System.Windows.Forms.TextBox TextBoxPassword;
    private System.Windows.Forms.Button ButtonConnect;
    private System.Windows.Forms.Label LabelStoredProcedures;
    private System.Windows.Forms.ComboBox ComboBoxStoredProcedures;
    private System.Windows.Forms.Button ButtonExecuteStoredProcedure;
    private CheckBox CheckBoxUseWindowsAuth;
}