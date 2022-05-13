using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           ddlContinent.DataSource = GetData("sp_getcontinent", null);
            ddlContinent.DataTextField = "ContinentName";
            ddlContinent.DataValueField = "ContinentID";
            ddlContinent.DataBind();
            ddlContinent.Items.Insert(0, new DropDownListItem("Select Continent", "-1"));
            ddlCountries.Items.Insert(0, new DropDownListItem("Select Countries", "-1"));
            cboCity.Items.Insert(0, new DropDownListItem("Select City", "-1"));

            ddlCountries.Enabled = false;
            cboCity.Enabled = false;
        }
    }

    private DataSet GetData(string spName, SqlParameter spParameter)
    {

        DataSet das = new DataSet();
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlDataAdapter da = new SqlDataAdapter(spName, con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if(spParameter!= null)
            {
                da.SelectCommand.Parameters.Add(spParameter);
            }

            da.Fill(das );
        }
        return das ;


    }



    protected void ddlcontinent_SelectedIndexChanged(object sender, DropDownListEventArgs e)
    {
        if(ddlContinent.SelectedIndex == 0)
        {
            ddlCountries.SelectedIndex = 0;
            ddlCountries.Enabled = false;
            cboCity.SelectedIndex = 0;
            cboCity.Enabled = false;
        }
        else
        {
            ddlCountries.Enabled = true;
            SqlParameter spparam = new SqlParameter("@ContinentID", ddlContinent.SelectedValue);
            ddlCountries.DataSource = GetData("sp_getcountriesbycontinent", spparam);
            ddlCountries.DataTextField = "CountriesName";
            ddlCountries.DataValueField = "CountriesID";
            ddlCountries.DataBind();
            ddlCountries.Items.Insert(0, new DropDownListItem("Select Countries", "-1"));

        }
    }

    protected void ddlCountries_SelectedIndexChanged(object sender, DropDownListEventArgs e)
    {
        if (ddlCountries.SelectedIndex == 0)
        {
            cboCity.SelectedIndex = 0;
            cboCity.Enabled = false;
        }
        else
        {
            cboCity.Enabled = true;

            SqlParameter spparam = new SqlParameter("@CountryID", ddlCountries.SelectedValue);
            cboCity.DataSource = GetData("sp_getcitybycountry", spparam);
            cboCity.DataTextField = "CityName";
            cboCity.DataValueField = "CityID";
            cboCity.DataBind();
            cboCity.Items.Insert(0, new DropDownListItem("Select City", "-1"));

        }
    }
}
