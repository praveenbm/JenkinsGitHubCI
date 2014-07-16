<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebpartToTestUserControl.ascx.cs" Inherits="SharepointTestProjForJenkins.WebpartToTest.WebpartToTestUserControl" %>
<p>
    &nbsp;</p>

    <div>   
    
<asp:Label ID="Label1" runat="server" Text='Number 1'></asp:Label>

<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    
    
    </div>
    <div>
    <asp:Label ID="Label2" runat="server" Text='Number 2'></asp:Label>

<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </div>
    <div>
     <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
        Text="Add" />
    </div>
    <div>
    
    <asp:Label ID="Label3" runat="server"></asp:Label>
    </div>
   


