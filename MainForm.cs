using System.Data;
using Microsoft.Data.SqlClient;

namespace DatabaseStoredProcedureRunner;

public partial class MainForm : Form
{

    private DbConnection? _dbConnection = null;

    public MainForm()
    {
        InitializeComponent();

        TextBoxServerName.Text = "IRACINGPC";
        TextBoxDatabaseName.Text = "AdventureWorks2022";
        CheckBoxUseWindowsAuth.Checked = true;
        TextBoxUsername.Text = "SYSADM";
        TextBoxPassword.Text = "sysadm";

    }
    private void ClearStoredProceduresInfo()
    {

        ComboBoxStoredProcedures.SelectedItem = null;
        ComboBoxStoredProcedures.Items.Clear();
        StoredProcedureParameterInputs.LoadParameters("", "");
        DataGridViewResults.DataSource = null;

    }
    private void ButtonConnect_Click(object sender, EventArgs e)
    {

        ClearStoredProceduresInfo();

        if (string.IsNullOrEmpty(TextBoxServerName.Text.Trim()) || string.IsNullOrEmpty(TextBoxDatabaseName.Text.Trim()))
        {
            
            MessageBox.Show("Server Name and Database Name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;

        }

        if (CheckBoxUseWindowsAuth.Checked == false && (string.IsNullOrEmpty(TextBoxUsername.Text.Trim()) || string.IsNullOrEmpty(TextBoxPassword.Text.Trim())))
        {
            
            MessageBox.Show("Username and Password cannot be empty when using SQL Server authentication.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        
        }

        _dbConnection = new DbConnection(TextBoxServerName.Text.Trim(), TextBoxDatabaseName.Text.Trim(), CheckBoxUseWindowsAuth.Checked, TextBoxUsername.Text.Trim(), TextBoxPassword.Text.Trim());

        try
        {

            using (SqlConnection sqlConnection = new SqlConnection(_dbConnection.CreateConnectionString()))
            {

                sqlConnection.Open();

                string[] restrictions = { null, null, null, "PROCEDURE" };
                DataTable storedProcedures = sqlConnection.GetSchema("Procedures", restrictions);

                ComboBoxStoredProcedures.Items.Clear();

                foreach (DataRow row in storedProcedures.Rows)
                {

                    ComboBoxStoredProcedures.Items.Add(row["ROUTINE_NAME"]);

                }

                ComboBoxStoredProcedures.SelectedIndex = 0;

            }

        }
        catch (SqlException ex)
        {
            MessageBox.Show($"Error connecting to the database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _dbConnection = null;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _dbConnection = null;
        }

    }
    private void ComboBoxStoredProcedures_SelectedIndexChanged(object sender, EventArgs e)
    {

        DataGridViewResults.DataSource = null;

        string? selectedStoredProcedure = ComboBoxStoredProcedures.SelectedItem == null ? string.Empty : ComboBoxStoredProcedures.SelectedItem.ToString();

        if (string.IsNullOrWhiteSpace(selectedStoredProcedure) == false && _dbConnection is not null && _dbConnection.IsValid())
        {

            StoredProcedureParameterInputs.LoadParameters(_dbConnection.CreateConnectionString(), selectedStoredProcedure);

        }
        else
        {

            StoredProcedureParameterInputs.LoadParameters("", "");

        }

    }
    private void ButtonExecuteStoredProcedure_Click(object sender, EventArgs e)
    {

        string? selectedStoredProcedure = ComboBoxStoredProcedures.SelectedItem == null ? string.Empty : ComboBoxStoredProcedures.SelectedItem.ToString();

        if (string.IsNullOrWhiteSpace(selectedStoredProcedure) == false && _dbConnection is not null && _dbConnection.IsValid())
        {

            Dictionary<string, object> parameters = StoredProcedureParameterInputs.GetParameterValues();

            try
            {

                using (SqlConnection connection = new SqlConnection(_dbConnection.CreateConnectionString()))
                {

                    connection.Open();

                    using (SqlCommand command = new SqlCommand(selectedStoredProcedure, connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        foreach (var param in parameters)
                        {

                            command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value); // Handle null values

                        }

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            DataTable dataTable = new DataTable();

                            dataTable.Load(reader);

                            DataGridViewResults.DataSource = dataTable;

                        }

                    }

                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error executing stored procedure: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        else
        {

            MessageBox.Show("Please connect to a database and select a stored procedure first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

    }
    private void CheckBoxUseWindowsAuth_CheckedChanged(object sender, EventArgs e)
    {

        TextBoxUsername.Text = string.Empty;
        TextBoxPassword.Text = string.Empty;

        TextBoxUsername.Enabled = !CheckBoxUseWindowsAuth.Checked;
        TextBoxPassword.Enabled = !CheckBoxUseWindowsAuth.Checked;

    }

}
