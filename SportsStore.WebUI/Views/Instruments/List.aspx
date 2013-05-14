<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SportsStore.Domain.Entities.Instrument>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Instruments
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<% foreach (var instrument in Model)
	   { %>

	   
	<div id="item">
		<h2><%: instrument.Name %></h2>
		<h3><%: instrument.Price %></h3>
		<h3><%: instrument.Type %></h3>
	</div>
	<% } %>

</asp:Content>
