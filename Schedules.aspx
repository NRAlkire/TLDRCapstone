<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Schedules.aspx.cs" Inherits="TLDR_Capstone.Schedules" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <h1>Available Schedules</h1>
        </div>
         <div style="text-align: center">
			<asp:Button ID="Button1" runat="server" Text="Generate Schedules from Selected Courses" OnClick="GenerateSchedules_Click" />
        </div>
        <div>
			<asp:GridView ID="schedulesGV" runat="server" AutoGenerateColumns="False">
                <Columns>
					<asp:TemplateField>
						<ItemTemplate>
							<asp:CheckBox runat="server" ID="chkbox" />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField>
						<ItemTemplate>
                            <asp:Label ID="scheduleLabel" runat="server" HeaderText="Available Schedule(s)" Text='<%# Eval("Schedule").ToString().Replace("\n", "<br/>") %>'></asp:Label>
						</ItemTemplate>
					</asp:TemplateField>
                </Columns>
			</asp:GridView>
        </div>
        <div>
			<asp:Button ID="saveSchedules" class="submit-btn" runat="server" Text="Save Selected Schedules" OnClick="saveSchedules_Click"/>
        </div>
        <div style="text-align:center">
            <h2>Saved Schedules</h2>
        </div>
         <div>
			<asp:GridView ID="savedSchedulesGV" runat="server" AutoGenerateColumns="False">
                <Columns>
					<asp:TemplateField>
						<ItemTemplate>
                            <asp:Label ID="savedScheduleLabel" HeaderText="Saved Schedule(s)" runat="server" Text='<%# Eval("Schedule").ToString().Replace("\n", "<br/>") %>'></asp:Label>
						</ItemTemplate>
					</asp:TemplateField>
                </Columns>
			</asp:GridView>
        </div>
    </form>
</body>
</html>
