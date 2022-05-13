<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MYwebAPP.aspx.cs" Inherits="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
        </Scripts>
    </telerik:RadScriptManager>
    <script type="text/javascript">
        //Put your JavaScript code here.
    </script>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
    <div>
        <table>
            <tr>
                <td >
                     <telerik:RadDropDownList ID="ddlContinent" width ="200" runat ="server"
                         AutoPostBack ="true" OnSelectedIndexChanged ="ddlcontinent_SelectedIndexChanged">
        </telerik:RadDropDownList>
                     <br />
                </td>
            </tr>
         <tr>
             <td>
                 <telerik:RadDropDownList ID="ddlCountries"  width ="200" runat ="server"
                     OnSelectedIndexChanged ="ddlCountries_SelectedIndexChanged"
                     AutoPostBack ="true" >
        </telerik:RadDropDownList>
                 <br />
             </td>
         </tr>
            <tr>
            <td>
                     <telerik:RadDropDownList ID="cboCity" runat= "server" width ="200" 
                         AutoPostBack ="true" >
                     </telerik:RadDropDownList>
            </td>
            </tr>
                
        </table>
    
    </div>
    </form>
</body>
</html>
