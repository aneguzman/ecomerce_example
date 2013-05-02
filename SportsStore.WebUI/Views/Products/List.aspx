<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SportsStore.WebUI.Models.ProductsListViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Products
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% foreach (var product in Model.Products)
   {%>
   <div class="item">
		<h3><%: product.Name %></h3>
		<%: product.Description %>
		<h4><%: product.Price.ToString("c") %></h4>   
	</div>
<% } %>

<div id="pager">
	<%: Html.PageLinks(Model.PagingInfo, x=> Url.Action("List", new {page = x})) %>
</div>

</asp:Content>
