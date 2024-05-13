<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddNote.aspx.cs" Inherits="take_notes.AddNote" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-3"></div>
        <div class="col-6">
            <%if (Request.QueryString["id"] == null)
                { %>
            <h1>New Note</h1>
            <%}
                else
                { %>
            <h1>Modify Note</h1>
            <%} %>
            <hr />
            <div class="mb-3">
                <label class="form-label">Title</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtTitle" />
            </div>
            
            <div class="mb-3">
                <label class="form-label">Category</label>
                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>

            <div class="mb-3">
                <label class="form-label">Note</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtDescription" TextMode="MultiLine" />
            </div>
            <asp:Button Text="Accept" runat="server" ID="btnAddNewNote" OnClick="btnAddNewNote_Click" CssClass="btn btn-primary" Style="width: 112px; height: 50px" />
            <a href="./" style="margin-left: 10px;">Cancel</a>
        </div>
        <div class="col-3"></div>
    </div>
</asp:Content>
