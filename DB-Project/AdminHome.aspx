<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminHome.aspx.cs" Inherits="AdminHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>

    </p>
     <table style="width: 100%; table-layout: fixed;">
        <tr>
            <th colspan="4" style="background-color: #00CC66; color: black; text-align: left; padding: 5px; margin-bottom: 10px;">University Information</th>
        </tr>
        <tr>
            <td style="padding: 5px;"><strong>Admin ID:</strong>&nbsp;&nbsp; <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label></td>
            <td style="padding: 5px;"><strong>Campus:</strong>&nbsp;&nbsp; <asp:Label ID="Label18" runat="server" Text="Label"></asp:Label></td>
           
        </tr> 
          <tr height="50"></tr>
        <tr>
            <th colspan="4" style="background-color: #00CC66; color: black; text-align: left; padding: 5px; margin-bottom: 10px;">Personal Information</th>
        </tr>
        <tr>
            <td style="padding: 5px;"><strong>First Name:</strong>&nbsp;&nbsp; <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label>
                <br />
            </td>
            <td style="padding: 5px;"><strong>Last Name:</strong>&nbsp;&nbsp; <asp:Label ID="Label20" runat="server" Text="Label"></asp:Label>
                <br />
            </td>
        </tr>
          <tr height="50"></tr>
        <tr>
            <th colspan="4" style="background-color: #00CC66; color: black; text-align: left; padding: 5px; margin-bottom: 10px;">Contact Details</th>
        </tr>
        <tr>
            <td style="padding: 5px;"><strong>Email:</strong>&nbsp;&nbsp;&nbsp; <asp:Label ID="Label21" runat="server" Text="Label"></asp:Label></td>
            <td style="padding: 5px;"><strong>Phone Number:</strong>&nbsp;&nbsp; <asp:Label ID="Label22" runat="server" Text="Label"></asp:Label></td>
        </tr>
    </table>

</asp:Content>

