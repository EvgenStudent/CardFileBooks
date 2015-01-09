function applyKendoGrid(pageSize) {
	$(document).ready(function() {
		$("#kendoBooksGrid").kendoGrid({
			dataSource: {
				transport: {
					read: {
						url: "http://localhost:9010/api/Books/",
						type: "GET"
					},
					create: {
						url: "http://localhost:9010/api/Books/create/",
						type: "post"
					},
					update: {
						url: "http://localhost:9010/api/Books/update/",
						type: "post"
					},
					destroy: {
						url: "http://localhost:9010/api/Books/delete",
						type: "post"
					},
					error: function(e) {
						alert("Status: " + e.status + "; Error message: " + e.errorThrown);
					}
				},
				schema: {
					data: function(data) {
						return data.Values;
					},
					total: function(data) {
						return data.Total;
					},
					model: {
						id: "BookId",
						fields: {
							BookId: { type: "number", editable: false, nullable: true },
							Title: { type: "string", validation: { required: true } },
							Publisher: { type: "string", validation: { required: true } },
							Description: { type: "string", validation: { required: true } },
							ISBN: { type: "string", validation: { required: true } },
							Authors: { type: "string", validation: { required: true } },
							Genres: { type: "string", validation: { required: true } },
							ReleaseYear: { type: "number", validation: { required: true, min: 1 } },
							NumberOfPages: { type: "number", validation: { required: true, min: 1 } }
						}
					}
				},
				pageSize: pageSize,
				serverPaging: true,
				serverFiltering: true,
				serverSorting: true
			},
			//height: 560,
			scrollable: false,
			toolbar: ["create"],
			sortable: true,
			filterable: {
				extra: false,
				operators: {
					string: {
						contains: "Contains",
						startswith: "Starts with",
						eq: "Is equal to"
					},
					number: {
						eq: "Equal to",
						gte: "Greater than or equal to",
						lte: "Less than or equal to"
					}
				}
			},
			//columnMenu: true,
			pageable: true,
			columns: [
				{ field: "Title", title: "Title" },
				{ field: "Publisher", title: "Publisher" },
				{ field: "Description", title: "Description" },
				{ field: "Authors", title: "Authors" },
				{ field: "Genres", title: "Genres" },
				{ field: "ISBN", title: "ISBN" },
				{ field: "ReleaseYear", title: "Year" },
				{ field: "NumberOfPages", title: "Pages" },
				{ command: ["edit", "destroy"], title: "&nbsp;", width: "170px" }
			],
			editable: "popup"
		});
	});
}