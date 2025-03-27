using System.Data;
using Microsoft.Data.SqlClient;

namespace DatabaseStoredProcedureRunner;

public class StoredProcedureParameterInput : Panel
{

    private List<Control> _parameterControls = new List<Control>();

    public StoredProcedureParameterInput()
    {

        AutoSize = true;
        FlowLayoutPanel layoutPanel = new FlowLayoutPanel();
        layoutPanel.AutoSize = true;
        layoutPanel.FlowDirection = FlowDirection.TopDown;
        Controls.Add(layoutPanel);

    }

    public void LoadParameters(string connectionString, string storedProcedureName)
    {

        FlowLayoutPanel? panel = Controls.OfType<FlowLayoutPanel>().FirstOrDefault();

        if (panel != null)
        {

            foreach (var control in _parameterControls)
            {

                panel.Controls.Remove(control);
                control.Dispose();

            }

            _parameterControls.Clear();

            try
            {

                if (!string.IsNullOrEmpty(connectionString) && !string.IsNullOrEmpty(storedProcedureName))
                {

                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    {

                        sqlConnection.Open();

                        using (SqlCommand sqlCommand = new SqlCommand(storedProcedureName, sqlConnection))
                        {

                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlCommandBuilder.DeriveParameters(sqlCommand);

                            foreach (SqlParameter sqlParameter in sqlCommand.Parameters)
                            {

                                if (sqlParameter.Direction != ParameterDirection.ReturnValue)
                                {

                                    Label label = new Label();

                                    label.Text = $"{sqlParameter.ParameterName} ({sqlParameter.SqlDbType})";
                                    label.AutoSize = true;

                                    Control inputControl = null;

                                    if (sqlParameter.SqlDbType == SqlDbType.Bit)
                                    {

                                        inputControl = new CheckBox();

                                    }
                                    else if (sqlParameter.SqlDbType == SqlDbType.DateTime || sqlParameter.SqlDbType == SqlDbType.Date || sqlParameter.SqlDbType == SqlDbType.DateTime2 || sqlParameter.SqlDbType == SqlDbType.SmallDateTime)
                                    {

                                        inputControl = new DateTimePicker();

                                    }
                                    else if (sqlParameter.SqlDbType.ToString().Contains("Int") || sqlParameter.SqlDbType == SqlDbType.Decimal || sqlParameter.SqlDbType == SqlDbType.Float || sqlParameter.SqlDbType == SqlDbType.Money || sqlParameter.SqlDbType == SqlDbType.SmallMoney || sqlParameter.SqlDbType == SqlDbType.Real)
                                    {

                                        inputControl = new NumericUpDown();

                                        if (sqlParameter.SqlDbType == SqlDbType.Decimal || sqlParameter.SqlDbType == SqlDbType.Float || sqlParameter.SqlDbType == SqlDbType.Money || sqlParameter.SqlDbType == SqlDbType.SmallMoney || sqlParameter.SqlDbType == SqlDbType.Real)
                                        {

                                            ((NumericUpDown)inputControl).DecimalPlaces = sqlParameter.Scale;

                                        }
                                        else
                                        {

                                            ((NumericUpDown)inputControl).DecimalPlaces = 0;

                                        }

                                    }
                                    else
                                    {

                                        inputControl = new TextBox();

                                    }

                                    inputControl.Name = sqlParameter.ParameterName.Replace("@", "");
                                    inputControl.Width = 200;

                                    panel.Controls.Add(label);
                                    panel.Controls.Add(inputControl);

                                    _parameterControls.Add(label);
                                    _parameterControls.Add(inputControl);

                                }

                            }

                        }

                    }

                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error retrieving parameters for '{storedProcedureName}': {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        Invalidate();
        Update();
        if (Parent != null) Parent.PerformLayout();

    }
    public Dictionary<string, object> GetParameterValues()
    {

        Dictionary<string, object> parameterValues = new Dictionary<string, object>();

        foreach (var control in _parameterControls.Where(cntrl => cntrl is TextBox || cntrl is CheckBox || cntrl is DateTimePicker || cntrl is NumericUpDown))
        {

            string parameterName = "@" + control.Name; // Reconstruct the parameter name

            if (control is TextBox textBox)
            {

                parameterValues[parameterName] = textBox.Text;

            }
            else if (control is CheckBox checkBox)
            {

                parameterValues[parameterName] = checkBox.Checked;

            }
            else if (control is DateTimePicker dateTimePicker)
            {

                parameterValues[parameterName] = dateTimePicker.Value;

            }
            else if (control is NumericUpDown numericUpDown)
            {

                parameterValues[parameterName] = numericUpDown.Value;

            }

        }

        return parameterValues;

    }

}
