<%@ Page Title="" Language="C#" MasterPageFile="~/Student.master" AutoEventWireup="true" CodeFile="S_feedback.aspx.cs" Inherits="S_feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>

        <br />
        <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="Course"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:DropDownList ID="DropDownList1" runat="server" Width="166px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
   <asp:ListItem Text="Select Course" Value="" Selected="True"></asp:ListItem>
</asp:DropDownList>
    </p>
    <p style="box-sizing: border-box; color: rgb(99, 33, 28); font-family: &quot;Nova Round&quot;, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(255, 255, 255, 0.75); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;">
        <strong style="box-sizing: border-box;">Please fill out the form in evaluating your instructor for the semester. After completion, please press the submit button.</strong></p>
    <p style="box-sizing: border-box; color: rgb(99, 33, 28); font-family: &quot;Nova Round&quot;, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(255, 255, 255, 0.75); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;">
        <strong style="box-sizing: border-box;">For reference, the metric are as follows:</strong></p>
    <p style="box-sizing: border-box; color: rgb(99, 33, 28); font-family: &quot;Nova Round&quot;, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(255, 255, 255, 0.75); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; padding-left: 30px;">
        1&nbsp;- Poor<br style="box-sizing: border-box;" />
        2 -&nbsp;Below Average<br style="box-sizing: border-box;" />
        3 - Average<br style="box-sizing: border-box;" />
        4 - Good<br style="box-sizing: border-box;" />
        5 - Excellent</p>
    <p
       style="box-sizing: border-box; color: rgb(99, 33, 28); font-family: &quot;Nova Round&quot;, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(255, 255, 255, 0.75); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;">
        &nbsp;<p
       style="box-sizing: border-box; color: rgb(99, 33, 28); font-family: &quot;Nova Round&quot;, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(255, 255, 255, 0.75); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;">
        <strong style="box-sizing: border-box;">Appearance and Personal Presentation*</strong></>
        <asp:Table ID="Table1" runat="server"   Width="60%" Height="100px">
            <asp:TableHeaderRow>
         <asp:TableHeaderCell></asp:TableHeaderCell>
        <asp:TableHeaderCell>1</asp:TableHeaderCell>
        <asp:TableHeaderCell>2</asp:TableHeaderCell>
        <asp:TableHeaderCell>3</asp:TableHeaderCell>
        <asp:TableHeaderCell>4</asp:TableHeaderCell>
        <asp:TableHeaderCell>5</asp:TableHeaderCell>
        
    </asp:TableHeaderRow>
    <asp:TableRow>
        <asp:TableCell>Teacher attends class in a well presentable manner</asp:TableCell>
       <asp:TableCell>
            <asp:RadioButton ID="RadioButton1" runat="server" GroupName="Rating1" Value="1" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton2" runat="server" GroupName="Rating1" Value="2"  />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton3" runat="server" GroupName="Rating1" Value="3" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton4" runat="server" GroupName="Rating1" Value="4" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton5" runat="server" GroupName="Rating1" Value="5" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>Teacher shows enthusiasm when teaching in class</asp:TableCell>
      <asp:TableCell>
            <asp:RadioButton ID="RadioButton6" runat="server" GroupName="Rating2" Value="1" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton7" runat="server" GroupName="Rating2" Value="2" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton8" runat="server" GroupName="Rating2" Value="3" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton9" runat="server" GroupName="Rating2" Value="4" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton10" runat="server" GroupName="Rating2" Value="5" />
        </asp:TableCell>
            
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>Teacher shows initiative and flexibility in teaching</asp:TableCell>
   <asp:TableCell>
            <asp:RadioButton ID="RadioButton11" runat="server" GroupName="Rating3" Value="1" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton12" runat="server" GroupName="Rating3" Value="2"  />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton13" runat="server" GroupName="Rating3" Value="3"  />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton14" runat="server" GroupName="Rating3" Value="4"  />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton15" runat="server" GroupName="Rating3" Value="5"  />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>Teacher is very articulated and shows full knowlede of the course</asp:TableCell>
      <asp:TableCell>
            <asp:RadioButton ID="RadioButton16" runat="server" GroupName="Rating4" Value="1" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton17" runat="server" GroupName="Rating4" Value="2" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton18" runat="server" GroupName="Rating4" Value="3"  />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton19" runat="server" GroupName="Rating4" Value="4" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton20" runat="server" GroupName="Rating4" Value="5" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>Teacher speaks loud and clear enough to be heard by the whole class</asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton21" runat="server" GroupName="Rating5" Value="1" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton22" runat="server" GroupName="Rating5" Value="2" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton23" runat="server" GroupName="Rating5" Value="3" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton24" runat="server" GroupName="Rating5" Value="4" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton25" runat="server" GroupName="Rating5" Value="5" />
        </asp:TableCell>
    </asp:TableRow>
        </asp:Table>
&nbsp;<p
       style="box-sizing: border-box; color: rgb(99, 33, 28); font-family: &quot;Nova Round&quot;, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(255, 255, 255, 0.75); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;">
        <strong style="box-sizing: border-box;">Professional Practices*</strong></>
        
        <asp:Table ID="Table2" runat="server"   Width="60%" Height="100px">
            <asp:TableHeaderRow>
         <asp:TableHeaderCell></asp:TableHeaderCell>
        <asp:TableHeaderCell>1</asp:TableHeaderCell>
        <asp:TableHeaderCell>2</asp:TableHeaderCell>
        <asp:TableHeaderCell>3</asp:TableHeaderCell>
        <asp:TableHeaderCell>4</asp:TableHeaderCell>
        <asp:TableHeaderCell>5</asp:TableHeaderCell>
        
    </asp:TableHeaderRow>
    <asp:TableRow>
        <asp:TableCell>Teacher shows professionalism in class</asp:TableCell>
       <asp:TableCell>
            <asp:RadioButton ID="RadioButton26" runat="server" GroupName="Rating6" Value="1" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton27" runat="server" GroupName="Rating6" Value="2" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton28" runat="server" GroupName="Rating6" Value="3" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton29" runat="server" GroupName="Rating6" Value="4" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton30" runat="server" GroupName="Rating6" Value="5"  />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>Teacher shows commitment to teaching the class</asp:TableCell>
       <asp:TableCell>
            <asp:RadioButton ID="RadioButton31" runat="server" GroupName="Rating7" Value="1" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton32" runat="server" GroupName="Rating7" Value="2" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton33" runat="server" GroupName="Rating7" Value="3" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton34" runat="server" GroupName="Rating7" Value="4" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton35" runat="server" GroupName="Rating7" Value="5" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>Teacher encourages students to engage in class</asp:TableCell>
     <asp:TableCell>
            <asp:RadioButton ID="RadioButton36" runat="server" GroupName="Rating8" Value="1" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton37" runat="server" GroupName="Rating8" Value="2" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton38" runat="server" GroupName="Rating8" Value="3"  />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton39" runat="server" GroupName="Rating8" Value="4" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton40" runat="server" GroupName="Rating8" Value="5"  />
        </asp:TableCell>   
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>Teacher handles criticism and suggestions professionally</asp:TableCell>
       <asp:TableCell>
            <asp:RadioButton ID="RadioButton41" runat="server" GroupName="Rating9" Value="1" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton42" runat="server" GroupName="Rating9" Value="2" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton43" runat="server" GroupName="Rating9" Value="3" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton44" runat="server" GroupName="Rating9" Value="4" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton45" runat="server" GroupName="Rating9" Value="5" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>Teacher comes to class on time</asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton46" runat="server" GroupName="Rating10" Value="1"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton47" runat="server" GroupName="Rating10" Value="2"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton48" runat="server" GroupName="Rating10" Value="3"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton49" runat="server" GroupName="Rating10" Value="4"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton50" runat="server" GroupName="Rating10" Value="5"/>
        </asp:TableCell>
    </asp:TableRow>
        </asp:Table>
&nbsp;</p>

    <p>
        <p
       style="box-sizing: border-box; color: rgb(99, 33, 28); font-family: &quot;Nova Round&quot;, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(255, 255, 255, 0.75); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;">
        <strong style="box-sizing: border-box;">Teaching Methods*</strong></>
        
    <p>
        <asp:Table ID="Table3" runat="server"   Width="60%" Height="100px">
            <asp:TableHeaderRow>
         <asp:TableHeaderCell></asp:TableHeaderCell>
        <asp:TableHeaderCell>1</asp:TableHeaderCell>
        <asp:TableHeaderCell>2</asp:TableHeaderCell>
        <asp:TableHeaderCell>3</asp:TableHeaderCell>
        <asp:TableHeaderCell>4</asp:TableHeaderCell>
        <asp:TableHeaderCell>5</asp:TableHeaderCell>
        
    </asp:TableHeaderRow>
    <asp:TableRow>
        <asp:TableCell>Teacher shows well rounded knowledge over the subject matter</asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton51" runat="server" GroupName="Rating11" Value="1"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton52" runat="server" GroupName="Rating11" Value="2"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton53" runat="server" GroupName="Rating11" Value="3"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton54" runat="server" GroupName="Rating11" Value="4"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton55" runat="server" GroupName="Rating11" Value="5"/>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>Teacher has organized the lesson conducive for easy understanding</asp:TableCell>
       <asp:TableCell>
            <asp:RadioButton ID="RadioButton56" runat="server" GroupName="Rating12" Value="1"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton57" runat="server" GroupName="Rating12" Value="2"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton58" runat="server" GroupName="Rating12" Value="3"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton59" runat="server" GroupName="Rating12" Value="4"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton60" runat="server" GroupName="Rating12" Value="5"/>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>Teacher shows dynamism and enthuasiasm</asp:TableCell>
     <asp:TableCell>
            <asp:RadioButton ID="RadioButton61" runat="server" GroupName="Rating13" Value="1" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton62" runat="server" GroupName="Rating13" Value="2"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton63" runat="server" GroupName="Rating13" Value="3"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton64" runat="server" GroupName="Rating13" Value="4"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton65" runat="server" GroupName="Rating13" Value="5"/>
        </asp:TableCell> 
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>Teacher stimulates the critical thinking of students</asp:TableCell>
       <asp:TableCell>
            <asp:RadioButton ID="RadioButton66" runat="server" GroupName="Rating14" Value="1"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton67" runat="server" GroupName="Rating14" Value="2"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton68" runat="server" GroupName="Rating14" Value="3"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton69" runat="server" GroupName="Rating14" Value="4"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton70" runat="server" GroupName="Rating14" Value="5"/>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>Teacher handles the class environment conductive for learning</asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton71" runat="server" GroupName="Rating15" Value="1"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton72" runat="server" GroupName="Rating15" Value="2"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton73" runat="server" GroupName="Rating15" Value="3"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton74" runat="server" GroupName="Rating15" Value="4"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton75" runat="server" GroupName="Rating15" Value="5"/>
        </asp:TableCell>
    </asp:TableRow>
        </asp:Table>
    </p>


     <p>
        <p
       style="box-sizing: border-box; color: rgb(99, 33, 28); font-family: &quot;Nova Round&quot;, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(255, 255, 255, 0.75); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;">
        <strong style="box-sizing: border-box;">Disposition Towards Students*</strong></>
        
    <p>
        <asp:Table ID="Table4" runat="server"   Width="60%" Height="100px">
            <asp:TableHeaderRow>
         <asp:TableHeaderCell></asp:TableHeaderCell>
        <asp:TableHeaderCell>1</asp:TableHeaderCell>
        <asp:TableHeaderCell>2</asp:TableHeaderCell>
        <asp:TableHeaderCell>3</asp:TableHeaderCell>
        <asp:TableHeaderCell>4</asp:TableHeaderCell>
        <asp:TableHeaderCell>5</asp:TableHeaderCell>
        
    </asp:TableHeaderRow>
    <asp:TableRow>
        <asp:TableCell>Teacher believes that students can learn from the class</asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton76" runat="server" GroupName="Rating16" Value="1"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton77" runat="server" GroupName="Rating16" Value="2"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton78" runat="server" GroupName="Rating16" Value="3"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton79" runat="server" GroupName="Rating16" Value="4"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton80" runat="server" GroupName="Rating16" Value="4"/>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>Teacher shows equal respect to various cultural backgrounds, individuals, religion, and race</asp:TableCell>
       <asp:TableCell>
            <asp:RadioButton ID="RadioButton81" runat="server" GroupName="Rating17" Value="1"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton82" runat="server" GroupName="Rating17" Value="2"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton83" runat="server" GroupName="Rating17" Value="3"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton84" runat="server" GroupName="Rating17" Value="4"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton85" runat="server" GroupName="Rating17" Value="5"/>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>Teacher finds the students strenghts as basis for growth and weaknesses for opportunities for improvement</asp:TableCell>
     <asp:TableCell>
            <asp:RadioButton ID="RadioButton86" runat="server" GroupName="Rating18" Value="1" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton87" runat="server" GroupName="Rating18" Value="2"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton88" runat="server" GroupName="Rating18" Value="3"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton89" runat="server" GroupName="Rating18" Value="4"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton90" runat="server" GroupName="Rating18" Value="5"/>
        </asp:TableCell> 
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>Teacher understands the weakness of a student and helps in the student's improvement</asp:TableCell>
       <asp:TableCell>
            <asp:RadioButton ID="RadioButton91" runat="server" GroupName="Rating19" Value="1"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton92" runat="server" GroupName="Rating19" Value="2"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton93" runat="server" GroupName="Rating19" Value="3"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton94" runat="server" GroupName="Rating19" Value="4"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButton ID="RadioButton95" runat="server" GroupName="Rating19" Value="5"/>
        </asp:TableCell>
    </asp:TableRow>
    
        </asp:Table>
    </p>

    <p
       style="box-sizing: border-box; color: rgb(99, 33, 28); font-family: &quot;Nova Round&quot;, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(255, 255, 255, 0.75); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;">
        &nbsp;<p
       style="box-sizing: border-box; color: rgb(99, 33, 28); font-family: &quot;Nova Round&quot;, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(255, 255, 255, 0.75); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;">
        <strong style="box-sizing: border-box;">Comments</strong></>
        
    <p
       style="box-sizing: border-box; color: rgb(99, 33, 28); font-family: &quot;Nova Round&quot;, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(255, 255, 255, 0.75); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;">
        <asp:TextBox ID="TextBox3" runat="server" Height="100px" Width="460px" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
    <p
       style="box-sizing: border-box; color: rgb(99, 33, 28); font-family: &quot;Nova Round&quot;, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(255, 255, 255, 0.75); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;">
        &nbsp;<p
       style="box-sizing: border-box; color: rgb(99, 33, 28); font-family: &quot;Nova Round&quot;, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(255, 255, 255, 0.75); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;">
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
        
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>

