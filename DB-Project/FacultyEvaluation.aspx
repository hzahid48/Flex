<%@ Page Title="" Language="C#" MasterPageFile="~/Faculty.master" AutoEventWireup="true" CodeFile="FacultyEvaluation.aspx.cs" Inherits="FacultyEvaluation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
    .green-header {
        background-color:  #00CC66;
        color: black;
        padding: 5px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <asp:Panel ID="pnlErrorMessage" runat="server" CssClass="error-box" Visible="false">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="ErrorMessageLabel" runat="server" Text="" ForeColor="Red"></asp:Label>
</asp:Panel>
    <p>
        &nbsp;</p>
    <p>
        <br />
&nbsp;<asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Save" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" Width="166px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
   
</asp:DropDownList>

&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="DropDownList2" runat="server" Width="166px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
   
</asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Show" />
      
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Download Report" />
      
        <p>
    &nbsp;<div style="margin-left: 40px">
          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" style="margin-left: 0px">
              <HeaderStyle CssClass="green-header" />
              <Columns>
                  <asp:BoundField HeaderText="Student ID" DataField="Student ID" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                  <asp:BoundField HeaderText="Student Name" DataField="Student Name" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" />
                  <asp:TemplateField HeaderText="Quizzes" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                      <ItemTemplate>
                          <asp:TextBox ID="QuizTextBox" runat="server" />
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Assignments" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                      <ItemTemplate>
                          <asp:TextBox ID="AssignmentsTextBox" runat="server" />
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Sessional1" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                      <ItemTemplate>
                          <asp:TextBox ID="Sessional1TextBox" runat="server" />
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Sessional2" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                      <ItemTemplate>
                          <asp:TextBox ID="Sessional2TextBox" runat="server" />
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Final" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                      <ItemTemplate>
                          <asp:TextBox ID="FinalTextBox" runat="server" />
                      </ItemTemplate>
                  </asp:TemplateField>
              </Columns>
          </asp:GridView>
      </div>
      <div style="margin-left: 520px">
    </div>
</p>

          &nbsp;</asp:Content>


