// handles the add location event
$("#addLocation").click(function addLocation() {
    var location = { "Name": $("#locationName").val() };
    $.ajax({
        type: "POST",
        url: "api/AjaxLocation",
        contentType: "application/json",
        data: JSON.stringify(location),
    }).done(addToPage);
});

$("#showModal").click(function showModal() {
    $('#myModal').modal('show');
});

function addToPage(data) {
    console.log(data);
    var row = "";
    row += "<tr>";
    row +=    "<td>" + data.Name + "</td>";
    row +=    '<td><a class="btn" href="/CheckIn/Here?locationId=' + data.Id + '">Check In</a></td>';
    row += "</tr>";
    $('#myTable tr:last').after(row);
}